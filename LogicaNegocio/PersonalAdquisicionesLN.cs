using System;
using System.Collections.Generic;
using System.Linq;
using LogicaNegocio.Interfaces;
using ModeloDominio;
using Persistencia;
using Persistencia.Interfaces;

namespace LogicaNegocio
{
    /// <summary>
    /// Lógica de Negocio (Fachada) para el rol de Personal de Adquisiciones.
    /// <br/>
    /// <b>RESPONSABILIDAD:</b> Actuar como ORQUESTADOR. No accede a BBDD directamente,
    /// sino que coordina a los especialistas (DocumentoLN y EjemplarLN).
    /// </summary>
    public class PersonalAdquisicionesLN : PersonalLN, IPersonalAdquisicionesLN
    {
        // ==========================================
        // ESPECIALISTAS (Los que hacen el trabajo duro)
        // ==========================================
        private readonly DocumentoLN documentoLN;
        private readonly EjemplarLN ejemplarLN;

        // Fachada de préstamos necesaria para calcular disponibilidades futuras
        private readonly IPersistenciaPrestamo persistenciaPrestamo;

        
        private readonly IPersistenciaPersonalAdquisiciones perPersonalAdq;


        /// <summary>
        /// Constructor: Inicializa las dependencias y configura a los especialistas.
        /// </summary>
        public PersonalAdquisicionesLN(
            IPersistenciaUsuario perUsuario, 
            IPersistenciaLibro perLibro, 
            IPersistenciaAudioLibro perAudio, 
            IPersistenciaEjemplar perEjemplar, 
            IPersistenciaEjemplarPrestamo perEjPres, 
            IPersistenciaPrestamo perPrestamo,
            IPersistenciaPersonalAdquisiciones perPersonalAdq) 
            : base(perUsuario)
        {
            this.persistenciaPrestamo = perPrestamo;
            this.perPersonalAdq = perPersonalAdq;


            this.documentoLN = new DocumentoLN(perLibro, perAudio, perEjPres);
            this.ejemplarLN = new EjemplarLN(perEjemplar);
        }

        public override void RegistrarPersonal(Personal personal)
        {
            this.perPersonalAdq.AltaPersonalAdquisiciones((PersonalAdquisiciones) personal);
        }

        // ==========================================
        // GESTIÓN DE DOCUMENTOS (Delega en DocumentoLN)
        // ==========================================

        public bool AltaDocumento(Documento documento)
        {
            return this.documentoLN.AltaDocumento(documento);
        }

        public bool BajaDocumento(Documento documento)
        {
            return this.documentoLN.BajaDocumento(documento);
        }

        public Documento BuscarDocumento(string isbn)
        {
            return this.documentoLN.BuscarDocumento(isbn);
        }

        public List<Documento> ListarDocumentos()
        {
            return this.documentoLN.ListarDocumentos();
        }

        public List<Libro> ListarLibros()
        {
            return this.documentoLN.ListarLibros();
        }

        public List<AudioLibro> ListarAudioLibros()
        {
            return this.documentoLN.ListarAudioLibros();
        }

        // ==========================================
        // GESTIÓN DE EJEMPLARES (Delega en EjemplarLN)
        // ==========================================

        public bool RegistrarEjemplar(Ejemplar ejemplar, PersonalAdquisiciones personalAdquisiones)
        {
            // Delegamos pasando el personal responsable para la auditoría
            return this.ejemplarLN.AltaEjemplar(ejemplar, personalAdquisiones);
        }

        public bool BajaEjemplar(Ejemplar ejemplar)
        {
            return this.ejemplarLN.BajaEjemplar(ejemplar);
        }

        public Ejemplar BuscarEjemplar(string codigo)
        {
            return this.ejemplarLN.BuscarEjemplar(codigo);
        }

        
        public Personal QuienDioAlta(Ejemplar ejemplar)
        {
            return this.ejemplarLN.QuienDioAlta(ejemplar);
        }

