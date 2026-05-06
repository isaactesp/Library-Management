using LogicaNegocio.Interfaces;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Formulario de Búsqueda de Préstamos.
    /// <para>
    /// Implementa el patrón <b>Maestro-Detalle</b> con búsqueda predictiva.
    /// Utiliza <b>Programación Defensiva</b> para garantizar la robustez ante fallos.
    /// </para>
    /// </summary>
    public partial class FBusquedaPrestamo : Form
    {
        // ==========================================
        // ATRIBUTOS E INYECCIÓN
        // ==========================================
        private readonly IPersonalSalaLN personalSalaLN;
        private BindingSource bsID;
        private BindingSource bsDetalle;
        private BindingSource bsEjemplares;

        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        public FBusquedaPrestamo(IPersonalSalaLN personalSalaLN)
        {
            // Defensa: Validar Inyección
            if (personalSalaLN == null)
                throw new ArgumentNullException(nameof(personalSalaLN), "El servicio de LN no puede ser nulo.");

            InitializeComponent();
            this.personalSalaLN = personalSalaLN;

            try
            {
                ConfigurarBusqueda();
                ConfigurarBindingDetalle();
                ConfigurarBindingListaEjemplares();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // ==========================================
        // CONFIGURACIÓN (PRIVADA)
        // ==========================================
        private void ConfigurarBusqueda()
        {
            this.bsID = new BindingSource();

            var prestamos = this.personalSalaLN.ObtenerTodosPrestamos();

            // Protección contra nulos en LINQ
            List<string> ids = (prestamos ?? new List<Prestamo>())
                               .Select(p => p.IdPrestamo)
                               .ToList();

            this.bsID.DataSource = new BindingList<string>(ids);
            this.cbIdPrestamo.DataSource = this.bsID;

            // UX: Autocompletado
            this.cbIdPrestamo.DropDownStyle = ComboBoxStyle.DropDown;
            this.cbIdPrestamo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbIdPrestamo.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Suscripción al evento de selección manual
            this.cbIdPrestamo.SelectionChangeCommitted += cbIdPrestamo_SelectionChangeCommitted;
        }

        private void ConfigurarBindingDetalle()
        {
            this.bsDetalle = new BindingSource();
            this.bsDetalle.DataSource = typeof(Prestamo);

            // Bindings con formato
            this.txtFecha.DataBindings.Add("Text", bsDetalle, "FechaPrestado", true, DataSourceUpdateMode.OnValidation, "", "dd/MM/yyyy");

            Binding bEstado = new Binding("Text", bsDetalle, "Estado", true);
            bEstado.Format += (s, e) =>
            {
                if (e.Value != null && e.Value is bool val)
                    e.Value = val ? "En proceso" : "Finalizado";
            };
            this.txtEstado.DataBindings.Add(bEstado);

            // Solo lectura
            this.txtFecha.ReadOnly = true;
            this.txtEstado.ReadOnly = true;
            this.txtUsuario.ReadOnly = true;
        }

        private void ConfigurarBindingListaEjemplares()
        {
            this.bsEjemplares = new BindingSource();
            this.lstEjemplares.DataSource = this.bsEjemplares;
            this.lstEjemplares.DisplayMember = "Codigo";
        }

        // ==========================================
        // LÓGICA CORE (EJECUCIÓN)
        // ==========================================
        private void EjecutarBusqueda(string idInput)
        {
            // 1. Saneamiento
            string idLimpio = (idInput ?? string.Empty).Trim();

            // 2. Validación Básica
            if (string.IsNullOrWhiteSpace(idLimpio))
            {
                MessageBox.Show("El campo de ID no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // NOTA: No hacemos .Focus() aquí para evitar bucles con el evento KeyDown
                return;
            }

            // Limpieza preventiva
            LimpiarDetalle();

            // 3. Proceso Seguro
            try
            {
                var prestamo = this.personalSalaLN.ObtenerPrestamoPorId(idLimpio);

                if (prestamo != null)
                {
                    // --- ENCONTRADO ---

                    // A. Binding Simple (Automático)
                    this.bsDetalle.DataSource = prestamo;

                    // B. Usuario (Manual y Defensivo)
                    Usuario u = null;
                    try { u = this.personalSalaLN.ObtenerUsuarioDePrestamo(prestamo); } catch { }

                    this.txtUsuario.Text = (u != null) ? $"{u.Nombre} ({u.DNI})" : "DESCONOCIDO";

                    // C. Binding Complejo (Lista)
                    var listaEjemplares = this.personalSalaLN.ConsultarEjemplaresPrestamo(prestamo);
                    if (listaEjemplares == null) listaEjemplares = new List<Ejemplar>();

                    this.bsEjemplares.DataSource = new BindingList<Ejemplar>(listaEjemplares);
                }
                else
                {
                    // --- NO ENCONTRADO ---
                    MessageBox.Show($"No se encontró el préstamo: {idLimpio}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Aquí es seguro seleccionar el texto porque el MessageBox ya se cerró
                    this.cbIdPrestamo.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de sistema: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarDetalle();
            }
        }

        private void LimpiarDetalle()
        {
            // Al resetear el DataSource, los TextBoxes enlazados (Fecha, Estado) se limpian solos.
            this.bsDetalle.DataSource = typeof(Prestamo);

            // Los no enlazados hay que limpiarlos a mano
            this.txtUsuario.Clear();

            // La lista se limpia poniendo null
            this.bsEjemplares.DataSource = null;
        }

        // ==========================================
        // EVENTOS
        // ==========================================
        private void btBuscar_Click(object sender, EventArgs e)
        {
            this.EjecutarBusqueda(this.cbIdPrestamo.Text);
        }

        private void cbIdPrestamo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // VITAL: Esto evita el sonido "Ding" y previene el rebote del evento
                e.SuppressKeyPress = true;
                this.btBuscar.PerformClick();
            }
        }

        private void cbIdPrestamo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.btBuscar.PerformClick();
        }
    }
}