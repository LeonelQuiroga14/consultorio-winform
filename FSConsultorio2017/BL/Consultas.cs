using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public   class Consultas
    {

        public int IdConsulta { get; set; }
        public ReservasTurno Turno { get; set; }

        public string Sintomas { get; set; }
        public string Diagnostico { get; set; }
        public string Medicacion { get; set; }
        public string Observaciones { get; set; }

    }
}
