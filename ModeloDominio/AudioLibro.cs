using System;

namespace ModeloDominio
{
    /// <summary>
    /// Representa un audiolibro digital.
    /// </summary>
    public class AudioLibro : Documento 
    {
        // ===== Propiedades Auto-implementadas =====

        /// <summary>
        /// Duración del audio en minutos.
        /// </summary>
        public int DuracionMinutos { get; set; }

        /// <summary>
        /// Formato del archivo (mp3, wav, aac...).
        /// </summary>
        public string Formato { get; set; }

        // ===== Constructores =====

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Crea una instancia vacía.
        /// </remarks>
        public AudioLibro() : base()
        {
            this.DuracionMinutos = 0;
            this.Formato = string.Empty;
        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Se asume que los datos son válidos. <br/>
        /// <b>POST:</b> Crea un audiolibro inicializado.
        /// </remarks>
        /// <param name="isbn">Identificador único.</param>
        /// <param name="titulo">Título.</param>
        /// <param name="autor">Autor.</param>
        /// <param name="editorial">Editorial.</param>
        /// <param name="anioPublicacion">Año de edición.</param>
        /// <param name="duracionMinutos">Duración en minutos.</param>
        /// <param name="formato">Formato digital.</param>
        public AudioLibro(string isbn, string titulo, string autor, string editorial, int anioPublicacion,
                          int duracionMinutos, string formato)
            : base(isbn, titulo, autor, editorial, anioPublicacion)
        {
            this.DuracionMinutos = duracionMinutos;
            this.Formato = formato;
        }

        // ===== Sobrescrituras =====

        /// <summary>
        /// Representación textual del AudioLibro.
        /// </summary>
        public override string ToString() // <-- CORREGIDO: 'S' mayúscula
        {
            return $"{base.ToString()}, Duración: {DuracionMinutos} min, Fmt: {Formato}";
        }
    }
}