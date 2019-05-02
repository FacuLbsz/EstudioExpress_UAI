using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Usuario
{

    public String apellido { get; set; }
    public String contrasena { get; set; }
    public String email { get; set; }
    public int identificador { get; set; }
    public String nombre { get; set; }
    public String nombreUsuario { get; set; }
    //SDC nuevo parametro si esta habilitado
    public Boolean habilitado { get; set; }
    public int cantidadDeIntentos { get; set; }
    public List<PatenteUsuario> patenteUsuarioAsignadas { get; set; }
    public Familia m_Familia { get; set; }

    public Usuario()
    {

    }

    public override bool Equals(object obj)
    {
        var item = obj as Usuario;

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