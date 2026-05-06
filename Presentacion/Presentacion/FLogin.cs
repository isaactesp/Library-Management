using LogicaNegocio;
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
    /// Formulario de inicio de sesión para el personal de la biblioteca.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Validar las credenciales del usuario y su rol
    /// (Personal de Adquisiciones o Personal de Sala) para abrir el formulario
    /// principal correspondiente a su perfil.
    /// </para>
    /// </summary>
    public partial class FLogin : Form
    {
        // Contraseñas hardcodeadas con nss como contraseña 
        private static readonly Dictionary<string, string> Credenciales = new Dictionary<string, string>
        {
            { "juan", "NSS1234" },
            { "maria", "NSS8888" },
            { "admin", "NSS9999" },
            {"pepe","1" }
        };

        private readonly IPersonalAdquisicionesLN adqLN;
        private readonly IPersonalSalaLN salaLN;

        public FLogin(IPersonalAdquisicionesLN adqLN, IPersonalSalaLN salaLN)
        {
            InitializeComponent();
            this.adqLN = adqLN;
            this.salaLN = salaLN;
        }

        /// <summary>
        /// Verifica si la contraseña es correcta para el personal indicado.
        /// </summary>
        /// <param name="nombrePersonal">Nombre del usuario</param>
        /// <param name="password">Contraseña introducida</param>
        /// <returns>true si la contraseña es correcta, false en caso contrario</returns>
        private bool VerificarCredenciales(string nombrePersonal, string password)
        {
            // Convertir a minúsculas para comparación sin importar mayúsculas
            string nombreLower = nombrePersonal.ToLower();
            if (Credenciales.TryGetValue(nombreLower, out string passwordCorrecta))
            {
                return password == passwordCorrecta;
            }
            return false;
        }


        
        private void btEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBxNombre.Text))
            {
                MessageBox.Show("Debe introducir el nombre");
                return;
            }
            string nombre = txtBxNombre.Text.Trim();
            string password = txtBxContraseña.Text;

            if (rbPAdq.Checked)
            {
                // Verificar contraseña del personal
                if (!VerificarCredenciales(nombre, password))
                {
                    MessageBox.Show("Nombre o contraseña incorrectos");
                    return;
                }

                // NSS será la contraseña
                string nss = password;

                // Usar las dependencias ya inyectadas
                PersonalAdquisiciones personalAdq = new PersonalAdquisiciones(nss);
                Form principal = new FPalAdq(adqLN, personalAdq, nombre);

                this.Hide();
                principal.FormClosed += (s, args) => this.Close();
                principal.Show();
            }
            else if (rbPSala.Checked)
            {
                // Verificar contraseña del personal
                if (!VerificarCredenciales(nombre, password))
                {
                    MessageBox.Show("Nombre o contraseña incorrectos");
                    return;
                }

                string nss = password;

                // Usar las dependencias ya inyectadas
                PersonalSala pSala = new PersonalSala(nss);
                Form principal = new FPalSala(salaLN, pSala, nombre);

                this.Hide();
                principal.FormClosed += (s, args) => this.Close();
                principal.Show();

            }
            else
            {
                MessageBox.Show("Seleccione un tipo de empleado");
                return;
            }
        }


    }
}
