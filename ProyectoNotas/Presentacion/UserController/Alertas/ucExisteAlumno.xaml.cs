using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentacion.UserController.Alertas
{
    /// <summary>
    /// Lógica de interacción para ucExisteAlumno.xaml
    /// </summary>
    public partial class ucExisteAlumno : UserControl
    {
        public ucExisteAlumno(string texto = "")
        {
            InitializeComponent();
            if (!texto.Equals(""))
            {
                textoMensaje.Text = texto;
            }
        }
    }
}
