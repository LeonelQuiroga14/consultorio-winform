using BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class EspecialidadesBD
    {

        public static List<Especialidades> GetLista()
        {
            try
            {
                List<Especialidades> lista = new List<Especialidades>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    // string strComando = "Select IdEspecialidad,Especialidad From Especialidades";
                    string strComando = "Select * from ListaEspecialidades";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Especialidades p = new Especialidades();
                        p.IdEspecialidad = reader.GetInt32(0);
                        p.Especialidad = reader.GetString(1);

                        lista.Add(p);
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void CargarCombobox(ref ComboBox cboEspecialidades)
        {
            List<Especialidades> lista = EspecialidadesBD.GetLista();
            Especialidades defaultEspecialidad = new Especialidades() { Especialidad = "<Seleccione Especialidad>" };
            lista.Insert(0, defaultEspecialidad);
            cboEspecialidades.DataSource = lista;
            cboEspecialidades.DisplayMember = "Especialidad";
            cboEspecialidades.ValueMember = "IdEspecialidad";
            cboEspecialidades.SelectedIndex = 0;
        }

        public static Especialidades GetObjeto(int p)
        {
            Especialidades Especialidades = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdEspecialidad,Especialidad FROM Especialidades WHERE IdEspecialidad=@p";

                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@p", p);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        Especialidades = new Especialidades();
                        Especialidades.IdEspecialidad = reader.GetInt32(0);
                        Especialidades.Especialidad = reader.GetString(1);
                    }

                }
                return Especialidades;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Agregar(Especialidades especialidad)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();

                    SqlCommand comando = new SqlCommand("AltaEspecialidad", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Especialidad", SqlDbType.NVarChar, 100);
                    comando.Parameters["@Especialidad"].Value = especialidad.Especialidad;
                    comando.ExecuteNonQuery();
                    string strComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(strComando, cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    especialidad.IdEspecialidad = id;

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_NombreEspecialidad"))
                {
                    throw new Exception("Especialidad Repetida");
                }
                throw;
            }
        }

        public static void Editar(Especialidades p)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("EditarEspecialidad", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdEspecialidad", SqlDbType.Int);
                    comando.Parameters.Add("@Especialidad", SqlDbType.NVarChar, 100);
                    comando.Parameters["@IdEspecialidad"].Value = p.IdEspecialidad;
                    comando.Parameters["@Especialidad"].Value = p.Especialidad;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_NombreEspecialidad"))
                {
                    throw new Exception("Especialidad Repetida");
                }

                throw;
            }

        }

        public static void Borrar(Especialidades p)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("BajaEspecialidad", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdEspecialidad", SqlDbType.Int);
                    comando.Parameters["@IdEspecialidad"].Value = p.IdEspecialidad;
                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("FK_Medicos_Especialidadess"))
                {
                    throw new Exception($"{p.Especialidad} tiene un medico relacionado \n No se puede eliminar");
                }
                throw;
            }

        }

    }
}
