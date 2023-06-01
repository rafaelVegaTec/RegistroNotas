using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DATOS
{
    public class DMateria
    {
        public DataTable ListarMaterias()
        {
            DataTable tabla = new DataTable();
            SqlDataReader resultado = null;
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ListaMaterias", sqlCon);
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
        public bool CrearMateria(Materia obj)
        {
            bool exito;
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("CrearMateria", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Materia", SqlDbType.VarChar).Value = obj.NombreMateria;
                comando.Parameters.Add("@IdDocente", SqlDbType.Int).Value = obj.IdDocente;
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

        public bool ActualizarMateria(Materia obj)
        {
            bool exito;
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.GetInstancia().CrearConexcion();
                SqlCommand comando = new SqlCommand("ActualizarMateria", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdMateria", SqlDbType.Int).Value = obj.IdMateria;
                comando.Parameters.Add("@Materia", SqlDbType.VarChar).Value = obj.NombreMateria;
                comando.Parameters.Add("@IdDocente", SqlDbType.Int).Value = obj.IdDocente;
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