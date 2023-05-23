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
                if(sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        //public string InsertarAlumno(Alumno obj)
        //{

        //}

        //public string EditarAlumno(Alumno obj)
        //{

        //}

        //public string DesactivarAlumnp(int id)
        //{

        //}
    }
}
