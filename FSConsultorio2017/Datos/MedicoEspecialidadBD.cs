using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using System.Windows.Forms;

namespace Datos
{
    public class MedicoEspecialidadBD
    {

        public static List<MedicoEspecialidad> GetLista()
        {
            try
            {
                List<MedicoEspecialidad> lista = new List<MedicoEspecialidad>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strcomando = "SELECT IdMedicoEspecialidad,IdEspecialidad,IdMedico,Matricula,CostoConsulta From Medicos_Especialidades ";
                    SqlCommand comando = new SqlCommand(strcomando, cnn);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        MedicoEspecialidad mp = new MedicoEspecialidad();
                        mp.IdMedicoEspecialidad = reader.GetInt32(0);
                        mp.Especialidad = EspecialidadesBD.GetObjeto(reader.GetInt32(1));
                        mp.Medico = MedicosBD.GetObjeto(reader.GetInt32(2));
                        mp.Matricula = reader.GetString(3);
                        mp.CostoConsulta =reader.GetDecimal(4);

                        lista.Add(mp);

                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static List<MedicoEspecialidad> GetLista(Medicos m)
        {
            try
            {
                List<MedicoEspecialidad> lista = new List<MedicoEspecialidad>();
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                   // string strcomando = "SELECT IdMedicoEspecialidad,IdEspecialidad,IdMedico,Matricula,CostoConsulta From Medicos_Especialidades ";
                    SqlCommand comando = new SqlCommand("SP_ListaPorMedicos", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdMedico", SqlDbType.Int);
                    comando.Parameters["@IdMedico"].Value = m.IdMedico;
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        MedicoEspecialidad mp = new MedicoEspecialidad();
                        mp.IdMedicoEspecialidad = reader.GetInt32(0);
                        mp.Medico = MedicosBD.GetObjeto(reader.GetInt32(1));
                        mp.Especialidad = EspecialidadesBD.GetObjeto(reader.GetInt32(2));
                        mp.Matricula = reader.GetString(3);
                        mp.CostoConsulta = reader.GetDecimal(4);

                        lista.Add(mp);

                    }
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static void Agregar(MedicoEspecialidad mp)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("Sp_AltaMedico_Especialidad", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdEspecialidad", SqlDbType.Int);
                    comando.Parameters.Add("@IdMedico", SqlDbType.Int);
                    comando.Parameters.Add("@Matricula", SqlDbType.NVarChar,100);
                    comando.Parameters.Add("@Costo", SqlDbType.Decimal);
                    comando.Parameters["@IdEspecialidad"].Value = mp.Especialidad.IdEspecialidad;
                    comando.Parameters["@IdMedico"].Value = mp.Medico.IdMedico;
                    comando.Parameters["@Matricula"].Value = mp.Matricula;
                    comando.Parameters["@Costo"].Value = mp.CostoConsulta;
                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_Medicos_Especialidades_Medico_Esp"))
                {
                    throw new Exception("Existe ese registro en la Base de datos verifique los campos ");
                }
                throw ex;
            }


        }
        //public static void CargarCombobox(ref ComboBox cboMedico,Especialidades d)
        //{

        //    List<Medicos> lista = MedicosBD.GetLista(d);
        //    Medicos defaultPersona = new Medicos() { Apellido="<Seleccione ", Nombre = "el medico>" };       
        //    lista.Insert(0, defaultPersona);
        //    lista = lista.OrderBy(c => c.Medico.Apellido).ThenBy(c => c.Medico.Nombre).ToList();
        //    cboMedico.DataSource = lista;
        //    cboMedico.DisplayMember = "ApellidoNombre";
        //    cboMedico.ValueMember = "IdMedicoEspecialidad";
        //    cboMedico.SelectedIndex = 0;
        //}

        private static List<MedicoEspecialidad> GetLista(Especialidades d)
        {
            throw new NotImplementedException();
        }

        public static void Borrar(MedicoEspecialidad mp)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("Sp_BajaMedico_Especialidad", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdMedicoEspecialidad", SqlDbType.Int);
                    comando.Parameters["@IdMedicoEspecialidad"].Value = mp.IdMedicoEspecialidad;
                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public static MedicoEspecialidad GetObjeto(int m)
        {

            MedicoEspecialidad mp = null;
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();
                    string strcomando = "SELECT IdMedicoEspecialidad,IdEspecialidad,IdMedico,Matricula,CostoConsulta FROM Medicos_Especialidades WHERE IdMedicoEspecialidad=@m";
                    SqlCommand comando = new SqlCommand(strcomando, cnn);
                    comando.Parameters.AddWithValue("@m", m);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        mp = new MedicoEspecialidad();
                        mp.IdMedicoEspecialidad = reader.GetInt32(0);
                        mp.Especialidad = EspecialidadesBD.GetObjeto(reader.GetInt32(1));
                        mp.Medico = MedicosBD.GetObjeto(reader.GetInt32(2));
                        mp.Matricula = reader.GetString(3);
                        mp.CostoConsulta = reader.GetDecimal(4);



                    }
                }
                return mp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Editar(MedicoEspecialidad mp)
        {
            try
            {
                using (SqlConnection cnn = Conexion.ConectarBD())
                {
                    cnn.Open();

                    SqlCommand comando = new SqlCommand("Sp_EditarMedico_Especialidad", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@IdMedicoEspecialidad", SqlDbType.Int);
                    comando.Parameters.Add("@IdEspecialidad", SqlDbType.Int);
                    comando.Parameters.Add("@IdMedico", SqlDbType.Int);
                    comando.Parameters.Add("@Matricula", SqlDbType.NVarChar,100);
                    comando.Parameters.Add("@Costo", SqlDbType.Decimal);

                    comando.Parameters["@IdMedicoEspecialidad"].Value = mp.IdMedicoEspecialidad;
                    comando.Parameters["@IdEspecialidad"].Value = mp.Especialidad.IdEspecialidad;
                    comando.Parameters["@IdMedico"].Value = mp.Medico.IdMedico;
                    comando.Parameters["@Matricula"].Value = mp.Matricula;
                    comando.Parameters["@Costo"].Value = mp.CostoConsulta;

                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_Medicos_Especialidades_Medico_Esp"))
                {
                    throw new Exception("Existe ese registro en la Base de datos verifique los campos ");
                }
                throw ex;
                throw ex;
            }


        }



    }
}
