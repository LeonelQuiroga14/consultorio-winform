using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class ConsultasBD
    {
        public static void Agregar(Consultas consulta)
        {
            throw new NotImplementedException();
        }

        public static void Agregar(Consultas consulta, ReservasTurno turno)
        {
          //  SqlTransaction tran;
            try
            {
                
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                  //  tran = cnn.BeginTransaction();
                    SqlCommand comando = new SqlCommand("SP_AgregarConsulta", cnn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdTurno",turno.IdTurno);
                    comando.Parameters.AddWithValue("@Sintomas", consulta.Sintomas);
                    comando.Parameters.AddWithValue("@Diagnostico", consulta.Diagnostico);
                    comando.Parameters.AddWithValue("@Medicacion",consulta.Medicacion);
                    comando.Parameters.AddWithValue("@Observaciones", consulta.Observaciones);
                    comando.ExecuteNonQuery();
                   // ReservasTurnosBD.EditarPresenteY(turno,tran);
                   // tran.Commit();
                }
            }
            catch (Exception ex )
            {
               // tran.Rollback();
                throw;
            }
        }

        public static List<Consultas> GetListaHistorias(Pacientes p)
        {
            try
            {
                List<Consultas> lista = new List<Consultas>();
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_ListaHistoriaClinica",cnn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdPaciente", SqlDbType.Int);
                    comando.Parameters["@IdPaciente"].Value = p.IdPaciente;
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Consultas c = new Consultas();
                        c.IdConsulta = reader.GetInt32(0);
                        c.Turno = ReservasTurnosBD.GetTurno(reader.GetInt32(1));
                        c.Sintomas = reader.GetString(2);
                        c.Diagnostico = reader.GetString(3);
                        c.Medicacion = reader.GetString(4);
                        c.Observaciones = reader.GetString(5);

                        lista.Add(c);
                    }
                }
                return lista;
            }
            catch (Exception ex )
            {

                throw ex ;
            }
        }
    }
}
