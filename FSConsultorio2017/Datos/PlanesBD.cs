using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using System.Windows.Forms;

namespace Datos
{
   public  class PlanesBD
    {

        public static List<Planes> GetLista()
        {
            try
            {
                List<Planes> lista = new List<Planes>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "Select IdPlan,IdObraSocial,Nombre,Cobertura From Planes";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Planes p = new Planes();
                        p.IdPlan = reader.GetInt32(0);
                        p.ObraSocial = ObrasSocialesBD.GetObjeto(reader.GetInt32(1));
                        p.Plan = reader.GetString(2);
                        p.Cobertura = reader.GetDecimal(3);

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

        public static void CargarDatosCombo(ref ComboBox cboPlanes, ObraSociales obrasocial)
        {
            List<Planes> lista = GetLista(obrasocial);
            Planes defaultPlan = new Planes() { Plan = "<Seleccione Plan>" };
            lista.Insert(0, defaultPlan);
            cboPlanes.DataSource = lista;
            cboPlanes.DisplayMember = "Plan";
            cboPlanes.ValueMember = "IdPlan";
            cboPlanes.SelectedIndex = 0;

        }

        private static List<Planes> GetLista(ObraSociales obrasocial)
        {
            try
            {
                List<Planes> lista = new List<Planes>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "Select IdPlan,IdObraSocial,Nombre,Cobertura From Planes WHERE IdObraSocial=@os";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@os", obrasocial.IdObraSocial);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Planes p = new Planes();
                        p.IdPlan = reader.GetInt32(0);
                        p.ObraSocial = ObrasSocialesBD.GetObjeto(reader.GetInt32(1));
                        p.Plan = reader.GetString(2);
                        p.Cobertura = reader.GetDecimal(3);

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

        public static void CargarCombobox(ref ComboBox cboPlanes)
        {
            List<Planes> lista = PlanesBD.GetLista();
            Planes defaultPlan = new Planes() { Plan = "<Seleccione Plan>" };
            lista.Insert(0, defaultPlan);
            cboPlanes.DataSource = lista;
            cboPlanes.DisplayMember = "Plan";
            cboPlanes.ValueMember = "IdPlan";
            cboPlanes.SelectedIndex = 0;
        }

        public static Planes GetObjeto(int p)
        {
            Planes Planes = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdPlan,IdObraSocial,Nombre,Cobertura FROM Planes WHERE IdPlan=@p";

                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@p", p);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Planes = new Planes();
                        Planes.IdPlan = reader.GetInt32(0);
                        Planes.ObraSocial = ObrasSocialesBD.GetObjeto(reader.GetInt32(1));
                        Planes.Plan = reader.GetString(2);
                        Planes.Cobertura = reader.GetDecimal(3);
                    }

                }
                return Planes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Agregar(Planes os)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();

                    SqlCommand comando = new SqlCommand("AltaPlan", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdObraSocial", SqlDbType.Int);
                    comando.Parameters.Add("@Plan", SqlDbType.NVarChar, 50);
                    comando.Parameters.Add("@Cobertura", SqlDbType.Decimal, 18);
                    comando.Parameters["@IdObraSocial"].Value = os.ObraSocial.IdObraSocial;
                    comando.Parameters["@Plan"].Value = os.Plan;
                    comando.Parameters["@Cobertura"].Value = os.Cobertura;
                    //comando.Parameters.AddWithValue("@Plan", os.Plan);
                    comando.ExecuteNonQuery();
                    string strComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(strComando, cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    os.IdPlan = id;

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_Planes_ObraSocial_Plan"))
                {
                    throw new Exception("Plan Repetido");
                }
                throw;
            }
        }

        public static void Editar(Planes os)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("EditarPlan", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdPlan", SqlDbType.Int);
                    comando.Parameters.Add("@IdObraSocial", SqlDbType.Int);
                    comando.Parameters.Add("@Plan", SqlDbType.NVarChar, 50);
                    comando.Parameters.Add("@Cobertura", SqlDbType.Decimal, 18);
                    comando.Parameters["@IdPlan"].Value = os.IdPlan;
                    comando.Parameters["@IdObraSocial"].Value = os.ObraSocial.IdObraSocial;
                    comando.Parameters["@Plan"].Value = os.Plan;
                    comando.Parameters["@Cobertura"].Value = os.Cobertura;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_Planes_ObraSocial_Plan"))
                {
                    throw new Exception("Plan Repetido");
                }

                throw;
            }

        }

       public static void Borrar(Planes os)
       {
           try
           {
               using (SqlConnection cnn = Conexion.ConectarBD())
               {
                   cnn.Open();
                   SqlCommand comando = new SqlCommand("BajaPlan", cnn);
                   comando.CommandType = CommandType.StoredProcedure;
                   comando.Parameters.Add("@IdPlan", SqlDbType.Int);
                   comando.Parameters["@IdPlan"].Value = os.IdPlan;
                   comando.ExecuteNonQuery();

               }
           }
           catch (Exception ex)
           {

               //if (ex.Message.Contains("FK_Localidades_Planess"))
               //{
               //    throw new Exception($"{p.Nombre} tiene una localidad relacionada \n No se puede eliminar");
               //}
               throw ex;
           }

       }
    }
}
