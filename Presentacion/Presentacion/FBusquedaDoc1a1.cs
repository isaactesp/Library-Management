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
    /// Formulario para navegar una lista de documentos uno por uno, mostrando
    /// campos específicos según si el documento es un Libro o un AudioLibro.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Permitir el recorrido de una colección de documentos,
    /// adaptando la interfaz para mostrar detalles adicionales para subtipos como <see cref="AudioLibro"/>.
    /// </para>
    /// </summary>
    public partial class FBusquedaDoc1a1 : Form
    {
        private BindingSource bindingSource;

        public FBusquedaDoc1a1()
        {
            InitializeComponent();
            this.Text = "Recorrido de documentos 1 a 1";
        }

        public FBusquedaDoc1a1(List<Documento> documentos) : this()
        {
            bindingSource = new BindingSource();
            bindingSource.DataSource = documentos;

            bindingNavDocs.BindingSource = bindingSource;

            ConfigurarEnlaces();
            ActualizarCamposEspecificos();

            // Cuando cambias de documento en el navegador, actualizamos tipo y campos extra
            bindingSource.PositionChanged += (s, e) => ActualizarCamposEspecificos();
        }

        private void ConfigurarEnlaces()
        {
            // Comunes
            txtISBN.DataBindings.Add(new Binding("Text", bindingSource, "ISBN", true));
            txtTitulo.DataBindings.Add(new Binding("Text", bindingSource, "Titulo", true));
            txtAutor.DataBindings.Add(new Binding("Text", bindingSource, "Autor", true));
            txtEditorial.DataBindings.Add(new Binding("Text", bindingSource, "Editorial", true));
            txtAnio.DataBindings.Add(new Binding("Text", bindingSource, "AnioPublicacion", true));

            // Solo lectura
            txtISBN.ReadOnly = true;
            txtTitulo.ReadOnly = true;
            txtAutor.ReadOnly = true;
            txtEditorial.ReadOnly = true;
            txtAnio.ReadOnly = true;

            // Campos específicos (no los bindeamos a propiedades que no existen en Libro)
            txtDuracion.ReadOnly = true;
            txtFormato.ReadOnly = true;
            txtTipo.ReadOnly = true;
        }

        private void ActualizarCamposEspecificos()
        {
            var doc = bindingSource?.Current as Documento;

            if (doc == null)
            {
                txtTipo.Text = "";
                txtDuracion.Text = "";
                txtFormato.Text = "";
                panelAudio.Visible = false;
                return;
            }

            if (doc is AudioLibro a)
            {
                txtTipo.Text = "AudioLibro";
                panelAudio.Visible = true;
                txtDuracion.Text = a.DuracionMinutos.ToString();
                txtFormato.Text = a.Formato ?? "";
            }
            else
            {
                txtTipo.Text = "Libro";
                panelAudio.Visible = false;
                txtDuracion.Text = "";
                txtFormato.Text = "";
            }
        }
    }
}
