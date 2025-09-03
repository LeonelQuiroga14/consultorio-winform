using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using BL;

namespace BL
{
    public class PacientesBD
    {

        public static List<Pacientes> GetLista()
        {
            try
            {
                List<Pacientes> lista = new List<Pacientes>();
                string cn = @"Data Source=.;Initial Catalog=FinalConsultorio;Integrated Security= True; MultipleActiveResultSets=true";
                SqlConnection cnn = new SqlConnection(cn);
                cnn.Open();
                string Csql = "SELECT * FROM ListaPacientes";
                SqlCommand comando = new SqlCommand(Csql, cnn);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Pacientes pc = new Pacientes();
                    pc.IdPaciente = reader.GetInt32(0);
                    pc.Apellido = reader.GetString(1);
                    pc.Nombre = reader.GetString(2);
                    pc.TipoDoc = TiposDocBD.GetObjeto(reader.GetInt32(3));
                    pc.NumeroDoc = reader.GetInt32(4);
                    pc.Genero = GenerosBD.GetObjeto(reader.GetInt32(5));
                    pc.Nacionalidad = NacionalidadesBD.GetObjeto(reader.GetInt32(6));
                    pc.Provincia = ProvinciaBD.GetObjeto(reader.GetInt32(7));
                    pc.Localidad = LocalidadesBD.GetObjeto(reader.GetInt32(8));
                    pc.GrupoSanguineo = reader.GetString(9);
                    pc.Direccion = reader.GetString(10);
                    pc.FechaNac = reader.GetDateTime(11);
                    pc.TelefonoMovil = reader[12] == DBNull.Value ? String.Empty : reader.GetString(12);
                    pc.TelefonoFijo = reader[13] == DBNull.Value ? String.Empty : reader.GetString(13);
                    //   pc.Salario = reader.GetDecimal(10);
                    //   pc.FechaIngreso = reader.GetDateTime(11);
                    pc.ObraSocial = ObrasSocialesBD.GetObjeto(reader[14] == DBNull.Value ? 0 : reader.GetInt32(14));
                    pc.Plan = PlanesBD.GetObjeto(reader[15]== DBNull.Value ? 0: reader.GetInt32(15));
                    pc.NroAfiliado =  reader[16] == DBNull.Value ? String.Empty : reader.GetString(16);
                  
                    lista.Add(pc);
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static Pacientes GetPaciente(int dni)
        {
            try
            {
                Pacientes pc = null;
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_BuscarPacientePorDni", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Dni",SqlDbType.Int);
                    comando.Parameters["@Dni"].Value = dni;
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        pc = new Pacientes();
                        pc.IdPaciente = reader.GetInt32(0);
                        pc.Apellido = reader.GetString(1);
                        pc.Nombre = reader.GetString(2);
                        pc.TipoDoc = TiposDocBD.GetObjeto(reader.GetInt32(3));
                        pc.NumeroDoc = reader.GetInt32(4);
                        pc.Genero = GenerosBD.GetObjeto(reader.GetInt32(5));
                        pc.Nacionalidad = NacionalidadesBD.GetObjeto(reader.GetInt32(6));
                        pc.Provincia = ProvinciaBD.GetObjeto(reader.GetInt32(7));
                        pc.Localidad = LocalidadesBD.GetObjeto(reader.GetInt32(8));
                        pc.GrupoSanguineo = reader.GetString(9);
                        pc.Direccion = reader.GetString(10);
                        pc.FechaNac = reader.GetDateTime(11);
                        pc.TelefonoMovil = reader[12] == DBNull.Value ? String.Empty : reader.GetString(12);
                        pc.TelefonoFijo = reader[13] == DBNull.Value ? String.Empty : reader.GetString(13);
                        //   pc.Salario = reader.GetDecimal(10);
                        //   pc.FechaIngreso = reader.GetDateTime(11);
                        pc.ObraSocial = ObrasSocialesBD.GetObjeto(reader[14] == DBNull.Value ? 0 : reader.GetInt32(14));
                        pc.Plan = PlanesBD.GetObjeto(reader[15] == DBNull.Value ? 0 : reader.GetInt32(15));
                        pc.NroAfiliado = reader[16] == DBNull.Value ? String.Empty : reader.GetString(16);
                    }

                
                }
                return pc;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Pacientes> GetLista(string dni)
        {
            try
            {
                List<Pacientes> lista = new List<Pacientes>();
                string cn = @"Data Source=.;Initial Catalog=FinalConsultorio;Integrated Security= True; MultipleActiveResultSets=true";
                SqlConnection cnn = new SqlConnection(cn);
                cnn.Open();
               // string Csql = "SELECT * FROM ListaPacientes
                SqlCommand comando = new SqlCommand("Sp_ListaPacientePorDNI", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Dni",SqlDbType.VarChar,20);
                comando.Parameters["@Dni"].Value = dni;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Pacientes pc = new Pacientes();
                    pc.IdPaciente = reader.GetInt32(0);
                    pc.Apellido = reader.GetString(1);
                    pc.Nombre = reader.GetString(2);
                    pc.TipoDoc = TiposDocBD.GetObjeto(reader.GetInt32(3));
                    pc.NumeroDoc = reader.GetInt32(4);
                    pc.Genero = GenerosBD.GetObjeto(reader.GetInt32(5));
                    pc.Nacionalidad = NacionalidadesBD.GetObjeto(reader.GetInt32(6));
                    pc.Provincia = ProvinciaBD.GetObjeto(reader.GetInt32(7));
                    pc.Localidad = LocalidadesBD.GetObjeto(reader.GetInt32(8));
                    pc.GrupoSanguineo = reader.GetString(9);
                    pc.Direccion = reader.GetString(10);
                    pc.FechaNac = reader.GetDateTime(11);
                    pc.TelefonoMovil = reader[12] == DBNull.Value ? String.Empty : reader.GetString(12);
                    pc.TelefonoFijo = reader[13] == DBNull.Value ? String.Empty : reader.GetString(13);
                    //   pc.Salario = reader.GetDecimal(10);
                    //   pc.FechaIngreso = reader.GetDateTime(11);
                    pc.ObraSocial = ObrasSocialesBD.GetObjeto(reader[14] == DBNull.Value ? 0 : reader.GetInt32(14));
                    pc.Plan = PlanesBD.GetObjeto(reader[15] == DBNull.Value ? 0 : reader.GetInt32(15));
                    pc.NroAfiliado = reader[16] == DBNull.Value ? String.Empty : reader.GetString(16);

                    lista.Add(pc);
                }
                return lista;
            }
            catch (Exception ex )
            {

                throw ex ;
            }
        }

        internal static Pacientes GetObjeto(int v)
        {
            Pacientes pc = null;
            try
            {
                using (SqlConnection cn= Conexion.ConectarBD())
                {
                    cn.Open();
                    string strComando = "Select * From Pacientes Where IdPaciente=@id";
                    SqlCommand comando = new SqlCommand(strComando,cn);
                    comando.Parameters.AddWithValue("@id",v);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        pc = new Pacientes();

                        pc.IdPaciente = reader.GetInt32(0);
                        pc.Apellido = reader.GetString(1);
                        pc.Nombre = reader.GetString(2);
                        pc.TipoDoc = TiposDocBD.GetObjeto(reader.GetInt32(3));
                        pc.NumeroDoc = reader.GetInt32(4);
                        pc.Genero = GenerosBD.GetObjeto(reader.GetInt32(5));
                        pc.Nacionalidad = NacionalidadesBD.GetObjeto(reader.GetInt32(6));
                        pc.Provincia = ProvinciaBD.GetObjeto(reader.GetInt32(7));
                        pc.Localidad = LocalidadesBD.GetObjeto(reader.GetInt32(8));
                        pc.GrupoSanguineo = reader.GetString(9);
                        pc.Direccion = reader.GetString(10);
                        pc.FechaNac = reader.GetDateTime(11);
                        pc.TelefonoMovil = reader[12] == DBNull.Value ? String.Empty : reader.GetString(12);
                        pc.TelefonoFijo = reader[13] == DBNull.Value ? String.Empty : reader.GetString(13);
                        //   pc.Salario = reader.GetDecimal(10);
                        //   pc.FechaIngreso = reader.GetDateTime(11);
                        pc.ObraSocial = ObrasSocialesBD.GetObjeto(reader[14] == DBNull.Value ? 0 : reader.GetInt32(14));
                        pc.Plan = PlanesBD.GetObjeto(reader[15] == DBNull.Value ? 0 : reader.GetInt32(15));
                        pc.NroAfiliado = reader.GetString(16);

                    }
                }
                return pc;          
            }
            catch (Exception ex )
            {

                throw ex ;
            }
        }

