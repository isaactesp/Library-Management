using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // Necesario para OrderBy
using System.Windows.Forms;
using ModeloDominio;

namespace Presentacion
{
    /// <summary>
    /// Formulario que muestra un listado de usuarios en dos ListBox sincronizadas,
    /// una para el DNI y otra para el Nombre, permitiendo la ordenación por ambos campos.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Visualizar una lista de usuarios de forma sincronizada
    /// y permitir al usuario reordenar dicha lista.
    /// </para>
    /// </summary>
    public partial class FListadoUsuarios : Form
    {
        private BindingSource bsUsuarios;

        public FListadoUsuarios(List<Usuario> usuarios)
        {
            InitializeComponent();

            // 1. Crear el intermediario local
            this.bsUsuarios = new BindingSource();

            // 2. Cargar los datos. Usar BindingList es buena idea para actualizaciones.
            this.bsUsuarios.DataSource = new BindingList<Usuario>(usuarios);

            // 3. Enlazamos los controles, no los rellenamos.
            // Al enlazar AMBOS al MISMO bsUsuarios, se sincronizan solos.

            // Configurar lista DNI
            lstDNI.DataSource = this.bsUsuarios;
            lstDNI.DisplayMember = "DNI"; // Nombre exacto de la propiedad en la clase Usuario

            // Configurar lista Nombre
            lstNombre.DataSource = this.bsUsuarios;
            lstNombre.DisplayMember = "Nombre";
        }

        private void btnOrdenarDNI_Click(object sender, EventArgs e)
        {
            // 1. Sacamos la lista, la ordenamos y la convertimos a lista normal
            var listaOrdenada = ((BindingList<Usuario>)bsUsuarios.DataSource)
                                .OrderBy(u => u.DNI)
                                .ToList();

            // 2. Reasignamos al DataSource. 
            // Los ListBox detectan el cambio y se repintan SOLOS automáticamente.
            bsUsuarios.DataSource = new BindingList<Usuario>(listaOrdenada);
        }

        private void btnOrdenarNombre_Click(object sender, EventArgs e)
        {
            var listaOrdenada = ((BindingList<Usuario>)bsUsuarios.DataSource)
                                .OrderBy(u => u.Nombre)
                                .ToList();

            bsUsuarios.DataSource = new BindingList<Usuario>(listaOrdenada);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
