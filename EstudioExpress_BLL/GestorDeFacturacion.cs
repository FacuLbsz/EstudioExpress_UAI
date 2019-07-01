using System;
using System.Collections.Generic;
using System.Data;



public class GestorDeFacturacion
{
    private static GestorDeFacturacion instancia;
    private BaseDeDatos baseDeDatos;



    private String sqlCrearFacturaConDetalle =
    "begin tran;"
    + "DECLARE @AuxTable TABLE (id INT);"
    + "DECLARE @id int;"
    + "INSERT INTO FACTURA (fecha ,idUsuario) OUTPUT INSERTED.idFactura INTO @AuxTable(id) VALUES (GETDATE() ,%idUsuario%);"
    + "SET @id = (select id from @AuxTable);"
    + "%detalles%"
    + "commit tran;";

    private String sqlCrearDetalleFactura = "INSERT INTO DETALLEFACTURA (descripcion, monto, idFactura) VALUES ('%descripcion%', %monto%, @id);";

    private GestorDeFacturacion()
    {
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
    }

    public static GestorDeFacturacion ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeFacturacion();
        }

        return instancia;
    }

    public int CrearFactura(Factura factura)
    {
        var detalle = "";

        foreach (DetalleFactura detalleFactura in factura.DetalleFactura)
        {   
            detalle = sqlCrearDetalleFactura.Replace("%descripcion%", detalleFactura.descripcion + "").Replace("%monto%", detalleFactura.monto + "");
        }
        //'%fecha%' ,%idUsuario%
        var registros = baseDeDatos.ModificarBase(sqlCrearFacturaConDetalle
            .Replace("%idUsuario%", factura.usuario.identificador + "")
            .Replace("%detalles%", detalle));

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se crea una factura para el usuario", criticidad = 3, funcionalidad = "ADMINISTRACION DE FACTURACION", usuario = factura.usuario };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);


        return registros;
    }

    public List<Factura> ObtenerFacturasDeUnUsuario(int usuario)
    {
        var dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT * from FACTURA where Factura.idUsuario = {0}", usuario));
        List<Factura> facturas = new List<Factura>();
        foreach (DataRow row in dataTable.Rows)
        {
            Factura factura = FacturaRow(row);

            factura.DetalleFactura = ObtenerDetallesDeUnaFactura(factura.identificador);
            factura.monto = CalcularMonto(factura.DetalleFactura);
            facturas.Add(factura);

        }
        return facturas;
    }

    private Factura FacturaRow(DataRow row)
    {
        Factura factura = new Factura();

        factura.fecha = Convert.ToDateTime(row["fecha"]);
        factura.identificador = Convert.ToInt32(row["idFactura"]);
        return factura;
    }

    private Decimal CalcularMonto(List<DetalleFactura> detalles)
    {
        Decimal monto = 0;
        detalles.ForEach((d) =>
        {
            monto = monto + d.monto;
        });

        return monto;
    }

    public List<DetalleFactura> ObtenerDetallesDeUnaFactura(int factura)
    {
        var dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM DETALLEFACTURA where DETALLEFACTURA.idFactura = {0}", factura));

        List<DetalleFactura> detalles = new List<DetalleFactura>();
        foreach (DataRow row in dataTable.Rows)
        {
            DetalleFactura detalleFactura = new DetalleFactura();
            detalleFactura.descripcion = Convert.ToString(row["descripcion"]);
            detalleFactura.monto = Convert.ToDecimal(row["monto"]);
            detalles.Add(detalleFactura);
        }

        return detalles;

    }
}
