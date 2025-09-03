using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class Especialidades:ICloneable
    {

       public int IdEspecialidad { get; set; }
       public string Especialidad { get; set; }

       public override int GetHashCode()
       {
           return this.GetHashCode();
       }

       public object Clone()
        {
            return this.MemberwiseClone();
        }

       public override bool Equals(object obj)
       {
           if (!(obj is Especialidades)||(obj==null))
           {
               return false;
           }
           return this.Especialidad==((Especialidades)obj).Especialidad;
       }
    }
}
