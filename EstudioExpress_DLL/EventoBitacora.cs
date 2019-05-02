using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class EventoBitacora
{

    public int criticidad { get; set; }
    public String descripcion { get; set; }
    public DateTime fecha { get; set; }
    public String funcionalidad { get; set; }
    public Usuario usuario { get; set; }

    public EventoBitacora()
    {

    }
}