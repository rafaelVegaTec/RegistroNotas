using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DATOS
{
    public class DAlumno
    {
        public DataTable ListarAlumnos()
        {
            SqlDataReader resultado = null;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ListarAlmunos", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        public DataTable FiltrarAlumnos(string valor)
        {
            SqlDataReader resultado = null;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("FiltrarAlumno", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                sqlCon.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) { sqlCon.Close(); }
            }

        }

        public string InsertarAlumno(Alumno obj)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("CrearAlumno", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombreAlumno;
                comando.Parameters.Add("@edad", SqlDbType.Int).Value = obj.edad;
                comando.Parameters.Add("@fechaNacimiento", SqlDbType.VarChar).Value = obj.fechaNacimiento;
                comando.Parameters.Add("@telefonoAlumno", SqlDbType.VarChar).Value = obj.telefonoAlumno;
                comando.Parameters.Add("@telefonoEncargado", SqlDbType.VarChar).Value = obj.telefonoEncargado;
                comando.Parameters.Add("@emailAlumno", SqlDbType.VarChar).Value = obj.emailAlumno;
                comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = true;
                sqlCon.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "Ok" : "Error";
            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) { sqlCon.Close(); }
            }
            return respuesta;
        }

        public string EditarAlumno(Alumno obj)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ActualizarAlumno", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idAlumno", SqlDbType.VarChar).Value = obj.idAlumno;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombreAlumno;
                comando.Parameters.Add("@edad", SqlDbType.Int).Value = obj.edad;
                comando.Parameters.Add("@fechaNacimiento", SqlDbType.DateTime).Value = obj.fechaNacimiento;
                comando.Parameters.Add("@telefonoAlumno", SqlDbType.VarChar).Value = obj.telefonoAlumno;
                comando.Parameters.Add("@telefonoEncargado", SqlDbType.VarChar).Value = obj.telefonoEncargado;
                comando.Parameters.Add("@emailAlumno", SqlDbType.VarChar).Value = obj.emailAlumno;
                sqlCon.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "Ok" : "Error";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return respuesta;
        }

        public string DesactivarAlumnp(int id)
        {
            string resultado;
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("DesactivarAlumno", con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idAlumno", SqlDbType.Int).Value = id;
                con.Open();
                resultado = comando.ExecuteNonQuery() == 1 ? "Ok" : "Error";
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return resultado;
        }
    }
}
