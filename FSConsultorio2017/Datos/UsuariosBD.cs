using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using System.Data.SqlClient;

namespace Datos
{
    public class UsuariosBD
    {
        public static List<Usuarios> GetLista()
        {
            try
            {
                List<Usuarios> lista = new List<Usuarios>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("Select* from Vw_ListaUsuarios", cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuarios usuario = new Usuarios();
                        usuario.IdUsuario = reader.GetInt32(0);
                        usuario.Medico = MedicosBD.GetObjeto(reader[1] == DBNull.Value ? 0 : reader.GetInt32(1));
                        usuario.Administrativo = AdministrativosBD.GetObjeto(reader[2] == DBNull.Value ? 0 : reader.GetInt32(2));       
                        usuario.Nombre = reader.GetString(3);
                        usuario.TipoUsuario = TipoUsuariosBD.GetObjeto(reader.GetInt32(4));
                        usuario.Contrasenia = reader.GetString(5);
                        usuario.Bloqueo = reader.GetBoolean(6);
                        lista.Add(usuario);
                    }
                }
                return lista;
            }
            catch (Exception ex )
            {

                throw ex ;
            }
        }

        public static Usuarios GetUsuario(string userp, string contrasenia)
        {
            try
            {
                Usuarios user=null;
                using(SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_LoginUsuario",cnn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", userp);
                    comando.Parameters.AddWithValue("@Contraseña", contrasenia);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        user = new Usuarios();
                        user.IdUsuario = reader.GetInt32(0);
                        user.Medico = MedicosBD.GetObjeto(reader[1] == DBNull.Value ? 0 : reader.GetInt32(1));
                        user.Administrativo = AdministrativosBD.GetObjeto(reader[2] == DBNull.Value ? 0 : reader.GetInt32(2));
                        user.Nombre = reader.GetString(3);
                        user.TipoUsuario = TipoUsuariosBD.GetObjeto(reader.GetInt32(4));
                        user.Contrasenia = reader.GetString(5);
                        user.Bloqueo = reader.GetBoolean(6);
                    }

                }
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Agregar(Usuarios usuario)
        {
            try
            {
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_AgregarUsuario", cnn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    if (usuario.Medico == null)
                    {
                        comando.Parameters.AddWithValue("@IdMedico", DBNull.Value);
                    }
                    else { comando.Parameters.AddWithValue("@IdMedico", usuario.Medico.IdMedico);
                        }
                    if (usuario.Administrativo == null)
                    {
                        comando.Parameters.AddWithValue("@IdAdministrativo", DBNull.Value);
                    }
                    else { comando.Parameters.AddWithValue("@IdAdministrativo", usuario.Administrativo.IdAdministrativo); }
                    comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@IdTipoUsuario", usuario.TipoUsuario.IdTipoUsuario);
                    comando.Parameters.AddWithValue("@Contraseña", usuario.Contrasenia);
                    comando.Parameters.AddWithValue("@Bloqueo", usuario.Bloqueo);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }
       // 
        public static void Editar(Usuarios usuario)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_EditarUsuario", cnn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    if (usuario.Medico == null)
                    {
                        comando.Parameters.AddWithValue("@IdMedico", DBNull.Value);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@IdMedico", usuario.Medico.IdMedico);
                    }
                    if (usuario.Administrativo == null)
                    {
                        comando.Parameters.AddWithValue("@IdAdministrativo", DBNull.Value);
                    }
                    else { comando.Parameters.AddWithValue("@IdAdministrativo", usuario.Administrativo.IdAdministrativo); }
                    comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@IdTipoUsuario", usuario.TipoUsuario.IdTipoUsuario);
                    comando.Parameters.AddWithValue("@Contraseña", usuario.Contrasenia);
                    comando.Parameters.AddWithValue("@Bloqueo", usuario.Bloqueo);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void BloquearUsuario(Usuarios usuario, bool bloqueo)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_BloquearUsuario", cnn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    comando.Parameters.AddWithValue("@Bloqueo", bloqueo);
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
