using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Esta clase se usa para arrojar una excepcion cuando 
///  se encuentran entidades duplicadas.
/// </summary>
public class EntidadDuplicadaExcepcion : Exception
{
    public String atributo { get; set; }

    public EntidadDuplicadaExcepcion(String atributo)

    {
        this.atributo = atributo;
    }
}