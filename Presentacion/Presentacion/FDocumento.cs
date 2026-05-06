using ModeloDominio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Formulario de presentación para el alta y la consulta de documentos
    /// (Libros y Audiolibros) del sistema de biblioteca.
    /// <br/>
    /// <b>RESPONSABILIDAD:</b>
    /// Formulario de presentación para introducir, validar y mostrar la información
    /// de un documento (Libro o Audiolibro).
    /// </summary>
    public partial class FDocumento : Form
    {
        // ==========================================
        // PROPIEDADES (Safe Getters)
        // ==========================================

        public string Isbn { get { return txtISBN.Text.Trim(); } }
        public string Titulo { get { return txtTitulo.Text.Trim(); } }
        public string Autor { get { return txtAutor.Text.Trim(); } }
        public string Editorial { get { return txtEditorial.Text.Trim(); } }

        public int AnoPublicacion
        {
            get
            {
                // Parseo seguro: si falla devuelve 0, validamos en el botón Aceptar
                int.TryParse(txtAnoPublicacion.Text, out int val);
                return val;
            }
        }

        public int DuracionMinutos
        {
            get
            {
                // CORREGIDO: Eliminada la excepción. Parseo seguro.
                int.TryParse(txtDuracion.Text.Trim(), out int dur);
                return dur;
            }
        }

        public string Formato { get { return txtFormato.Text.Trim(); } }
        public bool EsAudiolibro { get { return rbAudioLibro.Checked; } }


        // ==========================================
        // CONSTRUCTORES
        // ==========================================

        /// <summary>
        /// Constructor del formulario en modo ALTA.
        /// </summary>
        public FDocumento(string isbn)
        {
            InitializeComponent();
            InicializarComponentesComunes(); // 1. Configuración base

            // 2. Configuración específica para ALTA
            Text = "Alta de documento";
            txtISBN.Text = isbn;

            btAceptar.Text = "Dar alta";
            btCancelar.Text = "Cancelar";
            btCancelar.Visible = true;
        }

        /// <summary>
        /// Constructor del formulario en modo CONSULTA.
        /// </summary>
        public FDocumento(Documento doc)
        {
            if (doc == null) throw new ArgumentNullException(nameof(doc));

            InitializeComponent();
            InicializarComponentesComunes(); // 1. Configuración base

            // 2. Configuración específica para CONSULTA
            Text = "Consultar documento";

            // Cargar datos
            txtISBN.Text = doc.ISBN;
            txtTitulo.Text = doc.Titulo;
            txtAutor.Text = doc.Autor;
            txtEditorial.Text = doc.Editorial;
            txtAnoPublicacion.Text = doc.AnioPublicacion.ToString();

            if (doc is AudioLibro a)
            {
                rbAudioLibro.Checked = true;
                txtDuracion.Text = a.DuracionMinutos.ToString();
                txtFormato.Text = a.Formato;
            }
            else
            {
                rbLibro.Checked = true;
            }

            // Bloquear y ajustar botones
            BloquearEdicion();

            btAceptar.Text = "Cerrar";
            btCancelar.Visible = false;

            // Reemplazar evento del botón Aceptar para que solo cierre
            btAceptar.Click -= btAceptar_Click;
            btAceptar.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
        }

        // ==========================================
        // MÉTODOS AUXILIARES Y EVENTOS
        // ==========================================

        /// <summary>
        /// Configuración común para ambos modos (Alta y Consulta).
        /// Suscribe eventos y establece el estado visual inicial.
        /// </summary>
        private void InicializarComponentesComunes()
        {
            // El ISBN siempre es de solo lectura (viene de fuera)
            txtISBN.ReadOnly = true;

            // Suscripción a eventos de cambio de tipo
            rbLibro.CheckedChanged += (s, e) => ActualizarCamposPorTipo();
            rbAudioLibro.CheckedChanged += (s, e) => ActualizarCamposPorTipo();

            // Estado visual inicial
            ActualizarCamposPorTipo();
        }

        private void BloquearEdicion()
        {
            txtTitulo.ReadOnly = true;
            txtAutor.ReadOnly = true;
            txtEditorial.ReadOnly = true;
            txtAnoPublicacion.ReadOnly = true;
            txtDuracion.ReadOnly = true;
            txtFormato.ReadOnly = true;

            rbLibro.Enabled = false;
            rbAudioLibro.Enabled = false;
        }

        private void ActualizarCamposPorTipo()
        {
            panelAudio.Visible = EsAudiolibro;

            if (!EsAudiolibro)
            {
                txtDuracion.Text = "";
                txtFormato.Text = "";
            }
        }

        // ==========================================
        // BOTONES
        // ==========================================

        private void btAceptar_Click(object sender, EventArgs e)
        {
            // VALIDACIONES DE UI
            if (string.IsNullOrWhiteSpace(Titulo) ||
                string.IsNullOrWhiteSpace(Autor) ||
                string.IsNullOrWhiteSpace(Editorial))
            {
                MessageBox.Show("Debe rellenar título, autor y editorial.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación usando TryParse directo (la propiedad es segura ahora)
            if (!int.TryParse(txtAnoPublicacion.Text.Trim(), out int anio) || anio <= 0)
            {
                MessageBox.Show("El año de publicación debe ser un número válido.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnoPublicacion.Focus();
                return;
            }

            if (!rbAudioLibro.Checked && !rbLibro.Checked)
            {
                MessageBox.Show("Selecciona un tipo de documento.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (EsAudiolibro)
            {
                if (!int.TryParse(txtDuracion.Text.Trim(), out int dur) || dur <= 0)
                {
                    MessageBox.Show("La duración debe ser un número válido (minutos).", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDuracion.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(Formato))
                {
                    MessageBox.Show("Debe introducir el formato del audiolibro.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFormato.Focus();
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Eventos vacíos generados por el diseñador (se pueden borrar si no se usan)
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}