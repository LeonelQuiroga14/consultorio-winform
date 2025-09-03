using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class CuentasCorrientesMedicos
    {


        public int IdCtaCte { get; set; }
        public Medicos Medico { get; set; }
        public AlquileresConsultorio alquilerConsultorio { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public ReservasTurno turno { get; set; }
        public bool Liquidado { get; set; }
        public DateTime FechaLiquidacion { get; set; }
        public decimal total { get; set; }
    }
}
