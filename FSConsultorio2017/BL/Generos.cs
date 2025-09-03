using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Generos : ICloneable
    {



        public int IdGenero { get; set; }
        public string Genero { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Generos)||(obj==null ))
            {
                return false;
            }
            return this.Genero==((Generos)obj).Genero;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
