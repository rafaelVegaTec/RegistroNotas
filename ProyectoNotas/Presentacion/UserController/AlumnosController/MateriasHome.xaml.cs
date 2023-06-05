using DATOS;
using ENTIDADES;
using NEGOCIO;
using Presentacion.UserController.Alertas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

namespace Presentacion.UserController.AlumnosController
{
    /// <summary>
    /// Lógica de interacción para MateriasHome.xaml
    /// </summary>
    public partial class MateriasHome : UserControl
    {
        NDocente nDocente = new NDocente();
        NMateria nMateria = new NMateria();

        //Instancias de UserControllers
        ucExitoAlerta aExito = new ucExitoAlerta();
        ucExisteAlumno aExiste = new ucExisteAlumno();
        ucCamObli aCamObli = new ucCamObli();
        ucCancelar aCancelar = new ucCancelar();

        //Isntancias Apoyo
        DispatcherTimer timer = new DispatcherTimer();

        private int IdMateria = 0;

        public MateriasHome()
        {
            InitializeComponent();
            CargarMaterias();
            CargarCombobox();
        }

        #region Eventos
        private void btnCrearAlum_Click(object sender, RoutedEventArgs e)
        {
            if (txtMateriaCre.Text.Equals(string.Empty) || cmbDocentes.Text.Equals(string.Empty))
            {
                aCamObli.Width = 405;
                aCamObli.Height = 50;

                if (!aCamObli.IsVisible)
                {
                    stAlertas.Children.Add(aCamObli);
                    EjecutarAlerta();
                }
            }
            else
            {
                Materia oMateria = new Materia();
                DataRowView row = (DataRowView)cmbDocentes.SelectedItem;

                oMateria.NombreMateria = txtMateriaCre.Text;
                oMateria.IdDocente = (int)row.Row.ItemArray[0];
                bool resultado = nMateria.CrearMateria(oMateria);
                if (resultado)
                {
                    LimpiarCampos();
                    tbGeneralMaterias.SelectedIndex = 0;
                    CargarMaterias();
                    aExito.Height = 50;
                    aExito.Width = 200;
                    if (!aExito.IsVisible)
                    {
                        stAlertasExito.Children.Add(aExito);
                        EjecutarAlerta();
                    }
                }
                else
                {
                    aExiste.Width = 200;
                    aExiste.Height = 50;

                    if (!aExiste.IsVisible)
                    {
                        stAlertas.Children.Add(aExiste);
                        EjecutarAlerta();
                    }
                }
            }
        }

        private void BtnCanCreAlum_Click(object sender, RoutedEventArgs e)
        {
            tbGeneralMaterias.SelectedIndex = 0;
            CrearMateria.IsEnabled = true;
            ModificarMateria.IsEnabled = false;
            LimpiarCampos();
            aCancelar.Height = 50;
            aCancelar.Width = 200;
            stAlertasExito.Children.Add(aCancelar);
            EjecutarAlerta();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            CrearMateria.IsEnabled = false;
            ModificarMateria.IsEnabled = true;
            ListaMaterias.IsEnabled = false;
            tbEliminar.IsEnabled = false;
            tbGeneralMaterias.SelectedIndex = 2;

            DataRowView modMateria = (DataRowView)dtMaterias.SelectedItem;
            IdMateria = (int)modMateria.Row.ItemArray[0];
            txtMateriaMod.Text = modMateria.Row.ItemArray[1].ToString();
            int item = -1;
            foreach (DataRowView row in cmbDocentes.ItemsSource)
            {
                if (row.Row.ItemArray[1].ToString() == modMateria.Row.ItemArray[2].ToString())
                {
                    item++;
                    cmbDocentesMod.SelectedIndex = item;
                    break;
                }
                item++;
            }
        }

