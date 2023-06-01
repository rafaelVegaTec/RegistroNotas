using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class DDocente
    {
        public DataTable ListarDocentes()
        {
            SqlDataReader resultado = null;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ListarDocentes", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return tabla;
        }

        public DataTable ListarDocentesDesactivados()
        {
            DataTable tabla = new DataTable();
            SqlDataReader resultado;
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ListarDocentesDesactivados", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return tabla;
        }

        public DataTable FiltrarDocentes(string valor)
        {
            SqlDataReader resultado = null;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("FiltrarDocentes", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = valor;
                sqlCon.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return tabla;
        }

        public DataTable FiltrarDocenteDesactivado(string valor)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("FiltrarDocenteDesactivado", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                sqlCon.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return tabla;
        }

        public bool CrearDocente(Docente obj)
        {
            bool exito;
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("CrearDocente", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@NombreDocente", SqlDbType.VarChar).Value = obj.NombreDocente;
                comando.Parameters.Add("@TelefonoDocente", SqlDbType.VarChar).Value = obj.TelefonoDocente;
                comando.Parameters.Add("@EmailDocente", SqlDbType.VarChar).Value = obj.EmailDocente;
                comando.Parameters.Add("@UsuarioDocente", SqlDbType.VarChar).Value = obj.UsuarioDocente;
                comando.Parameters.Add("@PasswordDocente", SqlDbType.VarChar).Value = obj.PasswordDocente;
                comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = true;
                sqlCon.Open();
                exito = comando.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return exito;
        }

        public bool ActualizarDocente(Docente obj)
        {
            bool exito;
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ActualizarDocente", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdDocente", SqlDbType.Int).Value = obj.IdDocente;
                comando.Parameters.Add("@NombreDocente", SqlDbType.VarChar).Value = obj.NombreDocente;
                comando.Parameters.Add("@TelefonoDocente", SqlDbType.VarChar).Value = obj.TelefonoDocente;
                comando.Parameters.Add("@EmailDocente", SqlDbType.VarChar).Value = obj.EmailDocente;
                comando.Parameters.Add("@UsuarioDocente", SqlDbType.VarChar).Value = obj.UsuarioDocente;
                comando.Parameters.Add("@PasswordDocente", SqlDbType.VarChar).Value = obj.PasswordDocente;
                comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = true;
                sqlCon.Open();
                exito = comando.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) { sqlCon.Close(); }
            }
            return exito;
        }

        public bool DesactivarDocente(int id)
        {
            bool exito;
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("DesactivarDocente", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdDocente", SqlDbType.Int).Value = id;
                sqlCon.Open();
                exito = comando.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) { sqlCon.Close(); }
            }
            return exito;
        }

        public bool ActivarDocente(int id)
        {
            bool exito;
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ActivarDocente", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdDocente", SqlDbType.Int).Value = id;
                sqlCon.Open();
                exito = comando.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return exito;
        }

        public bool Existe(string valor)
        {
            bool existe;
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ExisteDocente", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                SqlParameter parExiste = new SqlParameter();
                parExiste.ParameterName = "@existe";
                parExiste.SqlDbType = SqlDbType.Bit;
                parExiste.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parExiste);
                sqlCon.Open();
                comando.ExecuteNonQuery();
                existe = (bool)parExiste.Value;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return existe;
        }

        public string Encriptacion(string contraseña)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(contraseña));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }

        public DataTable MostrarDocentes()
        {
            SqlDataReader resultado = null;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("MostrarDocentes", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) { sqlCon.Close(); }
            }
            return tabla;
        }
    }
}
