using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class ObraSociales:ICloneable
    {

       public int IdObraSocial { get; set; }
       public string ObraSocial { get; set; }

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
           if (!(obj is ObraSociales)||(obj==null))
           {
               return false;
           }
           return this.ObraSocial==((ObraSociales)obj).ObraSocial;
       }
    }
}
