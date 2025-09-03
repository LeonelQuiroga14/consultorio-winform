using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class Usuarios:ICloneable
    {
        public int IdUsuario { get; set; }
        public Medicos Medico { get; set; }
        public Administrativos Administrativo { get; set; }
        public TipoUsuarios TipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public bool Bloqueo { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
