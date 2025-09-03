using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace Datos
{
    public class ObrasPlanesBD
    {

        public static List<ObrasPlan> GetLista()
        {
            try
            {
                List<ObrasPlan> lista = new List<ObrasPlan>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdObraPlan,IdObraSocial,IdPlan,Cobertura FROM ObrasPlanes";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ObrasPlan osp = new ObrasPlan();
                        osp.IdObraPlan = reader.GetInt32(0);
                        osp.ObraSocial = ObrasSocialesBD.GetObjeto(reader.GetInt32(1));
                       osp.plan=PlanesBD.GetObjeto(reader.GetInt32(2));
                        osp.Cobertura = reader.GetDecimal(3);
                        lista.Add(osp);
                    }

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public static void Agregar(ObrasPlan osp)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("AltaObraPlan", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdObraSocial", SqlDbType.Int);
                    comando.Parameters.Add("@IdPlan", SqlDbType.Int);
                    comando.Parameters.Add("@Cobertura", SqlDbType.Decimal,(18));

                    comando.Parameters["@IdObraSocial"].Value = osp.ObraSocial.IdObraSocial;
                    comando.Parameters["@IdPlan"].Value = osp.plan.IdPlan;
                    comando.Parameters["@Cobertura"].Value = osp.Cobertura;
                    comando.ExecuteNonQuery();
                    string strComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(strComando, cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                   osp.IdObraPlan= id;
                }
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("IX_ObraSocial_Plan"))
                {
                    throw new Exception("La obra social ya tiene ese plan asignado");
                }
                throw;
            }



        }

        internal static ObrasPlan GetObjeto(int v)
        {

            ObrasPlan tp = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdObraPlan,IdObraSocial,IdPlan,Cobertura FROM Obras_Planes WHERE IdObraPlan=@v";

                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@v", v);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        tp = new ObrasPlan();
                        tp.IdObraPlan= reader.GetInt32(0);
                        tp.ObraSocial = ObrasSocialesBD.GetObjeto(reader.GetInt32(1));
                        tp.plan = PlanesBD.GetObjeto(reader.GetInt32(2));
                        tp.Cobertura = reader.GetDecimal(3);

                    }

                }
                return tp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Editar(ObrasPlan osp)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    //string strComando = "UPDATE Localidades SET IdProvincia=@IdProvincia,Localidad=@Localidad WHERE IdLocalidad=@Id";
                    SqlCommand comando = new SqlCommand("EditarObraPlan", cnn);
                    //comando.Parameters.AddWithValue("@IdProvincia", loc.provincia.IdProvincia);
                    //comando.Parameters.AddWithValue("@Localidad", loc.NombreLocalidad);
                    //comando.Parameters.AddWithValue("@Id", loc.IdLocalidad);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdObraPlan", SqlDbType.Int);
                    comando.Parameters.Add("@IdObraSocial", SqlDbType.Int);
                    comando.Parameters.Add("@IdPlan", SqlDbType.Int);
                    comando.Parameters.Add("@Cobertura", SqlDbType.Decimal, (18));
                    comando.Parameters["@IdObraplan"].Value = osp.IdObraPlan;
                    comando.Parameters["@IdObraSocial"].Value = osp.ObraSocial.IdObraSocial;
                    comando.Parameters["@idPlan"].Value = osp.plan.IdPlan;
                    comando.Parameters["@Cobertura"].Value = osp.Cobertura;
                    comando.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_ObraSocial_Plan"))
                {
                    throw new Exception("La obra social ya tiene ese plan asignado");
                }
                throw;
            }
        }

        public static void Borrar(ObrasPlan osp)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("BajaObraPlan", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdObraPlan", SqlDbType.Int);
                    comando.Parameters["@IdObraPlan"].Value =osp.IdObraPlan;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


       

        private static List<ObrasPlan> GetLista(ObraSociales obraSocial)
        {
            throw new NotImplementedException();
        }
    }
}
