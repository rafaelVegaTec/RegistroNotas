using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;

        private static Conexion con = null;

        private Conexion()
        {
            this.Base = "db_Escuela";
            this.Servidor = "DESKTOP-0AIN3TR";
            this.Usuario = string.Empty;
            this.Clave = string.Empty;
            this.Seguridad = true;
        }

        public SqlConnection CrearConexcion()
        {
            SqlConnection cadena = new SqlConnection();
            try
            {
                cadena.ConnectionString = $"Server={Servidor};Database={Base};Trusted_Connection={Seguridad};";
            }
            catch (Exception ex)
            {
                cadena = null;
                throw ex;
            }
            return cadena;
        }

        public static Conexion GetInstancia()
        {
            if(con == null)
            {
                con = new Conexion();
            }
            return con;
        }
    }
}
