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
    public class CtasCtesMedicosBD
    {
        public static void Agregar(ReservasTurno turno)
        {
            try
            {
                using (SqlConnection CN = Conexion.ConectarBD())
                {
                    CN.Open();
                    CuentasCorrientesMedicos ctaCte = new CuentasCorrientesMedicos();
                    SqlCommand Com = new SqlCommand("SP_AgregaPagoEnCta", CN);
                    Com.CommandType = CommandType.StoredProcedure;
                    Com.Parameters.AddWithValue("@IdMedico", turno.Medico.IdMedico);
                    Com.Parameters.AddWithValue("@IdAlquilerConsultorio", turno.Alquiler.IdAlquilerConsultorio);
                    Com.Parameters.AddWithValue("@Fecha", turno.Fecha);
                    Com.Parameters.AddWithValue("@Debe", turno.Cobro);
                    Com.Parameters.AddWithValue("@Haber", 0);
                    Com.Parameters.AddWithValue("@IdTurno", turno.IdTurno);
                    Com.Parameters.AddWithValue("@Liquidado", false);
                    //Com.ExecuteNonQuery();
                    int id = (int)(decimal)Com.ExecuteScalar();
                    ctaCte.IdCtaCte = id;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public  static void Editar(CuentasCorrientesMedicos cuenta)
        {
            try
            {
                using (SqlConnection CN = Conexion.ConectarBD())
                {
                    CN.Open();
                    CuentasCorrientesMedicos ctaCte = new CuentasCorrientesMedicos();
                    SqlCommand Com = new SqlCommand("SP_AltaLiquidacion", CN);
                    Com.CommandType = CommandType.StoredProcedure;
                    Com.Parameters.AddWithValue("@IdMedico", cuenta.Medico.IdMedico);
                    Com.Parameters.AddWithValue("@Fecha", cuenta.turno.Fecha);
                    Com.Parameters.AddWithValue("@Consul", cuenta.alquilerConsultorio.Consultorio.Costo);
                    Com.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<CuentasCorrientesMedicos> GetListaFiltrada(ReservasTurno T)
        {
            List<CuentasCorrientesMedicos> Lista = new List<CuentasCorrientesMedicos>();
            try
            {
                using (SqlConnection CN = Conexion.ConectarBD())
                {
                    CN.Open();
                    SqlCommand Com = new SqlCommand("SP_ListaCtaCtePorMedicoYFecha", CN); //Hacer SP y revisar 
                    Com.CommandType = CommandType.StoredProcedure;
                    Com.Parameters.AddWithValue("@IdMedico", T.Medico.IdMedico);
                   // Com.Parameters.AddWithValue("@Fecha", T.Fecha);
                    SqlDataReader Lector = Com.ExecuteReader();
                    while (Lector.Read())
                    {
                        CuentasCorrientesMedicos ctacte = new CuentasCorrientesMedicos();
                        ctacte.IdCtaCte = Lector.GetInt32(0);
                        ctacte.Medico = MedicosBD.GetObjeto(Lector.GetInt32(1));
                        ctacte.alquilerConsultorio = AlquilerConsultorioBD.GetObjeto(Lector.GetInt32(2));
                        ctacte.turno = ReservasTurnosBD.GetTurno(Lector.GetInt32(3));
                        ctacte.Fecha = Lector.GetDateTime(4);
                        ctacte.Liquidado = Lector.GetBoolean(5);
                        ctacte.FechaLiquidacion = Lector[6] == DBNull.Value ? DateTime.MaxValue : Lector.GetDateTime(6);
                        ctacte.Debe = Lector.GetDecimal(7);
                        ctacte.Haber = Lector.GetDecimal(8);
                        ctacte.total = Lector.GetDecimal(9);
                        
                       
                        Lista.Add(ctacte);
                    }
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
