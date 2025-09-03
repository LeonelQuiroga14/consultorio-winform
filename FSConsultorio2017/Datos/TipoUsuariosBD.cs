using BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class TipoUsuariosBD
    {



        public static TipoUsuarios GetObjeto(int v)
        {
            TipoUsuarios tp = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT * FROM TipoUsuarios WHERE IdTipoUsuario=@v";

                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@v", v);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        tp = new TipoUsuarios();
                        tp.IdTipoUsuario= reader.GetInt32(0);
                        tp.TipoUsuario= reader.GetString(1);

                    }

                }
                return tp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void CargarCombobox(ref ComboBox cboTipoUsuario)
        {
            List<TipoUsuarios> lista = GetLista();
            TipoUsuarios defaultTipoDocumento = new TipoUsuarios() { TipoUsuario = "<Seleccione Tipo de Usuario>" };
            lista.Insert(0, defaultTipoDocumento);
            cboTipoUsuario.DataSource = lista;
            cboTipoUsuario.DisplayMember = "TipoUsuario";
            cboTipoUsuario.ValueMember = "IdtipoUsuario";
            cboTipoUsuario.SelectedIndex = 0;
        }
        public static List<TipoUsuarios> GetLista()
        {
            try
            {
                List<TipoUsuarios> lista = new List<TipoUsuarios>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "Select * From TipoUsuarios";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        TipoUsuarios td = new TipoUsuarios();
                        td.IdTipoUsuario = reader.GetInt32(0);
                        td.TipoUsuario = reader.GetString(1);

                        lista.Add(td);
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void Agregar(TipoUsuarios tipouser)
        {
            try
            {
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_AgregarTipoUsuario", cnn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@TipoUsuario",tipouser.TipoUsuario);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex )
            {

                throw ex ;
            }
        }


        public static void Eliminar(TipoUsuarios tipouser)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_EliminarTipoUsuario", cnn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdTipoUsuario", tipouser.IdTipoUsuario);
                   // comando.Parameters.AddWithValue("@TipoUsuario", tipouser.TipoUsuario);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void Editar(TipoUsuarios tipouser)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_EditarTipoUsuario", cnn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdTipoUsuario", tipouser.IdTipoUsuario);
                    comando.Parameters.AddWithValue("@TipoUsuario", tipouser.TipoUsuario);
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
