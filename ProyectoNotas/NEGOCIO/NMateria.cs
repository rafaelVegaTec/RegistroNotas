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

        public DataTable ListarMateriasDesactivadas()
        {
            DMateria dMateria = new DMateria();
            return dMateria.ListarMateriasDesactivadas();
        }

        public DataTable FiltrarMateria(string valor)
        {
            DMateria dMateria = new DMateria();
            return dMateria.FiltrarMateria(valor);
        }

        public DataTable FiltrarMateriasDesactivadas(string valor)
        {
            DMateria dMateria = new DMateria();
            return dMateria.FiltrarMateriasDesactivadas(valor);
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

        public bool DesactivarMateria(int id)
        {
            DMateria dMateria = new DMateria();
            return dMateria.DesactivarMateria(id);
        }

        public bool ActivarMateria(int id)
        {
            DMateria dMateria = new DMateria();
            return dMateria.ActivarMateria(id);
        }
    }
}
