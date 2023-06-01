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
    public class NMateria
    {
        public DataTable ListarMaterias()
        {
            DMateria dMateria = new DMateria();
            return dMateria.ListarMaterias();
        }
        public bool CrearMateria(Materia obj)
        {
            DMateria dMateria = new DMateria();
            return dMateria.CrearMateria(obj);
        }

        public bool ActualizarMateria(Materia obj)
        {
            DMateria dMateria = new DMateria();
            return dMateria.ActualizarMateria(obj);
        }
    }
}
