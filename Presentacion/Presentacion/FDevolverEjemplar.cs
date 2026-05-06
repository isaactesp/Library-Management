using LogicaNegocio.Interfaces;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Formulario para gestionar la devolución de un ejemplar prestado.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Permitir al personal de sala seleccionar un préstamo activo,
    /// elegir uno de los ejemplares asociados a dicho préstamo y ejecutar la operación
    /// de devolución a través de la lógica de negocio.
    /// </para>
    /// </summary>
    public partial class FDevolverEjemplar : Form
    {
        private readonly IPersonalSalaLN pSalaLN;
        private List<Prestamo> prestamosActivos;
        private List<Ejemplar> ejemplaresDelPrestamo;

        public FDevolverEjemplar(IPersonalSalaLN pSalaLN)
        {
            InitializeComponent();
            this.pSalaLN = pSalaLN;
        }

        private void FDevolverEjemplar_Load(object sender, EventArgs e)
        {
            CargarPrestamosActivos();
            cbPrestamos.SelectedIndexChanged += new EventHandler(cbPrestamos_SelectedIndexChanged);
        }

        private void CargarPrestamosActivos()
        {
            // Nota: IPersonalSalaLN no tiene un método directo. Lo implementamos aquí.
            // Esto podría ser refactorizado a la capa de Lógica de Negocio si se usa en más sitios.
            var todosLosPrestamos = pSalaLN.ObtenerTodosPrestamos(); // Asumiendo que este método existe o se crea
            prestamosActivos = todosLosPrestamos.Where(p => p.Estado).ToList();

            cbPrestamos.DataSource = prestamosActivos;
            cbPrestamos.DisplayMember = "IdPrestamo";

            if (prestamosActivos.Count == 0)
            {
                MessageBox.Show("No hay préstamos activos para devolver.");
                btnDevolver.Enabled = false;
                cbEjemplares.Enabled = false;
            }
        }

        private void cbPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Prestamo prestamoSeleccionado = cbPrestamos.SelectedItem as Prestamo;
            if (prestamoSeleccionado != null)
            {
                CargarEjemplaresDelPrestamo(prestamoSeleccionado);
            }
        }

        private void CargarEjemplaresDelPrestamo(Prestamo p)
        {
            ejemplaresDelPrestamo = pSalaLN.ConsultarEjemplaresPrestamo(p).Where(e => e.Prestado).ToList();
            
            cbEjemplares.DataSource = ejemplaresDelPrestamo;
            cbEjemplares.DisplayMember = "Codigo";

            cbEjemplares.Enabled = ejemplaresDelPrestamo.Count > 0;
            btnDevolver.Enabled = ejemplaresDelPrestamo.Count > 0;
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            Prestamo prestamoSeleccionado = cbPrestamos.SelectedItem as Prestamo;
            Ejemplar ejemplarSeleccionado = cbEjemplares.SelectedItem as Ejemplar;

            if (prestamoSeleccionado == null || ejemplarSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un préstamo y un ejemplar.");
                return;
            }

            try
            {
                pSalaLN.DevolverEjemplar(prestamoSeleccionado, ejemplarSeleccionado);
                MessageBox.Show($"Ejemplar '{ejemplarSeleccionado.Codigo}' devuelto correctamente.");
                
                // Recargar la lista de ejemplares del préstamo actual
                CargarEjemplaresDelPrestamo(prestamoSeleccionado);

                // Si no quedan más ejemplares en este préstamo, podría ser útil recargar todo.
                if (cbEjemplares.Items.Count == 0)
                {
                    CargarPrestamosActivos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al devolver el ejemplar: {ex.Message}");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}