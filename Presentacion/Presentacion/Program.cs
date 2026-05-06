using LogicaNegocio;
using LogicaNegocio.Interfaces;
using ModeloDominio;
using Persistencia;
using Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Clase principal de la aplicación.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Contiene el punto de entrada (Main) de la aplicación. Se encarga
    /// de configurar el "Composition Root" para la inyección de dependencias, cargar los datos
    /// iniciales del sistema y lanzar el formulario de login.
    /// </para>
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // --- COMPOSITION ROOT ---
            // 1. Crear todas las instancias de la capa de Persistencia.
            var perUsuario = new PersistenciaUsuario();
            var perLibro = new PersistenciaLibro();
            var perAudio = new PersistenciaAudioLibro();
            var perEjemplar = new PersistenciaEjemplar();
            var perEjPres = new PersistenciaEjemplarPrestamo();
            var perPrestamo = new PersistenciaPrestamo();
            var perPersonalAdq = new PersistenciaPersonalAdquisiciones();
            var perPersonalSala = new PersistenciaPersonalSala();


            // 2. Crear las instancias de la capa de Lógica de Negocio.
            IPersonalAdquisicionesLN adqLN = new PersonalAdquisicionesLN(perUsuario, perLibro, perAudio, perEjemplar, perEjPres, perPrestamo, perPersonalAdq);
            IPersonalSalaLN salaLN = new PersonalSalaLN(perUsuario, perPrestamo, perEjemplar, perPersonalSala);

            // 3. Cargar datos de ejemplo usando las fachadas de Lógica de Negocio.
            CargarDatosIniciales(adqLN, salaLN);

            // 4. Inyectar las fachadas en el formulario de Login y ejecutar.
            Application.Run(new FLogin(adqLN, salaLN));
        }

        /// <summary>
        /// Crea y añade entidades de ejemplo a través de la Lógica de Negocio.
        /// </summary>
        private static void CargarDatosIniciales(IPersonalAdquisicionesLN adqLN, IPersonalSalaLN salaLN)
        {
            try
            {
                // NOTA: El alta de Personal no está implementada en la LN.
                // Se crean objetos locales para cumplir con las firmas de los métodos.
                var pa1 = new PersonalAdquisiciones("NSS1234"); // Corresponde a 'juan' en FLogin
                var ps1 = new PersonalSala("NSS8888");        // Corresponde a 'maria' en FLogin
                adqLN.RegistrarPersonal(pa1);
                salaLN.RegistrarPersonal(ps1);




                // Particularidad del diseño: Inyectar el Personal de Sala en la LN para que sepa quién registra el préstamo.
                if (salaLN is PersonalSalaLN salaConcreta)
                {
                    salaConcreta.PersonalActual = ps1;
                }

                // --- USUARIOS ---
                adqLN.RegistrarUsuario("111A", "Ana Torres");
                adqLN.RegistrarUsuario("333C", "Carla Sanz");
                adqLN.RegistrarUsuario("12345678A", "Juan Pérez");
                adqLN.RegistrarUsuario("87654321B", "Ana López");

                // --- DOCUMENTOS ---
                var l1 = new Libro("978-0307474728", "Cien Años de Soledad", "Gabriel García Márquez", "Sudamericana", 1967);
                var l2 = new Libro("978-8420412146", "El Quijote de la Mancha", "Miguel de Cervantes", "RAE", 1605);
                var l3 = new Libro("978-8433914339", "Elantris", "Brandon Sanderson", "Nova", 2005);
                var l4 = new Libro("978-0765326355", "The Way of Kings", "Brandon Sanderson", "Tor Books", 2010);
                var al1 = new AudioLibro("978-0743533470", "The Hobbit", "J.R.R. Tolkien", "Random House Audio", 1937, 660, "MP3");
                var al2 = new AudioLibro("978-1427213293", "Mistborn: The Final Empire", "Brandon Sanderson", "Macmillan Audio", 2011, 1572, "MP3");
                var al3 = new AudioLibro("978-0307743458", "Ready Player One", "Ernest Cline", "Random House Audio", 2011, 946, "MP3");

                adqLN.AltaDocumento(l1);
                adqLN.AltaDocumento(l2);
                adqLN.AltaDocumento(l3);
                adqLN.AltaDocumento(l4);
                adqLN.AltaDocumento(al1);
                adqLN.AltaDocumento(al2);
                adqLN.AltaDocumento(al3);
                
                // --- EJEMPLARES ---
                var e_l1_1 = new Ejemplar("L001", l1);
                var e_l1_2 = new Ejemplar("L002", l1);
                var e_l2_1 = new Ejemplar("Q001", l2);
                var e_l3_1 = new Ejemplar("E001", l3);
                var e_l4_1 = new Ejemplar("WOK01", l4);
                var e_l4_2 = new Ejemplar("WOK02", l4);
                var e_al1_1 = new Ejemplar("H001", al1);
                var e_al2_1 = new Ejemplar("MIST01", al2);
                var e_al3_1 = new Ejemplar("RPO01", al3);

                adqLN.RegistrarEjemplar(e_l1_1, pa1);
                adqLN.RegistrarEjemplar(e_l1_2, pa1);
                adqLN.RegistrarEjemplar(e_l2_1, pa1);
                adqLN.RegistrarEjemplar(e_l3_1, pa1);
                adqLN.RegistrarEjemplar(e_l4_1, pa1);
                adqLN.RegistrarEjemplar(e_l4_2, pa1);
                adqLN.RegistrarEjemplar(e_al1_1, pa1);
                adqLN.RegistrarEjemplar(e_al2_1, pa1);
                adqLN.RegistrarEjemplar(e_al3_1, pa1);

                // --- PRÉSTAMOS ---
                // Recuperamos las entidades completas de Usuario para usarlas en los préstamos
                var u_ana = adqLN.BuscarUsuario("111A");
                var u_luis = adqLN.BuscarUsuario("222B");
                var u_juan = adqLN.BuscarUsuario("12345678A");

                // Préstamo 1 (ACTIVO): Ana (u1) se lleva "Cien Años..." y "The Hobbit"
                var pr1 = new Prestamo("P001", true, DateTime.Now.AddDays(-5));
                salaLN.IniciarPrestamo(pr1, new List<Ejemplar> { e_l1_1, e_al1_1 }, u_ana);

                // Préstamo 2 (FINALIZADO): Luis (u2) se llevó "El Quijote" y ya lo devolvió.
                var pr2 = new Prestamo("P002", true, DateTime.Now.AddDays(-20));
                salaLN.IniciarPrestamo(pr2, new List<Ejemplar> { e_l2_1 }, u_luis);
                salaLN.DevolverEjemplar(pr2, e_l2_1);

                // Préstamo 3 (ACTIVO): Juan se lleva "The Way of Kings".
                var pr3 = new Prestamo("P003", true, DateTime.Now.AddDays(-2));
                salaLN.IniciarPrestamo(pr3, new List<Ejemplar> { e_l4_1 }, u_juan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos iniciales: " + ex.Message, "Error de Inicialización");
            }
        }
    }
}


