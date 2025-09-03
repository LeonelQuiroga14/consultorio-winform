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
    public class ReservasTurnosBD
    {
        public static void Agregar(ReservasTurno rturno, Jornadas jornada)
        {
           // SqlTransaction tran = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                   // tran = cnn.BeginTransaction();
                    SqlCommand comando = new SqlCommand("Sp_GeneraTurnoPorDia", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Fecha", rturno.Fecha);
                    comando.Parameters.AddWithValue("@IdMedico", rturno.Medico.IdMedico);
                    comando.Parameters.AddWithValue("@IdMedicoEspecialidad", rturno.MedicoEspecialidad.IdMedicoEspecialidad);
                    comando.Parameters.AddWithValue("@Hora", Convert.ToDateTime(jornada.HoraInicial));
                    comando.Parameters.AddWithValue("@IdConsultorio", rturno.Consultorio.IdConsultorio);
                    comando.Parameters.AddWithValue("@Estado", rturno.Reserva);
                    comando.Parameters.AddWithValue("@Presente", rturno.Presente);
                    comando.Parameters.AddWithValue("@IdJornada", jornada.IdJornada);
                    comando.Parameters.AddWithValue("@IdAlquilerConsultorio", rturno.Alquiler.IdAlquilerConsultorio);

                    
                    comando.ExecuteNonQuery();



                }
                //tran.Commit();
            }
            catch (Exception ex )
            {
               // tran.Rollback();
                throw ex ;
            }
        }

        public static List<ReservasTurno> ListaTodosTurnoPorMedico(ReservasTurno turno)
        {
            List<ReservasTurno> lista = new List<ReservasTurno>();
            try
            {
                using (SqlConnection cn = Conexion.ConectarBD())
                {
                    cn.Open();
                    SqlCommand comando = new SqlCommand("SP_ListaTurnosPorMedico", cn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdMedico", turno.Medico.IdMedico);
                    comando.Parameters.AddWithValue("@IdMedicoEspecialidad", turno.MedicoEspecialidad.IdMedicoEspecialidad);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ReservasTurno t = new ReservasTurno();
                        t.Alquiler = AlquilerConsultorioBD.GetObjeto(reader.GetInt32(0));

                        t.Medico = MedicosBD.GetObjeto(reader.GetInt32(1));
                        t.Consultorio = ConsultoriosBD.GetObjeto(reader.GetInt32(2));
                        t.Turno = reader.GetString(3);
                        t.IdTurno = reader.GetInt32(4);
                        t.Paciente = PacientesBD.GetObjeto(reader[5] == DBNull.Value ? 0 : reader.GetInt32(5));
                       // t.MedicoEspecialidad = MedicoEspecialidadBD.GetObjeto(reader[5] == DBNull.Value ? 0 : reader.GetInt32(5));
                        t.Fecha = reader.GetDateTime(6);
                        t.Hora = reader.GetString(7);
                        t.Reserva = reader.GetBoolean(8);
                        t.Cobro = reader.GetDecimal(9);
                        t.Presente = reader.GetBoolean(10);

                        lista.Add(t);

                    }
                }
                return lista;
            }
            catch (Exception ex )
            {

                throw ex ;
            }
        }

        internal static ReservasTurno GetTurno(int v)
        {
            
            try
            {ReservasTurno t = null;
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();

                    SqlCommand comando = new SqlCommand("Sp_BuscarTurno", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdTurno", v);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        t = new ReservasTurno();

                        t.IdTurno = reader.GetInt32(0);
                        t.Turno = reader.GetString(1);
                        t.Fecha = reader.GetDateTime(2);
                        t.Hora = reader.GetString(3);
                        t.Medico = MedicosBD.GetObjeto(reader.GetInt32(4));
                        t.MedicoEspecialidad = MedicoEspecialidadBD.GetObjeto(reader[5] == DBNull.Value ? 0 : reader.GetInt32(5));
                        t.Paciente = PacientesBD.GetObjeto(reader[6] == DBNull.Value ? 0 : reader.GetInt32(6));
                       // t.Alquiler = AlquilerConsultorioBD.GetObjeto(reader.GetInt32(7));
                        t.Consultorio = ConsultoriosBD.GetObjeto(reader.GetInt32(7));
                        t.Reserva = reader.GetBoolean(8);
                        t.Cobro = reader.GetDecimal(9);
                        t.Presente = reader.GetBoolean(10);
                    }
                }
                return t;
            }
            catch (Exception ex )
            {

                throw ex ;
            }
        }

        public static void EditarPresenteYCobro(ReservasTurno turno)
        {
            try
            {
                using (SqlConnection CN = Conexion.ConectarBD())
                {
                    CN.Open();
                    SqlCommand Com = new SqlCommand("SP_EditaTurnoPresenteYCobro", CN);
                    Com.CommandType = CommandType.StoredProcedure;
                    Com.Parameters.AddWithValue("@Idturno", turno.IdTurno);
                    Com.Parameters.AddWithValue("@Presente", turno.Presente);
                    Com.Parameters.AddWithValue("@Cobro", turno.Cobro);
                    Com.ExecuteNonQuery();
                    //int id = (int)(decimal)Com.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<ReservasTurno> ListaReservasTurnoPorFechaYMedico(ReservasTurno turno)
        {
            List<ReservasTurno> lista = new List<ReservasTurno>();
            try
            {
                using (SqlConnection cn = Conexion.ConectarBD())
                {
                    cn.Open();
                    SqlCommand comando = new SqlCommand("Sp_ListaTurnosPorMedicoYFecha", cn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdMedico", turno.Medico.IdMedico);
                    comando.Parameters.AddWithValue("@IdMedicoEspecialidad", turno.MedicoEspecialidad.IdMedicoEspecialidad);
                    comando.Parameters.AddWithValue("@Fecha", turno.Fecha.Date);

                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ReservasTurno t = new ReservasTurno();
                        t.Medico = MedicosBD.GetObjeto(reader.GetInt32(0));
                        t.Consultorio = ConsultoriosBD.GetObjeto(reader.GetInt32(1));
                        t.Turno = reader.GetString(2);
                        t.IdTurno = reader.GetInt32(3);
                        t.Paciente = PacientesBD.GetObjeto(reader[4] == DBNull.Value ? 0 : reader.GetInt32(4));
                        // t.MedicoEspecialidad = MedicoEspecialidadBD.GetObjeto(reader.GetInt32(5));
                        t.Alquiler = AlquilerConsultorioBD.GetObjeto(reader.GetInt32(5));

                      //  t.Fecha = reader.GetDateTime(6);
                        t.Hora = reader.GetString(6);
                        t.Reserva = reader.GetBoolean(7);
                        t.Cobro = reader.GetDecimal(8);
                        t.Presente = reader.GetBoolean(9);

                        lista.Add(t);

                    }
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ReservasTurno> ListaReservasTurnoPorFechaYMedico(MedicoEspecialidad medesp,DateTime fecha)
        {
            List<ReservasTurno> lista = new List<ReservasTurno>();
            try
            {
                using (SqlConnection cn = Conexion.ConectarBD())
                {
                    cn.Open();
                    SqlCommand comando = new SqlCommand("Sp_ListaTurnosPorMedicoYFecha", cn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdMedico",medesp.Medico.IdMedico);
                    comando.Parameters.AddWithValue("@IdMedicoEspecialidad", medesp.IdMedicoEspecialidad);
                    comando.Parameters.AddWithValue("@Fecha", fecha.Date);

                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ReservasTurno t = new ReservasTurno();
                        t.Medico = MedicosBD.GetObjeto(reader.GetInt32(0));
                        t.Consultorio = ConsultoriosBD.GetObjeto(reader.GetInt32(1));
                        t.Turno = reader.GetString(2);
                        t.IdTurno = reader.GetInt32(3);
                        t.Paciente = PacientesBD.GetObjeto(reader[4] == DBNull.Value ? 0 : reader.GetInt32(4));
                        // t.MedicoEspecialidad = MedicoEspecialidadBD.GetObjeto(reader.GetInt32(5));
                        t.Alquiler = AlquilerConsultorioBD.GetObjeto(reader.GetInt32(5));

                        //  t.Fecha = reader.GetDateTime(6);
                        t.Hora = reader.GetString(6);
                        t.Reserva = reader.GetBoolean(7);
                        t.Cobro = reader.GetDecimal(8);
                        t.Presente = reader.GetBoolean(9);

                        lista.Add(t);

                    }
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void AgregarPacienteAlTurno(ReservasTurno turno, Pacientes paciente)
        {
            try
            {
                using (SqlConnection CN = Conexion.ConectarBD())
                {
                    CN.Open();
                    SqlCommand Com = new SqlCommand("Sp_AgregarPacienteAlturno", CN);
                    Com.CommandType = CommandType.StoredProcedure;
                    Com.Parameters.AddWithValue("@Idturno", turno.IdTurno);
                    Com.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    Com.ExecuteNonQuery();
                    //int id = (int)(decimal)Com.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void QuitarPacientesDeTurnos(ReservasTurno turno)
        {
            try
            {
                using (SqlConnection CN = Conexion.ConectarBD())
                {
                    CN.Open();
                    SqlCommand Com = new SqlCommand("Sp_QuitarPacienteDelTurno", CN);
                    Com.CommandType = CommandType.StoredProcedure;
                    Com.Parameters.AddWithValue("@Idturno", turno.IdTurno);
                    Com.ExecuteNonQuery();
                    //int id = (int)(decimal)Com.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
