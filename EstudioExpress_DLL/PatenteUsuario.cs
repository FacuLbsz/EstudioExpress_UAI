using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class PatenteUsuario
{

     public Boolean esPermisivo { get; set; }
     public int identificador { get; set; }
     public Patente patente { get; set; }
     public Usuario usuario { get; set; }
     public Usuario m_Usuario { get; set; }

    public PatenteUsuario()
    {

    }

    public override bool Equals(object obj)
    {
        var item = obj as PatenteUsuario;

        if (item == null)
        {
            return false;
        }

        if(item.esPermisivo && !this.esPermisivo)
        {
            return false;
        }

        return item.patente.identificador == patente.identificador;
    }

    public override int GetHashCode()
    {
        return patente.identificador;
    }

}