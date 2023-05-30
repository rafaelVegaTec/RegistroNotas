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
            this.Servidor = "DESKTOP-SHTHRSU";
            this.Usuario = "sa";
            this.Clave = "Mecanica2013=";
            this.Seguridad = false;
        }

        public SqlConnection CrearConexcion()
        {
            SqlConnection cadena = new SqlConnection();
            try
            {
                cadena.ConnectionString = $"Server={Servidor};Database={Base};User Id={Usuario};Password={Clave};";
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
