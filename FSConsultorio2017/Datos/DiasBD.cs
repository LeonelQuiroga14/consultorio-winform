using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DiasBD
    {

        public static List<Dias> GetLista()
        {
            try
            {
                List<Dias> lista = new List<Dias>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdDia,Dia FROM Dias";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Dias d = new Dias();
                        d.IdDia= reader.GetInt32(0);
                        d.Dia = reader.GetString(1);

                        lista.Add(d);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public static void Agregar(Dias d)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("AltaDia", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Dia", SqlDbType.NVarChar, 20);
                    comando.Parameters["@Dia"].Value = d.Dia;
                    comando.ExecuteNonQuery();
                    string strComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(strComando, cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    d.IdDia = id;


                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_DiaNombre"))
                {
                    throw new Exception("Dia Repetido");
                }
                else if(ex.Message.Contains("CK_Dias"))
                {
                    throw new Exception("El dia ingresado no existe \nSolo se admite (Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Domingo)");
                }
                
                throw ex;
            }

        }

        public static void Borrar(Dias d)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("BajaDia", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdDia", SqlDbType.Int);
                    comando.Parameters["@IdDia"].Value = d.IdDia;
                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void Editar(Dias d)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("EditarDia", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdDia", SqlDbType.Int);
                    comando.Parameters.Add("@Dia", SqlDbType.NVarChar, 20);
                    comando.Parameters["@IdDia"].Value = d.IdDia;
                    comando.Parameters["@Dia"].Value = d.Dia;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_DiaNombre"))
                {
                    throw new Exception("Dia Repetido");
                }
                throw ex;
            }
        }
    }
}
