using LogicaNegocio.Interfaces;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Formulario de consulta de catálogo con vista Maestro-Detalle.
    /// <br/>
    /// <b>RESPONSABILIDAD:</b> Mostrar la lista de documentos (Maestro) y, al seleccionar uno,
    /// mostrar dinámicamente sus ejemplares físicos asociados (Detalle).
    /// </summary>
    public partial class FListadoDocumentos : Form
    {
        // ==========================================
        // ATRIBUTOS Y REFERENCIAS
        // ==========================================

        /// <summary>Intermediario para enlazar la lista de documentos al Grid superior.</summary>
        private BindingSource bsDocumentos;

        /// <summary>Intermediario para enlazar la lista de ejemplares al Grid inferior.</summary>
        private BindingSource bsEjemplares;

        /// <summary>Referencia a la Lógica de Negocio para realizar consultas.</summary>
        private IPersonalAdquisicionesLN pAd;

        /// <summary>
        /// Constructor principal.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Inicializa los componentes, crea los BindingSources y carga la vista inicial.
        /// </remarks>
        /// <param name="pAd">Fachada de Lógica de Negocio (Inyección de Dependencias).</param>
        /// <param name="documentos">Lista inicial de documentos a mostrar.</param>
        public FListadoDocumentos(IPersonalAdquisicionesLN pAd, List<Documento> documentos)
        {
            InitializeComponent();
            this.pAd = pAd;

            // 1. Instanciar los BindingSources ANTES de usarlos
            this.bsDocumentos = new BindingSource();
            this.bsEjemplares = new BindingSource();

            // 2. Configurar el Grid de Detalle (Inferior) primero
            this.IniciarEjemplares();

            // 3. Configurar y Cargar el Grid Maestro (Superior)
            this.IniciarDocumentos(documentos);
        }

        /// <summary>
        /// Constructor para una vista de lista simple de documentos.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Inicializa los componentes y muestra solo la lista de documentos, sin la funcionalidad de detalle.
        /// </remarks>
        /// <param name="documentos">Lista de documentos a mostrar.</param>
        public FListadoDocumentos(List<Documento> documentos)
        {
            InitializeComponent();
            this.pAd = null; // No se necesita LN para esta vista

            this.bsDocumentos = new BindingSource();
            this.bsEjemplares = new BindingSource();

            // Ocultar la vista de detalles
            this.dataGridEjemplares.Visible = false;
            this.dataGridEjemplares.Enabled = false;

            // Configurar y cargar solo el grid maestro
            this.IniciarDocumentos(documentos);

            // Desactivar el evento de cambio para evitar errores
            if (this.bsDocumentos != null)
            {
                this.bsDocumentos.CurrentChanged -= BsDocumentos_CurrentChanged;
            }
        }


        // ==========================================
        // GESTIÓN DEL GRID MAESTRO (DOCUMENTOS)
        // ==========================================

        /// <summary>
        /// Configura el DataGridView de documentos y carga los datos iniciales.
        /// </summary>
        public void IniciarDocumentos(List<Documento> documentos)
        {



            // A. Configuración Visual
            this.dataGridDocumento.AutoGenerateColumns = true;
            this.dataGridDocumento.ReadOnly = true;
            this.dataGridDocumento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDocumento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDocumento.AllowUserToAddRows = false; // ✅ Evita fila vacía al final


            // D. Suscripción a Eventos (Antes de quese carguen los datos, para qeu etecte el cambio)
            this.bsDocumentos.CurrentChanged += BsDocumentos_CurrentChanged;

            // B. Carga de Datos
            this.bsDocumentos.DataSource = new BindingList<Documento>(documentos);
            this.dataGridDocumento.DataSource = this.bsDocumentos;

            // C. Personalización (Después de cargar datos)
            PersonalizarColumnas();

            
        }

        /// <summary>
        /// Ajusta los nombres de las columnas del grid de documentos para que sean legibles.
        /// </summary>
        private void PersonalizarColumnas()
        {
            // ✅ CORREGIDO: Cada columna con su propio DisplayIndex
            if (this.dataGridDocumento.Columns["ISBN"] != null)
            {
                this.dataGridDocumento.Columns["ISBN"].HeaderText = "ISBN";
                this.dataGridDocumento.Columns["ISBN"].DisplayIndex = 0;
            }

            if (this.dataGridDocumento.Columns["Titulo"] != null)
            {
                this.dataGridDocumento.Columns["Titulo"].HeaderText = "Título";
                this.dataGridDocumento.Columns["Titulo"].DisplayIndex = 1;
            }

            if (this.dataGridDocumento.Columns["Autor"] != null)
            {
                this.dataGridDocumento.Columns["Autor"].HeaderText = "Autor";
                this.dataGridDocumento.Columns["Autor"].DisplayIndex = 2;
            }

            if (this.dataGridDocumento.Columns["Editorial"] != null)
            {
                this.dataGridDocumento.Columns["Editorial"].HeaderText = "Editorial";
                this.dataGridDocumento.Columns["Editorial"].DisplayIndex = 3;
            }

            if (this.dataGridDocumento.Columns["AnioPublicacion"] != null)
            {
                this.dataGridDocumento.Columns["AnioPublicacion"].HeaderText = "Año";
                this.dataGridDocumento.Columns["AnioPublicacion"].DisplayIndex = 4;
            }

            // ✅ Ocultar columnas específicas de AudioLibro si existen
            if (this.dataGridDocumento.Columns["DuracionMinutos"] != null)
                this.dataGridDocumento.Columns["DuracionMinutos"].Visible = false;

            if (this.dataGridDocumento.Columns["Formato"] != null)
                this.dataGridDocumento.Columns["Formato"].Visible = false;
        }

        // ==========================================
        // GESTIÓN DEL GRID DETALLE (EJEMPLARES)
        // ==========================================

        /// <summary>
        /// Configura el DataGridView de ejemplares (Estado inicial vacío/oculto).
        /// </summary>
        public void IniciarEjemplares()
        {
            this.dataGridEjemplares.AutoGenerateColumns = true;
            this.dataGridEjemplares.ReadOnly = true;
            this.dataGridEjemplares.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEjemplares.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEjemplares.AllowUserToAddRows = false; // ✅ Sin fila vacía

            // Enlazamos el BindingSource vacío
            this.dataGridEjemplares.DataSource = this.bsEjemplares;

            // Ocultamos el grid hasta que se seleccione un documento
            this.dataGridEjemplares.Visible = false;
            this.dataGridEjemplares.Enabled = false;
        }

        /// <summary>
        /// Ajusta las columnas del grid de ejemplares una vez cargados los datos.
        /// </summary>
        private void PersonalizarColumnasEjemplares()
        {
            // ✅ CORREGIDO: Formato consistente y legible
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
                this.dataGridEjemplares.Columns["Documento"].Visible = false;

            if (this.dataGridEjemplares.Columns["BajaLogica"] != null)
                this.dataGridEjemplares.Columns["BajaLogica"].Visible = false;
        }

        /// <summary>
        /// Carga los ejemplares correspondientes a un documento específico.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El objeto Documento no es nulo. <br/>
        /// <b>POST:</b> El grid inferior muestra los ejemplares y se hace visible.
        /// </remarks>
        /// <param name="doc">Documento seleccionado en el grid superior.</param>
        public void CargarEjemplaresDocumento(Documento doc)
        {
            if (doc == null)
            {
                // Si no hay documento, ocultar el detalle
                this.bsEjemplares.DataSource = null;
                this.dataGridEjemplares.Visible = false; 
                this.dataGridEjemplares.Enabled = false; 
                return;
            }

            // 1. Obtener datos de la Lógica de Negocio
            var ejemplares = pAd.ConsultarEjemplares(doc.ISBN);

            // 2. Actualizar el BindingSource
            this.bsEjemplares.DataSource = new BindingList<Ejemplar>(ejemplares);

            // 3. Personalizar columnas (tras cargar datos)
            this.PersonalizarColumnasEjemplares();

            // 4. Hacer visible el panel de detalle
            this.dataGridEjemplares.Visible = true;
            this.dataGridEjemplares.Enabled = true;
        }

        // ==========================================
        // EVENTOS DE SINCRONIZACIÓN
        // ==========================================

        /// <summary>
        /// Evento que se dispara al cambiar la selección en el Grid Maestro.
        /// </summary>
        private void BsDocumentos_CurrentChanged(object sender, EventArgs e)
        {
            if (bsDocumentos.Current is Documento doc)
            {
                this.CargarEjemplaresDocumento(doc);
            }
            else
            {
                // Si no hay selección válida, ocultar el detalle
                this.bsEjemplares.DataSource = null;
                this.dataGridEjemplares.Visible = false;
                this.dataGridEjemplares.Enabled = false;
            }
        }

        /// <summary>
        /// Fuerza un repintado de ambos grids. Útil tras operaciones externas.
        /// </summary>
        public void ActualizarDataGrid()
        {
            this.bsDocumentos.ResetBindings(false);
            this.bsEjemplares.ResetBindings(false);
        }
    }
}