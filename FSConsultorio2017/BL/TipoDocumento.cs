using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoDocumento:ICloneable
    {
        public int IdTipoDoc { get; set; }
        public string TipoDoc { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TipoDocumento)||obj==null)
            {
                return false;
            }
            return this.TipoDoc == ((TipoDocumento) obj).TipoDoc;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
    
}
