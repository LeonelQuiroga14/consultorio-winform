using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ObrasPlan : ICloneable
    {


        public int IdObraPlan { get; set; }
        public ObraSociales ObraSocial { get; set; }
        public Planes plan { get; set; }
        public decimal Cobertura { get; set; }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is ObrasPlan)||(obj ==null))
            {
                return false;
            }
            return this.ObraSocial == ((ObrasPlan) obj).ObraSocial && this.plan == ((ObrasPlan) obj).plan;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
