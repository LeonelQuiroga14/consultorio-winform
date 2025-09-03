using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace Datos
{
    public class NacionalidadesBD
    {

        public static List<Nacionalidades> GetLista()
        {
            try
            {
                List<Nacionalidades> lista = new List<Nacionalidades>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "Select IdNacionalidad,Nacionalidad From Nacionalidades";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Nacionalidades n= new Nacionalidades();
                        n.IdNacionalidad = reader.GetInt32(0);
                        n.Nacionalidad = reader.GetString(1);
                        lista.Add(n);
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void Agregar(Nacionalidades n)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();

                    SqlCommand comando = new SqlCommand("AltaNacionalidad", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Nacionalidad", SqlDbType.NVarChar, 100);
                    comando.Parameters["@Nacionalidad"].Value = n.Nacionalidad;
                    comando.ExecuteNonQuery();
                    string strComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(strComando, cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    n.IdNacionalidad = id;

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_NombreNac"))
                {
                    throw new Exception("Nacionalidad Repetida");
                }
                throw;
            }
        }

        internal static Nacionalidades GetObjeto(int v)
        {

            Nacionalidades tp = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdNacionalidad,Nacionalidad FROM Nacionalidades WHERE IdNacionalidad=@v";

                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@v", v);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        tp = new Nacionalidades();
                        tp.IdNacionalidad = reader.GetInt32(0);
                        tp.Nacionalidad = reader.GetString(1);

                    }

                }
                return tp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Editar(Nacionalidades n)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("EditarNacionalidad", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdNacionalidad", SqlDbType.Int);
                    comando.Parameters.Add("@Nacionalidad", SqlDbType.NVarChar, 100);
                    comando.Parameters["@IdNacionalidad"].Value = n.IdNacionalidad;
                    comando.Parameters["@Nacionalidad"].Value = n.Nacionalidad;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_NombreNac"))
                {
                    throw new Exception("Nacionalidad Repetida");
                }
                throw;
            }

        }

        public static void Borrar(Nacionalidades n)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("BajaNacionalidad", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdNacionalidad", SqlDbType.Int);
                    comando.Parameters["@IdNacionalidad"].Value = n.IdNacionalidad;
                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public static void CargarCombobox(ref ComboBox cboNacionalidad)
        {
            List<Nacionalidades> lista = GetLista();
            Nacionalidades defaultnac = new Nacionalidades() {Nacionalidad= "<Seleccione nacionalidad" };
            lista.Insert(0, defaultnac);
            cboNacionalidad.DataSource = lista;
            cboNacionalidad.DisplayMember = "Nacionalidad";
            cboNacionalidad.ValueMember = "IdNacionalidad";
            cboNacionalidad.SelectedIndex = 0;
        }
    }
}
