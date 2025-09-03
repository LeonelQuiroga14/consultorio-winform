using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Consultorios : ICloneable
    {



        public int IdConsultorio { get; set; }
        public string Consultorio { get; set; }
        public bool Estado { get; set; }
        public decimal Costo { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Consultorios)||(obj==null))
            {
                return false;
            }
            return this.Consultorio==((Consultorios)obj).Consultorio;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
