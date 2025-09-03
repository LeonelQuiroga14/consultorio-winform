using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace Datos
{
    public class AdministrativosBD
    {
        //******************
        //public static List<Administrativos> GetLista()
        //{
        //    try
        //    {
        //        List<Administrativos> lista = new List<Administrativos>();
        //        using (SqlConnection cn = Conexion.ConectarBD())
        //        {
        //            cn.Open();
        //            string csql ="Select IdAdministrativo,Apellido,Nombre,IdTipoDoc,NroDoc,IdGenero,"+
        //                "IdNacionalidad,FechaNac,TelefonoMovil,TelefonoFijo,Salario,FechaIngreso,"+
        //                "IdObraSocial,IdPlan,NroAfiliado,[Estado]FROM Administrativos";
        //            SqlCommand comand = new SqlCommand(csql, cn);
                    
        //            SqlDataReader reader = comand.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Administrativos adm = new Administrativos();
        //                adm.IdAdministrativo = reader.GetInt32(0);
        //                adm.Apellido = reader.GetString(1);
        //                adm.Nombre = reader.GetString(2);
        //                adm.TipoDoc = TiposDocBD.GetObjeto(reader.GetInt32(3));
        //                adm.NumeroDoc = reader.GetInt32(4);
        //                adm.Genero = GenerosBD.GetObjeto(reader.GetInt32(5));
        //                adm.Nacionalidad = NacionalidadesBD.GetObjeto(reader.GetInt32(6));
        //                adm.FechaNac = reader.GetDateTime(7);
        //                adm.TelefonoMovil = reader[8]==DBNull.Value? String.Empty : reader.GetString(8);
        //                adm.TelefonoFijo = reader.GetString(9);
        //                adm.Salario = reader.GetDecimal(10);
        //                adm.FechaIngreso = reader.GetDateTime(11);
        //                adm.ObraSocial = ObrasSocialesBD.GetObjeto(reader.GetInt32(12));
        //                adm.Plan = PlanesBD.GetObjeto(reader.GetInt32(13));
        //                adm.NroAfiliado = reader.GetString(14);
        //                adm.Estado = reader.GetBoolean(15);

        //                lista.Add(adm);


        //            }
        //        }
        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public static List<Administrativos> GetLista()
        {
            try
            {
                List<Administrativos>lista= new List<Administrativos>();
                using (SqlConnection cnn=Conexion.ConectarBD())
                {
                    cnn.Open();

                    // string Csql = " (SELECT IdAdministrativo,Apellido,Nombre,IdTipoDoc,NroDoc ,IdGenero,IdNacionalidad,FechaNac,TelefonoMovil,TelefonoFijo,Salario,FechaIngreso,IdObraSocial,IdPlan,NroAfiliado,Estado FROM Administrativos)";
                    string Csql = "SELECT * from ListaAdministrativos";
                    SqlCommand comando=new SqlCommand(Csql,cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Administrativos adm= new Administrativos();
                        adm.IdAdministrativo = reader.GetInt32(0);
                        adm.Apellido = reader.GetString(1);
                        adm.Nombre = reader.GetString(2);
                        adm.TipoDoc = TiposDocBD.GetObjeto(reader.GetInt32(3));
                        adm.NumeroDoc = reader.GetInt32(4);
                        adm.Genero = GenerosBD.GetObjeto(reader.GetInt32(5));
                        adm.Nacionalidad = NacionalidadesBD.GetObjeto(reader.GetInt32(6));
                        adm.FechaNac = reader.GetDateTime(7);
                        adm.TelefonoMovil =reader[8]==DBNull.Value?String.Empty : reader.GetString(8);
                        adm.TelefonoFijo =reader[9]==DBNull.Value?String.Empty : reader.GetString(9);
                        adm.Salario = reader.GetDecimal(10);
                        adm.FechaIngreso = reader.GetDateTime(11);
                        adm.ObraSocial = ObrasSocialesBD.GetObjeto(reader.GetInt32(12));
                        adm.Plan = PlanesBD.GetObjeto(reader.GetInt32(13));
                        adm.NroAfiliado = reader.GetString(14);
                        adm.Estado = reader.GetBoolean(15);
                        lista.Add(adm);

                    }
                    return lista;
                }
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        } 
        public static void Agregar(Administrativos adm)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("AltaAdministrativo", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Apellido", adm.Apellido);
                    comando.Parameters.AddWithValue("@Nombre", adm.Nombre);
                    comando.Parameters.AddWithValue("@IdTipoDoc", adm.TipoDoc.IdTipoDoc);
                    comando.Parameters.AddWithValue("@NroDoc", adm.NumeroDoc);
                    comando.Parameters.AddWithValue("@IdGenero", adm.Genero.IdGenero);
                    comando.Parameters.AddWithValue("@IdNacionalidad", adm.Nacionalidad.IdNacionalidad);
                    comando.Parameters.AddWithValue("@FechaNac", adm.FechaNac);
                    comando.Parameters.AddWithValue("@TelefonoMovil", adm.TelefonoMovil);
                    comando.Parameters.AddWithValue("@TelefonoFijo", adm.TelefonoFijo);
                    comando.Parameters.AddWithValue("@Salario", adm.Salario);
                    comando.Parameters.AddWithValue("@FechaIngreso", adm.FechaIngreso);
                    comando.Parameters.AddWithValue("@IdObraSocial", adm.ObraSocial.IdObraSocial);
                    comando.Parameters.AddWithValue("@IdPlan", adm.Plan.IdPlan);
                    comando.Parameters.AddWithValue("@NroAfiliado", adm.NroAfiliado);
                    comando.Parameters.AddWithValue("@Estado", adm.Estado);
                    comando.ExecuteNonQuery();
                    String strcomando = "SELECT @@IDENTITY";
                    comando= new SqlCommand(strcomando,cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    adm.IdAdministrativo = id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CargarCombobox(ref ComboBox cboAdministrativo)
        {
            List<Administrativos> lista = GetLista();
            Administrativos defaultPersona = new Administrativos() { Apellido = "<Seleccione el administrativo> " };//, Nombre = "el administrativo>" };
            lista.Insert(0, defaultPersona);
            lista = lista.OrderBy(c => c.Apellido).ToList();//.ThenBy(c => c.Nombre).ToList();
            cboAdministrativo.DataSource = lista;
            cboAdministrativo.DisplayMember = "Apellido";
            cboAdministrativo.ValueMember = "IdAdministrativo";
            cboAdministrativo.SelectedIndex = 0;
        }

        internal static Administrativos GetObjeto(int v)
        {
            Administrativos m = null;
            try
            {

                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando =
                        "Select [IdAdministrativo],[Apellido],[Nombre] ,[IdTipoDoc],[NroDoc],[IdGenero],[IdNacionalidad],[FechaNac],[TelefonoMovil],[TelefonoFijo],[Salario],[FechaIngreso],[IdObraSocial],[IdPlan],[NroAfiliado],[Estado] FROM Administrativos WHERE IdAdministrativo=@m";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    comando.Parameters.AddWithValue("@m", v);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        m = new Administrativos();
                        m.IdAdministrativo = reader.GetInt32(0);
                        m.Apellido = reader.GetString(1);
                        m.Nombre = reader.GetString(2);
                        m.TipoDoc = TiposDocBD.GetObjeto(reader.GetInt32(3));
                        m.NumeroDoc = reader.GetInt32(4);
                        m.Genero = GenerosBD.GetObjeto(reader.GetInt32(5));
                        m.Nacionalidad = NacionalidadesBD.GetObjeto(reader.GetInt32(6));
                        m.FechaNac = reader.GetDateTime(7);
                        m.TelefonoMovil = reader[8] == DBNull.Value ? string.Empty : reader.GetString(8);
                        m.TelefonoFijo = reader[9] == DBNull.Value ? string.Empty : reader.GetString(9);
                        m.Salario = reader.GetDecimal(10);
                        m.FechaIngreso = reader.GetDateTime(11);
                        m.ObraSocial = ObrasSocialesBD.GetObjeto(reader.GetInt32(12));
                        m.Plan = PlanesBD.GetObjeto(reader.GetInt32(13));
                        m.NroAfiliado = reader.GetString(14);
                        m.Estado = reader.GetBoolean(15);
                    }



                }
                return m;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
