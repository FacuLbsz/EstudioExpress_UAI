using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

/// <summary>
/// Se maneja toda la logica implicada en la gestion del digito verificador
/// </summary>
public class GestorDeDigitoVerificador
{

    private static GestorDeDigitoVerificador instancia;

    //SDC Relacion con gestor de encriptacion

    private BaseDeDatos baseDeDatos;

    private GestorDeDigitoVerificador()
    {
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
    }

    public static GestorDeDigitoVerificador ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeDigitoVerificador();
        }

        return instancia;
    }

    /// <summary>
    /// Arma la query que va a agregar o modificar un registro en la 
    /// tabla digitoverificadorvertical de la bd.
    /// </summary>
    /// <param name="tabla"></param>
    public void ModificarDigitoVV(String tabla)
    {
        DataTable dataTable = baseDeDatos.ConsultarBase("SELECT digitoVerificadorH from " + tabla);

        Int64 digitoVV = 0;
        foreach (DataRow row in dataTable.Rows)
        {
            var digitoVH = Convert.ToString(row["digitoVerificadorH"]);
            foreach (char a in digitoVH)
            {
                digitoVV = digitoVV + a;
            }
        }

        DataTable digitoVVPrevio = baseDeDatos.ConsultarBase(String.Format("Select * From digitoverificadorvertical where tabla = '{0}'", tabla));

        if (digitoVVPrevio.Rows.Count == 0)
        {
            baseDeDatos.ModificarBase(String.Format("INSERT INTO digitoverificadorvertical (tabla,digitoVerificador) VALUES ('{0}','{1}')", tabla, digitoVV));
        }
        else
        {
            baseDeDatos.ModificarBase(String.Format("UPDATE digitoverificadorvertical SET digitoVerificador = '{0}' WHERE tabla = '{1}'", digitoVV, tabla));
        }

    }

    /// <summary>
    /// Se realiza el calculo y obtencion del DVH
    /// </summary>
    /// <param name="argumentos"></param>
    /// <returns></returns>
    public static String ObtenerDigitoVH(List<String> argumentos)
    {
        String digitoVH = "";

        foreach (String arugmento in argumentos)
        {
            digitoVH = digitoVH + arugmento;
        }

        return GestorDeEncriptacion.EncriptarMD5(digitoVH);
    }

}