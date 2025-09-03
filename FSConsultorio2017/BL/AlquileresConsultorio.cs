using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlquileresConsultorio
    {

        public int IdAlquilerConsultorio { get; set; }
        public Consultorios Consultorio { get; set; }
        public Medicos Medico { get; set; }
        public MedicoEspecialidad MedicoEspecialidad { get; set; }
        public Jornadas Jornada { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }



    }
}
