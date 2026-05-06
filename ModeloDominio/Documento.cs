using System;

namespace ModeloDominio
{
    /// <summary>
    /// Representa un documento base en el dominio (Libro, AudioLibro).
    /// </summary>
    public abstract class Documento : ICloneable
    {
        // Usamos Propiedades Auto-implementadas para un código más limpio
        // (Al quitar las validaciones, no necesitamos los campos privados explícitos)

        /// <summary>
        /// Identificador único (ISBN).
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Título del documento.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Autor principal.
        /// </summary>
        public string Autor { get; set; }

        /// <summary>
        /// Año de publicación.
        /// </summary>
        public int AnioPublicacion { get; set; }

        /// <summary>
        /// Editorial responsable.
        /// </summary>
        public string Editorial { get; set; }

        // ===== Constructores =====

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Documento()
        {
            this.ISBN = string.Empty;
            this.Titulo = string.Empty;
            this.Autor = string.Empty;
            this.AnioPublicacion = 0;
            this.Editorial = string.Empty;
        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="isbn">ISBN del documento.</param>
        /// <param name="titulo">Título.</param>
        /// <param name="autor">Autor.</param>
        /// <param name="editorial">Editorial.</param>
        /// <param name="anioPublicacion">Año de publicación.</param>
        protected Documento(string isbn, string titulo, string autor, string editorial, int anioPublicacion)
        {
            // Asignación directa (Happy Path: confiamos en que los datos vienen bien)
            this.ISBN = isbn;
            this.Titulo = titulo;
            this.Autor = autor;
            this.Editorial = editorial;
            this.AnioPublicacion = anioPublicacion;
        }

        // ===== Sobrescrituras y utilidades =====

        /// <summary>
        /// Compara documentos basándose en el ISBN.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;

            Documento otro = obj as Documento;
            if (otro == null) return false;

            // Comparación de strings segura (ignora mayúsculas/minúsculas)
            return string.Equals(this.ISBN, otro.ISBN, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Genera el HashCode basado en el ISBN.
        /// </summary>
        public override int GetHashCode()
        {
            return string.IsNullOrEmpty(ISBN) ? 0 : ISBN.GetHashCode();
        }

        /// <summary>
        /// Clona el objeto (Copia superficial).
        /// </summary>
        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Representación en cadena del documento.
        /// </summary>
        public override string ToString()
        {
            return $"ISBN: {ISBN}, Título: {Titulo}, Autor: {Autor}, Año: {AnioPublicacion}, Editorial: {Editorial}";
        }
    }
}