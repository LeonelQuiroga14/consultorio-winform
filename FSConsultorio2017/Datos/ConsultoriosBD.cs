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
   public  class ConsultoriosBD
    {
        public static List<Consultorios> GetLista()
        {
            try
            {
                List<Consultorios> lista = new List<Consultorios>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "Select IdConsultorio,Consultorio,CostoAlquiler,Estado From Consultorios";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                      Consultorios con= new Consultorios();
                        con.IdConsultorio = reader.GetInt32(0);
                        con.Consultorio = reader.GetString(1);
                        con.Costo = reader.GetDecimal(2);
                        con.Estado = reader.GetBoolean(3);


                        lista.Add(con);
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static void CargarCombobox(ref ComboBox cboConsultorio)
        {
            List<Consultorios> lista = ConsultoriosBD.GetLista();
            Consultorios defaultConsultorio = new Consultorios() { Consultorio= "<Seleccione consultorio>" };
            lista.Insert(0, defaultConsultorio);
            cboConsultorio.DataSource = lista;
            cboConsultorio.DisplayMember = "Consultorio";
            cboConsultorio.ValueMember = "IdConsultorio";
            cboConsultorio.SelectedIndex = 0;
        }      
               
        public static Consultorios GetObjeto(int p)
        {
            Consultorios con = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdConsultorio,Consultorio,CostoAlquiler,Estado FROM Consultorios WHERE IdConsultorio=@p";

                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@p", p);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                       con = new Consultorios();
                      con.IdConsultorio = reader.GetInt32(0);
                        con.Consultorio = reader.GetString(1);
                        con.Costo = reader.GetDecimal(2);
                        con.Estado = reader.GetBoolean(3);
                    }

                }
                return con ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Agregar(Consultorios con)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();

                    SqlCommand comando = new SqlCommand("AltaConsultorio", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Consultorio", SqlDbType.NVarChar, 10);
                    comando.Parameters.Add("@Costo",SqlDbType.Decimal);
                    comando.Parameters.Add("@Estado",SqlDbType.Bit);
                    comando.Parameters["@Consultorio"].Value = con.Consultorio;
                    comando.Parameters["@Costo"].Value = con.Costo;
                    comando.Parameters["@Estado"].Value = con.Estado;
                    comando.ExecuteNonQuery();
                    string strComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(strComando, cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    con.IdConsultorio = id;

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_ConsultoriosNombre"))
                {
                    throw new Exception("Consultorio Repetido");
                }
                throw;
            }
        }

        public static void Editar(Consultorios con)
        {

            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("EditarConsultorio", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdConsultorio", SqlDbType.Int);
                    comando.Parameters.Add("@Consultorio", SqlDbType.NVarChar, 10);
                    comando.Parameters.Add("@Costo", SqlDbType.Decimal,18);
                    comando.Parameters.Add("@Estado", SqlDbType.Bit);
                    comando.Parameters["@IdConsultorio"].Value = con.IdConsultorio;
                    comando.Parameters["@Consultorio"].Value = con.Consultorio;
                    comando.Parameters["@Costo"].Value = con.Costo;
                    comando.Parameters["@Estado"].Value = con.Estado;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_ConsultoriosNombre"))
                {
                    throw new Exception("Consultorio Repetido");
                }

                throw;
            }

        }

        //public static void Borrar(Especialidades p)
        //{
        //    try
        //    {
        //        using (SqlConnection cnn = Conexion.ConectarBD())
        //        {
        //            cnn.Open();
        //            SqlCommand comando = new SqlCommand("BajaEspecialidad", cnn);
        //            comando.CommandType = CommandType.StoredProcedure;
        //            comando.Parameters.Add("@IdEspecialidad", SqlDbType.Int);
        //            comando.Parameters["@IdEspecialidad"].Value = p.IdEspecialidad;
        //            comando.ExecuteNonQuery();

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        if (ex.Message.Contains("FK_Medicos_Especialidadess"))
        //        {
        //            throw new Exception($"{p.Especialidad} tiene un medico relacionado \n No se puede eliminar");
        //        }
        //        throw;
        //    }

        }
    }


