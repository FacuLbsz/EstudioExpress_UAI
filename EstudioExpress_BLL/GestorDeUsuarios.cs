using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Net.Mail;

public class GestorDeUsuarios
{

    private static GestorDeUsuarios instancia;
    private GestorDeDigitoVerificador gestorDeDigitoVerificador;
    private GestorDePatentes gestorDePatentes;
    private GestorDeBitacora m_GestorDeBitacora;
    private GestorDeEncriptacion GestorDeEncriptacion;

    private GestorDeUsuarios()
    {
        gestorDeDigitoVerificador = GestorDeDigitoVerificador.ObtenerInstancia();
        gestorDePatentes = GestorDePatentes.ObtenerInstancia();
    }

    public static GestorDeUsuarios ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeUsuarios();
        }

        return instancia;
    }

    public List<Usuario> ConsultarUsuarios()
    {
        return ConsultarUsuarios("SELECT * FROM USUARIO WHERE habilitado = 1");
    }

    public List<Usuario> ConsultarUsuariosSinEquipo()
    {
        return ConsultarUsuarios("select * from usuario where idUsuario not in (SELECT idUsuario FROM USUARIO INNER JOIN equipoempleado ON equipoempleado.Usuario_idUsuario = USUARIO.idUsuario INNER JOIN equipo ON EQUIPO.idEquipo = equipoempleado.Equipo_idEquipo WHERE EQUIPO.habilitado = 1) and habilitado = 1");
    }


    public List<Usuario> ConsultarUsuariosTodos()
    {
        return ConsultarUsuarios("SELECT * FROM USUARIO");
    }

    private List<Usuario> ConsultarUsuarios(String consulta)
    {
        DataTable dataTable = BaseDeDatos.ObtenerInstancia().ConsultarBase(consulta);

        List<Usuario> usuarios = new List<Usuario>();
        foreach (DataRow row in dataTable.Rows)
        {
            Usuario usuario = new Usuario();

            usuario = PopularUsuarioDesdeBD(row);
            usuario.nombreUsuario = GestorDeEncriptacion.DesencriptarAes(usuario.nombreUsuario);

            usuarios.Add(usuario);
        }
        return usuarios;
    }

    public Usuario ObtenerUsuario(int idUsuario)
    {
        Usuario usuario = ObtenerUsuarioBD(idUsuario);
        usuario.nombreUsuario = GestorDeEncriptacion.DesencriptarAes(usuario.nombreUsuario);
        return usuario;
    }

    private Usuario PopularUsuarioDesdeBD(DataRow usuarioRow)
    {
        Usuario usuario = new Usuario();
        usuario.identificador = Convert.ToInt32(usuarioRow["idUsuario"]);
        usuario.nombreUsuario = Convert.ToString(usuarioRow["nombreUsuario"]);
        usuario.contrasena = Convert.ToString(usuarioRow["contrasena"]);
        usuario.nombre = Convert.ToString(usuarioRow["nombre"]);
        usuario.apellido = Convert.ToString(usuarioRow["apellido"]);
        usuario.email = Convert.ToString(usuarioRow["email"]);
        usuario.habilitado = Convert.ToBoolean(usuarioRow["habilitado"]);
        usuario.cantidadDeIntentos = Convert.ToInt32(usuarioRow["cantidadDeIntentos"]);
        return usuario;
    }

    private Usuario ObtenerUsuarioBD(int idUsuario)
    {
        DataTable dataTable = BaseDeDatos.ObtenerInstancia().ConsultarBase("SELECT * FROM USUARIO WHERE idUsuario = " + idUsuario);
        Usuario usuario = new Usuario();
        foreach (DataRow row in dataTable.Rows)
        {
            usuario = PopularUsuarioDesdeBD(row);
        }
        return usuario;
    }

    public int CrearUsuario(Usuario usuario)
    {
        if (VerificarEmail(usuario.email) == 1)
        {

            throw new EntidadDuplicadaExcepcion("email");
        }

        usuario.nombreUsuario = GestorDeEncriptacion.EncriptarAes(usuario.nombreUsuario);

        if (BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM USUARIO WHERE nombreUsuario = '{0}'", usuario.nombreUsuario)).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombreUsuario");
        }

        usuario.contrasena = GestorDeEncriptacion.EncriptarMD5(usuario.contrasena);

        var digitoVH = ObtenerDigitoVerificadorHDeUsuario(usuario);
        
        var registros = BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("INSERT INTO USUARIO(nombreUsuario,contrasena,nombre,apellido,email,habilitado,digitoVerificadorH) VALUES ('{0}','{1}','{2}','{3}','{4}',1,'{5}')", usuario.nombreUsuario, usuario.contrasena, usuario.nombre, usuario.apellido, usuario.email, digitoVH));

        gestorDeDigitoVerificador.ModificarDigitoVV("USUARIO");

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se crea el usuario " + usuario.nombre + " " + usuario.apellido, criticidad = 3, funcionalidad = "ADMINISTRACION DE USUARIOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        return registros;
    }

    public int EliminarUsuario(Usuario usuario)
    {

        var patentesDelUsuario = gestorDePatentes.ObtenerPatentesParaUnUsuario(usuario);
        patentesDelUsuario.AddRange(gestorDePatentes.ObtenerPatentesParaUnUsuarioPorFamilia(usuario));

        foreach (PatenteUsuario patente in patentesDelUsuario)
        {
            if (gestorDePatentes.VerificarPatenteEscencial(patente.patente, usuario, null, false) == 0)
            {
                throw new Exception(patente.patente.nombre);
            }
        }

        patentesDelUsuario.ForEach((patente) =>
        {
            gestorDePatentes.DesasignarAUnUsuario(usuario, patente.patente);
        });
        BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("update equipo set coordinador = null where coordinador = {0}", usuario.identificador));

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se elimino el usuario " + usuario.identificador, criticidad = 1, funcionalidad = "ADMINISTRACION DE USUARIOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        return BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("UPDATE USUARIO SET habilitado = 0 WHERE idUsuario = {0}", usuario.identificador));
    }
    
    public int ModificarUsuario(Usuario usuario)
    {
        Usuario usuarioViejo = ObtenerUsuarioBD(usuario.identificador);

        if (usuario.email != null && !usuarioViejo.email.Equals(usuario.email))
        {
            if (VerificarEmail(usuario.email) == 1)
            {
                throw new EntidadDuplicadaExcepcion("email");
            }
        }

        String set = "";
        if (usuario.nombre != null && usuarioViejo.nombre != usuario.nombre)
        {
            usuarioViejo.nombre = usuario.nombre;
            set = String.Format(" nombre = '{0}' ", usuario.nombre);
        }
        if (usuario.apellido != null && usuarioViejo.apellido != usuario.apellido)
        {
            if (set.Length > 0)
            {
                set = set + " , ";
            }
            usuarioViejo.apellido = usuario.apellido;
            set = set + String.Format(" apellido = '{0}' ", usuario.apellido);
        }

        if (usuario.email != null && usuarioViejo.email != usuario.email)
        {
            if (set.Length > 0)
            {
                set = set + " , ";
            }
            usuarioViejo.email = usuario.email;
            set = set + String.Format(" email = '{0}' ", usuario.email);
        }

        if (usuario.contrasena != null)
        {
            if (set.Length > 0)
            {
                set = set + " , ";
            }
            var contrasenaEncriptada = GestorDeEncriptacion.EncriptarMD5(usuario.contrasena);
            usuarioViejo.contrasena = contrasenaEncriptada;
            set = set + String.Format(" contrasena = '{0}' ", contrasenaEncriptada);
        }

        var digitoVH = ObtenerDigitoVerificadorHDeUsuario(usuarioViejo);

        if (set.Length > 0)
        {
            set = set + " , ";
        }
        set = set + String.Format(" digitoVerificadorH = '{0}' ", digitoVH);

        var registros = BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("UPDATE USUARIO SET {0} WHERE idUsuario = {1}", set, usuario.identificador));
        gestorDeDigitoVerificador.ModificarDigitoVV("USUARIO");

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se modifico el usuario " + usuario.identificador, criticidad = 2, funcionalidad = "ADMINISTRACION DE USUARIOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);
        return registros;
    }

    public Usuario RealizarLogIn(Usuario usuario)
    {
        var nombre = usuario.nombreUsuario;
        usuario.nombreUsuario = GestorDeEncriptacion.EncriptarAes(usuario.nombreUsuario);
        usuario.contrasena = GestorDeEncriptacion.EncriptarMD5(usuario.contrasena);
        DataTable usuarioTable = BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM USUARIO WHERE nombreUsuario = '{0}' AND contrasena = '{1}' AND habilitado = 1", usuario.nombreUsuario, usuario.contrasena));

        if (usuarioTable.Rows.Count > 0)
        {
            var usuarioLogin = PopularUsuarioDesdeBD(usuarioTable.Rows[0]);
            usuarioLogin.nombreUsuario = GestorDeEncriptacion.DesencriptarAes(usuario.nombreUsuario);
            return usuarioLogin;
        }

        DataTable usuarioSegunNombreTable = BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM USUARIO WHERE nombreUsuario = '{0}' AND habilitado = 1", usuario.nombreUsuario));

        if (usuarioSegunNombreTable.Rows.Count > 0)
        {
            var usuarioSegunNombre = PopularUsuarioDesdeBD(usuarioSegunNombreTable.Rows[0]);

            BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("UPDATE USUARIO SET cantidadDeIntentos = {0} WHERE nombreUsuario = '{1}'", usuarioSegunNombre.cantidadDeIntentos + 1, usuario.nombreUsuario));

            usuarioSegunNombre.identificador = 0;
            usuarioSegunNombre.cantidadDeIntentos = usuarioSegunNombre.cantidadDeIntentos + 1;
            return usuarioSegunNombre;
        }

        return null;
    }

    public int RealizarLogOut(Usuario usuario)
    {

        return 0;
    }

    private int VerificarEmail(String email)
    {
        if (BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM USUARIO WHERE email = '{0}'", email)).Rows.Count > 0)
        {
            return 1;
        }

        return 0;
    }

    private String ObtenerDigitoVerificadorHDeUsuario(Usuario usuario)
    {
        return GestorDeDigitoVerificador.ObtenerDigitoVH(new List<String>() { usuario.nombreUsuario, usuario.nombre, usuario.apellido, usuario.contrasena });
    }

    public bool ModificarContrasena(Usuario usuario, String contrasenaAntigua, String contrasena)
    {
        if (BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM USUARIO WHERE idUsuario = {0} AND contrasena = '{1}'", usuario.identificador, GestorDeEncriptacion.EncriptarMD5(contrasenaAntigua))).Rows.Count == 0)
        {
            return false;
        }
        usuario.contrasena = contrasena;
        ModificarUsuario(usuario);
        return true;
    }

    public void DesbloquearUsuario(Usuario usuario)
    {
        BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("UPDATE USUARIO SET cantidadDeIntentos = 0 where idUsuario = {0}", usuario.identificador));
    }

}