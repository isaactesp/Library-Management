using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModeloDominio;

namespace Presentacion
{
    /// <summary>
    /// Formulario que permite buscar un usuario por su DNI dentro de una lista
    /// y muestra su nombre correspondiente.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Facilitar la selección de un usuario a partir de su DNI
    /// en un ComboBox y mostrar el nombre del usuario seleccionado.
    /// </para>
    /// </summary>
    public partial class FBusquedaUsuarioDNI : Form
    {
        private List<Usuario> usuarios;

        public FBusquedaUsuarioDNI(List<Usuario> usuarios)
        {
            InitializeComponent();
            this.usuarios = usuarios;
            CargarDNIs();
        }

        private void CargarDNIs()
        {
            comboBoxDNI.Items.Clear();
            foreach (var usuario in usuarios)
            {
                comboBoxDNI.Items.Add(usuario.DNI);
            }

            if (comboBoxDNI.Items.Count > 0)
                comboBoxDNI.SelectedIndex = 0;
        }

        private void cmbDNI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDNI.SelectedIndex >= 0)
            {
                string dniSeleccionado = comboBoxDNI.SelectedItem.ToString();
                var usuario = usuarios.Find(u => u.DNI == dniSeleccionado);
                if (usuario != null)
                {
                    textNombre.Text = usuario.Nombre;
                }
            }
        }
    }
}
