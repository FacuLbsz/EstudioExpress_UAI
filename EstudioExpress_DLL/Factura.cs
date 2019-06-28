using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Factura
{
    public int identificador { get; set; }
    public Decimal monto { get; set; }
    public List<DetalleFactura> DetalleFactura { get; set; }
    public Usuario usuario { get; set; }
    public DateTime fecha { get; set; }
}
