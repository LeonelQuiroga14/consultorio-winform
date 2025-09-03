using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Nacionalidades : ICloneable
    {

        public int IdNacionalidad { get; set; }
        public string Nacionalidad { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Nacionalidades)||(obj==null))
            {
                return false;
            }
            return this.Nacionalidad==((Nacionalidades)obj).Nacionalidad;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
