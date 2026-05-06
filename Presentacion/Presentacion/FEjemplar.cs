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
    /// Formulario de presentación para el alta y la consulta de ejemplares.
    /// </summary>
    /// <remarks>
    /// <b>RESPONSABILIDAD:</b>
    /// Recoger, mostrar y validar la información de un ejemplar,
    /// diferenciando entre modo alta y modo consulta.
    /// </remarks>
    public partial class FEjemplar : Form
    {
        // ==========================================
        // PROPIEDADES
        // ==========================================
        public string Codigo { get { return txtCodigo.Text.Trim(); } }
        public string IsbnSeleccionado { get { return cbisbn.SelectedItem?.ToString(); } }


        // ==========================================
        // CONSTRUCTORES
        // ==========================================

        /// <summary>
        /// Constructor del formulario en modo alta de ejemplar.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> La lista de ISBN puede estar vacía, pero si se desea dar de alta debe contener valores.
        /// El código y el nombre del personal pueden ser cadenas vacías (se mostrarán tal cual).
        /// <br/>
        /// <b>POST:</b> El formulario queda preparado para introducir un nuevo ejemplar:
        /// - Código y personal quedan cargados y en solo lectura.
        /// - El checkbox "Prestado" se inicializa en false.
        /// - El combo de ISBN se carga con los valores recibidos.
        /// </remarks>
        /// 
        public FEjemplar(string codigo, string nombrePersonal, List<string> isbn)
        {
            InitializeComponent();



            Text = "Alta de ejemplar";

            txtCodigo.Text = codigo;
            txtCodigo.ReadOnly = true;

            txtPersonal.Text = nombrePersonal;
            txtPersonal.ReadOnly = true;

            cbisbn.DropDownStyle = ComboBoxStyle.DropDownList;
            cbisbn.Items.Clear();
            foreach (var item in isbn) { cbisbn.Items.Add(item); }


        }


        /// <summary>
        /// Constructor del formulario en modo consulta de ejemplar, mostrando también el personal que realizó el alta.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar puede ser null; en ese caso se mostrarán campos vacíos y prestado=false.
        /// El personal puede ser null.
        /// <br/>
        /// <b>POST:</b> El formulario queda en modo solo lectura:
        /// - Se muestran el código, el personal (o "(No disponible)"), el estado de préstamo y el ISBN asociado.
        /// - El checkbox "Prestado" y el combo ISBN quedan deshabilitados.
        /// - El botón Aceptar actúa como "Cerrar" y no se muestra Cancelar.
        /// </remarks>
        public FEjemplar(Ejemplar ej, Personal personalAlta)
        {
            InitializeComponent();

            Text = "Consultar ejemplar";

            // Código
            txtCodigo.Text = ej?.Codigo ?? "";
            txtCodigo.ReadOnly = true;

            // Personal que dio de alta (si viene)
            if (personalAlta != null)
            {
                txtPersonal.Text = personalAlta.ToString();
            }
            else
            {
                txtPersonal.Text = "(No disponible)";
            }
            txtPersonal.ReadOnly = true;



            // ISBN asociado 
            cbisbn.DropDownStyle = ComboBoxStyle.DropDownList;
            cbisbn.Items.Clear();

            string isbn = ej?.Documento?.ISBN;   
            if (!string.IsNullOrWhiteSpace(isbn))
            {
                cbisbn.Items.Add(isbn);
                cbisbn.SelectedIndex = 0;
            }
            cbisbn.Enabled = false;

            // Botones
            btAceptar.Text = "Cerrar";
            btCancelar.Visible = false;

            btAceptar.Click -= btAceptar_Click;
            btAceptar.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
        }





        /// <summary>
        /// Constructor alternativo (en desuso) para consulta de ejemplar sin personal.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar no puede ser null.
        /// <br/>
        /// <b>POST:</b> El formulario queda en modo consulta (solo lectura), mostrando:
        /// - Código, estado de préstamo e ISBN asociado (si existe).
        /// - El botón Aceptar actúa como "Cerrar" y no se muestra Cancelar.
        /// </remarks>
        public FEjemplar(Ejemplar ej) : this(
                codigo: ej?.Codigo,
                nombrePersonal: "",          
                isbn: new List<string>()     
)
        {
            if (ej == null) throw new ArgumentNullException(nameof(ej));

            Text = "Consultar ejemplar";

            // Código
            txtCodigo.Text = ej.Codigo;
            txtCodigo.ReadOnly = true;

            // Personal: en tu alta lo usas para auditoría, pero el ejemplar quizá no lo guarda.
            // Si no existe propiedad, lo dejamos vacío y ocultamos.
            txtPersonal.Text = "";
            txtPersonal.ReadOnly = true;


            
            cbisbn.Items.Clear();
            string isbn = ej.Documento?.ISBN; 
            if (!string.IsNullOrWhiteSpace(isbn))
            {
                cbisbn.Items.Add(isbn);
                cbisbn.SelectedIndex = 0;
            }
            cbisbn.Enabled = false;

            // Botones: solo cerrar
            btAceptar.Text = "Cerrar";
            btCancelar.Visible = false;

            btAceptar.Click -= btAceptar_Click;
            btAceptar.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };
        }

        /// <summary>
        /// Valida la selección de ISBN y confirma la operación.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El formulario está en modo alta y el usuario ha seleccionado (o no) un ISBN del combo.
        /// <br/>
        /// <b>POST:</b> Si hay ISBN seleccionado, el formulario se cierra con DialogResult.OK.
        /// Si no hay ISBN seleccionado, se muestra un mensaje de error y el formulario permanece abierto.
        /// </remarks>
        /// 

        // ==========================================
        // EVENTOS DE CLICK
        // ==========================================
        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(IsbnSeleccionado))
            {
                MessageBox.Show("Se debe seleccionar un isbn");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Cancela la operación y cierra el formulario.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna.
        /// <br/>
        /// <b>POST:</b> El formulario se cierra con DialogResult.Cancel.
        /// </remarks>
        private void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
        }
    }
}
