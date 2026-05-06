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
    /// Formulario genérico para introducir un identificador del sistema.
    /// </summary>
    /// <remarks>
    /// <b>RESPONSABILIDAD:</b>
    /// Solicitar y validar la introducción de un identificador
    /// (DNI, ISBN o Código) según el tipo indicado.
    /// </remarks>
    public partial class FIntroducirID : Form
    {
        // ==========================================
        // PROPIEDADES
        // ==========================================
        public string ValorIntroducido { get; private set; }

        private readonly TipoIdentificador tipo;    //solo se asisgna en el constructor

        // ==========================================
        // CONSTRUCTORES
        // ==========================================

        /// <summary>
        /// Constructor del formulario de introducción de identificador.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El tipo de identificador debe ser un valor válido del enumerado TipoIdentificador.
        /// <br/>
        /// <b>POST:</b> El formulario se inicializa con los textos adecuados
        /// según el tipo de identificador solicitado.
        /// </remarks>
        public FIntroducirID(TipoIdentificador tipo)
        {
            InitializeComponent();
            this.tipo = tipo;

            ConfigurarTexto();
        }


        // ==========================================
        // METODOS PRIVADOS
        // ==========================================

        /// <summary>
        /// Configura los textos del formulario según el tipo de identificador.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El campo tipo ha sido correctamente inicializado en el constructor.
        /// <br/>
        /// <b>POST:</b> El título del formulario y la etiqueta se adaptan
        /// al tipo de identificador (DNI, ISBN o Código).
        /// </remarks>
        private void ConfigurarTexto()
        {
            switch (tipo)
            {
                case TipoIdentificador.DNI:
                    this.Text = "Introducir DNI";
                    lbTexto.Text = "DNI:";
                    break;

                case TipoIdentificador.ISBN:
                    this.Text = "Introducir ISBN";
                    lbTexto.Text = "ISBN:";
                    break;

                case TipoIdentificador.CODIGO:
                    this.Text = "Introducir código";
                    lbTexto.Text = "Código:";
                    break;
            }
        }

        /// <summary>
        /// Valida el valor introducido y confirma la operación.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El usuario ha introducido (o no) un valor en el campo de texto.
        /// <br/>
        /// <b>POST:</b> Si el valor es válido, se asigna a ValorIntroducido y
        /// el formulario se cierra con DialogResult.OK.
        /// En caso contrario, se muestra un mensaje de error y el formulario permanece abierto.
        /// </remarks>
        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValor.Text))
            {
                MessageBox.Show("Debe introducir un valor.");
                return;
            }

            ValorIntroducido = txtValor.Text.Trim();
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


        private void FIntroducirID_Load(object sender, EventArgs e)
        {

        }
    }
}
