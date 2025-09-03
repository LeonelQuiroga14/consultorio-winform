using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Dias:ICloneable
    {
        public int IdDia { get; set; }
        public string Dia { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();

        }
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Dias )||(obj==null))
            {
                return false;
            }
           
            return this.Dia==((Dias)obj).Dia;
        }
    }
}
