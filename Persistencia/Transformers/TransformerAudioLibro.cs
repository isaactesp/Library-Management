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
    /// Realiza la conversión entre la entidad de Dominio (AudioLibro) y la entidad de Persistencia (AudioLibroDato).
    /// <br/>
    /// <b>NOTA:</b> Se asume que los objetos de entrada contienen datos válidos y correctos.
    /// </summary>
    internal class TransformerAudioLibro
    {
        /// <summary>
        /// Convierte un objeto de Dominio a un objeto de Datos.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El parámetro 'audioLibro' no es nulo y sus datos son válidos. <br/>
        /// <b>POST:</b> Devuelve una nueva instancia de AudioLibroDato lista para persistir.
        /// </remarks>
        /// <param name="audioLibro">Objeto del dominio AudioLibro.</param>
        /// <returns>Objeto de datos AudioLibroDato.</returns>
        internal static AudioLibroDato ToDato(AudioLibro audioLibro)
        {
            return new AudioLibroDato(
                audioLibro.Titulo,
                audioLibro.Autor,
                audioLibro.Editorial,
                audioLibro.AnioPublicacion,
                audioLibro.ISBN,
                audioLibro.DuracionMinutos, // Propiedad del dominio
                audioLibro.Formato
            );
        }

        /// <summary>
        /// Reconstruye un objeto de Dominio a partir de un objeto de Datos.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El parámetro 'dato' no es nulo. <br/>
        /// <b>POST:</b> Devuelve una nueva instancia de AudioLibro reconstruida.
        /// </remarks>
        /// <param name="dato">Objeto de datos recuperado de la persistencia.</param>
        /// <returns>Objeto del dominio AudioLibro.</returns>
        internal static AudioLibro ToObject(AudioLibroDato dato)
        {
            return new AudioLibro(
                 dato.Isbn,
                 dato.Titulo,
                 dato.Autor,
                 dato.Editorial,
                 dato.AnioPublicacion,
                 dato.Duracion, // Propiedad del dato
                 dato.Formato
            );
        }
    }
}