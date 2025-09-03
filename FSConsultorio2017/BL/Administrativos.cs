using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Administrativos : ICloneable
    {


        public int IdAdministrativo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }

        public TipoDocumento TipoDoc { get; set; }
        public int NumeroDoc { get; set; }
        public Generos Genero { get; set; }
        public Nacionalidades Nacionalidad { get; set; }

        public DateTime FechaNac { get; set; }
        public string TelefonoMovil { get; set; }
        public string TelefonoFijo { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public ObraSociales ObraSocial { get; set; }
        public Planes Plan { get; set; }
        public string NroAfiliado { get; set; }
        public bool Estado { get; set; }


        public override bool Equals(object obj)
        {
            if (!(obj is Administrativos)||(obj==null))
            {
                return false;
            }
            return this.Apellido==((Administrativos)obj).Apellido &&this.Nombre==((Administrativos)obj).Nombre && this.NumeroDoc==((Administrativos)obj).NumeroDoc;
        }

        public override string ToString()
        {
            return $"{Nombre}" + $"{Apellido}";
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
