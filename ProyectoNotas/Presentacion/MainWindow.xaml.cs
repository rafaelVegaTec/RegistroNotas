using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //REFERENCIAS
       

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Eventos MouseLeftButtonDown_Botones_Menu
        private void stInicio_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            stInicio.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#b388ff");
            stAlumnos.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stMaterias.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stGrados.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stNotas.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAsistencia.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stDocentes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stReportes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            //stPanelCentro.Children.Remove(alumnosHome);
        }

        private void stAlumnos_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            stAlumnos.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#b388ff");
            stInicio.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stMaterias.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stGrados.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stNotas.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAsistencia.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stDocentes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stReportes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");

            stPanelCentro.Children.Clear();
            AlumnosHome alumnosHome = new AlumnosHome();
            stPanelCentro.Children.Add(alumnosHome);




        }

        private void stMaterias_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            stInicio.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAlumnos.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stMaterias.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#b388ff");
            stGrados.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stNotas.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAsistencia.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stDocentes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stReportes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
        }

        private void stGrados_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            stInicio.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAlumnos.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stMaterias.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stGrados.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#b388ff");
            stNotas.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAsistencia.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stDocentes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stReportes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
        }

        private void stNotas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            stInicio.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAlumnos.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stMaterias.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stGrados.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stNotas.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#b388ff");
            stAsistencia.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stDocentes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stReportes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
        }

        private void stAsistencia_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            stInicio.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAlumnos.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stMaterias.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stGrados.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stNotas.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAsistencia.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#b388ff");
            stDocentes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stReportes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
        }

        private void stDocentes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            stInicio.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAlumnos.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stMaterias.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stGrados.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stNotas.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAsistencia.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stDocentes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#b388ff");
            stReportes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
        }

        private void stReportes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            stInicio.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAlumnos.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stMaterias.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stGrados.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stNotas.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stAsistencia.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stDocentes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#673ab7");
            stReportes.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#b388ff");
        }
        #endregion
    }
}
