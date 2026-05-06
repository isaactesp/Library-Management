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
    public partial class FUsuario : Form


    /// <summary>
    /// Formulario de presentación para la gestión de usuarios.
    /// </summary>
    /// <remarks>
    /// <b>RESPONSABILIDAD:</b>
    /// Mostrar y validar los datos de un usuario en los modos Alta, Baja y Consulta,
    /// adaptando la interfaz según la operación solicitada.
    /// </remarks>
    {

        public string NombreIntroducido
        {
            get
            {
                return txtNombre.Text.Trim();
            }
        }
        public string Dni
        {
            get
            {
                return txtdni.Text.Trim();
            }
        }


        private readonly ModoUsuario modo;  //Para los diferentes estados del form: Alta, Baja, Busqueda

        // ==========================================
        // CONSTRUCTORES
        // ==========================================

        /// <summary>
        /// Constructor del formulario de usuario.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El DNI debe ser un valor válido (puede ser cadena vacía).
        /// El modo debe ser un valor válido del enumerado ModoUsuario.
        /// <br/>
        /// <b>POST:</b> El formulario queda configurado según el modo indicado,
        /// mostrando el DNI en solo lectura y ajustando los controles y botones.
        /// </remarks>
        public FUsuario(string dni, ModoUsuario modo)
        {
            InitializeComponent();
            this.modo = modo;

            // DNI viene del formulario anterior
            txtdni.Text = dni;
            txtdni.ReadOnly = true; // mejor que enabled que lo pone gris
            //txtdni.Enabled = false;     //Para que no se pueda cambiar el dni

            ConfigurarModo();
        }

        // ==========================================
        // METODOS PUBLICOS
        // ==========================================

        // Para que en Baja/Búsqueda puedas precargar el nombre desde FPal
        /// <summary>
        /// Precarga el nombre del usuario en el formulario.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El formulario está inicializado.
        /// <br/>
        /// <b>POST:</b> El campo nombre muestra el valor recibido.
        /// </remarks>
        public void CargarNombre(string nombre)
        {
            txtNombre.Text = nombre;
        }


        // ==========================================
        // METODOS PRIVADOS
        // ==========================================

        /// <summary>
        /// Configura la interfaz del formulario según el modo de uso.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El atributo modo ha sido inicializado en el constructor.
        /// <br/>
        /// <b>POST:</b> El formulario ajusta su título, botones y edición de campos
        /// según se trate de Alta, Baja o Consulta.
        /// </remarks>
        private void ConfigurarModo()
        {
            switch (modo)
            {
                case ModoUsuario.Alta:
                    this.Text = "Alta de usuario";
                    txtNombre.ReadOnly = false;
                    btAceptar.Text = "Dar de alta";
                    btCancelar.Text = "Cancelar";
                    btCancelar.Visible = true;
                    break;

                case ModoUsuario.Baja:
                    this.Text = "Baja de usuario";
                    txtNombre.ReadOnly = true;
                    btAceptar.Text = "Dar de baja";
                    btCancelar.Text = "Cancelar";
                    btCancelar.Visible = true;
                    break;

                case ModoUsuario.Busqueda:
                    this.Text = "Consulta de usuario";
                    txtNombre.ReadOnly = true;
                    btAceptar.Text = "Cerrar";
                    btCancelar.Visible = false; // El usuaro solo mra y cerra
                    break;
            }
        }

        /// <summary>
        /// Confirma la operación y cierra el formulario.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El usuario ha interactuado con el formulario.
        /// <br/>
        /// <b>POST:</b> En modo Alta, valida que el nombre no esté vacío.
        /// Si la validación es correcta (o no es necesaria), el formulario
        /// se cierra con DialogResult.OK.
        /// </remarks>
        private void btAceptar_Click(object sender, EventArgs e)
        {
            // Validación solo en Alta, porque no hace falta en el resto
            if (modo == ModoUsuario.Alta)
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe introducir el nombre.");
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lbdni_Click(object sender, EventArgs e)
        {

        }
    }
}