        public static void Agregar(Pacientes p)
        {

            try
            {
                using (SqlConnection Cnn = Conexion.ConectarBD())
                {
                    Cnn.Open();
                    SqlCommand comando = new SqlCommand("AltaPaciente", Cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    /* 2 formas de pasarles  valores a los parametros en los metodos ****/
                    //comando.Parameters.Add("@TipoDoc", SqlDbType.NVarChar, 50);
                    //comando.Parameters["@TipoDoc"].Value = td.TipoDoc;
                    comando.Parameters.AddWithValue("@Apellido", p.Apellido);
                    comando.Parameters.AddWithValue("@Nombre", p.Nombre);
                    comando.Parameters.AddWithValue("@IdTipoDoc", p.TipoDoc.IdTipoDoc);
                    comando.Parameters.AddWithValue("@NroDoc", p.NumeroDoc);
                    comando.Parameters.AddWithValue("@IdGenero", p.Genero.IdGenero);
                    comando.Parameters.AddWithValue("@IdNacionalidad", p.Nacionalidad.IdNacionalidad);
                    comando.Parameters.AddWithValue("@IdProvincia", p.Provincia.IdProvincia);
                    comando.Parameters.AddWithValue("@IdLocalidad", p.Localidad.IdLocalidad);
                    comando.Parameters.AddWithValue("@GrupoSanguineo", p.GrupoSanguineo);
                    comando.Parameters.AddWithValue("@Direccion", p.Direccion);
                    comando.Parameters.AddWithValue("@FechaNac", p.FechaNac);
                    comando.Parameters.AddWithValue("@TelefonoMovil", p.TelefonoMovil);
                    comando.Parameters.AddWithValue("@TelefonoFijo", p.TelefonoFijo);
                    comando.Parameters.AddWithValue("@IdObraSocial", p.ObraSocial.IdObraSocial);
                    comando.Parameters.AddWithValue("@IdPlan", p.Plan.IdPlan);
                    comando.Parameters.AddWithValue("@NroAfiliado", p.NroAfiliado);
                    
                    comando.ExecuteNonQuery();
                    string strcomando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(strcomando, Cnn);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    p.IdPaciente = id;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_Pacientes_NyA_DNI"))
                {
                    throw new Exception("El paciente ya esta registrado en el sistema");
                }
                else
                if (ex.Message.Contains("CK_Pacientes_GS"))
                {
                    throw  new Exception("Ingreso un grupo sanguineo que no pertenece a los siguientes (A+,A-,B+,B-, O+,O-)");
                }
                throw;
            }

        }
        public static void Editar(Pacientes p)
        {
            try
            {
                using (SqlConnection cnn= Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando= new SqlCommand("EditarPaciente",cnn);
                    comando.CommandType=CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdPaciente", SqlDbType.Int);
                    comando.Parameters["@IdPaciente"].Value = p.IdPaciente;
                    comando.Parameters.AddWithValue("@Apellido", p.Apellido);
                    comando.Parameters.AddWithValue("@Nombre", p.Nombre);
                    comando.Parameters.AddWithValue("@IdTipoDoc", p.TipoDoc.IdTipoDoc);
                    comando.Parameters.AddWithValue("@NroDoc", p.NumeroDoc);
                    comando.Parameters.AddWithValue("@IdGenero", p.Genero.IdGenero);
                    comando.Parameters.AddWithValue("@IdNacionalidad", p.Nacionalidad.IdNacionalidad);
                    comando.Parameters.AddWithValue("@IdProvincia", p.Provincia.IdProvincia);
                    comando.Parameters.AddWithValue("@IdLocalidad", p.Localidad.IdLocalidad);
                    comando.Parameters.AddWithValue("@GrupoSanguineo", p.GrupoSanguineo);
                    comando.Parameters.AddWithValue("@Direccion", p.Direccion);
                    comando.Parameters.AddWithValue("@FechaNac", p.FechaNac);
                    if (p.TelefonoMovil == string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", DBNull.Value);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoMovil", p.TelefonoMovil);
                    }
                    if (p.TelefonoFijo == string.Empty)
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", DBNull.Value);

                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@TelefonoFijo", p.TelefonoFijo);
                    }
                    comando.Parameters.AddWithValue("@IdObraSocial", p.ObraSocial.IdObraSocial);
                    comando.Parameters.AddWithValue("@IdPlan", p.Plan.IdPlan);
                    comando.Parameters.AddWithValue("@NroAfiliado", p.NroAfiliado);
                  
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex )
            {
                if (ex.Message.Contains("IX_Pacientes_NyA_DNI"))
                {
                    throw new Exception("El paciente ya esta registrado en el sistema");
                } else 
                if (ex.Message.Contains("CK_Pacientes_GS"))
                {
                    throw  new Exception("Ingreso un grupo sanguineo que no pertenece a los siguientes (A+,A-,B+,B-, O+,O-)");
                }
                throw;
            }
        }

    }
}
