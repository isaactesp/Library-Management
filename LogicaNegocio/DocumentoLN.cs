using System;
using System.Collections.Generic;
using ModeloDominio;
using Persistencia.Interfaces;

namespace LogicaNegocio
{
    /// <summary>
    /// Especialista en la gestión del Catálogo de Documentos (Libros y AudioLibros).
    /// <br/>
    /// <b>RESPONSABILIDAD:</b> Validar y persistir la información bibliográfica, abstrayendo
    /// si se trata de un libro físico o digital.
    /// </summary>
    public class DocumentoLN
    {
        // Dependencias de persistencia (solo catálogo y estadísticas)
        private readonly IPersistenciaLibro persistenciaLibro;
        private readonly IPersistenciaAudioLibro persistenciaAudioLibro;
        private readonly IPersistenciaEjemplarPrestamo persistenciaEjemplarPrestamo;

        /// <summary>
        /// Constructor que recibe las dependencias necesarias (Inyección de Dependencias).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Las interfaces de persistencia no deben ser nulas. <br/>
        /// <b>POST:</b> Crea una instancia lista para operar sobre el catálogo.
        /// </remarks>
        /// <param name="persistenciaLibro">Acceso a datos de Libros.</param>
        /// <param name="persistenciaAudioLibro">Acceso a datos de Audiolibros.</param>
        /// <param name="persistenciaEjemplarPrestamo">Acceso a datos estadísticos de préstamos.</param>
        public DocumentoLN(IPersistenciaLibro persistenciaLibro, IPersistenciaAudioLibro persistenciaAudioLibro, IPersistenciaEjemplarPrestamo persistenciaEjemplarPrestamo)
        {
            this.persistenciaLibro = persistenciaLibro;
            this.persistenciaAudioLibro = persistenciaAudioLibro;
            this.persistenciaEjemplarPrestamo = persistenciaEjemplarPrestamo;
        }

        // ==========================================
        // MÉTODOS DE ESCRITURA (ALTA/BAJA/MOD)
        // ==========================================

        /// <summary>
        /// Registra un nuevo documento en el repositorio correspondiente según su tipo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El documento es válido y no existe previamente en el catálogo. <br/>
        /// <b>POST:</b> Devuelve true si el documento se persiste correctamente.
        /// </remarks>
        /// <param name="documento">El objeto Documento (puede ser Libro o AudioLibro).</param>
        /// <returns>True si se registró, False si hubo error o tipo desconocido.</returns>
        public bool AltaDocumento(Documento documento)
        {
            if (documento is Libro libro)
            {
                return persistenciaLibro.AltaLibro(libro);
            }
            if (documento is AudioLibro audioLibro)
            {
                return persistenciaAudioLibro.AltaAudioLibro(audioLibro);
            }
            return false;
        }

        /// <summary>
        /// Elimina un documento del catálogo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El documento existe en el sistema. <br/>
        /// <b>POST:</b> Devuelve true si se elimina el registro.
        /// </remarks>
        /// <param name="documento">El objeto Documento a eliminar.</param>
        /// <returns>True si la baja fue exitosa.</returns>
        public bool BajaDocumento(Documento documento)
        {
            if (documento is Libro libro)
            {
                return persistenciaLibro.BajaLibro(libro);
            }
            if (documento is AudioLibro audioLibro)
            {
                return persistenciaAudioLibro.BajaAudioLibro(audioLibro);
            }
            return false;
        }

        /// <summary>
        /// Actualiza los datos de un documento existente.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El documento existe y los datos modificados son válidos. <br/>
        /// <b>POST:</b> La información en la persistencia queda actualizada.
        /// </remarks>
        /// <param name="documento">El objeto Documento con los cambios.</param>
        public void ModificarDocumento(Documento documento)
        {
            if (documento is Libro libro)
            {
                persistenciaLibro.ModificarLibro(libro);
            }
            if (documento is AudioLibro audioLibro)
            {
                persistenciaAudioLibro.ModificarAudioLibro(audioLibro);
            }
        }

        // ==========================================
        // MÉTODOS DE LECTURA (CONSULTAS)
        // ==========================================

        /// <summary>
        /// Busca un documento por su ISBN en ambos catálogos (Libros y Audiolibros).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ISBN no es nulo ni vacío. <br/>
        /// <b>POST:</b> Devuelve el documento encontrado o null si no existe en ninguno de los repositorios.
        /// </remarks>
        /// <param name="isbn">Identificador único (ISBN).</param>
        /// <returns>El objeto Documento encontrado o null.</returns>
        public Documento BuscarDocumento(string isbn)
        {
            // 1. Intentamos buscar como Libro
            Documento doc = persistenciaLibro.ObtenerLibro(isbn);

            // 2. Si no es libro, probamos como AudioLibro
            if (doc == null)
            {
                doc = persistenciaAudioLibro.ObtenerAudioLibro(isbn);
            }

            return doc;
        }

        /// <summary>
        /// Obtiene solo la lista de Libros (formato papel) registrados.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Devuelve la lista completa de libros.
        /// </remarks>
        /// <returns>Lista de Libros.</returns>
        public List<Libro> ListarLibros()
        {
            return persistenciaLibro.ObtenerTodosLibros();
        }

        /// <summary>
        /// Obtiene solo la lista de AudioLibros registrados.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Devuelve la lista completa de audiolibros.
        /// </remarks>
        /// <returns>Lista de AudioLibros.</returns>
        public List<AudioLibro> ListarAudioLibros()
        {
            return persistenciaAudioLibro.ObtenerTodosAudioLibros();
        }

        /// <summary>
        /// Obtiene el catálogo completo unificado (Libros + AudioLibros).
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Devuelve una lista polimórfica con todos los documentos.
        /// </remarks>
        /// <returns>Lista de Documentos.</returns>
        public List<Documento> ListarDocumentos()
        {
            List<Documento> catalogo = new List<Documento>();

            catalogo.AddRange(persistenciaLibro.ObtenerTodosLibros());
            catalogo.AddRange(persistenciaAudioLibro.ObtenerTodosAudioLibros());

            return catalogo;
        }

        /// <summary>
        /// Obtiene el documento más popular en un rango de fechas personalizado.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> La fecha de inicio debe ser anterior o igual a la fecha de fin. <br/>
        /// <b>POST:</b> Devuelve el documento con mayor número de préstamos en ese intervalo.
        /// </remarks>
        /// <param name="inicio">Fecha de inicio del periodo.</param>
        /// <param name="fin">Fecha de fin del periodo.</param>
        /// <returns>Documento más popular o null.</returns>
        public Documento ObtenerDocumentoPopularIntervaloDeTiempo(DateTime inicio, DateTime fin)
        {
            return persistenciaEjemplarPrestamo.ObtenerDocumentoMasPrestado(inicio, fin);
        }
    }
}