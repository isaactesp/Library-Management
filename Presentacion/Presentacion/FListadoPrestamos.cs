using LogicaNegocio.Interfaces;
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
    /// Formulario para mostrar un listado completo de todos los préstamos del sistema.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Obtener todos los préstamos a través de la lógica de negocio,
    /// enriquecerlos con los datos del usuario asociado y mostrarlos en un DataGridView.
    /// </para>
    /// </summary>
    public partial class FListadoPrestamos : Form
    {
        IPersonalSalaLN pSala;
        public FListadoPrestamos(IPersonalSalaLN pSala)
        {
            InitializeComponent();
            this.pSala = pSala;
        }

        private void FListadoPrestamos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            var todosLosPrestamos = pSala.ObtenerTodosPrestamos();
            
            var dataSource = todosLosPrestamos.Select(p => {
                var usuario = pSala.ObtenerUsuarioDePrestamo(p);
                return new
                {
                    PrestamoId = p.IdPrestamo,
                    Fecha = p.FechaPrestado.ToShortDateString(),
                    Estado = p.Estado ? "En Proceso" : "Finalizado",
                    UsuarioDni = usuario?.DNI ?? "N/A",
                    UsuarioNombre = usuario?.Nombre ?? "N/A"
                };
            }).ToList();

            dgvPrestamos.DataSource = dataSource;
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvPrestamos.ReadOnly = true;
            dgvPrestamos.AllowUserToAddRows = false;
            dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPrestamos.Columns["PrestamoId"].HeaderText = "ID Préstamo";
            dgvPrestamos.Columns["Fecha"].HeaderText = "Fecha";
            dgvPrestamos.Columns["Estado"].HeaderText = "Estado";
            dgvPrestamos.Columns["UsuarioDni"].HeaderText = "DNI Usuario";
            dgvPrestamos.Columns["UsuarioNombre"].HeaderText = "Nombre Usuario";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

