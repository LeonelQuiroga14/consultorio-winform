using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace Datos
{
    public class ProvinciaBD
    {

        public static List<Provincia> GetLista()
        {
            try
            {
                List<Provincia> lista = new List<Provincia>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "Select IdProvincia,Provincia From Provincias";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Provincia p = new Provincia();
                        p.IdProvincia = reader.GetInt32(0);
                        p.Nombre = reader.GetString(1);

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

        public static void CargarCombobox(ref ComboBox cboProvincia)
        {
            List<Provincia> lista = ProvinciaBD.GetLista();
            Provincia defaultProvincia = new Provincia() {Nombre = "<Seleccione Provincia>"};
            lista.Insert(0,defaultProvincia);
            cboProvincia.DataSource = lista;
            cboProvincia.DisplayMember = "Nombre";
            cboProvincia.ValueMember = "IdProvincia";
            cboProvincia.SelectedIndex = 0;
        }

        public static Provincia GetObjeto(int p)
        {
            Provincia provincia = null;
            try
            {
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdProvincia,Provincia FROM Provincias WHERE IdProvincia=@p"; 
                                        
                    SqlCommand comando = new SqlCommand(strComando,cnn);
                    comando.Parameters.AddWithValue("@p", p);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        provincia=new Provincia();
                        provincia.IdProvincia = reader.GetInt32(0);
                        provincia.Nombre = reader.GetString(1);
                    }

                }
                return provincia;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static void Agregar(Provincia p)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();

                    SqlCommand comando = new SqlCommand("AltaProvincia", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Provincia", SqlDbType.NVarChar, 100);
                    comando.Parameters["@Provincia"].Value = p.Nombre;
                    comando.ExecuteNonQuery();
                    string strComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(strComando, cnn);
                    int id = (int) (decimal) comando.ExecuteScalar();
                    p.IdProvincia = id;

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_NombreProv"))
                {
                    throw new Exception("Provincia Repetida");
                }
                throw;
            }
        }

        public static void Editar(Provincia p)
            {

                try
                {
                    using (SqlConnection cnn= Conexion.ConectarBD())
                    {
                        cnn.Open();
                    SqlCommand comando= new SqlCommand("EditarProvincia",cnn);
                    comando.CommandType=CommandType.StoredProcedure;
                        comando.Parameters.Add("@IdProvincia", SqlDbType.Int);
                        comando.Parameters.Add("@Provincia", SqlDbType.NVarChar, 100);
                        comando.Parameters["@IdProvincia"].Value = p.IdProvincia;
                        comando.Parameters["@Provincia"].Value = p.Nombre;
                        comando.ExecuteNonQuery();
                    }
                }
                catch (Exception ex )
                {
                    if (ex.Message.Contains("IX_NombreProv"))
                    {
                        throw  new Exception("Provincia Repetida");
                    }
                    
                    throw;
                }

            }

        public static void Borrar(Provincia p)
        {
            try
            {
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando= new SqlCommand("BajaProvincia",cnn);
                    comando.CommandType=CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdProvincia",SqlDbType.Int);
                    comando.Parameters["@IdProvincia"].Value = p.IdProvincia;
                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception ex )
            {

                if (ex.Message.Contains("FK_Localidades_Provincias"))
                {
                    throw  new Exception($"{p.Nombre} tiene una localidad relacionada \n No se puede eliminar");
                }
                throw;
            }

        }

            /*
             * provinciaAE 
             * Borrar
             * Editar(on Load)
             * 
             */
        }
    }

