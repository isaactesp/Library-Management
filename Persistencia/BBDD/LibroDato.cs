using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.BBDD
{
    /// <summary>
    /// Representa los datos de un Libro (papel) en la capa de persistencia.
    /// <br/>
    /// <b>NOTA:</b> Se asume que todos los datos se van a introducir correctamente antes de instanciar esta clase.
    /// </summary>
    internal class LibroDato : Entity<string>
    {
        private string titulo;
        private string autor;
        private string editorial;
        private int anioPublicacion;

        /// <summary>
        /// Constructor de LibroDato.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Todos los parámetros son válidos y el ISBN es correcto. <br/>
        /// <b>POST:</b> Crea una instancia inicializada, usando el ISBN como identificador.
        /// </remarks>
        /// <param name="titulo">Título del libro.</param>
        /// <param name="autor">Autor principal.</param>
        /// <param name="editorial">Editorial responsable.</param>
        /// <param name="anioPublicacion">Año de edición.</param>
        /// <param name="isbn">Identificador único (ISBN).</param>
        public LibroDato(string titulo, string autor, string editorial, int anioPublicacion, string isbn)
            : base(isbn) // Pasamos el ISBN al padre
        {
            this.titulo = titulo;
            this.autor = autor;
            this.editorial = editorial;
            this.anioPublicacion = anioPublicacion;
        }

        /// <summary>
        /// Título del libro.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El título no es vacío. <br/>
        /// <b>POST:</b> Devuelve o establece el título.
        /// </remarks>
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        /// <summary>
        /// Autor del libro.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El autor es válido. <br/>
        /// <b>POST:</b> Devuelve o establece el autor.
        /// </remarks>
        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        /// <summary>
        /// Editorial del libro.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> La editorial es válida. <br/>
        /// <b>POST:</b> Devuelve o establece la editorial.
        /// </remarks>
        public string Editorial
        {
            get { return editorial; }
            set { editorial = value; }
        }

        /// <summary>
        /// Año de publicación.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El año es un entero válido. <br/>
        /// <b>POST:</b> Devuelve o establece el año.
        /// </remarks>
        public int AnioPublicacion
        {
            get { return anioPublicacion; }
            set { anioPublicacion = value; }
        }

        /// <summary>
        /// ISBN del libro (Identificador único).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ISBN es válido y único. <br/>
        /// <b>POST:</b> Devuelve o establece el identificador del libro.
        /// </remarks>
        public string Isbn
        {
            get { return base.Id; } // Accedemos a la propiedad del padre
            set { base.Id = value; }
        }
    }
}