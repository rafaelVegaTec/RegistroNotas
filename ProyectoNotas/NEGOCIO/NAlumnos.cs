using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class NAlumnos
    {
        public DataTable ListarAlumnos()
        {
            DAlumno dAlum = new DAlumno();
            return dAlum.ListarAlumnos();
        }

        public DataTable FiltrarAlumnos(string valor)
        {
            DAlumno dAlum = new DAlumno();
            return dAlum.FiltrarAlumnos(valor);
        }

        public string InsertarAlumno(Alumno obj)
        {
            DAlumno dAlumno = new DAlumno();
            return dAlumno.InsertarAlumno(obj);
        }

        public string ActualizarAlumno(Alumno obj)
        {
            DAlumno dAlumno = new DAlumno();
            return dAlumno.EditarAlumno(obj);
        }

        public string DesactivarAlumno(int Id)
        {
            DAlumno dAlumno=new DAlumno();
            return dAlumno.DesactivarAlumnp(Id);
        }
    }
}
