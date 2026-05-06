using ModeloDominio;
using Persistencia.BBDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Transformers
{
    /// <summary>
    /// Realiza la conversión entre la entidad de Dominio (Libro) y la entidad de Persistencia (LibroDato).
    /// <br/>
    /// <b>NOTA:</b> Se asume que los objetos de entrada contienen datos válidos y correctos.
    /// </summary>
    internal class TransformerLibro
    {
        /// <summary>
        /// Convierte un objeto de Dominio a un objeto de Datos.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El parámetro 'libro' no es nulo y tiene datos válidos. <br/>
        /// <b>POST:</b> Devuelve una nueva instancia de LibroDato lista para persistir.
        /// </remarks>
        /// <param name="libro">Objeto del dominio Libro.</param>
        /// <returns>Objeto de datos LibroDato.</returns>
        internal static LibroDato ToDato(Libro libro)
        {
            return new LibroDato(
                libro.Titulo,
                libro.Autor,
                libro.Editorial,
                libro.AnioPublicacion,
                libro.ISBN
            );
        }

        /// <summary>
        /// Reconstruye un objeto de Dominio a partir de un objeto de Datos.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El parámetro 'dato' no es nulo. <br/>
        /// <b>POST:</b> Devuelve una nueva instancia de Libro reconstruida.
        /// </remarks>
        /// <param name="dato">Objeto de datos recuperado de la persistencia.</param>
        /// <returns>Objeto del dominio Libro.</returns>
        internal static Libro ToObject(LibroDato dato)
        {
            return new Libro(
                dato.Isbn,
                dato.Titulo,
                dato.Autor,
                dato.Editorial,
                dato.AnioPublicacion
            );
        }
    }
}