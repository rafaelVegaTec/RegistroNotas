using DATOS;
using ENTIDADES;
using NEGOCIO;
using Presentacion.UserController.Alertas;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Presentacion.UserController.AlumnosController
{
    /// <summary>
    /// Lógica de interacción para GradosHome.xaml
    /// </summary>
    public partial class GradosHome : UserControl
    {
        NGrado nGrado = new NGrado();

        //Instancias de UserControllers
        ucExitoAlerta aExito = new ucExitoAlerta();
        ucExisteAlumno aExiste = new ucExisteAlumno();
        ucCamObli aCamObli = new ucCamObli();
        ucCancelar aCancelar = new ucCancelar();

        //Isntancias Apoyo
        DispatcherTimer timer = new DispatcherTimer();

        int IdGrado = 0;

        public GradosHome()
        {
            InitializeComponent();
            CargarMaterias();
            CargarCombobox();
        }

        private void CargarCombobox()
        {
            cmbAlumno.DataContext = nGrado.MostrarAlumnos();
            cmbMateria.DataContext = nGrado.MostrarMateriaDocente();

            cmbAlumnoMod.DataContext = nGrado.MostrarAlumnos();
            cmbMateriaMod.DataContext = nGrado.MostrarMateriaDocente();
        }

        private void btnCrearGrado_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomGrado.Text.Equals(string.Empty) || cmbSeccion.Text.Equals(string.Empty) || cmbAlumno.Text.Equals(string.Empty) || cmbMateria.Text.Equals(string.Empty))
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
                Grado oGrado = new Grado();
                DataRowView rowAlumno = (DataRowView)cmbAlumno.SelectedItem;
                DataRowView rowMateria = (DataRowView)cmbMateria.SelectedItem;

                oGrado.NombreGrado = txtNomGrado.Text;
                oGrado.Seccion = cmbSeccion.Text;
                oGrado.IdAlumno = (int)rowAlumno.Row.ItemArray[0];
                oGrado.IdMateria = (int)rowMateria.Row.ItemArray[0];
                bool resultado = nGrado.CrearGrado(oGrado);
                if (resultado)
                {
                    LimpiarCampos();
                    tbGeneralGraddos.SelectedIndex = 0;
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

        private void CargarMaterias()
        {
            dtGrados.DataContext = nGrado.ListarGrados();
            dtGradosEli.DataContext = nGrado.ListarGradosEliminados();
        }

        private void LimpiarCampos()
        {
            txtNomGrado.Clear();
            cmbSeccion.SelectedIndex = -1;
            cmbAlumno.SelectedIndex = -1;
            cmbMateria.SelectedIndex = -1;

            txtNomGradoMod.Clear();
            cmbSeccionMod.SelectedIndex = -1;
            cmbAlumnoMod.SelectedIndex = -1;
            cmbMateriaMod.SelectedIndex = -1;
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

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dtGrados.DataContext = nGrado.FiltrarGrados(txtFiltrar.Text);
        }

        private void btnCancelarGrado_Click(object sender, RoutedEventArgs e)
        {
            tbGeneralGraddos.SelectedIndex = 0;
            CrearGrado.IsEnabled = true;
            ModificarGrado.IsEnabled = false;
            LimpiarCampos();
            aCancelar.Height = 50;
            aCancelar.Width = 200;
            stAlertasExito.Children.Add(aCancelar);
            EjecutarAlerta();
        }

        private void btnModificarGrado_Click(object sender, RoutedEventArgs e)
        {
            CrearGrado.IsEnabled = false;
            ModificarGrado.IsEnabled = true;
            ListaGrados.IsEnabled = false;
            tbEliminar.IsEnabled = false;
            tbGeneralGraddos.SelectedIndex = 2;

            DataRowView modGrado = (DataRowView)dtGrados.SelectedItem;
            IdGrado = (int)modGrado.Row.ItemArray[0];
            txtNomGradoMod.Text = modGrado.Row.ItemArray[1].ToString();
            cmbSeccionMod.Text = modGrado.Row.ItemArray[2].ToString();
            int item = -1;
            foreach (DataRowView row in cmbAlumnoMod.ItemsSource)
            {
                if (row.Row.ItemArray[1].ToString() == modGrado.Row.ItemArray[3].ToString())
                {
                    item++;
                    cmbAlumnoMod.SelectedIndex = item;
                    item = -1;
                    break;
                }
                item++;
            }
            //unir materia y docente
            string materiaDoc = $"{modGrado.Row.ItemArray[5].ToString()} - {modGrado.Row.ItemArray[4].ToString()}";
            foreach (DataRowView row in cmbMateriaMod.ItemsSource)
            {
                if (row.Row.ItemArray[1].ToString() == materiaDoc)
                {
                    item++;
                    cmbMateriaMod.SelectedIndex = item;
                    item = -1;
                    break;
                }
                item++;
            }
        }

        private void BtnCanModGrado_Click(object sender, RoutedEventArgs e)
        {
            tbGeneralGraddos.SelectedIndex = 0;
            CrearGrado.IsEnabled = true;
            ModificarGrado.IsEnabled = false;
            ListaGrados.IsEnabled = true;
            tbEliminar.IsEnabled = true;
            LimpiarCampos();
            aCancelar.Height = 50;
            aCancelar.Width = 200;
            stAlertasExito.Children.Add(aCancelar);
            EjecutarAlerta();
        }

        private void btnModificarGradoMod_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomGradoMod.Text.Equals(string.Empty) || cmbSeccionMod.Text.Equals(string.Empty) || cmbAlumnoMod.Text.Equals(string.Empty) || cmbMateriaMod.Text.Equals(string.Empty))
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
                Grado oGrado = new Grado();
                DataRowView rowAlumno = (DataRowView)cmbAlumnoMod.SelectedItem;
                DataRowView rowMateria = (DataRowView)cmbMateriaMod.SelectedItem;

                oGrado.IdGrado = IdGrado;
                oGrado.NombreGrado = txtNomGradoMod.Text;
                oGrado.Seccion = cmbSeccionMod.Text;
                oGrado.IdAlumno = (int)rowAlumno.Row.ItemArray[0];
                oGrado.IdMateria = (int)rowMateria.Row.ItemArray[0];
                bool resultado = nGrado.ModificarGrado(oGrado);
                if (resultado)
                {
                    LimpiarCampos();
                    tbGeneralGraddos.SelectedIndex = 0;
                    CrearGrado.IsEnabled = true;
                    ModificarGrado.IsEnabled = false;
                    ListaGrados.IsEnabled = true;
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

        private void btnEliminarGrado_Click(object sender, RoutedEventArgs e)
        {
            Notificacion not = new Notificacion();
            ucEliminar aEliminar = new ucEliminar(not);
            DataRowView row = (DataRowView)dtGrados.SelectedItem;
            IdGrado = (int)row.Row.ItemArray[0];
            aEliminar.ShowDialog();
            var resultado = not.valor_confirmacion;
            if (resultado.Equals("Ok"))
            {
                bool respuesta = nGrado.EliminarGrado(IdGrado);
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
            DataRowView row = (DataRowView)dtGradosEli.SelectedItem;
            IdGrado = (int)row.Row.ItemArray[0];
            bool respuesta = nGrado.ActivarGrado(IdGrado);
            if (respuesta)
            {
                CargarMaterias();
                tbGeneralGraddos.SelectedIndex = 0;
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

        private void btnBuscarEli_Click(object sender, RoutedEventArgs e)
        {
            dtGradosEli.DataContext = nGrado.FiltrarGradosEliminados(txtFiltrarEli.Text);  
        }
    }
}
