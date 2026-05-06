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
    /// Formulario de diálogo para seleccionar un ejemplar de una lista de disponibles.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Mostrar una lista de ejemplares disponibles en un ComboBox
    /// y devolver el ejemplar seleccionado por el usuario.
    /// </para>
    /// </summary>
    public partial class FSeleccionarEjemplar : Form
        {
            public Ejemplar EjemplarSeleccionado { get; private set; }
            private List<Ejemplar> ejemplaresDisponibles;

            public FSeleccionarEjemplar(List<Ejemplar> disponibles)
            {
                InitializeComponent();

                this.ejemplaresDisponibles = disponibles;
                Text = "Añadir ejemplar";

                btnAceptar.Click += new EventHandler(btnAceptar_Click);

                ConfigurarCombo();
            }

            private void ConfigurarCombo()
            {
                
                cbEjemplares.DropDownStyle = ComboBoxStyle.DropDownList;
                cbEjemplares.Items.Clear();

                foreach (var ej in ejemplaresDisponibles)
                {

                    // Mostrar info útil: Código + ISBN + Título
                    string display = ej.ToString();
                    cbEjemplares.Items.Add(display);
                }

                if (cbEjemplares.Items.Count > 0)
                    cbEjemplares.SelectedIndex = 0;
            }

            private void btnAceptar_Click(object sender, EventArgs e)
            {
                if (cbEjemplares.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un ejemplar.");
                    return;
                }

                EjemplarSeleccionado = ejemplaresDisponibles[cbEjemplares.SelectedIndex];
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    
}
