using Presentacion.UserController.AlumnosController;
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
using System.Windows.Shapes;

namespace Presentacion.UserController.Alertas
{
    /// <summary>
    /// Lógica de interacción para ucEliminar.xaml
    /// </summary>
    public partial class ucEliminar : Window
    {
        Notificacion valorNot;

        public ucEliminar()
        {
            InitializeComponent();
        }

        public ucEliminar(Notificacion not)
        {
            InitializeComponent();
            valorNot = not;
        }
        private void AceptarAlerta_Click(object sender, RoutedEventArgs e)
        {
            valorNot.valor_confirmacion = "Ok";
            this.Close();
        }

        private void CancelarAlerta_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
