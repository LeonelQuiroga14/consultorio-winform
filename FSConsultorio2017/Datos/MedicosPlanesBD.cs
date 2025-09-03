using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace Datos
{
    public class MedicosPlanesBD
    {
        public static List<MedicosPlanes> GetLista()
        {
            try
            {
                List<MedicosPlanes> lista = new List<MedicosPlanes>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strcomando = "SELECT IdMedicoPlan,IdMedicoEspecialidad,IdObraSocial,IdPlan FROM MedicosPlanes ";
                    SqlCommand comando = new SqlCommand(strcomando, cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        MedicosPlanes mp = new MedicosPlanes();
                        mp.IdMedicoPlan = reader.GetInt32(0);
                        mp.MedicoEspecialidad = MedicoEspecialidadBD.GetObjeto(reader.GetInt32(1));
                        mp.ObraSocial = ObrasSocialesBD.GetObjeto(reader.GetInt32(2));
                        mp.Plan = PlanesBD.GetObjeto(reader.GetInt32(3));

                        lista.Add(mp);

                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        public static void Agregar(MedicosPlanes mp)
        {
            try
            {
                using (SqlConnection cnn =Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando= new SqlCommand("Sp_AgregarMedicoPlanes",cnn);
                    comando.CommandType=CommandType.StoredProcedure;                 
                    comando.Parameters.Add("@IdMedicoEspecialidad", SqlDbType.Int);
                    comando.Parameters.Add("@IdObraSocial", SqlDbType.Int);
                    comando.Parameters.Add("@IdPlan", SqlDbType.Int);
                    comando.Parameters["@IdMedicoEspecialidad"].Value = mp.MedicoEspecialidad.IdMedicoEspecialidad;
                    comando.Parameters["@IdObraSocial"].Value = mp.ObraSocial.IdObraSocial;
                    comando.Parameters["@IdPlan"].Value = mp.Plan.IdPlan;
                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                
                throw  ex ;
            }


        }

        public static void Borrar(MedicosPlanes mp)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("Sp_BorrarMedicoPlanes", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdMedicoPlan", SqlDbType.Int);
                    comando.Parameters["@IdMedicoPlan"].Value = mp.IdMedicoPlan;
                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public static MedicosPlanes GetObjeto(int m)
        {

            MedicosPlanes mp = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strcomando = "SELECT IdMedicoPlan,IdMedicoEspecialidad,IdObraSocial,IdPlan FROM MedicoPlanes WHERE IdMedicoPlan=@m";
                    SqlCommand comando = new SqlCommand(strcomando, cnn);
                    comando.Parameters.AddWithValue("@m", m);
                    SqlDataReader reader = comando.ExecuteReader();
                   if (reader.HasRows)
                    {
                        mp = new MedicosPlanes();
                        mp.IdMedicoPlan = reader.GetInt32(0);
                      //  mp.Especialidad = EspecialidadesBD.GetObjeto(reader.GetInt32(1));
                        mp.MedicoEspecialidad = MedicoEspecialidadBD.GetObjeto(reader.GetInt32(1));
                        mp.ObraSocial = ObrasSocialesBD.GetObjeto(reader.GetInt32(2));
                        mp.Plan = PlanesBD.GetObjeto(reader.GetInt32(3));

                        

                    }
                }
                return mp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void Editar(MedicosPlanes mp)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();

                   
                    SqlCommand comando = new SqlCommand("Sp_EditarMedicoPlanes", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdMedicoPlan", SqlDbType.Int);
                 //   comando.Parameters.Add("@IdEspecialidad", SqlDbType.Int);
                    comando.Parameters.Add("@IdMedicoEspecialidad", SqlDbType.Int);
                    comando.Parameters.Add("@IdObraSocial", SqlDbType.Int);
                    comando.Parameters.Add("@IdPlan", SqlDbType.Int);
                    
                    comando.Parameters["@IdMedicoPlan"].Value = mp.IdMedicoPlan;
                   // comando.Parameters["@IdEspecialidad"].Value=mp.Especialidad.IdEspecialidad;
                    comando.Parameters["@IdMedicoEspecialidad"].Value=mp.MedicoEspecialidad.IdMedicoEspecialidad;
                    comando.Parameters["@IdObraSocial"].Value = mp.ObraSocial.IdObraSocial;
                    comando.Parameters["@IdPlan"].Value = mp.Plan.IdPlan;
                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
