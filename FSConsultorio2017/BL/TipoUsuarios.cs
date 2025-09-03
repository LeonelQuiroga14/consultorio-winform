using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoUsuarios:ICloneable    
    {
        public int IdTipoUsuario { get; set; }
        public string TipoUsuario { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
