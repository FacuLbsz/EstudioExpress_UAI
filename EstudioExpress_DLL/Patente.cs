using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Patente
{
    public int identificador { get; set; }
    public String nombre { get; set; }
    public PatenteUsuario m_PatenteUsuario { get; set; }

    public static string MI_ESTADO = "MI_ESTADO";
    public static string EVALUAR_EQUIPOS_A_CARGO = "EVALUAR_EQUIPOS_A_CARGO";
    public static string REPORTE_OBJETIVOS_POR_EMPLEADO = "REPORTE_OBJETIVOS_POR_EMPLEADO";
    public static string REPORTE_OBJETIVOS_POR_EQUIPO = "REPORTE_OBJETIVOS_POR_EQUIPO";
    public static string REPORTE_BENEFICIO_POR_EMPLEADO = "REPORTE_BENEFICIO_POR_EMPLEADO";
    public static string BITACORA = "BITACORA";
    public static string BACKUP = "BACKUP";
    public static string RESTORE = "RESTORE";
    public static string ADMINISTRACION_USUARIOS_CREACION = "ADMINISTRACION_USUARIOS_CREACION";
    public static string ADMINISTRACION_USUARIOS_MODIFICACION = "ADMINISTRACION_USUARIOS_MODIFICACION";
    public static string ADMINISTRACION_USUARIOS_ELIMINACION = "ADMINISTRACION_USUARIOS_ELIMINACION";
    public static string ADMINISTRACION_FAMILIAS_CREACION = "ADMINISTRACION_FAMILIAS_CREACION";
    public static string ADMINISTRACION_FAMILIAS_MODIFICACION = "ADMINISTRACION_FAMILIAS_MODIFICACION";
    public static string ADMINISTRACION_FAMILIAS_ELIMINACION = "ADMINISTRACION_FAMILIAS_ELIMINACION";
    public static string ADMINISTRACION_GRUPOS_CREACION = "ADMINISTRACION_GRUPOS_CREACION";
    public static string ADMINISTRACION_GRUPOS_MODIFICACION = "ADMINISTRACION_GRUPOS_MODIFICACION";
    public static string ADMINISTRACION_GRUPOS_ELIMINACION = "ADMINISTRACION_GRUPOS_ELIMINACION";
    public static string ADMINISTRACION_EQUIPOS_CREACION = "ADMINISTRACION_EQUIPOS_CREACION";
    public static string ADMINSITRACION_EQUIPOS_MODIFICACION = "ADMINSITRACION_EQUIPOS_MODIFICACION";
    public static string ADMINISTRACION_EQUIPOS_ELIMINACION = "ADMINISTRACION_EQUIPOS_ELIMINACION";
    public static string ADMINISTRACION_BENEFICIOS_CREACION = "ADMINISTRACION_BENEFICIOS_CREACION";
    public static string ADMINISTRACION_BENEFICIOS_MODIFICACION = "ADMINISTRACION_BENEFICIOS_MODIFICACION";
    public static string ADMINISTRACION_BENEFICIOS_ELIMINACION = "ADMINISTRACION_BENEFICIOS_ELIMINACION";
    public static string ADMINISTRACION_OBJETIVOS_CREACION = "ADMINISTRACION_OBJETIVOS_CREACION";
    public static string ADMINISTRACION_OBJETIVOS_MODIFICACION = "ADMINISTRACION_OBJETIVOS_MODIFICACION";
    public static string ADMINISTRACION_OBJETIVOS_ELIMINACION = "ADMINISTRACION_OBJETIVOS_ELIMINACION  ";

    public Patente()
    {

    }

    public override bool Equals(object obj)
    {
        var item = obj as Patente;

        if (item == null)
        {
            return false;
        }

        return item.identificador == identificador;
    }

    public override int GetHashCode()
    {
        return identificador;
    }
}