        private void btnModificarMateria_Click(object sender, RoutedEventArgs e)
        {
            if (txtMateriaMod.Text.Equals(string.Empty) || cmbDocentesMod.Text.Equals(string.Empty))
            {
                aCamObli.Width = 405;
                aCamObli.Height = 50;

                if (!aCamObli.IsVisible)
                {
                    stAlertas.Children.Add(aCamObli);
                    EjecutarAlerta();
                }
            }
            else
            {
                Materia oMateria = new Materia();
                DataRowView row = (DataRowView)cmbDocentes.SelectedItem;
                oMateria.IdMateria = IdMateria;
                oMateria.NombreMateria = txtMateriaMod.Text;
                oMateria.IdDocente = (int)row.Row.ItemArray[0];
                bool resultado = nMateria.ActualizarMateria(oMateria);
                if (resultado)
                {
                    LimpiarCampos();
                    tbGeneralMaterias.SelectedIndex = 0;
                    CrearMateria.IsEnabled = true;
                    ModificarMateria.IsEnabled = false;
                    ListaMaterias.IsEnabled = true;
                    tbEliminar.IsEnabled = true;
                    CargarMaterias();
                    aExito.Height = 50;
                    aExito.Width = 200;
                    if (!aExito.IsVisible)
                    {
                        stAlertasExito.Children.Add(aExito);
                        EjecutarAlerta();
                    }
                }
                else
                {
                    MessageBox.Show("Error: Contacte al administrador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnCanModAlum_Click(object sender, RoutedEventArgs e)
        {
            tbGeneralMaterias.SelectedIndex = 0;
            CrearMateria.IsEnabled = true;
            ModificarMateria.IsEnabled = false;
            ListaMaterias.IsEnabled = true;
            tbEliminar.IsEnabled = true;
            LimpiarCampos();
            aCancelar.Height = 50;
            aCancelar.Width = 200;
            stAlertasExito.Children.Add(aCancelar);
            EjecutarAlerta();
        }

        private void btnBuscarMateria_Click(object sender, RoutedEventArgs e)
        {
            dtMaterias.DataContext = nMateria.FiltrarMateria(txtFiltrar.Text);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Notificacion not = new Notificacion();
            ucEliminar aEliminar = new ucEliminar(not);
            DataRowView row = (DataRowView)dtMaterias.SelectedItem;
            IdMateria = (int)row.Row.ItemArray[0];
            aEliminar.ShowDialog();
            var resultado = not.valor_confirmacion;
            if (resultado.Equals("Ok"))
            {
                bool respuesta = nMateria.DesactivarMateria(IdMateria);
                if (respuesta)
                {
                    CargarMaterias();
                    aExito.Height = 50;
                    aExito.Width = 200;
                    if (!aExito.IsVisible)
                    {
                        stAlertasExito.Children.Add(aExito);
                        EjecutarAlerta();
                    }
                }
                else
                {
                    MessageBox.Show("Error: Contacte al administrador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnActivar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = (DataRowView)dtMateriasEliminadas.SelectedItem;
            IdMateria = (int)row.Row.ItemArray[0];
            bool respuesta = nMateria.ActivarMateria(IdMateria);
            if (respuesta)
            {
                CargarMaterias();
                tbGeneralMaterias.SelectedIndex = 0;
                aExito.Height = 50;
                aExito.Width = 200;
                if (!aExito.IsVisible)
                {
                    stAlertasExito.Children.Add(aExito);
                    EjecutarAlerta();
                }
            }
            else
            {
                MessageBox.Show("Error: Contacte al administrador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBuscarElim_Click(object sender, RoutedEventArgs e)
        {
            dtMateriasEliminadas.DataContext = nMateria.FiltrarMateriasDesactivadas(txtFiltrarElim.Text);
        }
        #endregion

        #region Metodos
        private void CargarCombobox()
        {
            cmbDocentes.DataContext = nDocente.MostrarDocentes();
            cmbDocentesMod.DataContext = nDocente.MostrarDocentes();
        }

        private void CargarMaterias()
        {
            dtMaterias.DataContext = nMateria.ListarMaterias();
            dtMateriasEliminadas.DataContext = nMateria.ListarMateriasDesactivadas();
        }

        private void LimpiarCampos()
        {
            txtMateriaCre.Clear();
            cmbDocentes.SelectedIndex = -1;

            txtMateriaMod.Clear();
            cmbDocentesMod.SelectedIndex = -1;
        }

        private void EjecutarAlerta()
        {
            timer.Tick += new EventHandler(OcultarElemento);
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }

        private void OcultarElemento(object? sender, EventArgs e)
        {
            stAlertasExito.Children.Remove(aExito);
            stAlertas.Children.Remove(aCamObli);
            stAlertasExito.Children.Remove(aCancelar);
            stAlertasMod.Children.Remove(aCamObli);
            stAlertas.Children.Remove(aExiste);
            timer.Stop();
        }
        #endregion        
    }
}
