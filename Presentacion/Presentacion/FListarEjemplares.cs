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
    /// Formulario para mostrar un listado de ejemplares en un DataGridView.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Visualizar una lista de objetos <see cref="Ejemplar"/>,
    /// personalizando las columnas para una presentación clara de los datos.
    /// </para>
    /// </summary>
    public partial class FListarEjemplares : Form
    {
        private BindingSource bsEjemplares = new BindingSource();
        public FListarEjemplares(List<Ejemplar> ejemplares)
        {
            InitializeComponent();

            this.bsEjemplares.DataSource = new BindingList<Ejemplar>(ejemplares);
            this.dataGridEjemplares.DataSource = this.bsEjemplares;

            this.PersonalizarColumnasEjemplares();

        }

        /// <summary>
        /// Ajusta las columnas del grid de ejemplares una vez cargados los datos.
        /// </summary>
        private void PersonalizarColumnasEjemplares()
        {
            if (this.dataGridEjemplares.Columns["Codigo"] != null)
            {
                this.dataGridEjemplares.Columns["Codigo"].HeaderText = "Código";
                this.dataGridEjemplares.Columns["Codigo"].DisplayIndex = 0;
            }

            if (this.dataGridEjemplares.Columns["Prestado"] != null)
            {
                this.dataGridEjemplares.Columns["Prestado"].HeaderText = "¿En Préstamo?";
                this.dataGridEjemplares.Columns["Prestado"].DisplayIndex = 1;
            }

            if (this.dataGridEjemplares.Columns["VecesPrestado"] != null)
            {
                this.dataGridEjemplares.Columns["VecesPrestado"].HeaderText = "Hist. Préstamos";
                this.dataGridEjemplares.Columns["VecesPrestado"].DisplayIndex = 2;
            }

            // Ocultar columnas redundantes o internas
            if (this.dataGridEjemplares.Columns["Documento"] != null)
            {
                this.dataGridEjemplares.Columns["Documento"].DisplayIndex = 3;
            }

            if (this.dataGridEjemplares.Columns["BajaLogica"] != null)
                this.dataGridEjemplares.Columns["BajaLogica"].Visible = false;
        }


    }
}
