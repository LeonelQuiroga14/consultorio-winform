using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace Datos
{
    public class JornadasBD
    {

        public static List<Jornadas> GetLista()
        {
            try
            {
                List<Jornadas>lista= new List<Jornadas>();
                using (SqlConnection cnn=Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strcom = "Select * FROM Vw_ListaJornadas";
                    SqlCommand comando = new SqlCommand(strcom,cnn);
                    SqlDataReader read = comando.ExecuteReader();
                    while (read.Read())
                    {
                        Jornadas j = new Jornadas();
                        j.IdJornada = read.GetInt32(0);
                        j.Alquiler = read.GetString(1);
                        j.HoraInicial = read.GetString(2);
                        lista.Add(j);
                    }

                }
                return lista;
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }

        }

        public static void CargarCombobox(ref ComboBox cboJornda)
        {
            List<Jornadas> lista = GetLista();
            Jornadas defaultJornada= new Jornadas() {Alquiler = "<Seleccione jornada>"};
            lista.Insert(0,defaultJornada);
            cboJornda.DataSource = lista;
            cboJornda.DisplayMember="Alquiler";
            cboJornda.ValueMember="IdJornada";
            cboJornda.SelectedIndex = 0;
        }


        internal static Jornadas GetObjeto(int v)
        {
            Jornadas j = null;
             
            try
            {
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    string cadena = "Select IdJornada,Nombre,Cast(HoraInicio as nvarchar(8)) as HoraInicio From Jornadas Where IdJornada=@v";
                    SqlCommand comando= new SqlCommand(cadena,cnn);
                    comando.Parameters.AddWithValue("@v",v);
                    
                    SqlDataReader read = comando.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                          j= new Jornadas();
                        j.IdJornada = read.GetInt32(0);
                        j.Alquiler = read.GetString(1);
                        j.HoraInicial = read.GetString(2);

                    }
                }
                return j;
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }
    }
}
