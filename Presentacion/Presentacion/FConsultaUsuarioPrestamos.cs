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
    /// Formulario para consultar los préstamos de un usuario específico.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Permitir la selección de un usuario y, para ese usuario,
    /// listar los ejemplares que tiene actualmente en préstamo y los documentos vencidos.
    /// </para>
    /// </summary>
    public partial class FConsultaUsuarioPrestamos : Form
    {
        private IPersonalSalaLN pSalaLN;
        private Usuario usuarioSeleccionado;
        private BindingSource bindingSourceUsuarios = new BindingSource();

        public FConsultaUsuarioPrestamos(IPersonalSalaLN pSalaLN)
        {
            InitializeComponent();
            this.pSalaLN = pSalaLN;
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            List<Usuario> usuarios = this.pSalaLN.ListarUsuarios();
            bindingSourceUsuarios.DataSource = usuarios;

            // Configurar ComboBox
            this.comboDNI.DataSource = bindingSourceUsuarios;
            this.comboDNI.DisplayMember = "DNI";
            this.comboDNI.ValueMember = "DNI";
            this.comboDNI.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.comboDNI.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Limpiar selección inicial
            this.comboDNI.SelectedIndex = -1;
            this.lblNombreUsuario.Text = "";
        }

        private void comboDNI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboDNI.SelectedItem is Usuario usuario)
            {
                this.usuarioSeleccionado = usuario;
                this.lblNombreUsuario.Text = usuario.Nombre;
                this.btnListarEjemplares.Enabled = true;
                this.btnListarVencidos.Enabled = true;
            }
            else
            {
                this.usuarioSeleccionado = null;
                this.lblNombreUsuario.Text = "";
                this.btnListarEjemplares.Enabled = false;
                this.btnListarVencidos.Enabled = false;
            }
        }

        private void btnListarEjemplares_Click(object sender, EventArgs e)
        {
            if (this.usuarioSeleccionado == null) return;

            var prestamos = this.pSalaLN.ObtenerPrestamosDeUsuario(this.usuarioSeleccionado);
            var prestamosActivos = prestamos.Where(p => p.Estado).ToList();

            if (prestamosActivos.Count == 0)
            {
                MessageBox.Show("El usuario no tiene préstamos activos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var todosLosEjemplares = new List<Ejemplar>();
            foreach (var p in prestamosActivos)
            {
                todosLosEjemplares.AddRange(this.pSalaLN.ConsultarEjemplaresPrestamo(p));
            }

            if (todosLosEjemplares.Count == 0)
            {
                MessageBox.Show("El usuario no tiene ejemplares prestados actualmente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var fListado = new FListarEjemplares(todosLosEjemplares);
            fListado.ShowDialog();
        }

        private void btnListarVencidos_Click(object sender, EventArgs e)
        {
            if (this.usuarioSeleccionado == null) return;

            var prestamosVencidos = this.pSalaLN.ConsultarVencidos();
            var prestamosVencidosUsuario = new List<Prestamo>();

            foreach (var p in prestamosVencidos)
            {
                // Este método puede ser lento si hay muchos préstamos vencidos,
                // pero es la única forma de obtener el usuario de un préstamo con el modelo actual.
                Usuario usuarioDelPrestamo = this.pSalaLN.ObtenerUsuarioDePrestamo(p);
                if (usuarioDelPrestamo != null && usuarioDelPrestamo.Equals(this.usuarioSeleccionado))
                {
                    prestamosVencidosUsuario.Add(p);
                }
            }

            if (prestamosVencidosUsuario.Count == 0)
            {
                MessageBox.Show("El usuario no tiene documentos vencidos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var documentosVencidos = new List<Documento>();
            foreach (var p in prestamosVencidosUsuario)
            {
                var ejemplares = this.pSalaLN.ConsultarEjemplaresPrestamo(p);
                foreach (var ej in ejemplares)
                {
                    documentosVencidos.Add(ej.Documento);
                }
            }
            
            var documentosUnicos = documentosVencidos.Distinct().ToList();

            var fListado = new FListadoDocumentos(documentosUnicos);
            fListado.ShowDialog();
        }
    }
}
