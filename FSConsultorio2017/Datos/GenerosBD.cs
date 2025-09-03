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
    public class GenerosBD
    {
        public static List<Generos> GetLista()
        {
            try
            {
                List<Generos>lista= new List<Generos>();
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdGenero,Genero FROM Generos";
                    SqlCommand comando= new SqlCommand(strComando,cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Generos g= new Generos();
                        g.IdGenero = reader.GetInt32(0);
                        g.Genero = reader.GetString(1);

                        lista.Add(g);
                    }
                }
                return lista;
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }


        }

        public static void Agregar(Generos g)
        {

            try
            {
                using (SqlConnection cnn=Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando= new SqlCommand("AltaGenero",cnn);
                    comando.CommandType=CommandType.StoredProcedure;
                    comando.Parameters.Add("@Genero", SqlDbType.NVarChar, 50);
                    comando.Parameters["@Genero"].Value = g.Genero;
                    comando.ExecuteNonQuery();
                    string strComando = "SELECT @@IDENTITY";
                    comando= new SqlCommand(strComando,cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    g.IdGenero = id;
                    

                }
            }
            catch (Exception ex )
            {
                if (ex.Message.Contains("IX_GeneroNombre"))
                {
                    throw new Exception("Genero Repetido");
                }
                throw ex ;
            }

        }

        internal static Generos GetObjeto(int v)
        {

            Generos tp = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdGenero,Genero FROM Generos WHERE IdGenero=@v";

                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@v", v);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        tp = new Generos();
                        tp.IdGenero = reader.GetInt32(0);
                        tp.Genero= reader.GetString(1);

                    }

                }
                return tp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Borrar (Generos g)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("BajaGenero", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdGenero", SqlDbType.Int);
                    comando.Parameters["@IdGenero"].Value = g.IdGenero;
                    comando.ExecuteNonQuery();
                 
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void Editar(Generos g)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("EditarGenero", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdGenero", SqlDbType.Int);
                    comando.Parameters.Add("@Genero", SqlDbType.NVarChar, 50);
                    comando.Parameters["@IdGenero"].Value = g.IdGenero;
                    comando.Parameters["@Genero"].Value = g.Genero;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_GeneroNombre"))
                {
                    throw new Exception("Genero Repetido");
                }
                throw ex;
            }
        }

        public static void CargarCombobox(ref ComboBox cboGenero)
        {
            List<Generos> lista = GetLista();
            Generos defaultGenero = new Generos() { Genero = "<Seleccione un genero>" };
            lista.Insert(0, defaultGenero);
            cboGenero.DataSource = lista;
            cboGenero.DisplayMember = "Genero";
            cboGenero.ValueMember = "IdGenero";
            cboGenero.SelectedIndex = 0;
        }
    }
}
