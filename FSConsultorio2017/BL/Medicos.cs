using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Medicos:Persona,ICloneable
    {
        public int IdMedico { get; set; }
        public bool Estado { get; set; }
        //public string ApellidoNombre { get { return String.Format("{0} {1}", this.Apellido, this.Nombre); } }

        
        public override bool Equals(object obj)
        {
            if (!(obj is Medicos)||(obj==null))
            {
                return false;
            }
            return this.Apellido==((Medicos)obj).Apellido && this.Nombre==((Medicos)obj).Nombre && this.NumeroDoc==((Medicos)obj).NumeroDoc;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Nombre}" + $"{Apellido}";

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
