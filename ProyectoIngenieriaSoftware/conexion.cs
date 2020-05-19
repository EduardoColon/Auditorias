using System;
using System.Data.Odbc;

namespace Inventarios
{
    public class conexion
    {
        public OdbcConnection conectar()
        {
            OdbcConnection conectar = new OdbcConnection("Dsn=auditorias");

            try
            {
                conectar.Open();
                OdbcCommand cmd = new OdbcCommand("SET wait_timeout = 7200;", conectar);
                cmd.ExecuteNonQuery();
                return conectar;
            }
            catch (OdbcException ex)
            {

                Console.WriteLine("No conecto la Base de Datos ", ex);
                return null;
            }
        }
    }
}
