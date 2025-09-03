using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public   class MedicosPlanes:ICloneable
    {


      public int IdMedicoPlan { get; set; }
      //public Especialidades Especialidad { get; set; }
      public MedicoEspecialidad MedicoEspecialidad { get; set; }
      public ObraSociales ObraSocial { get; set; }
      public Planes Plan { get; set; }

      public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
