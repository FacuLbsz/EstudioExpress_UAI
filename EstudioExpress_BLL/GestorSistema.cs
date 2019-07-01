using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using Ionic.Zip;

/// <summary>
/// Sirve como facade a la capa de presentacion.
/// </summary>
public class GestorSistema
{

    private static GestorSistema instancia;
    public GestorDeUsuarios m_GestorDeUsuarios;
    public GestorDePatentes m_GestorDePatentes;

    //SDC Añadir relacion GestorDeEncriptacion 

    //SDC Relacion con gestor de digito verificador GestorDeDigitoVerificador

    private BaseDeDatos baseDeDatos;
    
    private GestorSistema()
    {
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
    }

    public static GestorSistema ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorSistema();
        }

        return instancia;
    }

    /// <summary>
    /// recalcula los DVH
    /// </summary>
    public void RecalcularDigitosVerificadores()
    {
        var map = new Dictionary<String, Dictionary<String, List<String>>>();
        map.Add("BITACORA",
            new Dictionary<String, List<String>>()
            { {"idBitacora", new List<String>() { "criticidad", "descripcion", "fecha", "funcionalidad", "Usuario_idUsuario" } } });

        map.Add("USUARIO",
            new Dictionary<String, List<String>>()
            {{"idUsuario" , new List<String>() { "nombreUsuario", "nombre", "apellido", "contrasena" } } });
        map.Add("PATENTEUSUARIO",
            new Dictionary<String, List<String>>()
            {{"idPatente" , new List<String>() { "esPermisiva", "Patente_idPatente", "Usuario_idUsuario" } } });
        map.Add("FAMILIAPATENTE",
            new Dictionary<String, List<String>>()
            {{"idFamiliaPatente" , new List<String>() { "Patente_idPatente", "Familia_idFamilia" } } });

        foreach (String tabla in map.Keys)
        {
            var identificadorConColumnas = map[tabla];
            identificadorConColumnas.Keys.GetEnumerator().MoveNext();
            foreach (String identificador in identificadorConColumnas.Keys)
            {
                var atributos = identificadorConColumnas[identificador];
                RecalcularDigitosVerificadores(tabla, atributos, identificador);
            }
        }

        var evento1 = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se recalculan los digitos verificadores", criticidad = 1, funcionalidad = "INTEGRIDAD DE BASE DATOS", usuario = null };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento1);
    }

    /// <summary>
    /// Recalcula los DVH
    /// </summary>
    /// <param name="tabla"></param>
    /// <param name="atributos"></param>
    /// <param name="identificador"></param>
    private void RecalcularDigitosVerificadores(String tabla, List<String> atributos, String identificador)
    {
        DataTable dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM {0}", tabla));

        Int64 digitosVHBitacora = 0;
        foreach (DataRow eventoBitacora in dataTable.Rows)
        {
            List<String> argumentos = new List<String>();
            foreach (String atributo in atributos)
            {
                if (DBNull.Value != eventoBitacora[atributo])
                {
                    argumentos.Add(Convert.ToString(eventoBitacora[atributo]));
                }
                else
                {
                    argumentos.Add("");
                }
            }

            var id = eventoBitacora[identificador];

            var digitoVH = GestorDeDigitoVerificador.ObtenerDigitoVH(argumentos);

            baseDeDatos.ModificarBase(String.Format("UPDATE {0} SET digitoVerificadorH = '{1}' WHERE {2} = {3}", tabla, digitoVH, identificador, id));

            foreach (char a in digitoVH)
            {
                digitosVHBitacora = digitosVHBitacora + a;
            }
        }

        if (digitosVHBitacora > 0)
        {
            baseDeDatos.ModificarBase(String.Format("UPDATE digitoverificadorvertical SET digitoVerificador = '{0}' WHERE tabla = '{1}'", digitosVHBitacora, tabla));
        }
    }

    /// <summary>
    /// Verifica la integridad en la base de datos.
    /// </summary>
    /// <returns></returns>
    public int ConsultarIntegridadDeBaseDeDatos()
    {

        var map = new Dictionary<String, List<String>>();
        map.Add("BITACORA", new List<String>() { "criticidad", "descripcion", "fecha", "funcionalidad", "Usuario_idUsuario" });
        map.Add("USUARIO", new List<String>() { "nombreUsuario", "nombre", "apellido", "contrasena" });
        map.Add("PATENTEUSUARIO", new List<String>() { "esPermisiva", "Patente_idPatente", "Usuario_idUsuario" });
        map.Add("FAMILIAPATENTE", new List<String>() { "Patente_idPatente", "Familia_idFamilia" });

        foreach (String tabla in map.Keys)
        {
            if (ConsultaIntegridadDeUnaTabla(tabla, map[tabla]) == 0)
            {
                return 0;
            }
        }
        return 1;
    }

    /// <summary>
    /// Se consulta la integridad por una tabla especifica.
    /// </summary>
    /// <param name="tabla"></param>
    /// <param name="atributos"></param>
    /// <returns></returns>
    private int ConsultaIntegridadDeUnaTabla(String tabla, List<String> atributos)
    {

        DataTable dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM {0}", tabla));

        Int64 digitoVV = 0;
        foreach (DataRow eventoBitacora in dataTable.Rows)
        {
            List<String> argumentos = new List<String>();
            Dictionary<String, String> columnRow = new Dictionary<string, string>();
            foreach (String atributo in atributos)
            {
                if (DBNull.Value != eventoBitacora[atributo])
                {
                    String argumento = Convert.ToString(eventoBitacora[atributo]);
                    columnRow.Add(atributo, argumento);
                    argumentos.Add(argumento);
                }
                else
                {
                    argumentos.Add("");
                }
            }

            var digitoVH = GestorDeDigitoVerificador.ObtenerDigitoVH(argumentos);

            if (!digitoVH.Equals(Convert.ToString(eventoBitacora["digitoVerificadorH"])))
            {
                var columns = "";
                foreach (String key in columnRow.Keys)
                {
                    columns = columns + " Columna: " + key;
                }
                var evento1 = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Error de digito verificador horizontal en la tabla " + tabla + columns, criticidad = 1, funcionalidad = "INTEGRIDAD DE BASE DATOS", usuario = null };
                GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento1);
                return 0;
            }


            foreach (char a in digitoVH)
            {
                digitoVV = digitoVV + a;
            }
        }

        if (digitoVV > 0)
        {
            dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT digitoVerificador FROM digitoverificadorvertical WHERE tabla = '{0}'", tabla));

            if (dataTable.Rows.Count > 0)
            {
                if (!Convert.ToString(dataTable.Rows[0]["digitoVerificador"]).Equals(digitoVV.ToString()))
                {
                    var evento1 = new EventoBitacora() { fecha = DateTime.Now, descripcion = "El digito verificador de la tabla " + tabla + " no coincide con el calculado por el sistema.", criticidad = 1, funcionalidad = "INTEGRIDAD DE BASE DATOS", usuario = null };
                    GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento1);
                    return 0;
                }
            }
            else
            {
                var evento1 = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Error de integridad de datos en la tabla " + tabla + ", no existe digito vertical.", criticidad = 1, funcionalidad = "INTEGRIDAD DE BASE DATOS", usuario = null };
                GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento1);
                return 0;
            }
        }
        return 1;
    }

    /// <summary>
    /// Se realiza la logica del Login y retornamos un valor por cada caso.
    /// </summary>
    /// <param name="usuario"></param>
    /// <returns></returns>
    public int RealizarLogIn(Usuario usuario)
    {
        var nombre = usuario.nombreUsuario;
        Usuario usuarioLogin = GestorDeUsuarios.ObtenerInstancia().RealizarLogIn(usuario);

        if (usuarioLogin != null && usuarioLogin.cantidadDeIntentos >= 5)
        {
            var evento1 = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Intento login usuario bloqueado " + nombre, criticidad = 1, funcionalidad = "LOGIN", usuario = null };
            GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento1);
            return 2;
        }
        else if (usuarioLogin == null || usuarioLogin.identificador == 0)
        {
            return 0;
        }
        else if (usuarioLogin.cantidadDeIntentos < 5)
        {
            GestorDeUsuarios.ObtenerInstancia().DesbloquearUsuario(usuarioLogin);
        }
        
        usuario.identificador = usuarioLogin.identificador;

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Login", criticidad = 3, funcionalidad = "LOGIN", usuario = new Usuario() { identificador = usuarioLogin.identificador } };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);
        return 1;
    }

    /// <summary>
    /// Metodo usado para modificar la connectionstring 
    /// </summary>
    /// <param name="stringDeConexion"></param>
    /// <returns></returns>
    public static int ModificarStringDeConexion(String stringDeConexion)
    {

        EstudioExpress_BLL.EstudioExpress.Default.StringDeConexion = stringDeConexion;
        EstudioExpress_BLL.EstudioExpress.Default.Save();
        try
        {
            instancia = new GestorSistema();
            BaseDeDatos.ObtenerInstancia().ConsultarBase("SELECT 1");
        }
        catch (Exception e)
        {
            EventoBitacora eventoo = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se modifico el String de conexión y fallo la conexion", criticidad = 1, funcionalidad = "MODIFICAR STRING DE CONEXION", usuario = null };
            GestorDeBitacora.ObtenerInstancia().RegistrarEvento(eventoo);
            throw new Exception("No fue posible acceder a la Base de datos ingresada, por favor verifique el String de Conexion.");
        }
        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se modifico el String de conexión correctamente", criticidad = 2, funcionalidad = "MODIFICAR STRING DE CONEXION", usuario = null };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);
        return 1;
    }

    /// <summary>
    /// Se realiza el backup por un volumen y hacia una ruta especifica.
    /// </summary>
    /// <param name="rutaDestino"></param>
    /// <param name="cantidadVolumenes"></param>
    /// <returns></returns>
    public int RealizarBackup(String rutaDestino, int cantidadVolumenes, int usuarioEnSesion)
    {
        try
        {
            using (ZipFile zip = new ZipFile())
            {
                var backupPath = baseDeDatos.ObtenerBackup();
                var ruta = backupPath;
                var multiplesVolumenes = cantidadVolumenes > 1;
                var rutaDestinoTemp = rutaDestino + "\\EstudioExpress-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".zip";

                zip.AddFile(ruta, "");
                zip.TempFileFolder = Path.GetTempPath();
                zip.Save(rutaDestinoTemp);

                if (cantidadVolumenes > 1)
                {
                    FileInfo fileInfo = new FileInfo(rutaDestinoTemp);
                    var tamañoDeVolumen = fileInfo.Length / cantidadVolumenes;

                    using (ZipFile zip2 = new ZipFile())
                    {
                        zip2.MaxOutputSegmentSize = (int)tamañoDeVolumen;
                        zip2.AddFile(rutaDestinoTemp, "");
                        zip2.TempFileFolder = Path.GetTempPath();
                        zip2.Save(rutaDestinoTemp);
                    }

                }
            }
        }
        catch (Exception e)
        {
            return 0;
        }

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se exporta backup de la base de datos en " + cantidadVolumenes + " particiones en la ruta " + rutaDestino, criticidad = 1, funcionalidad = "REALIZAR BACKUP", usuario = new Usuario() { identificador = usuarioEnSesion } };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        return 1;
    }

    /// <summary>
    /// se realiza la restauracion de un .bak especifico
    /// </summary>
    /// <param name="rutaOrigen"></param>
    /// <returns></returns>
    public int RealizarRestore(String rutaOrigen, int usuarioEnSesion)
    {
        try
        {
            DataTable rutaBackupDataTable = baseDeDatos.ConsultarBase("EXEC xp_instance_regread  N'HKEY_LOCAL_MACHINE', N'Software\\Microsoft\\MSSQLServer\\MSSQLServer',N'BackupDirectory'");
            var rutaBackup = "";
            foreach (DataRow row in rutaBackupDataTable.Rows)
            {
                rutaBackup = row["Data"].ToString();
            }

            using (ZipFile zipFile = new ZipFile(rutaOrigen))
            {
                rutaBackup = rutaBackup + "\\Backup-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                zipFile.ExtractAll(rutaBackup);

                string[] zipFiles = Directory.GetFiles(rutaBackup, "*.zip*", SearchOption.AllDirectories);

                if (zipFiles.Length > 0)
                {
                    var zipFile2 = new ZipFile(zipFiles[0]);
                    zipFile2.ExtractAll(rutaBackup);
                }

                string[] backFiles = Directory.GetFiles(rutaBackup, "*.bak*", SearchOption.AllDirectories);

                if (backFiles.Length == 1)
                {
                    baseDeDatos.RealizarRestore(backFiles[0]);
                }
                else
                {
                    return 0;
                }
            }
        }
        catch (Exception e)
        {
            return 0;
        }


        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "El usuario " + GestorDeUsuarios.ObtenerInstancia().ObtenerUsuario(usuarioEnSesion).nombreUsuario + " realiza la restauracion de la base de datos", criticidad = 1, funcionalidad = "REALIZAR RESTORE" };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        return 1;
    }

    /// <summary>
    /// Se consulta las patentes por un usuario especifico
    /// </summary>
    /// <param name="patente"></param>
    /// <param name="usuario"></param>
    /// <returns></returns>
    public bool ConsultarPatentePorUsuario(String patente, int usuario)
    {
        var patenteUsuarios = baseDeDatos.ConsultarBase(String.Format("select esPermisiva from patenteusuario inner join patente on patente.idPatente = patenteusuario.Patente_idPatente inner join usuario on patenteusuario.Usuario_idUsuario = usuario.idUsuario where patenteusuario.Usuario_idUsuario = {0} and patente.nombre = '{1}' and usuario.habilitado = 1", usuario, patente));
        if (patenteUsuarios.Rows.Count > 0)
        {
            foreach (DataRow row in patenteUsuarios.Rows)
            {
                return Convert.ToBoolean(row["esPermisiva"]);
            }
        }
        return baseDeDatos.ConsultarBase(String.Format("select * from familiausuario inner join familiapatente on familiapatente.Familia_idFamilia = familiausuario.Familia_idFamilia inner join patente on patente.idPatente = familiapatente.Patente_idPatente inner join familia on familiapatente.Familia_idFamilia = familia.idFamilia inner join usuario on familiausuario.Usuario_idUsuario = usuario.idUsuario where familiausuario.Usuario_idUsuario = {0} and patente.nombre = '{1}' and familia.habilitado = 1 and usuario.habilitado = 1", usuario, patente)).Rows.Count > 0;
    }
}