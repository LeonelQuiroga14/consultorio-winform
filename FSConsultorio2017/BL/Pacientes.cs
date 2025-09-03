using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pacientes:Persona,ICloneable
    {
        public int IdPaciente { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{Nombre} " + $" {Apellido}";
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pacientes)||(obj == null))
            {
                return false;
            }
            return base.Equals(obj);
        }
    }
}
