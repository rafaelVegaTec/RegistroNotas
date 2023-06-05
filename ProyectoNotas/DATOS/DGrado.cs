using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class DGrado
    {
        public DataTable ListarGrados()
        {
            SqlDataReader resultado = null;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ListarGrados", sqlCon);
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

        public DataTable ListarGradosEliminados()
        {
            SqlDataReader resultado = null;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ListarGradosEliminados", sqlCon);
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


        public DataTable FiltrarGrados(string valor)
        {
            SqlDataReader resultado = null;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("FiltrarGrados", sqlCon);
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

        public DataTable FiltrarGradosEliminados(string valor)
        {
            SqlDataReader resultado = null;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("FiltrarGradosEliminados", sqlCon);
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

        public DataTable MostrarAlumnos()
        {
            SqlDataReader resultado = null;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("MostrarAlumnos", sqlCon);
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

        public DataTable MostrarMateriaDocente()
        {
            DataTable tabla = new DataTable();
            SqlDataReader resultado = null;
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("MostrarMateriaDocente", sqlCon);
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

        public bool CrearGrado(Grado obj)
        {
            SqlConnection sqlCon = new SqlConnection();
            bool exito;
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("CrearGrado", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@NombreGrado", SqlDbType.VarChar).Value = obj.NombreGrado;
                comando.Parameters.Add("@Seccion", SqlDbType.VarChar).Value = obj.Seccion;
                comando.Parameters.Add("@IdAlumno", SqlDbType.Int).Value = (int)obj.IdAlumno;
                comando.Parameters.Add("@IdMateria", SqlDbType.Int).Value = (int)obj.IdMateria;
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

        public bool ModificarGrado(Grado obj)
        {
            SqlConnection sqlCon = new SqlConnection();
            bool exito;
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ModificarGrado", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdGrado", SqlDbType.VarChar).Value = obj.IdGrado;
                comando.Parameters.Add("@NombreGrado", SqlDbType.VarChar).Value = obj.NombreGrado;
                comando.Parameters.Add("@Seccion", SqlDbType.VarChar).Value = obj.Seccion;
                comando.Parameters.Add("@IdAlumno", SqlDbType.Int).Value = (int)obj.IdAlumno;
                comando.Parameters.Add("@IdMateria", SqlDbType.Int).Value = (int)obj.IdMateria;
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

        public bool EliminarGrado(int idGrado)
        {
            SqlConnection sqlCon = new SqlConnection();
            bool exito;
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("EliminarGrado", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdGrado", SqlDbType.VarChar).Value = idGrado;
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

        public bool ActivarGrado(int idGrado)
        {
            SqlConnection sqlCon = new SqlConnection();
            bool exito;
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ActivarGrado", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdGrado", SqlDbType.VarChar).Value = idGrado;
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
    }
}
