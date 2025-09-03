using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using BL;
using Datos;

namespace Datos
{
    public class LocalidadesBD
    {

        public static List<Localidad> GetLista()
        {
            try
            {
                List<Localidad> lista= new List<Localidad>();
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdLocalidad,IdProvincia,Localidad FROM Localidades";
                    SqlCommand comando= new SqlCommand(strComando,cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Localidad localidad= new Localidad();
                        localidad.IdLocalidad = reader.GetInt32(0);
                        localidad.provincia = ProvinciaBD.GetObjeto(reader.GetInt32(1));
                        localidad.NombreLocalidad = reader.GetString(2);

                        lista.Add(localidad);
                    }

                }
                return lista;
            }
            catch (Exception)
            {
                
                throw;
            }


        }

        public static void Agregar(Localidad localidad)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando= new SqlCommand("AltaLocalidad",cnn);
                    comando.CommandType=CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdProvincia", SqlDbType.Int);
                    comando.Parameters.Add("@Localidad", SqlDbType.NVarChar, 50);
                    comando.Parameters["@IdProvincia"].Value = localidad.provincia.IdProvincia;
                    comando.Parameters["@Localidad"].Value = localidad.NombreLocalidad;
                    comando.ExecuteNonQuery();
                    string strComando = "SELECT @@IDENTITY";
                    comando= new SqlCommand(strComando,cnn);
                    int id = (int) (decimal) comando.ExecuteScalar();
                    localidad.IdLocalidad = id;
                }
        }
            catch (Exception ex )
            {

                if (ex.Message.Contains("IX_Localidades_Provincia"))
                {
                    throw  new Exception("Localidad repetida");
                }
                throw;
            }



        }

        public static void Editar(Localidad loc)
        {
            try
            {
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    //string strComando = "UPDATE Localidades SET IdProvincia=@IdProvincia,Localidad=@Localidad WHERE IdLocalidad=@Id";
                    SqlCommand comando= new SqlCommand("EditarLocalidad",cnn);
                    //comando.Parameters.AddWithValue("@IdProvincia", loc.provincia.IdProvincia);
                    //comando.Parameters.AddWithValue("@Localidad", loc.NombreLocalidad);
                    //comando.Parameters.AddWithValue("@Id", loc.IdLocalidad);
                    comando.CommandType=CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdLocalidad", SqlDbType.Int);
                    comando.Parameters.Add("@IdProvincia", SqlDbType.Int);
                    comando.Parameters.Add("@Localidad", SqlDbType.NVarChar, (50));
                    comando.Parameters["@IdLocalidad"].Value = loc.IdLocalidad;
                    comando.Parameters["@IdProvincia"].Value = loc.provincia.IdProvincia;
                    comando.Parameters["@Localidad"].Value = loc.NombreLocalidad;
                    comando.ExecuteNonQuery();


                }
            }
            catch (Exception ex )
            {
                if (ex.Message.Contains("IX_Localidades_Provincia"))
                {
                    throw new Exception("Localidad repetida");
                }
                throw;
            }
        }

        public static void Borrar(Localidad loc)
        {
            try
            {
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando= new SqlCommand("BajaLocalidad",cnn);
                    comando.CommandType=CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdLocalidad", SqlDbType.Int);
                    comando.Parameters["@IdLocalidad"].Value = loc.IdLocalidad;
                    comando.ExecuteNonQuery();
                } 
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }


        public static void CargarCombobox(ref ComboBox cboLocalidad, Provincia Provincia)
        {
            List<Localidad> lista = GetLista(Provincia);
            Localidad defaultloc = new Localidad() { NombreLocalidad = "<Seleccione Localidad>" };
            lista.Insert(0, defaultloc);
            cboLocalidad.DataSource = lista;
            cboLocalidad.DisplayMember = "NombreLocalidad";
            cboLocalidad.ValueMember = "IdLocalidad";
            cboLocalidad.SelectedIndex = 0;

        }

        private static List<Localidad> GetLista(Provincia provincia)
        {
            try
            {
                List<Localidad> lista = new List<Localidad>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "Select IdLocalidad,IdProvincia,Localidad  From Localidades WHERE IdProvincia=@pv";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@pv", provincia.IdProvincia);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Localidad p = new Localidad();
                        p.IdLocalidad = reader.GetInt32(0);
                        p.provincia = ProvinciaBD.GetObjeto(reader.GetInt32(1));
                        p.NombreLocalidad = reader.GetString(2);
                      

                        lista.Add(p);
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void CargarCombobox(ref ComboBox cboLocalidad)
        {
            List<Localidad> lista = GetLista();
            Localidad defaultloc = new Localidad() { NombreLocalidad = "<Seleccione Localidad>" };
            lista.Insert(0, defaultloc);
            cboLocalidad.DataSource = lista;
            cboLocalidad.DisplayMember = "NombreLocalidad";
            cboLocalidad.ValueMember = "IdLocalidad";
            cboLocalidad.SelectedIndex = 0;
        }

        public static Localidad GetObjeto(int  v)
        {
            try
            {
                Localidad loc = null;
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdLocalidad,IdProvincia,Localidad FROM Localidades WHERE IdLocalidad=@p";

                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@p", v);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        loc= new Localidad();
                        loc.IdLocalidad = reader.GetInt32(0);
                        loc.provincia = ProvinciaBD.GetObjeto(reader.GetInt32(1));
                        loc.NombreLocalidad = reader.GetString(2);
                       
                    }

                }
                return loc;
            }
            catch (Exception ex )
            {

                throw ex ;
            }
        }
    }
}
