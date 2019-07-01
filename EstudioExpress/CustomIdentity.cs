using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace EstudioExpress
{
    public class CustomIdentity : GenericIdentity
    {
        public int identificador { get; set; }

        public CustomIdentity(string name, int identificador): base(name)
        {
            this.identificador = identificador;
        }
    }
}