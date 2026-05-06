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
    /// Formulario principal para el personal de adquisiciones.
    /// </summary>
    /// <remarks>
    /// <b>RESPONSABILIDAD:</b>
    /// Ampliar el menú principal con opciones de documentos y ejemplares,
    /// delegando las operaciones en la lógica de negocio de adquisiciones.
    /// </remarks>
    public partial class FPalAdq : FPal
    {
        /// <summary>
        /// Referencia a la lógica de negocio específica de adquisiciones.
        /// </summary>
        private IPersonalAdquisicionesLN adqLN
        {
            get { return (IPersonalAdquisicionesLN)base.PersonalLN; }
        }

        /// <summary>
        /// Personal de adquisiciones autenticado (para auditoría en altas).
        /// </summary>
        private PersonalAdquisiciones personalAdq
        {
            get { return (PersonalAdquisiciones)base.Empleado; }
        }

        // ==========================================
        // CONSTRUCTORES
        // ==========================================

        /// <summary>
        /// Constructor del formulario de personal de adquisiciones.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> personalLN y adqLN deben estar inicializados para ejecutar operaciones.
        /// personalAdq no debe ser null y debe contener un NSS válido.
        /// nombreEmpleado puede ser cadena vacía.
        /// <br/>
        /// <b>POST:</b> El formulario queda configurado con el empleado autenticado,
        /// se inicializan las dependencias y se crea el menú específico de adquisiciones.
        /// </remarks>
        public FPalAdq(IPersonalAdquisicionesLN adqLN, PersonalAdquisiciones personalAdq, string nombreEmpleado) : base(adqLN, nombreEmpleado, personalAdq)
        {
            CrearMenuAdq();
        }

        // ==========================================
        // METODOS PRIVADOS
        // ==========================================

        /// <summary>
        /// Crea e inserta en el menú principal las opciones específicas de adquisiciones
        /// (Documentos y Ejemplares).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> menuPrincipal debe estar creado (por el formulario base).
        /// <br/>
        /// <b>POST:</b> Se agregan a la barra principal los menús "Documentos" y "Ejemplares"
        /// con sus elementos y manejadores asociados.
        /// </remarks>
        private void CrearMenuAdq()
        {
            // =========================
            // Menú: Documentos
            // =========================
            var menuDocumentos = new ToolStripMenuItem("Documentos");

            var itemAltaDoc = new ToolStripMenuItem("Alta");
            itemAltaDoc.Click += (s, e) => AltaDocumento();

            var itemBajaDoc = new ToolStripMenuItem("Baja");
            itemBajaDoc.Click += (s, e) => BajaDocumento();

            var itemBuscarDoc = new ToolStripMenuItem("Buscar documento");
            itemBuscarDoc.Click += (s, e) => BuscarDocumento(this.adqLN);

            // Recorrido 1 a 1 (típico: navegar documento por documento)
            var itemRecorrido = new ToolStripMenuItem("Recorrido 1 a 1");
            itemRecorrido.Click += (s, e) => RecorridoDocumentos1a1();

            // Listados
            var itemListado = new ToolStripMenuItem("Listado de documentos");

            var itemListarDocumentos = new ToolStripMenuItem("Listar todos los documentos");
            itemListarDocumentos.Click += (s, e) => ListadoDocumentos();

            var itemListarLibros = new ToolStripMenuItem("Listar libros");
            itemListarLibros.Click += (s, e) => ListadoLibros();

            var itemListarAudio = new ToolStripMenuItem("Listar audiolibros");
            itemListarAudio.Click += (s, e) => ListadoAudioLibros();

            itemListado.DropDownItems.Add(itemListarDocumentos);
            itemListado.DropDownItems.Add(itemListarLibros);
            itemListado.DropDownItems.Add(itemListarAudio);

            // Consultas / estadísticas
            var itemPopular = new ToolStripMenuItem("Documento popular");
            itemPopular.Click += (s, e) => DocumentoPopular();

            var itemPopularMes = new ToolStripMenuItem("Documento popular último mes");
            itemPopularMes.Click += (s, e) => DocumentoPopularMes();

            var itemDisponibles = new ToolStripMenuItem("Ejemplares disponibles");
            itemDisponibles.Click += (s, e) => EjemplaresDisponibles();

            var itemCuandoDisponible = new ToolStripMenuItem("¿Cuándo estará disponible un ejemplar?");
            itemCuandoDisponible.Click += (s, e) => CuandoDisponible();


            // Construcción del menú Documentos con separadores
            menuDocumentos.DropDownItems.Add(itemAltaDoc);
            menuDocumentos.DropDownItems.Add(itemBuscarDoc);
            menuDocumentos.DropDownItems.Add(itemBajaDoc);

            menuDocumentos.DropDownItems.Add(new ToolStripSeparator());

            menuDocumentos.DropDownItems.Add(itemRecorrido);
            menuDocumentos.DropDownItems.Add(itemListado);

            menuDocumentos.DropDownItems.Add(new ToolStripSeparator());

            menuDocumentos.DropDownItems.Add(itemPopular);
            menuDocumentos.DropDownItems.Add(itemPopularMes);
            menuDocumentos.DropDownItems.Add(itemDisponibles);
            menuDocumentos.DropDownItems.Add(itemCuandoDisponible);



            // =========================
            // Menú: Ejemplares
            // =========================
            var menuEjemplares = new ToolStripMenuItem("Ejemplares");

            var itemAltaEjem = new ToolStripMenuItem("Alta");
            itemAltaEjem.Click += (s, e) => AltaEjemplar();

            var itemBajaEjem = new ToolStripMenuItem("Baja");
            itemBajaEjem.Click += (s, e) => BajaEjemplar();

            var itemBuscarEjem = new ToolStripMenuItem("Buscar");
            itemBuscarEjem.Click += (s, e) => BuscarEjemplar();

            // Listados
            var itemListadoEjem = new ToolStripMenuItem("Listado de ejemplares");

            var itemListadoCompleto = new ToolStripMenuItem("Completo");
            itemListadoCompleto.Click += (s, e) => ListarEjemplares(this.adqLN.ObtenerTodosEjemplares());

            var itemListadoDeDocumento = new ToolStripMenuItem("De un documento");
            itemListadoDeDocumento.Click += (s, e) => ListadoEjemplaresDocumento(this.adqLN);

            itemListadoEjem.DropDownItems.Add(itemListadoCompleto);
            itemListadoEjem.DropDownItems.Add(itemListadoDeDocumento);


            // Construcción del menú Ejemplares con separador
            menuEjemplares.DropDownItems.Add(itemAltaEjem);
            menuEjemplares.DropDownItems.Add(itemBajaEjem);
            menuEjemplares.DropDownItems.Add(itemBuscarEjem);

            menuEjemplares.DropDownItems.Add(new ToolStripSeparator());

            menuEjemplares.DropDownItems.Add(itemListadoEjem);


            // =========================
            // Añadir a la barra principal
            // =========================
            menuPrincipal.Items.Add(menuDocumentos);
            menuPrincipal.Items.Add(menuEjemplares);
        }

        // =========================
        // DOCUMENTOS
        // =========================

        /// <summary>
        /// Lanza el flujo de alta de documento solicitando ISBN y datos del documento.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> adqLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si el ISBN no existe y el usuario confirma, se construye un Libro o AudioLibro
        /// y se solicita el alta en LN. Se informa del resultado mediante un mensaje.
        /// Si el usuario cancela, no se realizan cambios.
        /// </remarks>
        private void AltaDocumento()
        {
            if (adqLN == null) { MessageBox.Show("LN de Adquisiciones no inicializada"); return; }

            while (true)
            {
                //Perdir isbn
                var fIsbn = new FIntroducirID(TipoIdentificador.ISBN);
                if (fIsbn.ShowDialog() != DialogResult.OK)
                    return;

                string isbn = fIsbn.ValorIntroducido?.Trim();
                if (string.IsNullOrWhiteSpace(isbn)) continue;

                // Comprobar si ya existe el documento
                Documento docExixtente = adqLN.BuscarDocumento(isbn);
                if (docExixtente != null)
                {
                    var res = MessageBox.Show(
                        "Ya existe un documento con ese ISBN.\n¿Quieres introducir otro?",
                        "ISBN existente",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (res == DialogResult.Yes)
                        continue;

                    return;
                }

                //Pedir datos del documento
                var fDoc = new FDocumento(isbn);
                if (fDoc.ShowDialog() != DialogResult.OK) return;

                // Construir objeto DOCUMENTO
                Documento documento;
                if (fDoc.EsAudiolibro)
                {
                    documento = new AudioLibro(
                        isbn,
                        fDoc.Titulo,
                        fDoc.Autor,
                        fDoc.Editorial,
                        fDoc.AnoPublicacion,
                        fDoc.DuracionMinutos,
                        fDoc.Formato
                    );

                }
                else
                {
                    documento = new Libro(
                        isbn,
                        fDoc.Titulo,
                        fDoc.Autor,
                        fDoc.Editorial,
                        fDoc.AnoPublicacion
                    );
                }


                // Registrar
                bool ok = adqLN.AltaDocumento(documento);

                MessageBox.Show(ok
                    ? "Documento registrado correctamente."
                    : "No se pudo registrar el documento.");

                return;
            }

        }


        /// <summary>
        /// Lanza el flujo de baja de documento solicitando ISBN y confirmación.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> adqLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si el documento existe y se confirma, se solicita la baja en LN.
        /// Se informa del resultado mediante un mensaje.
        /// Si el usuario cancela o el documento no existe, no se realizan cambios.
        /// </remarks>
        private void BajaDocumento()
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada");
                return;
            }

            while (true)
            {
                // Pedir ISBN
                var fIsbn = new FIntroducirID(TipoIdentificador.ISBN);
                if (fIsbn.ShowDialog() != DialogResult.OK)
                    return;

                string isbn = fIsbn.ValorIntroducido?.Trim();
                if (string.IsNullOrWhiteSpace(isbn))
                    continue;

                // Buscar documento
                Documento doc = adqLN.BuscarDocumento(isbn);
                if (doc == null)
                {
                    var resNo = MessageBox.Show(
                        "No existe ningún documento con ese ISBN.\n¿Quieres introducir otro?",
                        "Documento no encontrado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (resNo == DialogResult.Yes) continue;
                    return;
                }
                // Confirmación mostrando ficha (mínimo)
                string ficha =
                    $"ISBN: {doc.ISBN}\n" +
                    $"Título: {doc.Titulo}\n" +
                    $"Autor: {doc.Autor}\n" +
                    $"Editorial: {doc.Editorial}\n" +
                    $"Año: {doc.AnioPublicacion}\n" +
                    $"Tipo: {doc.GetType().Name}\n\n" +
                    "¿Seguro que quieres dar de baja este documento?";

                var res = MessageBox.Show(
                    ficha,
                    "Confirmar baja de documento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (res == DialogResult.No)
                {
                    var otro = MessageBox.Show(
                        "¿Quieres introducir otro ISBN?",
                        "Continuar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (otro == DialogResult.Yes) continue;
                    return;
                }

                // Baja
                bool ok = adqLN.BajaDocumento(doc);

                if (ok)
                {
                    MessageBox.Show(
                        "Documento dado de baja correctamente.",
                        "Baja realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                "No se pudo dar de baja el documento.\n" +
                "Puede que no exista, tenga ejemplares activos o préstamos pendientes.",
                "Baja no realizada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
                }

                return;
            }
        }



        public void ListadoDocumentos()
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada");
                return;
            }
            var documentos = adqLN.ListarDocumentos();
            if (documentos == null || documentos.Count == 0)
            {
                MessageBox.Show("No hay documentos en el catálogo.");
                return;
            }
            var fListado = new FListadoDocumentos(this.adqLN, documentos);
            fListado.Name = "Listado de Documentos";
            fListado.ShowDialog();
        }

        public void ListadoLibros()
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada");
                return;
            }
            List<Libro> libros = adqLN.ListarLibros();
            List<Documento> documentos = libros.Cast<Documento>().ToList();

            if (documentos == null || documentos.Count == 0)
            {
                MessageBox.Show("No hay libros en el catálogo.");
                return;
            }
            var fListado = new FListadoDocumentos(this.adqLN, documentos);
            fListado.Name = "Listado de Libros";
            fListado.ShowDialog();
        }

        public void ListadoAudioLibros()
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada");
                return;
            }
            List<AudioLibro> audioLibros = adqLN.ListarAudioLibros();
            List<Documento> documentos = audioLibros.Cast<Documento>().ToList();
            if (documentos == null || documentos.Count == 0)
            {
                MessageBox.Show("No hay audiolibros en el catálogo.");
                return;
            }
            var fListado = new FListadoDocumentos(this.adqLN, documentos);
            fListado.Name = "Listado de Audiolibros";
            fListado.ShowDialog();
        }

        /// <summary>
        /// Lanza el flujo de búsqueda de documento por ISBN y muestra su ficha en modo consulta.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> adqLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si el documento existe, se abre el formulario de documento en modo consulta.
        /// Si no existe, se permite reintentar o cancelar.
        /// </remarks>
        private void BuscarDocumento(IPersonalAdquisicionesLN pAdq)
        {     
            this.ListadoEjemplaresDocumento(pAdq);
        }

        /// <summary>
        /// Muestra el documento más popular según la información obtenida desde la LN.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> adqLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si existe un documento popular, se muestra su ficha.
        /// En caso contrario, se informa mediante un mensaje.
        /// </remarks>
        private void DocumentoPopular()
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada");
                return;
            }

            Documento doc = adqLN.ObtenerDocumentoPopular();

            if (doc == null)
            {
                MessageBox.Show(
                    "No hay un documento popular disponible.\n" +
                    "Puede que no existan ejemplares o que no haya historial de préstamos.",
                    "Documento popular",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            else
            {
                var fDoc = new FDocumento(doc);
                fDoc.ShowDialog();
            }
        }


        public void DocumentoPopularMes()
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada");
                return;
            }
            Documento doc = adqLN.ObtenerDocumentoPopularUltimoMes();
            if (doc == null)
            {
                MessageBox.Show(
                    "No hay un documento popular disponible en el último mes.\n" +
                    "Puede que no existan ejemplares o que no haya historial de préstamos.",
                    "Documento popular último mes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            else
            {
                var fDoc = new FDocumento(doc);
                fDoc.ShowDialog();
            }
        }

        // Dice si hay algun ejemplar disponible o no. NO SACA LiSTA DE EJMEPLARES DiSPONiBLES
        /// <summary>
        /// Consulta si hay ejemplares disponibles para préstamo de un documento por ISBN.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> adqLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Se informa si existe disponibilidad.
        /// Si el ISBN no corresponde a ningún documento, se permite reintentar.
        /// </remarks>
        private void EjemplaresDisponibles()
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada");
                return;
            }

            while (true)
            {
                // Pedir ISBN
                var fIsbn = new FIntroducirID(TipoIdentificador.ISBN);
                if (fIsbn.ShowDialog() != DialogResult.OK)
                    return;

                string isbn = fIsbn.ValorIntroducido?.Trim();
                if (string.IsNullOrWhiteSpace(isbn))
                    continue;

                bool hay = adqLN.HayDisponibilidad(isbn);

                if (hay)
                {
                    MessageBox.Show(
                        "Sí: hay al menos un ejemplar disponible para préstamo.",
                        "Ejemplares disponibles",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }
                else
                {
                    // Ojo: HayDisponibilidad devuelve false también si el documento no existe.
                    // Para dar un mensaje correcto, comprobamos existencia.
                    Documento doc = adqLN.BuscarDocumento(isbn);

                    if (doc == null)
                    {
                        var resNo = MessageBox.Show(
                            "No existe ningún documento con ese ISBN.\n¿Quieres introducir otro?",
                            "Documento no encontrado",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information
                        );

                        if (resNo == DialogResult.Yes) continue;
                        return;
                    }

                    // Documento existe pero no hay stock
                    var res = MessageBox.Show(
                        "No hay ejemplares disponibles actualmente (puede que estén todos prestados o no haya ejemplares).\n" +
                        "¿Quieres consultar otro ISBN?",
                        "Ejemplares disponibles",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (res == DialogResult.Yes) continue;
                    return;
                }
            }
        }



        //Probar ben cuando configuremos los prestamos
        /// <summary>
        /// Calcula y muestra la fecha estimada en la que estará disponible un ejemplar de un documento.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> adqLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si hay disponibilidad inmediata, se informa.
        /// Si no se puede estimar la fecha, se informa.
        /// Si existe fecha estimada, se muestra.
        /// Se permite consultar otro ISBN o finalizar.
        /// </remarks>
        private void CuandoDisponible()
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada");
                return;
            }

            while (true)
            {
                // Pedir ISBN
                var fIsbn = new FIntroducirID(TipoIdentificador.ISBN);
                if (fIsbn.ShowDialog() != DialogResult.OK)
                    return;

                string isbn = fIsbn.ValorIntroducido?.Trim();
                if (string.IsNullOrWhiteSpace(isbn))
                    continue;

                // Si hay disponibilidad, no tiene sentido calcular fecha
                bool hay = adqLN.HayDisponibilidad(isbn);
                if (hay)
                {
                    MessageBox.Show(
                        "Hay ejemplares disponibles ahora mismo. No es necesario esperar.",
                        "Disponibilidad",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                // Si no hay disponibilidad, comprobar si el documento existe
                Documento doc = adqLN.BuscarDocumento(isbn);
                if (doc == null)
                {
                    var resNo = MessageBox.Show(
                        "No existe ningún documento con ese ISBN.\n¿Quieres introducir otro?",
                        "Documento no encontrado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (resNo == DialogResult.Yes) continue;
                    return;
                }

                // Calcular fecha estimada
                DateTime fecha = adqLN.CuandoDisponible(isbn);

                if (fecha == DateTime.MinValue)
                {
                    // Según contrato: disponibilidad inmediata
                    MessageBox.Show(
                        "Hay disponibilidad inmediata.",
                        "Disponibilidad",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                if (fecha == DateTime.MaxValue)
                {
                    // Según contrato: no se puede calcular (no hay ejemplares/préstamos activos, etc.)
                    MessageBox.Show(
                        "No se puede estimar la fecha de disponibilidad.\n" +
                        "Puede que no existan ejemplares registrados o no haya préstamos activos.",
                        "Disponibilidad no estimable",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        $"Fecha estimada de disponibilidad: {fecha:dd/MM/yyyy HH:mm}",
                        "Disponibilidad estimada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                // Preguntar si quiere consultar otro
                var res = MessageBox.Show(
                    "¿Quieres consultar otro ISBN?",
                    "Continuar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (res == DialogResult.Yes) continue;
                return;
            }
        }


        /// <summary>
        /// Abre un formulario de recorrido 1 a 1 sobre el listado de documentos.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> adqLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si existen documentos, se muestra el formulario de recorrido.
        /// Si no hay documentos, se informa mediante un mensaje.
        /// </remarks>
        private void RecorridoDocumentos1a1()
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada");
                return;
            }

            var documentos = adqLN.ListarDocumentos();
            if (documentos == null || documentos.Count == 0)
            {
                MessageBox.Show("No hay documentos registrados para mostrar.");
                return;
            }

            var f = new FBusquedaDoc1a1(documentos);
            f.ShowDialog();
        }



        // =========================
        // EJEMPLARES
        // =========================



        /// <summary>
        /// Lanza el flujo de alta de ejemplar solicitando código, ISBN asociado y estado de préstamo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> adqLN debe estar inicializado y personalAdq no debe ser null.
        /// Debe existir al menos un documento en el catálogo para asociar el ejemplar.
        /// <br/>
        /// <b>POST:</b> Si el código no existe y el usuario confirma, se construye un Ejemplar asociado a un Documento
        /// y se solicita el registro en LN junto con el personal responsable (auditoría).
        /// Se informa del resultado mediante un mensaje.
        /// </remarks>
        private void AltaEjemplar()
        {
            if (adqLN == null)
            {
                MessageBox.Show("No hay lógica de negocio de Adquisiciones inicializada.");
                return;
            }

            if (personalAdq == null)
            {
                MessageBox.Show("No hay personal de adquisiciones autenticado.");
                return;
            }


            while (true)
            {
                // Pedir código
                var fCod = new FIntroducirID(TipoIdentificador.CODIGO);
                if (fCod.ShowDialog() != DialogResult.OK)
                    return;

                string codigo = fCod.ValorIntroducido?.Trim();
                if (string.IsNullOrWhiteSpace(codigo))
                    continue;

                // Comprobar si ya existe
                var existente = adqLN.BuscarEjemplar(codigo);
                if (existente != null)
                {
                    var res = MessageBox.Show(
                        "Ya existe un ejemplar con ese código.\n¿Quieres introducir otro?",
                        "Código existente",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (res == DialogResult.Yes)
                        continue;

                    return;
                }

                // Cargar lista de ISBNs existentes
                var docs = adqLN.ListarDocumentos();
                if (docs == null || docs.Count == 0)
                {
                    MessageBox.Show("No hay documentos en el catálogo. Debe dar de alta un documento antes.");
                    return;
                }

                var isbns = docs
                    .Select(d => d.ISBN)
                    .Distinct()
                    .ToList();


                //  Formulario final
                var fEjem = new FEjemplar(codigo, nombreEmpleado, isbns);
                if (fEjem.ShowDialog() != DialogResult.OK)
                    return;

                string isbnSeleccionado = fEjem.IsbnSeleccionado;
                if (string.IsNullOrWhiteSpace(isbnSeleccionado))
                {
                    MessageBox.Show("Debe seleccionar un ISBN.");
                    continue; // vuelve al bucle y pide el código de nuevo
                }

                // Obtener documento real (para construir Ejemplar correctamente)
                Documento doc = adqLN.BuscarDocumento(isbnSeleccionado);
                if (doc == null)
                {
                    MessageBox.Show("El documento seleccionado ya no existe.");
                    return;
                }

                // Construir el ejemplar de dominio
                // IMPORTANTE: Ajusta constructor/propiedades al ModeloDominio real.
                Ejemplar nuevoEjemplar = new Ejemplar(codigo, doc);
                nuevoEjemplar.Prestado = false;  // el ejemplar nuevo lo marcamos como no prestado

                // Registrar en LN con auditoría
                bool ok = adqLN.RegistrarEjemplar(nuevoEjemplar, personalAdq);


                MessageBox.Show(ok
                            ? "Ejemplar registrado correctamente."
                            : "No se pudo registrar el ejemplar.");

                return;


            }



        }




        /// <summary>
        /// Lanza el flujo de búsqueda de ejemplar por código.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> adqLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si el ejemplar existe, se podría mostrar su ficha en modo consulta.
        /// Si no existe, se permite reintentar o cancelar.
        /// </remarks>
        private void BuscarEjemplar()
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada.");
                return;
            }

            while (true)
            {
                // Pedir código
                var fCod = new FIntroducirID(TipoIdentificador.CODIGO);
                if (fCod.ShowDialog() != DialogResult.OK)
                    return;

                string codigo = fCod.ValorIntroducido?.Trim();
                if (string.IsNullOrWhiteSpace(codigo))
                    continue;

                // Buscar
                Ejemplar ej = adqLN.BuscarEjemplar(codigo);

                if (ej == null)
                {
                    var res = MessageBox.Show(
                        "No existe ningún ejemplar con ese código.\n¿Quieres buscar otro?",
                        "Ejemplar no encontrado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (res == DialogResult.Yes) continue;
                    return;
                }

                // Recuperar el personal que dio de alta (si existe)
                Personal p = null;
                try { p = adqLN.QuienDioAlta(ej); } catch { p = null; }

                using (var f = new FEjemplar(ej, p))
                {
                    f.ShowDialog();
                }

                return;
            }

        }


        /// <summary>
        /// Lanza el flujo de baja de ejemplar solicitando código y confirmación.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> adqLN debe estar inicializado.
        /// <br/>
        /// <b>POST:</b> Si el ejemplar existe y no está prestado, se solicita su baja en LN.
        /// Se informa del resultado mediante mensajes.
        /// </remarks>
        private void BajaEjemplar()
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada.");
                return;
            }

            while (true)
            {
                // Pedir código
                var fCod = new FIntroducirID(TipoIdentificador.CODIGO);
                if (fCod.ShowDialog() != DialogResult.OK)
                    return;

                string codigo = fCod.ValorIntroducido?.Trim();
                if (string.IsNullOrWhiteSpace(codigo))
                    continue;

                // Buscar ejemplar
                Ejemplar ej = adqLN.BuscarEjemplar(codigo);
                if (ej == null)
                {
                    var resNo = MessageBox.Show(
                        "No existe ningún ejemplar con ese código.\n¿Quieres introducir otro?",
                        "Ejemplar no encontrado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (resNo == DialogResult.Yes) continue;
                    return;
                }

                // Regla de negocio: no se puede dar de baja si está prestado
                if (ej.Prestado)
                {
                    MessageBox.Show(
                        "No se puede dar de baja un ejemplar que está prestado actualmente.",
                        "Baja prohibida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    var otro = MessageBox.Show(
                        "¿Quieres introducir otro código?",
                        "Continuar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (otro == DialogResult.Yes) continue;
                    return;
                }


                // Confirmación
                var confirm = MessageBox.Show(
                    "¿Está seguro de que desea dar de baja este ejemplar?",
                    "Confirmar baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.No)
                {
                    var otro = MessageBox.Show(
                        "¿Quieres introducir otro código?",
                        "Continuar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (otro == DialogResult.Yes) continue;
                    return;
                }

                // Ejecutar baja en LN
                bool ok = adqLN.BajaEjemplar(ej);

                if (ok)
                {
                    MessageBox.Show(
                        "Ejemplar dado de baja correctamente.",
                        "Baja realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo dar de baja el ejemplar.\n" +
                        "Puede que no exista o esté prestado.",
                        "Baja no realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                return;
            }
        }

        public void ListadoEjemplaresDocumento(IPersonalAdquisicionesLN pAdq)
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada.");
                return;
            }
            // Pedir ISBN
            var fBuscarDocumento = new FBusquedaDocumento(pAdq);
            fBuscarDocumento.Name = "Buscar docuemnto";
            fBuscarDocumento.ShowDialog();
        }
        public void ListarEjemplares(List<Ejemplar> ejemplares)
        {
            if (adqLN == null)
            {
                MessageBox.Show("LN de Adquisiciones no inicializada.");
                return;
            }

            var fListado = new FListarEjemplares(ejemplares);
            fListado.Name = "Listado de Ejemplares";
            fListado.ShowDialog();




        }
    }
}
