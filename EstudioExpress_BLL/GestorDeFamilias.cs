using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class GestorDeFamilias
{

    private static GestorDeFamilias instancia;
    private GestorDeDigitoVerificador m_GestorDeDigitoVerificador;
    private GestorDeEncriptacion GestorDeEncriptacion;
    private GestorDePatentes gestorDePatentes;
    private BaseDeDatos baseDeDatos;


    private GestorDeFamilias()
    {
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
        m_GestorDeDigitoVerificador = GestorDeDigitoVerificador.ObtenerInstancia();
        gestorDePatentes = GestorDePatentes.ObtenerInstancia();
    }

    public static GestorDeFamilias ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeFamilias();
        }

        return instancia;
    }

    public int AsignarPatente(Patente patente, Familia familia)
    {
        var registros = 0;
        if (baseDeDatos.ConsultarBase(String.Format("SELECT * FROM FAMILIAPATENTE WHERE PATENTE_IDPATENTE = {0} AND FAMILIA_IDFAMILIA = {1}", patente.identificador, familia.identificador)).Rows.Count == 0)
        {
            registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO familiapatente (Patente_idPatente,Familia_idFamilia ,digitoVerificadorH) VALUES ({0} ,{1} ,'{2}')", patente.identificador, familia.identificador, GestorDeDigitoVerificador.ObtenerDigitoVH(new List<String>() { patente.identificador.ToString(), familia.identificador.ToString() })));
            m_GestorDeDigitoVerificador.ModificarDigitoVV("familiapatente");
        }
        return registros;
    }

    public int AsignarUsuario(Usuario usuario, Familia familia)
    {
        return baseDeDatos.ModificarBase(String.Format("INSERT INTO familiausuario (Familia_idFamilia ,Usuario_idUsuario) VALUES ({0} ,{1})", familia.identificador.ToString(), usuario.identificador.ToString()));
    }

    public List<Familia> ConsultarFamilias()
    {
        DataTable datable = baseDeDatos.ConsultarBase("SELECT * FROM FAMILIA");
        List<Familia> familias = new List<Familia>();
        foreach (DataRow familiaRow in datable.Rows)
        {
            Familia familia = new Familia() { identificador = Convert.ToInt32(familiaRow["idFamilia"]), nombre = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(familiaRow["nombre"])) };

            DataTable familiapatenteTable = baseDeDatos.ConsultarBase(String.Format("SELECT patente.idPatente, patente.nombre FROM familiapatente INNER JOIN PATENTE on familiapatente.Patente_idPatente = PATENTE.idPatente WHERE Familia_idFamilia = {0}", familia.identificador));
            foreach (DataRow familiapatenteRow in familiapatenteTable.Rows)
            {
                Patente patente = new Patente() { identificador = Convert.ToInt32(familiapatenteRow["idPatente"]), nombre = Convert.ToString(familiapatenteRow["nombre"]) };
                familia.patentesAsignadas.Add(patente);
            }

            DataTable familiausuarioTable = baseDeDatos.ConsultarBase(String.Format("SELECT usuario.idUsuario, usuario.nombreUsuario FROM familiausuario INNER JOIN USUARIO on familiausuario.Usuario_idUsuario = USUARIO.idUsuario WHERE Familia_idFamilia = {0} AND USUARIO.habilitado = 1", familia.identificador));
            foreach (DataRow familiausuarioTableRow in familiausuarioTable.Rows)
            {
                Usuario usuario = new Usuario() { identificador = Convert.ToInt32(familiausuarioTableRow["idUsuario"]), nombreUsuario = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(familiausuarioTableRow["nombreUsuario"])) };
                familia.usuariosAsignados.Add(usuario);
            }

            familias.Add(familia);
        }
        return familias;
    }

    public int ModificarFamilia(Familia familia)
    {

        if (baseDeDatos.ConsultarBase(String.Format("SELECT FAMILIA.IDFAMILIA FROM FAMILIA WHERE NOMBRE = '{0}' AND IDFAMILIA != {1}", GestorDeEncriptacion.EncriptarAes(familia.nombre), familia.identificador)).Rows.Count == 0)
        {
            return baseDeDatos.ModificarBase(String.Format("UPDATE FAMILIA SET NOMBRE = '{0}' WHERE IDFAMILIA = {1}", GestorDeEncriptacion.EncriptarAes(familia.nombre), familia.identificador));
        }
        else
        {
            throw new EntidadDuplicadaExcepcion("nombre");
        }

    }

    public int EliminarFamilia(Familia familia)
    {
        var patentesAsignadas = new List<Patente>();
        DataTable familiapatenteTable = baseDeDatos.ConsultarBase(String.Format("SELECT patente.idPatente, patente.nombre FROM familiapatente INNER JOIN PATENTE on familiapatente.Patente_idPatente = PATENTE.idPatente WHERE Familia_idFamilia = {0}", familia.identificador));
        foreach (DataRow familiapatenteRow in familiapatenteTable.Rows)
        {
            Patente patente = new Patente() { identificador = Convert.ToInt32(familiapatenteRow["idPatente"]), nombre = Convert.ToString(familiapatenteRow["nombre"]) };
            patentesAsignadas.Add(patente);
        }

        var usuariosAsignados = new List<Usuario>();
        DataTable familiausuarioTable = baseDeDatos.ConsultarBase(String.Format("SELECT usuario.idUsuario, usuario.nombreUsuario FROM familiausuario INNER JOIN USUARIO on familiausuario.Usuario_idUsuario = USUARIO.idUsuario WHERE Familia_idFamilia = {0}", familia.identificador));
        foreach (DataRow familiausuarioTableRow in familiausuarioTable.Rows)
        {
            Usuario usuario = new Usuario() { identificador = Convert.ToInt32(familiausuarioTableRow["idUsuario"]) };
            usuariosAsignados.Add(usuario);
        }

        foreach (Patente patente in patentesAsignadas)
        {
            if (gestorDePatentes.VerificarPatenteEscencial(patente, null, familia, false) == 0)
            {
                throw new EntidadDuplicadaExcepcion(patente.nombre);
            }
        }

        foreach (Patente patente in patentesAsignadas)
        {
            DesasignarPatente(patente, familia);
        }

        foreach (Usuario usuario in usuariosAsignados)
        {
            DesasignarUsuario(usuario, familia);
        }

        return baseDeDatos.ModificarBase(String.Format("delete familia where idFamilia = {0}", familia.identificador));
    }

    public int CrearFamilia(Familia familia)
    {
        if (baseDeDatos.ConsultarBase(String.Format("SELECT * FROM FAMILIA WHERE nombre = '{0}'", GestorDeEncriptacion.EncriptarAes(familia.nombre))).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombre");
        }

        var registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO FAMILIA (nombre,habilitado) VALUES ('{0}', 1)", GestorDeEncriptacion.EncriptarAes(familia.nombre)));


        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se crea la familia " + familia.nombre, criticidad = 3, funcionalidad = "ADMINISTRACION DE FAMILIAS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);


        return registros;
    }

    public int DesasignarPatente(Patente patente, Familia familia)
    {
        var registros = baseDeDatos.ModificarBase(String.Format("DELETE FROM familiapatente WHERE Patente_idPatente = {0} AND Familia_idFamilia = {1}", patente.identificador, familia.identificador));
        m_GestorDeDigitoVerificador.ModificarDigitoVV("familiapatente");
        return registros;
    }

    public int DesasignarUsuario(Usuario usuario, Familia familia)
    {
        var patentesDelUsuario = GestorDePatentes.ObtenerInstancia().ObtenerPatentesParaUnUsuarioPorFamilia(usuario);

        foreach (PatenteUsuario patente in patentesDelUsuario)
        {
            if (GestorDePatentes.ObtenerInstancia().VerificarPatenteEscencial(patente.patente, usuario, null, false) == 0)
            {
                throw new Exception("No se puede desasignar el empleado debido a que la patente " + patente.patente.nombre + " quedara sin asignacion");
            }
        }

        return baseDeDatos.ModificarBase(String.Format("DELETE FROM familiausuario WHERE Usuario_idUsuario = {0} AND Familia_idFamilia = {1}", usuario.identificador, familia.identificador)); ;
    }

}