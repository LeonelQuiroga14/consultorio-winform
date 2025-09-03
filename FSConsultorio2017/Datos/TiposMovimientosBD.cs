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
    public class TiposMovimientosBD
    {
        public static List<TipoMovimientos> GetLista()
        {
            try
            {
                List<TipoMovimientos> lista = new List<TipoMovimientos>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdTipoMovimiento,TipoMovimiento FROM TiposMovimientos";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        TipoMovimientos tm = new TipoMovimientos();
                        tm.IdTipoMovimiento = reader.GetInt32(0);
                        tm.TipoMovimiento = reader.GetString(1);

                        lista.Add(tm);
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public static void Agregar(TipoMovimientos tp)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("AltaTipoMov", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@TipoMov", SqlDbType.NVarChar, 50);
                    comando.Parameters["@TipoMov"].Value = tp.TipoMovimiento;
                    comando.ExecuteNonQuery();
                    string strComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(strComando, cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    tp.IdTipoMovimiento = id;


                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_NombreTipoMov"))
                {
                    throw new Exception("Tipo de movimiento repetido");
                }
                throw ex;
            }

        }

        public static void Borrar(TipoMovimientos tp)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("BajaTipoMov", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdTipoMov", SqlDbType.Int);
                    comando.Parameters["@IdTipoMov"].Value = tp.IdTipoMovimiento;
                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void Editar(TipoMovimientos tp)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("EditarTipoMov", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdTipoMov", SqlDbType.Int);
                    comando.Parameters.Add("@TipoMov", SqlDbType.NVarChar, 50);
                    comando.Parameters["@IdTipoMov"].Value = tp.IdTipoMovimiento;
                    comando.Parameters["@TipoMov"].Value = tp.TipoMovimiento;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_NombreTipoMov"))
                {
                    throw new Exception("Tipo de movimiento repetido");
                }
                throw ex;
            }
        }

    }
}
