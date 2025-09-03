using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MedicoEspecialidad:ICloneable
    {

        //public MedicoEspecialidad()
        //{
        //    Medico= new Medicos();
        //}

        public int IdMedicoEspecialidad { get; set; }
        public Especialidades Especialidad { get; set; }
        public Medicos Medico{ get; set; }
        public string  Matricula { get; set; }
        public decimal CostoConsulta { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
