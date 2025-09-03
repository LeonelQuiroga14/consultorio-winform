using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Localidad : ICloneable
    {

        public int IdLocalidad { get; set; }
        public Provincia provincia { get; set; }
        public string NombreLocalidad { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Localidad) || (obj == null))
            {
                return false;
            }
            return this.NombreLocalidad == ((Localidad) obj).NombreLocalidad &&
                   this.provincia == ((Localidad) obj).provincia;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //**********
        
        
      
       
     

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
