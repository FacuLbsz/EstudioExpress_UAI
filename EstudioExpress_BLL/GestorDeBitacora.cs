using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

/// <summary>
/// Logica implicada en el manejo de la bitacora
/// </summary>
public class GestorDeBitacora
{

    private static GestorDeBitacora instancia;
    private GestorDeDigitoVerificador m_GestorDeDigitoVerificador;
    private BaseDeDatos baseDeDatos;
    private const string SetFormatDate = "set dateformat dmy";
    //SDC Agregar llamado para obtener usuario desencriptado en diagrama de secuencia
    private GestorDeUsuarios gestorDeUsuarios;

    private GestorDeBitacora()
    {
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
        gestorDeUsuarios = GestorDeUsuarios.ObtenerInstancia();
        m_GestorDeDigitoVerificador = GestorDeDigitoVerificador.ObtenerInstancia();
    }

    public static GestorDeBitacora ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeBitacora();
        }

        return instancia;
    }

    /// <summary>
    /// Verifica que el evento de la bitacora no exista
    /// </summary>
    /// <param name="criticidad"></param>
    /// <param name="idUsuario"></param>
    /// <param name="fechaDesde"></param>
    /// <param name="fechaHasta"></param>
    /// <returns></returns>
    public List<EventoBitacora> ConsultarEventos(int? criticidad, int? idUsuario, DateTime? fechaDesde, DateTime? fechaHasta)
    {
        DataTable dataTable = baseDeDatos.ConsultarBase("Select * from Bitacora " + CrearWhere(criticidad, idUsuario, fechaDesde, fechaHasta));

        List<EventoBitacora> eventosBitacora = new List<EventoBitacora>();
        foreach (DataRow row in dataTable.Rows)
        {
            EventoBitacora eventoBitacora = new EventoBitacora();
            eventoBitacora.criticidad = Convert.ToInt32(row["criticidad"]);
            if (DBNull.Value != row["Usuario_idUsuario"])
            {
                eventoBitacora.usuario = gestorDeUsuarios.ObtenerUsuario(Convert.ToInt32(row["Usuario_idUsuario"]));
            }
            else
            {
                eventoBitacora.usuario = new Usuario() { nombreUsuario = "" };
            }
            eventoBitacora.fecha = Convert.ToDateTime(row["fecha"]);
            eventoBitacora.descripcion = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(row["descripcion"]));
            eventoBitacora.funcionalidad = Convert.ToString(row["funcionalidad"]);

            eventosBitacora.Add(eventoBitacora);
        }
        return eventosBitacora;
    }

    /// <summary>
    /// Arma el filtrado de la clausula where implicada en la query que 
    /// hace la busqueda de la bitacora.
    /// </summary>
    /// <param name="criticidad"></param>
    /// <param name="idUsuario"></param>
    /// <param name="fechaDesde"></param>
    /// <param name="fechaHasta"></param>
    /// <returns></returns>
    private string CrearWhere(int? criticidad, int? idUsuario, DateTime? fechaDesde, DateTime? fechaHasta)
    {
        String where = "";
        if (criticidad != null)
        {
            where = " criticidad = " + criticidad;
        }

        if (idUsuario != null)
        {
            if (where.Length > 0)
            {
                where = where + " AND ";
            }
            where = where + " Usuario_idUsuario = " + idUsuario;
        }

        if (fechaDesde != null && fechaHasta != null)
        {

            if (where.Length > 0)
            {
                where = where + " AND ";
            }
            where = where + " fecha between '" + fechaDesde.ToString() + "' and '" + fechaHasta.ToString() + "'";
        }

        if (where.Length > 0)
            return "WHERE " + where;
        else
            return "";

    }

    /// <summary>
    /// Genera la query que agrega un nuevo registro a la tabla Bitacora
    /// </summary>
    /// <param name="evento"></param>
    public void RegistrarEvento(EventoBitacora evento)
    {
        String insertarEvento = SetFormatDate + " INSERT INTO Bitacora ( criticidad , descripcion , fecha , funcionalidad , Usuario_idUsuario , digitoVerificadorH) VALUES ({0},'{1}','{2}','{3}',{4},'{5}')";
        evento.descripcion = GestorDeEncriptacion.EncriptarAes(evento.descripcion);

        String digitoVerficadorH = GestorDeDigitoVerificador.ObtenerDigitoVH(new List<String>() { evento.criticidad.ToString(), evento.descripcion, evento.fecha.ToString(), evento.funcionalidad, evento.usuario == null ? "" : evento.usuario.identificador.ToString() });
        baseDeDatos.ModificarBase(String.Format(insertarEvento, evento.criticidad, evento.descripcion, evento.fecha.ToString(), evento.funcionalidad, evento.usuario == null ? "null" : evento.usuario.identificador.ToString(), digitoVerficadorH));

        m_GestorDeDigitoVerificador.ModificarDigitoVV("BITACORA");
    }

}