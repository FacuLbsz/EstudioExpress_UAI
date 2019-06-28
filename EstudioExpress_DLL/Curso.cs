using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Curso
{
    public int identificador { get; set; }
    public String nombre { get; set; }
    public int duracion { get; set; }
    public String descripcion { get; set; }
    public Decimal precio { get; set; }
    public List<Episodio> Episodios { get; set; }
    
}
