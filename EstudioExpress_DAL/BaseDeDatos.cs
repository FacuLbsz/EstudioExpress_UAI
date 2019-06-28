using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Toda la logica que realiza conexion y queries contra la BD
/// </summary>
public class BaseDeDatos
{

    private static String sqlString = "Integrated Security=SSPI;Initial Catalog=EstudioExpress;Server=.\\SQLEXPRESS";
    private SqlConnection sqlConnection;
    private static BaseDeDatos instancia;

    private BaseDeDatos()
    {
        sqlConnection = new SqlConnection(sqlString);
        Console.WriteLine("Conexion realizada!");
    }

    private BaseDeDatos(String sqlString)
    {
        sqlConnection = new SqlConnection(sqlString);
        Console.WriteLine("Conexion realizada!");
    }
    

    public static BaseDeDatos ObtenerInstancia()
    {
        if(instancia == null)
        {
            instancia = new BaseDeDatos(sqlString);
        }
        return instancia;
    }

    /// <summary>
    /// A traves de una query recibida por parametro obtenemos un set de datos.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public DataTable ConsultarBase(String query)
    {
        AbrirConexion();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CrearComandoSQL(query));
        DataTable dataTable = new DataTable();

        sqlDataAdapter.Fill(dataTable);
        CerrarConexion();

        return dataTable;
    }

    /// <summary>
    /// A traves de una query recibida por parametro modificamos uno o mas registros de una tabla.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public int ModificarBase(String query)
    {
        AbrirConexion();
        var filasAfectadas = CrearComandoSQL(query).ExecuteNonQuery();
        CerrarConexion();
        return filasAfectadas;
    }

    /// <summary>
    /// Se abre la conexion a la BD
    /// </summary>
    private void AbrirConexion()
    {
        sqlConnection.Open();
    }

    /// <summary>
    /// Se cierra la conexion a la BD.
    /// </summary>
    private void CerrarConexion()
    {
        sqlConnection.Close();
    }

    /// <summary>
    /// Se crea un objeto Command
    /// </summary>
    /// <param name="comandoSQL"></param>
    /// <returns></returns>
    private SqlCommand CrearComandoSQL(String comandoSQL)
    {
        return new SqlCommand(comandoSQL, sqlConnection);
    }

    /// <summary>
    /// Se obtiene el backup de la BD
    /// </summary>
    /// <returns></returns>
    public String ObtenerBackup()
    {
        var rutaBackup = "";
        var nombreBaseDeDatos = sqlConnection.Database.ToString();
        var nombreBackup
            = nombreBaseDeDatos + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".bak";

        string cmd = "BACKUP DATABASE [" + nombreBaseDeDatos + "] TO DISK='" + nombreBackup + "'";

        using (SqlCommand command = new SqlCommand(cmd, sqlConnection))
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            command.ExecuteNonQuery();

            SqlCommand selectBackup = new SqlCommand(String.Format("SELECT top 1 physical_device_name as ruta ,backup_start_date, backup_finish_date, backup_size AS tamaño FROM msdb.dbo.backupset b JOIN msdb.dbo.backupmediafamily m ON b.media_set_id = m.media_set_id WHERE physical_device_name like '%{0}%' ORDER BY backup_finish_date DESC", nombreBackup), sqlConnection);

            SqlDataReader reader = selectBackup.ExecuteReader();
            while (reader.Read())
            {

                rutaBackup = Convert.ToString(reader["ruta"]);

            }

            sqlConnection.Close();
        }

        return rutaBackup;
    }

    /// <summary>
    /// Realizamos el restore de la BD a una ruta especifica.
    /// </summary>
    /// <param name="ruta"></param>
    public void RealizarRestore(String ruta)
    {
        var nombreBaseDeDatos = sqlConnection.Database.ToString();
        if (sqlConnection.State != ConnectionState.Open)
        {
            sqlConnection.Open();
        }
        try
        {
            string sqlStmt2 = string.Format("ALTER DATABASE [" + nombreBaseDeDatos + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            SqlCommand bu2 = new SqlCommand(sqlStmt2, sqlConnection);
            bu2.ExecuteNonQuery();

            string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + nombreBaseDeDatos + "] FROM DISK='" + ruta + "'WITH REPLACE;";
            SqlCommand bu3 = new SqlCommand(sqlStmt3, sqlConnection);
            bu3.ExecuteNonQuery();

            string sqlStmt4 = string.Format("ALTER DATABASE [" + nombreBaseDeDatos + "] SET MULTI_USER");
            SqlCommand bu4 = new SqlCommand(sqlStmt4, sqlConnection);
            bu4.ExecuteNonQuery();

            sqlConnection.Close();

        }
        catch (Exception ex)
        {
        }
    }

}