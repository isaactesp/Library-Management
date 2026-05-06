using LogicaNegocio;
using LogicaNegocio.Interfaces;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Formulario para la creación de un nuevo préstamo.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Recopilar y validar los datos de un nuevo préstamo (ID, usuario, ejemplares)
    /// y enviarlos a la capa de lógica de negocio para su procesamiento.
    /// </para>
    /// </summary>
    public partial class FAltaPrestamo : Form
    {
        // Interfaces separadas siguiendo ISP (Interface Segregation Principle)
        private readonly IPersonalSalaLN personalSalaLN; 

        private List<Ejemplar> ejemplaresSeleccionados;
        private BindingSource bsEjemplares;

        public FAltaPrestamo(IPersonalSalaLN pSalaLN)
        {
            InitializeComponent();
            personalSalaLN = pSalaLN;
            Text = "Alta de un préstamo";

            ejemplaresSeleccionados = new List<Ejemplar>();

            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Fecha actual (solo lectura)
            txtFecha.Text = DateTime.Now.ToShortDateString();
            txtFecha.ReadOnly = true;

            // Cargar ComboBox de usuarios con sus DNIs (usando IPersonalLN)
            List<Usuario> usuarios = personalSalaLN.ListarUsuarios();
            cbUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUsuarios.Items.Clear();
            foreach (var u in usuarios)
            {
                cbUsuarios.Items.Add(u.DNI);
            }
            if (cbUsuarios.Items.Count > 0)
                cbUsuarios.SelectedIndex = 0;

            // Configurar ListBox de ejemplares con BindingSource
            bsEjemplares = new BindingSource();
            bsEjemplares.DataSource = ejemplaresSeleccionados;
            lstEjemplares.DataSource = bsEjemplares;
            lstEjemplares.DisplayMember = "Codigo";
        }

        private void btnAnadirEjemplar_Click(object sender, EventArgs e)
        {
            // Obtener ejemplares disponibles (no prestados) desde la lógica de negocio
            // Necesitarás un método que devuelva ejemplares disponibles
            List<Ejemplar> disponibles = ObtenerEjemplaresDisponibles();

            // Filtrar los que ya están seleccionados
            disponibles.RemoveAll(ej => ejemplaresSeleccionados.Exists(sel => sel.Codigo == ej.Codigo));

            if (disponibles.Count == 0)
            {
                MessageBox.Show("No hay ejemplares disponibles para prestar.");
                return;
            }

            // Abrir formulario de selección
            using (var fSeleccionar = new FSeleccionarEjemplar(disponibles))
            {
                if (fSeleccionar.ShowDialog() == DialogResult.OK)
                {
                    Ejemplar seleccionado = fSeleccionar.EjemplarSeleccionado;
                    if (seleccionado != null)
                    {
                        ejemplaresSeleccionados.Add(seleccionado);
                        bsEjemplares.ResetBindings(false); // Actualiza la vista
                    }
                }
            }
        }


        private List<Ejemplar> ObtenerEjemplaresDisponibles()
        {
            return personalSalaLN.ObtenerEjemplaresDisponibles();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe introducir un ID de préstamo.");
                return;
            }

            if (cbUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }

            if (ejemplaresSeleccionados.Count == 0)
            {
                MessageBox.Show("Debe añadir al menos un ejemplar.");
                return;
            }

            // Crear el préstamo
            string idPrestamo = txtId.Text.Trim();
            string dniUsuario = cbUsuarios.SelectedItem.ToString();

            Prestamo nuevoPrestamo = new Prestamo(idPrestamo, true, DateTime.Now);
            Usuario usuario = personalSalaLN.BuscarUsuario(dniUsuario);  // Usa IPersonalLN

            // Llamar a la lógica de negocio
            bool exito = personalSalaLN.IniciarPrestamo(nuevoPrestamo, ejemplaresSeleccionados, usuario);

            if (exito)
            {
                MessageBox.Show("Préstamo registrado correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el préstamo.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


    }
}
