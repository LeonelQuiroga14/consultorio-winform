using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ReservasTurno
    {
        
        public int IdTurno { get; set; }
        public string Turno { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public Medicos Medico { get; set; }
        public Pacientes Paciente { get; set; }
        public AlquileresConsultorio Alquiler { get; set; }
        public Consultorios Consultorio { get; set; }
        public bool Reserva { get; set; }
        public decimal Cobro { get; set; }
        public bool Presente { get; set; }
        public MedicoEspecialidad MedicoEspecialidad { get; set; }

       
    }
}
