using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using BL;
using System.Windows.Forms;

namespace Datos
{
   public  class TiposDocBD
    {
       public static List<TipoDocumento> GetLista()
       {
           try
           {
               List<TipoDocumento> lista = new List<TipoDocumento>();
               using (SqlConnection cnn= Conexion.ConectarBD())
               {
                   cnn.Open();
                   string strComando = "Select IdTipoDoc,TipoDoc From TiposDocumento";
                    SqlCommand comando= new SqlCommand(strComando,cnn);
                   SqlDataReader reader = comando.ExecuteReader();
                   while (reader.Read())
                   {
                       TipoDocumento td= new TipoDocumento();
                       td.IdTipoDoc = reader.GetInt32(0);
                       td.TipoDoc = reader.GetString(1);

                        lista.Add(td);
                   }
                   return lista;
               }
           }
           catch (Exception ex )
           {

               throw ex;
           }


       }

        public static void CargarCombobox(ref ComboBox cboTipoDoc)
        {
            List<TipoDocumento> lista = GetLista();
            TipoDocumento defaultTipoDocumento = new TipoDocumento() {TipoDoc = "<Seleccione Tipo de documento>"};
            lista.Insert(0,defaultTipoDocumento);
            cboTipoDoc.DataSource = lista;
            cboTipoDoc.DisplayMember = "TipoDoc";
            cboTipoDoc.ValueMember = "IdtipoDoc";
            cboTipoDoc.SelectedIndex = 0;
        }

        public static void Agregar(TipoDocumento td)
       {
           try
           {
               using (SqlConnection cnn= Conexion.ConectarBD())
               {
                   cnn.Open();
                    SqlCommand comando = new SqlCommand("AltaTipoDoc",cnn);
                    comando.CommandType=CommandType.StoredProcedure;
                   comando.Parameters.Add("@TipoDoc", SqlDbType.NVarChar, 50);
                   comando.Parameters["@TipoDoc"].Value = td.TipoDoc;
                   comando.ExecuteNonQuery();
                   string strComando = "SELECT @@IDENTITY";
                    comando= new SqlCommand(strComando,cnn);
                   int id = (int) (decimal) comando.ExecuteScalar();
                   td.IdTipoDoc = id;


               }
           }
           catch (Exception ex )

            {

                if (ex.Message.Contains("IX_TipoDocumento"))
                {
                    throw new Exception("Registro Repetido");
                }
                throw ex;

            }
       }

        public  static TipoDocumento GetObjeto(int v)
        {
            TipoDocumento tp = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando = "SELECT IdTipoDoc,TipoDoc FROM TiposDocumento WHERE IdTipoDoc=@v";

                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@v", v);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        tp = new TipoDocumento();
                        tp.IdTipoDoc= reader.GetInt32(0);
                        tp.TipoDoc = reader.GetString(1);
                        
                    }

                }
                return tp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Borrar(TipoDocumento tp)
        {
            try
            {
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando= new SqlCommand("BajaTipoDoc",cnn);
                    comando.CommandType=CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdTipoDoc", SqlDbType.Int);
                    comando.Parameters["@IdTipoDoc"].Value = tp.IdTipoDoc;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }

        public static void Editar(TipoDocumento tp)
        {
            try
            {
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando= new SqlCommand("EditarTipoDoc",cnn);
                    comando.CommandType=CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdTipoDoc", SqlDbType.Int);
                    comando.Parameters.Add("@TipoDoc", SqlDbType.NVarChar, 50);
                    comando.Parameters["@IdTipoDoc"].Value = tp.IdTipoDoc;
                    comando.Parameters["@TipoDoc"].Value = tp.TipoDoc;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex )
            {
                if (ex.Message.Contains("IX_TipoDocumento"))
                {
                     throw  new Exception("Registro repetido");
                }
                throw ex ;
            }
        }
    }
}
