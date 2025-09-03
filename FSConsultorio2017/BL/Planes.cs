using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Planes : ICloneable
    {

        public int IdPlan { get; set; }
        public ObraSociales ObraSocial { get; set; }
    
        public string Plan { get; set; }
        public decimal Cobertura { get; set; }

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
            if (!(obj is Planes)||(obj==null))
            {
                return false;
            }
            return this.ObraSocial.ObraSocial==((Planes)obj).ObraSocial.ObraSocial && this.Plan==((Planes)obj).Plan;
        }
    }
}
