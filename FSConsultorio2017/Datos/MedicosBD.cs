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
    public class MedicosBD
    {


        public static void Agregar(Medicos med)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("AltaMedico", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Apellido", med.Apellido);
                    comando.Parameters.AddWithValue("@Nombre", med.Nombre);
                    comando.Parameters.AddWithValue("@IdTipoDoc", med.TipoDoc.IdTipoDoc);
                    comando.Parameters.AddWithValue("@NroDoc", med.NumeroDoc);
                    comando.Parameters.AddWithValue("@IdGenero", med.Genero.IdGenero);
                    comando.Parameters.AddWithValue("@IdNacionalidad", med.Nacionalidad.IdNacionalidad);
                    comando.Parameters.AddWithValue("@IdProvincia", med.Provincia.IdProvincia);
                    comando.Parameters.AddWithValue("@IdLocalidad", med.Localidad.IdLocalidad);
                    comando.Parameters.AddWithValue("@GrupoSanguineo", med.GrupoSanguineo);
                    comando.Parameters.AddWithValue("@Direccion", med.Direccion);
                    comando.Parameters.AddWithValue("@FechaNac", med.FechaNac);
                    if (med.TelefonoMovil == String.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", DBNull.Value);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", med.TelefonoMovil);
                    }
                    if (med.TelefonoFijo == String.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", DBNull.Value);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", med.TelefonoFijo);
                    }
                    comando.Parameters.AddWithValue("@IdObraSocial", med.ObraSocial.IdObraSocial);
                    comando.Parameters.AddWithValue("@IdPlan", med.Plan.IdPlan);
                    comando.Parameters.AddWithValue("@NroAfiliado", med.NroAfiliado);
                    comando.Parameters.AddWithValue("@Estado", med.Estado);
                    comando.ExecuteNonQuery();
                    String strcomando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(strcomando, cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    med.IdMedico = id;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_Medicos_AyN_NroDoc"))
                {
                    throw  new Exception("El medico ya esta registrado en el sistema.");
                }
                if (ex.Message.Contains("CK_Medicos_GrupoSanguineo"))
                {
                    throw new Exception("Ingreso un grupo sanguineo que no pertenece a los siguientes (A+,A-,B+,B-, O+,O-)");
                }
                throw ex;
            }
        }

        public static void CargarCombobox(ref ComboBox cboMedico)
        {

            List<Medicos> lista = MedicosBD.GetLista();
            Medicos defaultPersona = new Medicos() { Apellido = "<Seleccione ", Nombre = "el medico>" };
            lista.Insert(0, defaultPersona);
            lista = lista.OrderBy(c => c.Apellido).ThenBy(c => c.Nombre).ToList();
            cboMedico.DataSource = lista;
            cboMedico.DisplayMember = "ApellidoNombre";
            cboMedico.ValueMember = "IdMedico";
            cboMedico.SelectedIndex = 0;
        }

        public static Medicos GetObjeto(int v)
        {
            Medicos m = null;
            try
            {
               
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strComando =
                        "Select IdMedico,Apellido,Nombre,IdTipoDoc,NroDoc,idGenero,IdNacionalidad,IdProvincia,IdLocalidad,GrupoSanguineo,Direccion,FechaNac,TelefonoMovil,TelefonoFijo,IdObraSocial,IdPlan,NroAfiliado,Estado  FROM Medicos WHERE IdMedico=@m";
                    SqlCommand comando= new SqlCommand(strComando,cnn);
                    comando.Parameters.AddWithValue("@m", v);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        m= new Medicos();
                        m.IdMedico = reader.GetInt32(0);
                        m.Apellido = reader.GetString(1);
                        m.Nombre = reader.GetString(2);
                        m.TipoDoc = TiposDocBD.GetObjeto(reader.GetInt32(3));
                        m.NumeroDoc = reader.GetInt32(4);
                        m.Genero = GenerosBD.GetObjeto(reader.GetInt32(5));
                        m.Nacionalidad = NacionalidadesBD.GetObjeto(reader.GetInt32(6));
                        m.Provincia = ProvinciaBD.GetObjeto(reader.GetInt32(7));
                        m.Localidad = LocalidadesBD.GetObjeto(reader.GetInt32(8));
                        m.GrupoSanguineo = reader.GetString(9);
                        m.Direccion = reader[10] == DBNull.Value ? string.Empty : reader.GetString(10);
                        m.FechaNac = reader.GetDateTime(11);
                        m.TelefonoMovil = reader[12] == DBNull.Value ? string.Empty : reader.GetString(12);
                        m.TelefonoFijo = reader[13] == DBNull.Value ? string.Empty : reader.GetString(13);
                        m.ObraSocial = ObrasSocialesBD.GetObjeto(reader.GetInt32(14));
                        m.Plan = PlanesBD.GetObjeto(reader.GetInt32(15));
                        m.NroAfiliado = reader.GetString(16);
                        m.Estado = reader.GetBoolean(17);
                    }


                   
                }
                return m;
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }

        public static void Editar(Medicos med)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("EditarMedico", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdMedico", med.IdMedico);
                    comando.Parameters.AddWithValue("@Apellido", med.Apellido);
                    comando.Parameters.AddWithValue("@Nombre", med.Nombre);
                    comando.Parameters.AddWithValue("@IdTipoDoc", med.TipoDoc.IdTipoDoc);
                    comando.Parameters.AddWithValue("@NroDoc", med.NumeroDoc);
                    comando.Parameters.AddWithValue("@IdGenero", med.Genero.IdGenero);
                    comando.Parameters.AddWithValue("@IdNacionalidad", med.Nacionalidad.IdNacionalidad);
                    comando.Parameters.AddWithValue("@IdProvincia", med.Provincia.IdProvincia);
                    comando.Parameters.AddWithValue("@IdLocalidad", med.Localidad.IdLocalidad);
                    comando.Parameters.AddWithValue("@GrupoSanguineo", med.GrupoSanguineo);
                    comando.Parameters.AddWithValue("@Direccion", med.Direccion);
                    comando.Parameters.AddWithValue("@FechaNac", med.FechaNac);
                    if (med.TelefonoMovil == String.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", DBNull.Value);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", med.TelefonoMovil);
                    }
                    if (med.TelefonoFijo == String.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", DBNull.Value);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", med.TelefonoFijo);
                    }
                    comando.Parameters.AddWithValue("@IdObraSocial", med.ObraSocial.IdObraSocial);
                    comando.Parameters.AddWithValue("@IdPlan", med.Plan.IdPlan);
                    comando.Parameters.AddWithValue("@NroAfiliado", med.NroAfiliado);
                    comando.Parameters.AddWithValue("@Estado", med.Estado);
                    comando.ExecuteNonQuery();
                    //String strcomando = "SELECT @@IDENTITY";
                    //comando = new SqlCommand(strcomando, cnn);
                    //int id = (int)(decimal)comando.ExecuteScalar();
                    //med.IdMedico = id;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_Medicos_AyN_NroDoc"))
                {
                    throw new Exception("El medico ya esta registrado en el sistema.");
                }
                if (ex.Message.Contains("CK_Medicos_GrupoSanguineo"))
                {
                    throw new Exception("Ingreso un grupo sanguineo que no pertenece a los siguientes (A+,A-,B+,B-, O+,O-)");
                }
                throw ex;
            }
        }

        public static List<Medicos> GetLista()
        {
            try

            {

                List<Medicos> lista = new List<Medicos>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();

                    string strComando = "Select * from V_listaMedicos";
                    SqlCommand comando = new SqlCommand(strComando, cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Medicos m = new Medicos();
                        m.IdMedico = reader.GetInt32(0);
                        m.Apellido = reader.GetString(1);
                        m.Nombre = reader.GetString(2);
                        m.TipoDoc = TiposDocBD.GetObjeto(reader.GetInt32(3));
                        m.NumeroDoc = reader.GetInt32(4);
                        m.Genero = GenerosBD.GetObjeto(reader.GetInt32(5));
                        m.Nacionalidad = NacionalidadesBD.GetObjeto(reader.GetInt32(6));
                        m.Provincia = ProvinciaBD.GetObjeto(reader.GetInt32(7));
                        m.Localidad = LocalidadesBD.GetObjeto(reader.GetInt32(8));
                        m.GrupoSanguineo = reader.GetString(9);
                        m.Direccion = reader[10]== DBNull.Value ?string.Empty: reader.GetString(10);
                        m.FechaNac = reader.GetDateTime(11);
                        m.TelefonoMovil = reader[12] == DBNull.Value ? string.Empty : reader.GetString(12);
                        m.TelefonoFijo= reader[13] == DBNull.Value ? string.Empty : reader.GetString(13);
                        m.ObraSocial = ObrasSocialesBD.GetObjeto(reader.GetInt32(14));
                        m.Plan = PlanesBD.GetObjeto(reader.GetInt32(15));
                        m.NroAfiliado = reader.GetString(16);
                        m.Estado = reader.GetBoolean(17);

                        lista.Add(m);

                    }

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
   
    }

       //public static Medicos GetMedico(int idMedico)
       // {
       //     throw new NotImplementedException();
       // }
    }
}
