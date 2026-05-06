using LogicaNegocio;
using LogicaNegocio.Interfaces;
using ModeloDominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Formulario principal de la aplicación para el personal de biblioteca.
    /// </summary>
    /// <remarks>
    /// <b>RESPONSABILIDAD:</b>
    /// Construir el menú común y gestionar las operaciones de usuarios
    /// delegando la lógica en la capa de negocio.
    /// </remarks>
    public partial class FPal : Form
    {
        /// <summary>
        /// Referencia a la lógica de negocio del personal (inyección de dependencias).
        /// Protected para que las clases hijas puedan acceder (ISP).
        /// </summary>
        protected IPersonalLN personalLN;

        protected Personal empleado;

        protected string nombreEmpleado;


        protected Personal Empleado
        {
            get { return empleado; }
            set { empleado = value; }
        }

        protected string NombreEmpleado
        {
            get { return nombreEmpleado; }
            set { nombreEmpleado = value; }
        }

        protected IPersonalLN PersonalLN
        {
            get { return personalLN; }
            set { personalLN = value; }
        }

        // ==========================================
        // CONSTRUCTORES
        // ==========================================

        /// <summary>
        /// Constructor privado base del formulario.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna.
        /// <br/>
        /// <b>POST:</b> Inicializa los componentes gráficos del formulario.
        /// </remarks>
        private FPal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor principal del formulario, inicializando dependencias y datos del empleado.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> personalLN debe estar inicializado para ejecutar operaciones de usuario.
        /// nombreEmpleado y nss pueden ser cadenas vacías, pero se usarán para mostrar información.
        /// <br/>
        /// <b>POST:</b> El formulario queda configurado con el título del empleado y
        /// se crea el menú común de la aplicación.
        /// </remarks>
        public FPal(IPersonalLN personalLN, string nombreEmpleado, Personal empleado) : this()      //inyeccion de dependencias 
        {
            this.personalLN = personalLN;
            this.nombreEmpleado = nombreEmpleado;
            this.Text = $"{nombreEmpleado} - Gestión de Biblioteca";
            this.empleado = empleado;

            CrearMenuComun();
        }


        // ==========================================
        // METODOS PRVIVADOS
        // ==========================================

        /// <summary>
        /// Crea e inserta en el formulario el menú común disponible para el personal.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El formulario está inicializado.
        /// <br/>
        /// <b>POST:</b> Se crea el MenuStrip principal y se agregan las opciones de gestión de usuarios,
        /// quedando asociadas a sus respectivos manejadores.
        /// </remarks>
        private void CrearMenuComun()
        {
            // Crear MenuStrip principal
            menuPrincipal = new MenuStrip();

            // Menú: Usuarios
            menuUsuarios = new ToolStripMenuItem("Usuarios");


            var itemAlta = new ToolStripMenuItem("Alta");
            itemAlta.Click += (s, e) => AltaUsuario();      // se suscribe al evento click

            var itemBaja = new ToolStripMenuItem("Baja");
            itemBaja.Click += (s, e) => BajaUsuario();

            var itemConsulta = new ToolStripMenuItem("Búsqueda");
            itemConsulta.Click += (s, e) => ConsultaUsuario();

            var itemBusquedaDNI = new ToolStripMenuItem("Búsqueda por DNI");
            itemBusquedaDNI.Click += (s, e) => BusquedaUsuarioPorDNI();

            var itemListado = new ToolStripMenuItem("Listado");
            itemListado.Click += (s, e) => ListadoUsuarios();

            var item1a1 = new ToolStripMenuItem("Recorrido 1 a 1");
            item1a1.Click += new EventHandler(item1a1_Click);

            menuUsuarios.DropDownItems.Add(itemAlta);
            menuUsuarios.DropDownItems.Add(itemBaja);
            menuUsuarios.DropDownItems.Add(itemConsulta);
            menuUsuarios.DropDownItems.Add(itemBusquedaDNI);
            menuUsuarios.DropDownItems.Add(itemListado);
            menuUsuarios.DropDownItems.Add(item1a1);

            menuPrincipal.Items.Add(menuUsuarios);

            this.MainMenuStrip = menuPrincipal;
            this.Controls.Add(menuPrincipal);   // inserta el MenuStrip dentro del formulario
        }

        /// Lanza el flujo de alta de un usuario solicitando DNI y nombre, y registra el usuario en la LN.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> personalLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si el alta se confirma y los datos son válidos, se intenta registrar el usuario en LN
        /// y se informa del resultado mediante mensajes.
        /// Si el usuario cancela en cualquier formulario, no se realizan cambios.
        /// </remarks>
        private void AltaUsuario()
        { 
            if (personalLN == null)
            {
                MessageBox.Show("No hay lógica de negocio inicializada.");
                return;
            }

            string dni;

            // Por si introduce un dni repetido para poder dar de alta a otro
            while (true)
            {

                // Pedir DNI
                var fDni = new FIntroducirID(TipoIdentificador.DNI);
                if (fDni.ShowDialog() != DialogResult.OK)
                    return;     // si no es OK salgo del metodo

                dni = fDni.ValorIntroducido.Trim();
                if (string.IsNullOrWhiteSpace(dni)) continue;


                // Comprobar si el usuario ya existe
                // dijo la vico de hacerlo en el Fintroducirid, pero no tengo la ln ahi
                if (!personalLN.ExisteUsuario(dni)) break;

                //Ya existe, preguntar si quiere introducir otro
                var res = MessageBox.Show(
                    "Ya existe un usuario con ese DNI.\n¿Quieres introducir otro?",
                    "DNI existente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (res == DialogResult.No)
                    return;
                // Si es Yes, el while repite y vuelve a pedir DNI

            }

            // Pedir nombre (formulario solo para enseñar)
            var fUsuario = new FUsuario(dni, ModoUsuario.Alta);
            if (fUsuario.ShowDialog() != DialogResult.OK)
                return;

            string nombre = fUsuario.NombreIntroducido.Trim();
            if (string.IsNullOrWhiteSpace(nombre)) return;

            // Registrar usuario
            bool ok = personalLN.RegistrarUsuario(dni, nombre);

            // 6. Informar
            if (ok)
                MessageBox.Show("Usuario registrado correctamente.");
            else
                MessageBox.Show("No se pudo registrar el usuario.");
        }

        /// <summary>
        /// Lanza el flujo de baja de un usuario solicitando DNI, mostrando confirmación y ejecutando la baja en LN.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> personalLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si el usuario existe y se confirma la operación, se intenta dar de baja en LN
        /// y se informa del resultado mediante mensajes.
        /// Si el usuario cancela, no se realizan cambios.
        /// </remarks>
        private void BajaUsuario()
        {
            // Comprobar que existe la LN!=null
            if (personalLN == null)
            {
                MessageBox.Show("No hay lógica de negocio inicializada.");
                return;
            }

            while (true)
            {

                // Pedir DNI
                var fDni = new FIntroducirID(TipoIdentificador.DNI);
                if (fDni.ShowDialog() != DialogResult.OK)
                    return;

                string dni = fDni.ValorIntroducido.Trim();
                if (string.IsNullOrWhiteSpace(dni)) continue;

                // Consultar usuario
                var usuario = personalLN.BuscarUsuario(dni);
                if (usuario == null)
                {
                    var res = MessageBox.Show(
                        "No existe un usuario con ese DNI.\n¿Quieres introducir otro?",
                        "Usuario no encontrado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (res == DialogResult.Yes)
                        continue;
                    else
                        return;
                }

                // Si existe --> Formulario final (modo Baja)
                var fUsuario = new FUsuario(dni, ModoUsuario.Baja);
                fUsuario.CargarNombre(usuario.Nombre);  //Precargo el nombre del us

                if (fUsuario.ShowDialog() != DialogResult.OK)
                    return;

                // Mensage de confirmacion
                var confirmacion = MessageBox.Show(
                    "¿Está seguro que desea dar de baja al usuario?",
                    "Aviso",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.No)
                    return;

                // Dar de baja
                bool ok = personalLN.BajaUsuario(dni);

                if (ok)
                    MessageBox.Show("Usuario eliminado.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudo eliminar el usuario.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        /// <summary>
        /// Lanza el flujo de consulta de un usuario solicitando DNI y mostrando sus datos en modo búsqueda.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> personalLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si el usuario existe, se muestra el formulario de usuario en modo búsqueda.
        /// Si no existe, se permite reintentar o cancelar la operación.
        /// </remarks>
        private void ConsultaUsuario()
        {
            // Comprobar que existe la LN!=null, no se s es NECESARO???
            if (personalLN == null)
            {
                MessageBox.Show("No hay lógica de negocio inicializada.");
                return;
            }

            string dni;

            while (true)
            {
                // Pedir DNI
                var fDni = new FIntroducirID(TipoIdentificador.DNI);
                if (fDni.ShowDialog() != DialogResult.OK)
                    return;

                // Recuperar y validar dni
                dni = fDni.ValorIntroducido?.Trim();     // el ? evita excepcion si Valorintroducido fuese null
                if (string.IsNullOrWhiteSpace(dni)) continue;


                // Consultar usuario
                var usuario = personalLN.BuscarUsuario(dni);

                if (usuario == null)
                {

                    var res = MessageBox.Show(
                        "No existe un usuario con ese DNI.\n¿Quieres introducir otro?",
                        "Usuario no encontrado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (res == DialogResult.Yes)
                        continue;   // vuelve a abrir el formulario de DNI

                    return;
                }




                // Sabemos que exste --> Mostrar datos (modo Búsqueda)
                var fUsuario = new FUsuario(dni, ModoUsuario.Busqueda);
                fUsuario.CargarNombre(usuario.Nombre);

                fUsuario.ShowDialog();

                return;


            }

        }

        /// <summary>
        /// Abre un formulario de búsqueda de usuarios utilizando el listado completo obtenido desde LN.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> personalLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si existen usuarios, se muestra el formulario de búsqueda por DNI.
        /// Si no hay usuarios, se informa mediante un mensaje.
        /// </remarks>
        private void BusquedaUsuarioPorDNI()
        {
            if (personalLN == null)
            {
                MessageBox.Show("No hay lógica de negocio inicializada.");
                return;
            }

            var usuarios = personalLN.ListarUsuarios();
            if (usuarios == null || usuarios.Count == 0)
            {
                MessageBox.Show("No hay usuarios registrados.");
                return;
            }

            var fBusqueda = new FBusquedaUsuarioDNI(usuarios);
            fBusqueda.ShowDialog();
        }

        /// <summary>
        /// Muestra el listado completo de usuarios registrados.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> personalLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si existen usuarios, se muestra el formulario de listado.
        /// Si no hay usuarios, se informa mediante un mensaje.
        /// </remarks>
        private void ListadoUsuarios()
        {
            if (personalLN == null)
            {
                MessageBox.Show("No hay lógica de negocio inicializada.");
                return;
            }

            var usuarios = personalLN.ListarUsuarios();
            if (usuarios == null || usuarios.Count == 0)
            {
                MessageBox.Show("No hay usuarios registrados.");
                return;
            }

            var fListado = new FListadoUsuarios(usuarios);
            fListado.ShowDialog();
        }

        /// <summary>
        /// Abre un formulario de recorrido 1 a 1 sobre el listado de usuarios.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> personalLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si existen usuarios, se muestra el formulario de recorrido.
        /// Si no hay usuarios, se informa mediante un mensaje.
        /// </remarks>
        private void item1a1_Click(Object sender, EventArgs e)
        {
            var usuarios = personalLN.ListarUsuarios();

            if (usuarios == null || usuarios.Count == 0)
            {
                MessageBox.Show("NO hay usuarios registrados para mostrar.");
                return;
            }

            var fRecorrido = new FBusqueda1a1(usuarios);
            fRecorrido.ShowDialog();

        }

    }
}
