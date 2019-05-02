using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;

public class BaseDeDatos
{

    private String sqlString = "Persist Security Info=False;User ID=sa;Password=qwer1234;Initial Catalog=Benefix;Server=DESKTOP-VA9KCI4\\SQLEXPRESS";
    private SqlConnection sqlConnection;
    private static BaseDeDatos instancia;

    private BaseDeDatos()
    {
        sqlConnection = new SqlConnection(sqlString);
        Console.WriteLine("Conexion realizada!");
    }

    private BaseDeDatos(String sqlString)
    {
        this.sqlString = sqlString;
        sqlConnection = new SqlConnection(sqlString);
        Console.WriteLine("Conexion realizada!");
    }

    public static BaseDeDatos ObtenerInstancia(String sqlString)
    {
        instancia = new BaseDeDatos(sqlString);
        return instancia;
    }

    public static BaseDeDatos ObtenerInstancia()
    {
        return instancia;
    }

    public DataTable ConsultarBase(String query)
    {
        AbrirConexion();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CrearComandoSQL(query));
        DataTable dataTable = new DataTable();

        sqlDataAdapter.Fill(dataTable);
        CerrarConexion();

        return dataTable;
    }

    public int ModificarBase(String query)
    {
        AbrirConexion();
        var filasAfectadas = CrearComandoSQL(query).ExecuteNonQuery();
        CerrarConexion();
        return filasAfectadas;
    }

    private void AbrirConexion()
    {
        sqlConnection.Open();
    }

    private void CerrarConexion()
    {
        sqlConnection.Close();
    }

    private SqlCommand CrearComandoSQL(String comandoSQL)
    {
        return new SqlCommand(comandoSQL, sqlConnection);
    }

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