using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoMovimientos : ICloneable
    {


        public int IdTipoMovimiento { get; set; }
        public string  TipoMovimiento { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is TipoMovimientos)||(obj == null))
            {
                return false;
            }
            return this.TipoMovimiento==((TipoMovimientos)obj).TipoMovimiento;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }


    }
}