        /// <summary>
        /// Obtiene todos los ejemplares del sistema.
        /// </summary>
        /// <returns>Lista completa de ejemplares.</returns>
        public List<Ejemplar> ObtenerTodosEjemplares()
        {
            return this.ejemplarLN.ObtenerTodosEjemplares();
        }

        // ==========================================
        // LÓGICA COMPLEJA (El valor de esta clase)
        // ==========================================

        /// <summary>
        /// Coordina DocumentoLN y EjemplarLN para listar ejemplares de un ISBN.
        /// </summary>
        public List<Ejemplar> ConsultarEjemplares(string isbn)
        {
            // 1. Buscamos el documento (Cabecera)
            Documento doc = this.documentoLN.BuscarDocumento(isbn);

            if (doc == null) return new List<Ejemplar>(); // Si no existe el doc, no hay ejemplares

            // 2. Pedimos los ejemplares usando el objeto documento
            return this.ejemplarLN.ListarEjemplaresDeDocumento(doc);
        }

        public bool HayDisponibilidad(string isbn)
        {
            // Reutilizamos nuestro propio método orquestado
            List<Ejemplar> ejemplares = ConsultarEjemplares(isbn);

            // LINQ: ¿Hay alguno NO prestado?
            return ejemplares.Any(e => !e.Prestado);
        }

        public DateTime CuandoDisponible(string isbn)
        {
            // 1. Si hay stock ahora mismo, devolvemos MinValue
            if (HayDisponibilidad(isbn)) return DateTime.MinValue;

            // 2. Buscamos el documento para saber si es Libro o AudioLibro
            Documento doc = this.documentoLN.BuscarDocumento(isbn);
            if (doc == null) return DateTime.MaxValue; // Error: documento no existe

            // 3. Obtenemos los préstamos activos de este documento
            List<Prestamo> prestamosActivos = this.persistenciaPrestamo
                                                  .ObtenerPrestamosDeDocumento(doc)
                                                  .Where(p => p.Estado == true) // Estado true = En proceso
                                                  .ToList();

            if (prestamosActivos.Count == 0) return DateTime.MaxValue; // No hay ejemplares ni préstamos (¿perdidos?)

            // 4. Calculamos la fecha de devolución prevista para cada préstamo
            // Regla: Libros +15 días, AudioLibros +10 días desde la fecha de préstamo.
            int diasPlazo = (doc is Libro) ? 15 : 10;

            DateTime fechaMasProxima = prestamosActivos
                .Select(p => p.FechaPrestado.AddDays(diasPlazo))
                .OrderBy(f => f) // Ordenamos de más cercana a más lejana
                .FirstOrDefault();

            return fechaMasProxima;
        }

        public Documento ObtenerDocumentoPopular()
        {
            // 1. Obtenemos TODOS los ejemplares del sistema
            var todos = this.ejemplarLN.ObtenerTodosEjemplares();

            if (todos.Count == 0) return null;

            // 2. Agrupamos por Documento y sumamos sus préstamos (VecesPrestado es propiedad del Ejemplar)
            var popular = todos
                .GroupBy(e => e.Documento)
                .Select(g => new { Doc = g.Key, Total = g.Sum(e => e.VecesPrestado) })
                .OrderByDescending(x => x.Total)
                .FirstOrDefault();

            return popular?.Doc;
        }

        /// <summary>
        /// Obtiene el documento más popular (más prestado) en el último mes.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve el documento con más préstamos en los últimos 30 días, o null si no hubo actividad.
        /// </remarks>
        /// <returns>Documento más popular del mes.</returns>
        public Documento ObtenerDocumentoPopularUltimoMes()
        {
            // Calcula desde hace 1 mes hasta el instante actual
            return this.documentoLN.ObtenerDocumentoPopularIntervaloDeTiempo(DateTime.Now.AddMonths(-1), DateTime.Now);
        }

        public Documento ObtenerDocumentoPopularIntervaloDeTiempo(DateTime inicio, DateTime fin)
        {
            return this.documentoLN.ObtenerDocumentoPopularIntervaloDeTiempo(inicio, fin);
        }




    }
}