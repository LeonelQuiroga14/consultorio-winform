using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion


    {
        public static SqlConnection ConectarBD()
        {

            try
            {
                string cn = @"Data Source=.;Initial Catalog=FinalConsultorio;Integrated Security= True; MultipleActiveResultSets=true";
                SqlConnection cnn= new SqlConnection(cn);
                return cnn;
            }
            catch (Exception ex  )
            { 
                
                throw ex;
            }
        

        }

    }

}
