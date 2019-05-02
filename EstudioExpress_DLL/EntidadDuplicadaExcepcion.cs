using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EntidadDuplicadaExcepcion : Exception
{

    public String atributo { get; set; }

    public EntidadDuplicadaExcepcion(String atributo)

    {
        this.atributo = atributo;
    }

}