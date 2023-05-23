using DATOS;
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
    }
}
