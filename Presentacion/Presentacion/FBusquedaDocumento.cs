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
    /// Formulario para buscar un documento por su ISBN y ver sus detalles.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Permitir al usuario buscar un documento a través de un ComboBox
    /// con autocompletado, mostrar los detalles del documento encontrado y ofrecer la
    /// opción de listar sus ejemplares.
    /// </para>
    /// </summary>
    public partial class FBusquedaDocumento : Form
    {
        // ==========================================
        // ATRIBUTOS E INYECCIÓN
        // ==========================================
        private readonly IPersonalAdquisicionesLN adqLN;
        private BindingSource bsISBNs;
        private Documento documentoActual;

        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        public FBusquedaDocumento(IPersonalAdquisicionesLN adqLN)
        {
            if (adqLN == null)
                throw new ArgumentNullException(nameof(adqLN), "La Lógica de Negocio no puede ser nula.");

            InitializeComponent();
            this.adqLN = adqLN;

            try
            {
                ConfigurarBusqueda();
                ConfigurarEventos();
                LimpiarDetalle(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // ==========================================
        // CONFIGURACIÓN (PRIVADA)
        // ==========================================

        private void ConfigurarBusqueda()
        {
            this.bsISBNs = new BindingSource();
            var documentos = this.adqLN.ListarDocumentos();
            List<string> isbns = (documentos ?? new List<Documento>())
                               .Select(d => d.ISBN)
                               .ToList();

            this.bsISBNs.DataSource = new BindingList<string>(isbns);
            this.cbISBN.DataSource = this.bsISBNs;

            // Configuración del ComboBox para autocompletado
            this.cbISBN.DropDownStyle = ComboBoxStyle.DropDown;
            this.cbISBN.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbISBN.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ConfigurarEventos()
        {
            this.btnBuscar.Click += (s, e) => EjecutarBusqueda(this.cbISBN.Text);
            this.btnCerrar.Click += (s, e) => this.Close();
            this.btnListarEjemplares.Click += new EventHandler(this.btnListarEjemplares_Click);

            // Búsqueda al presionar Enter en el ComboBox
            this.cbISBN.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true; // Evita el "ding" de Windows
                    EjecutarBusqueda(this.cbISBN.Text);
                }
            };
            
            // Búsqueda al seleccionar un elemento de la lista
            this.cbISBN.SelectionChangeCommitted += (s, e) => EjecutarBusqueda(this.cbISBN.Text);
        }


        // ==========================================
        // LÓGICA CORE
        // ==========================================
        private void EjecutarBusqueda(string isbnInput)
        {
            string isbnLimpio = (isbnInput ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(isbnLimpio))
            {
                MessageBox.Show("El campo ISBN no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LimpiarDetalle();

            try
            {
                documentoActual = this.adqLN.BuscarDocumento(isbnLimpio);

                if (documentoActual != null)
                {
                    ActualizarDetalle(documentoActual);
                    this.btnListarEjemplares.Enabled = true;
                }
                else
                {
                    MessageBox.Show($"No se encontró ningún documento con el ISBN: {isbnLimpio}", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cbISBN.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error al buscar el documento: {ex.Message}", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarDetalle();
            }
        }

        private void ActualizarDetalle(Documento doc)
        {
            txtTitulo.Text = doc.Titulo;
            txtAutor.Text = doc.Autor;
            txtEditorial.Text = doc.Editorial;
            txtAnoPublicacion.Text = doc.AnioPublicacion.ToString();

            if (doc is AudioLibro audio)
            {
                rbAudioLibro.Checked = true;
                panelAudio.Visible = true;
                txtDuracion.Text = audio.DuracionMinutos.ToString();
                txtFormato.Text = audio.Formato;
            }
            else
            {
                rbLibro.Checked = true;
                panelAudio.Visible = false;
                txtDuracion.Text = "";
                txtFormato.Text = "";
            }
        }

        private void LimpiarDetalle()
        {
            documentoActual = null;
            txtTitulo.Clear();
            txtAutor.Clear();
            txtEditorial.Clear();
            txtAnoPublicacion.Clear();
            txtDuracion.Clear();
            txtFormato.Clear();
            rbLibro.Checked = false;
            rbAudioLibro.Checked = false;
            panelAudio.Visible = false;
            this.btnListarEjemplares.Enabled = false;
        }

        // ==========================================
        // EVENTOS DE BOTONES ADICIONALES
        // ==========================================
        private void btnListarEjemplares_Click(object sender, EventArgs e)
        {
            if (documentoActual == null)
            {
                MessageBox.Show("Primero debe buscar y encontrar un documento.", "Acción no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var ejemplares = adqLN.ConsultarEjemplares(documentoActual.ISBN);
                if (ejemplares == null || !ejemplares.Any())
                {
                    MessageBox.Show("Este documento no tiene ejemplares registrados.", "Sin Ejemplares", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Usamos el FListarEjemplares que ya existe
                var formListado = new FListarEjemplares(ejemplares);
                formListado.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar los ejemplares: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbISBN_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
            this.btnBuscar.PerformClick();

        }
    }
}