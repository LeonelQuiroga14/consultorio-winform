using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL
{
    public class Provincia:ICloneable
    {
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();

        }

        public override bool Equals(object obj)
        {
            if (!(obj is Provincia)||(obj ==null))
            {
                return false;
            }
            return this.IdProvincia==((Provincia)obj).IdProvincia && this.Nombre == ((Provincia) obj).Nombre;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
