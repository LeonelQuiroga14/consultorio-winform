using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Persona
    {

        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public TipoDocumento TipoDoc { get; set; }
        public int NumeroDoc { get; set; }
        public Generos Genero { get; set; }
        public Nacionalidades Nacionalidad { get; set; }
        public Provincia Provincia { get; set; }
        public Localidad Localidad { get; set; }
        public string GrupoSanguineo { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNac { get; set; }
        public string TelefonoMovil { get; set; }
        public string TelefonoFijo { get; set; }
        public ObraSociales ObraSocial { get; set; }
        public Planes Plan { get; set; }
        public string NroAfiliado { get; set; }
        public string ApellidoNombre { get { return String.Format("{0} {1}", this.Apellido, this.Nombre); } }

        // public bool Estado { get; set; }
        /*
         * controlar cada txt con capacidad (max lengh) segun la tablaen bd*/



    }
}
