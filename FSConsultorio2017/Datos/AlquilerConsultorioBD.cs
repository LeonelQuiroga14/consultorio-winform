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
    public class AlquilerConsultorioBD
    {

        public static void Agregar(AlquileresConsultorio alquiler)
        {
            //SqlTransaction tran = null;
            try
            {

                using (SqlConnection cnn = Conexion.ConectarBD())
                {


                    cnn.Open();
                    //   tran = cnn.BeginTransaction();
                    SqlCommand comando = new SqlCommand("Sp_AltaAlquilerConsultorio", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Idconsultorio", alquiler.Consultorio.IdConsultorio);
                    comando.Parameters.AddWithValue("@IdMedico", alquiler.Medico.IdMedico);
                    comando.Parameters.AddWithValue("@IdMedicoEspecialidad", alquiler.MedicoEspecialidad.IdMedicoEspecialidad);
                    comando.Parameters.AddWithValue("@IdJornada", alquiler.Jornada.IdJornada);
                    comando.Parameters.AddWithValue("@FechaIni", alquiler.FechaInicio.Date);
                    comando.Parameters.AddWithValue("@FechaFin", alquiler.FechaFin.Date);
                    comando.ExecuteNonQuery();
                }
                // tran.Commit();
                SqlConnection cn = Conexion.ConectarBD();
                cn.InfoMessage += (sender, e) => { MessageBox.Show(e.Message); };
            }

            catch (Exception ex)

            {
                // tran.Rollback();

                if (ex.Message.Contains("IX_AlquilerConsultorio_Consultorio_Jornada_Fechas"))
                {
                    throw new Exception($"El consultorio se encuentra alquilado hasta la fecha {alquiler.FechaFin.Date} y de Jornada '{alquiler.Jornada.Alquiler}'.");
                }

                //if (ex.Message.Contains("inhabilitado"))
                //{

                //    throw new Exception("El consultorio esta inhabilitado no se puede alquilar");


                //}

                throw ex;
            }
        }


        public static List<AlquileresConsultorio> GetListaAlquileres()
        {
            List<AlquileresConsultorio> lista = new List<AlquileresConsultorio>();
            try
            {
                using (SqlConnection cn = Conexion.ConectarBD())
                {
                    cn.Open();
                    SqlCommand comando = new SqlCommand("Sp_ListaAlquileres", cn);
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        AlquileresConsultorio AC = new AlquileresConsultorio();
                        AC.IdAlquilerConsultorio = reader.GetInt32(0);
                        AC.Consultorio = ConsultoriosBD.GetObjeto(reader.GetInt32(1));
                        AC.Medico = MedicosBD.GetObjeto(reader.GetInt32(2));
                        AC.MedicoEspecialidad = MedicoEspecialidadBD.GetObjeto(reader.GetInt32(3));
                        AC.Jornada = JornadasBD.GetObjeto(reader.GetInt32(4));
                        AC.FechaInicio = reader.GetDateTime(5);
                        AC.FechaFin = reader.GetDateTime(6);
                        lista.Add(AC);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int GetIDAlquiler(int idMedicoEspecialidad, DateTime date1, DateTime date2)
        {
            AlquileresConsultorio alq = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_TraerIdALquiler", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdMedicoEspecialidad", idMedicoEspecialidad);
                    comando.Parameters.AddWithValue("@FechaInicio", date1);
                    comando.Parameters.AddWithValue("@FechaFin", date2);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        alq = new AlquileresConsultorio();
                        alq.IdAlquilerConsultorio = reader.GetInt32(0);
                    }
                }
                return alq.IdAlquilerConsultorio;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static AlquileresConsultorio GetObjeto(int v)
        {

            AlquileresConsultorio Alq = new AlquileresConsultorio();
            try
            {
                using (SqlConnection CN = Conexion.ConectarBD())
                {
                    CN.Open();
                    SqlCommand Com = new SqlCommand("SP_BuscaAlquilerConsultorio1", CN);
                    Com.CommandType = CommandType.StoredProcedure;
                    Com.Parameters.AddWithValue("@IdAlquilerConsultorio", v);
                    SqlDataReader Lector = Com.ExecuteReader();
                    if (Lector.HasRows)
                    {
                        Lector.Read();

                        Alq.IdAlquilerConsultorio = Lector.GetInt32(0);
                        Alq.Consultorio = ConsultoriosBD.GetObjeto(Lector.GetInt32(1));
                        Alq.Medico = MedicosBD.GetObjeto(Lector.GetInt32(2));
                        Alq.MedicoEspecialidad = MedicoEspecialidadBD.GetObjeto(Lector.GetInt32(3));
                        Alq.Jornada = JornadasBD.GetObjeto(Lector.GetInt32(4));
                        Alq.FechaInicio = Lector.GetDateTime(5);
                        Alq.FechaFin = Lector.GetDateTime(6);
                    }
                    CN.Close();
                }
                return Alq;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static object GetAlquilerConsultorio(AlquileresConsultorio alquilercons)
        {
            List<AlquileresConsultorio> lista = new List<AlquileresConsultorio>();
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comand = new SqlCommand("Sp_BuscarAlquilerConsultorio", cnn);
                    comand.CommandType = CommandType.StoredProcedure;
                    comand.Parameters.AddWithValue("@IdConsultorio", alquilercons.Consultorio.IdConsultorio);
                    comand.Parameters.AddWithValue("@IdMedico", alquilercons.Medico.IdMedico);
                    comand.Parameters.AddWithValue("@IdJornada", alquilercons.Jornada.IdJornada);
                    comand.Parameters.AddWithValue("@fecha", alquilercons.FechaInicio);
                    SqlDataReader reader = comand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        AlquileresConsultorio ac = new AlquileresConsultorio();
                        ac.IdAlquilerConsultorio = reader.GetInt32(0);
                        ac.Consultorio = ConsultoriosBD.GetObjeto(reader.GetInt32(1));
                        ac.Medico = MedicosBD.GetObjeto(reader.GetInt32(2));
                        ac.Jornada = JornadasBD.GetObjeto(reader.GetInt32(3));
                        ac.FechaInicio = reader.GetDateTime(4);
                        ac.FechaFin = reader.GetDateTime(5);

                        lista.Add(ac);
                    }
                    if (lista.Count < 1)
                    {
                        lista = null;
                    }
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}