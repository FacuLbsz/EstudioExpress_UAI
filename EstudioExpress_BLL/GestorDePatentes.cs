using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class GestorDePatentes
{

    private GestorDeDigitoVerificador gestorDeDigitoVerificador;
    private BaseDeDatos baseDeDatos;
    private static GestorDePatentes instancia;

    private GestorDePatentes()
    {
        gestorDeDigitoVerificador = GestorDeDigitoVerificador.ObtenerInstancia();
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
    }

    public static GestorDePatentes ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDePatentes();
        }

        return instancia;
    }

    //SDC Modificar parametro de entrada como PatenteUsuario
    public int AsignarAUnUsuario(PatenteUsuario patenteUsuario)
    {
        var usuario = patenteUsuario.usuario.identificador.ToString();
        var patente = patenteUsuario.patente.identificador.ToString();

        var esPermisivo = patenteUsuario.esPermisivo ? "1" : "0";

        var digitoVH = GestorDeDigitoVerificador.ObtenerDigitoVH(new List<string>() { esPermisivo, patente, usuario });

        var datataTable = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM PATENTEUSUARIO  WHERE Patente_idPatente = {0} AND Usuario_idUsuario  = {1}", patente, usuario));
        var registros = 0;
        if (datataTable.Rows.Count > 0)
        {
            registros = baseDeDatos.ModificarBase(String.Format("UPDATE PATENTEUSUARIO SET esPermisiva = {0}, digitoVerificadorH = '{1}' WHERE Patente_idPatente = {2} AND Usuario_idUsuario  = {3} ", esPermisivo, digitoVH, patente, usuario));
        }
        else
        {
            registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO PATENTEUSUARIO  (esPermisiva  ,Patente_idPatente  ,Usuario_idUsuario  ,digitoVerificadorH)  VALUES  ({0}  ,{1}  ,{2} ,'{3}')", esPermisivo, patente, usuario, digitoVH));
        }

        gestorDeDigitoVerificador.ModificarDigitoVV("PATENTEUSUARIO");

        return registros;
    }

    public List<Patente> ObtenerPatentesParaUnaFamilia(Familia familia)
    {
        List<Patente> patentes = new List<Patente>();
        DataTable familiapatenteTable = baseDeDatos.ConsultarBase(String.Format("SELECT patente.idPatente, patente.nombre FROM familiapatente INNER JOIN PATENTE on familiapatente.Patente_idPatente = PATENTE.idPatente WHERE Familia_idFamilia = {0}", familia.identificador));
        foreach (DataRow familiapatenteRow in familiapatenteTable.Rows)
        {
            Patente patente = new Patente() { identificador = Convert.ToInt32(familiapatenteRow["idPatente"]), nombre = Convert.ToString(familiapatenteRow["nombre"]) };
            patentes.Add(patente);
        }
        return patentes;
    }

    public int DesasignarAUnUsuario(Usuario usuario, Patente patente)
    {

        var registros = baseDeDatos.ModificarBase(String.Format("DELETE FROM PATENTEUSUARIO  WHERE Patente_idPatente = {0} AND Usuario_idUsuario  = {1}", patente.identificador, usuario.identificador));
        gestorDeDigitoVerificador.ModificarDigitoVV("PATENTEUSUARIO");

        return registros;
    }

    public List<Patente> ObtenerPatentes()
    {
        var dataTable = baseDeDatos.ConsultarBase("SELECT * FROM PATENTE");
        List<Patente> patentes = new List<Patente>();
        foreach (DataRow row in dataTable.Rows)
        {
            Patente patente = new Patente();

            patente.identificador = Convert.ToInt32(row["idPatente"]);
            patente.nombre = Convert.ToString(row["nombre"]);

            patentes.Add(patente);

        }
        return patentes;
    }

    //SDC modificar por ObtenerPatentesNoAsignadasAUnUsuario
    public List<Patente> ObtenerPatentesNoAsignadasAUnUsuario(Usuario usuario)
    {
        var dataTable = baseDeDatos.ConsultarBase(String.Format("Select * from Patente where patente.idPatente not in(SELECT patenteusuario.Patente_idPatente FROM patenteusuario  where patenteusuario.Usuario_idUsuario = {0})", usuario.identificador));
        List<Patente> patentes = new List<Patente>();

        foreach (DataRow row in dataTable.Rows)
        {
            Patente patente = new Patente();

            patente.identificador = Convert.ToInt32(row["idPatente"]);
            patente.nombre = Convert.ToString(row["nombre"]);

            patentes.Add(patente);

        }
        return patentes;
    }

    public List<PatenteUsuario> ObtenerPatentesParaUnUsuarioPorFamilia(Usuario usuario)
    {
        var dataTable = baseDeDatos.ConsultarBase(String.Format("select patente.nombre, familiapatente.Patente_idPatente from familiapatente inner join patente on patente.idPatente = familiapatente.Patente_idPatente INNER JOIN familiausuario on familiausuario.familia_idFamilia = familiapatente.familia_idFamilia WHERE familiausuario.Usuario_idUsuario = {0}", usuario.identificador));
        List<PatenteUsuario> patenteUsuarios = new List<PatenteUsuario>();
        foreach (DataRow row in dataTable.Rows)
        {
            PatenteUsuario patenteUsuario = new PatenteUsuario();

            patenteUsuario.patente = new Patente() { identificador = Convert.ToInt32(row["Patente_idPatente"]), nombre = Convert.ToString(row["nombre"]) };
            patenteUsuario.usuario = usuario;
            patenteUsuario.esPermisivo = true;

            patenteUsuarios.Add(patenteUsuario);
        }

        return patenteUsuarios;
    }
    //SDC Modificar parametro de salida como Lista de PatenteUsuario
    public List<PatenteUsuario> ObtenerPatentesParaUnUsuario(Usuario usuario)
    {

        var dataTable = baseDeDatos.ConsultarBase(String.Format("select PATENTE.nombre, patenteusuario.esPermisiva, patenteusuario.Patente_idPatente,patenteusuario.Usuario_idUsuario from patenteusuario INNER JOIN PATENTE on patenteusuario.Patente_idPatente = patente.idPatente WHERE patenteusuario.Usuario_idUsuario = {0}", usuario.identificador));
        List<PatenteUsuario> patenteUsuarios = new List<PatenteUsuario>();
        foreach (DataRow row in dataTable.Rows)
        {
            PatenteUsuario patenteUsuario = new PatenteUsuario();

            patenteUsuario.patente = new Patente() { identificador = Convert.ToInt32(row["Patente_idPatente"]), nombre = Convert.ToString(row["nombre"]) };
            patenteUsuario.usuario = new Usuario() { identificador = Convert.ToInt32(row["Usuario_idUsuario"]) };
            patenteUsuario.esPermisivo = Convert.ToBoolean(row["esPermisiva"]);

            patenteUsuarios.Add(patenteUsuario);

        }
        return patenteUsuarios;
    }

    //SDC A diagrama de secuencia de asignar patentes a familia obtener patentes no asignadas
    public List<Patente> ObtenerPatentesNoAsignadasAUnaFamilia(Familia familia)
    {
        var dataTable = baseDeDatos.ConsultarBase(String.Format("Select * from Patente where Patente.idPatente not in(SELECT familiapatente.Patente_idPatente FROM familiapatente  where familiapatente.Familia_idFamilia = {0})", familia.identificador));
        List<Patente> patentes = new List<Patente>();

        foreach (DataRow row in dataTable.Rows)
        {
            Patente patente = new Patente();

            patente.identificador = Convert.ToInt32(row["idPatente"]);
            patente.nombre = Convert.ToString(row["nombre"]);

            patentes.Add(patente);

        }
        return patentes;
    }

    public int VerificarPatenteEscencialEnDesasignacion(Patente patente, Usuario usuario)
    {

        return 0;
    }

    //SDC agregar nuevos parametros de entrada
    public int VerificarPatenteEscencial(Patente patente, Usuario usuario, Familia familia, bool esDesasignacionPorUsuario)
    {
        var selectCantidadDeAsignacionesAUsuario = String.Format("select * FROM PATENTEUSUARIO inner join usuario on usuario.idUsuario = patenteusuario.Usuario_idUsuario WHERE PATENTEUSUARIO.Patente_idPatente = {0} AND esPermisiva = 1 AND Usuario.habilitado = 1", patente.identificador);
        if (usuario != null)
        {
            selectCantidadDeAsignacionesAUsuario = selectCantidadDeAsignacionesAUsuario + String.Format("  AND Usuario_idUsuario != {0}", usuario.identificador);
        }
        var cantidadDeAsignacionesAUsuario = baseDeDatos.ConsultarBase(selectCantidadDeAsignacionesAUsuario).Rows.Count;

        if (cantidadDeAsignacionesAUsuario >= 1)
        {
            return 1;
        }

        var selectfamiliasPatenteDataTable = String.Format("select * FROM FAMILIAPATENTE WHERE FAMILIAPATENTE.Patente_idPatente = {0}", patente.identificador);
        if (familia != null)
        {
            selectfamiliasPatenteDataTable = selectfamiliasPatenteDataTable + String.Format(" and Familia_idFamilia != {0}", familia.identificador);
        }
        var familiasPatenteDataTable = baseDeDatos.ConsultarBase(selectfamiliasPatenteDataTable);

        if (familiasPatenteDataTable.Rows.Count == 0)
        {
            return 0;
        }

        int usuariosConEsaPatenteSegunFamilia = 0;
        foreach (DataRow familiasPatente in familiasPatenteDataTable.Rows)
        {
            if (!esDesasignacionPorUsuario)
            {
                usuariosConEsaPatenteSegunFamilia = usuariosConEsaPatenteSegunFamilia + baseDeDatos.ConsultarBase(String.Format("select * FROM FAMILIAUSUARIO INNER JOIN USUARIO on familiausuario.Usuario_idUsuario = USUARIO.idUsuario WHERE FAMILIAUSUARIO.Familia_idFamilia = {0} AND usuario.habilitado = 1 {1}", familiasPatente["Familia_idFamilia"].ToString(), usuario != null ? " AND usuario.idUsuario !=" + usuario.identificador : "")).Rows.Count;

            }
            else
            {
                usuariosConEsaPatenteSegunFamilia = usuariosConEsaPatenteSegunFamilia + baseDeDatos.ConsultarBase(String.Format("select * FROM FAMILIAUSUARIO INNER JOIN USUARIO on familiausuario.Usuario_idUsuario = USUARIO.idUsuario WHERE FAMILIAUSUARIO.Familia_idFamilia = {0} AND usuario.habilitado = 1", familiasPatente["Familia_idFamilia"].ToString())).Rows.Count;
            }
        }

        //¿La patente que deseo desasignar ya la tengo asignada via familia?
        if (usuariosConEsaPatenteSegunFamilia == 0 && usuario != null)
        {

        }

        return usuariosConEsaPatenteSegunFamilia >= 1 ? 1 : 0;
    }

}