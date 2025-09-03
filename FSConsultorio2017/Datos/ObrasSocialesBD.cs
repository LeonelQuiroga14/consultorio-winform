using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using System.Windows.Forms;
using Datos;

namespace Datos
{
    public class ObrasSocialesBD
    {

        public static List<ObraSociales> GetLista()
        {
            try
            {
                List<ObraSociales> lista = new List<ObraSociales>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "Select IdObraSocial,ObraSocial From ObraSociales";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ObraSociales os = new ObraSociales();
                        os.IdObraSocial = reader.GetInt32(0);
                        os.ObraSocial = reader.GetString(1);

                        lista.Add(os);
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void CargarCombobox(ref ComboBox cboObraSocial)
        {
            List<ObraSociales> lista = ObrasSocialesBD.GetLista();
            ObraSociales defaultObraSocial = new ObraSociales() { ObraSocial = "<Seleccione Obra Social>" };
            lista.Insert(0, defaultObraSocial);
            cboObraSocial.DataSource = lista;
            cboObraSocial.DisplayMember = "ObraSocial";
            cboObraSocial.ValueMember = "IdObraSocial";
            cboObraSocial.SelectedIndex = 0;
        }

        public static ObraSociales GetObjeto(int p)
        {
            ObraSociales ObraSociales = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdObraSocial,ObraSocial FROM ObraSociales WHERE IdObraSocial=@p";

                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@p", p);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        ObraSociales = new ObraSociales();
                        ObraSociales.IdObraSocial = reader.GetInt32(0);
                        ObraSociales.ObraSocial = reader.GetString(1);
                    }

                }
                return ObraSociales;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Agregar(ObraSociales os)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();

                    SqlCommand comando = new SqlCommand("AltaObraSocial", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@ObraSocial", SqlDbType.NVarChar, 50);
                    comando.Parameters["@ObraSocial"].Value = os.ObraSocial;
                    comando.ExecuteNonQuery();
                    string strComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(strComando, cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    os.IdObraSocial = id;

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_ObraSocialNombre"))
                {
                    throw new Exception("Obra Social Repetida");
                }
                throw;
            }
        }

        public static void Editar(ObraSociales os)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("EditarObraSocial", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdObraSocial", SqlDbType.Int);
                    comando.Parameters.Add("@ObraSocial", SqlDbType.NVarChar, 500);
                    comando.Parameters["@IdObraSocial"].Value =os.IdObraSocial;
                    comando.Parameters["@ObraSocial"].Value = os.ObraSocial;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_ObraSocialNombre"))
                {
                    throw new Exception("Obra Social Repetida");
                }

                throw;
            }

        }

        public static void Borrar(ObraSociales os)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("BajaObraSocial", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdObraSocial", SqlDbType.Int);
                    comando.Parameters["@IdObraSocial"].Value = os.IdObraSocial;
                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                //if (ex.Message.Contains("FK_Localidades_ObraSocialess"))
                //{
                //    throw new Exception($"{p.Nombre} tiene una localidad relacionada \n No se puede eliminar");
                //}
                throw ex;
            }

        }

    }
}
