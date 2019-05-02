using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Familia
{

    public int identificador { get; set; }
    //SDC Agregar campo nombre que faltaba
    public String nombre { get; set; }
    public List<Patente> patentesAsignadas { get; set; }
    public List<Usuario> usuariosAsignados { get; set; }
    public Patente m_Patente { get; set; }

    public Familia()
    {
        patentesAsignadas = new List<Patente>();
        usuariosAsignados = new List<Usuario>();
    }
}