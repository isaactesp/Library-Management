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
    /// Formulario para navegar una lista de usuarios uno por uno.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Mostrar los datos de una lista de usuarios
    /// y permitir la navegación entre ellos mediante un <see cref="BindingNavigator"/>.
    /// </para>
    /// </summary>
    public partial class FBusqueda1a1 : Form
    {
        private BindingSource bindingSource;
        public FBusqueda1a1()
        {
            InitializeComponent();
            this.Text = "Recorrido de usuarios 1 a 1";

        }

        public FBusqueda1a1(List<Usuario> usuarios) : this()
        {
            bindingSource = new BindingSource();
            bindingSource.DataSource = usuarios;

            bindingNavUsuarios.BindingSource = bindingSource;
            ConfigurarEnlaces();

        }

        private void ConfigurarEnlaces()
        {
            textBoxDNI.DataBindings.Add(new Binding("Text", bindingSource, "Dni", true));
            textBoxNombre.DataBindings.Add(new Binding("Text", bindingSource, "Nombre", true));
            
            textBoxDNI.ReadOnly = true;
            textBoxNombre.ReadOnly = true;


        }

    }
}
