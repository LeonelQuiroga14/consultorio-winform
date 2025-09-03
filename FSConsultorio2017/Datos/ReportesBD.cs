using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
   public  class ReportesBD
    {

        public static DataTable GetResultadoTurnoIndividua(int IdTurno)
        {
            DataTable tabla = new DataTable();
            SqlConnection cn = Conexion.ConectarBD();
            cn.Open();
            try
            {
                SqlCommand comando = new SqlCommand("SP_ReporteTurnoPorIdTurno", cn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdTurno", IdTurno);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla);
                return tabla;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataTable GetResultadoTurnosPorMedico(int IdMedico)
        {
            DataTable tabla = new DataTable();
            SqlConnection cn = Conexion.ConectarBD();
            cn.Open();
            try
            {
                SqlCommand comando = new SqlCommand("SP_ReporteTurnosPorMedicoYFechaActual",cn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdMedico", IdMedico);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
             
        }

        public static DataTable GetResultadoTurnoPorMedicoYFecha(int IdMedico, DateTime fecha)
        {
            DataTable tabla = new DataTable();
            SqlConnection cn = Conexion.ConectarBD();
            cn.Open();
            try
            {
                SqlCommand comando = new SqlCommand("SP_ReporteTurnoPorMedicoYFecha", cn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdMedico", IdMedico);
                comando.Parameters.AddWithValue("@Fecha", fecha);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetResultadoConsulta(int idTurno)
        {
            DataTable tabla = new DataTable();
            SqlConnection cn = Conexion.ConectarBD();
            cn.Open();
            try
            {
                SqlCommand comando = new SqlCommand("Sp_ReporteConsulta", cn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Idturno", idTurno);
              
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public static DataTable GetResultadoConsultaPorId(int idConsulta)
        {
            DataTable tabla = new DataTable();
            SqlConnection cn = Conexion.ConectarBD();
            cn.Open();
            try
            {
                SqlCommand comando = new SqlCommand("Sp_ReporteConsultaPorIdConsulta", cn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdConsulta", idConsulta);

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetResultadoAlquiler(int idAlquiler)
        {
            DataTable tabla = new DataTable();
            SqlConnection cn = Conexion.ConectarBD();
            cn.Open();
            try
            {
                SqlCommand comando = new SqlCommand("SP_ReporteALquiler", cn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdAlquiler", idAlquiler);

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetResultadoCtaCte(int idCta)
        {
            DataTable tabla = new DataTable();
            SqlConnection cn = Conexion.ConectarBD();
            cn.Open();
            try
            {
                SqlCommand comando = new SqlCommand("SP_ListaCtaCtePorMedicoYFecha", cn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdMedico", idCta);

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
