using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace ModeloDominio
{
    /// <summary>
    /// Representa un libro en papel dentro del dominio.
    /// </summary>
    public class Libro : Documento 
    {
        // ===== Constructores =====

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Crea una instancia vacía.
        /// </remarks>
        public Libro() : base() { }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Se asume que todos los parámetros son válidos. <br/>
        /// <b>POST:</b> Crea un libro inicializado con los datos proporcionados.
        /// </remarks>
        /// <param name="isbn">Identificador único.</param>
        /// <param name="titulo">Título de la obra.</param>
        /// <param name="autor">Autor principal.</param>
        /// <param name="editorial">Editorial.</param>
        /// <param name="anioPublicacion">Año de edición.</param>
        public Libro(string isbn, string titulo, string autor, string editorial, int anioPublicacion)
            : base(isbn, titulo, autor, editorial, anioPublicacion)
        {
            // No necesita lógica adicional, todo lo maneja el padre Documento
        }

        // ===== Sobrescrituras =====

        /// <summary>
        /// Representación textual del Libro.
        /// </summary>
        public override string ToString()
        {
            return $"{base.ToString()} (Tipo: Libro Papel)";
        }
    }
}