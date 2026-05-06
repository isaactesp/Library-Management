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
    /// Realiza la conversión entre la entidad de Dominio (PersonalAdquisiciones) y la entidad de Persistencia (PersonalAdquisicionDato).
    /// <br/>
    /// <b>NOTA:</b> Se asume que los objetos de entrada contienen datos válidos y correctos.
    /// </summary>
    internal class TransformerPAdquisiciones
    {
        /// <summary>
        /// Convierte un objeto de Dominio a un objeto de Datos.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El parámetro 'personal' no es nulo y tiene datos válidos. <br/>
        /// <b>POST:</b> Devuelve una nueva instancia de PersonalAdquisicionDato con la información transferida.
        /// </remarks>
        /// <param name="personal">Objeto del dominio PersonalAdquisiciones.</param>
        /// <returns>Objeto de datos listo para la persistencia.</returns>
        internal static PersonalAdquisicionDato ToDato(PersonalAdquisiciones personal)
        {
            return new PersonalAdquisicionDato(personal.NSS);
        }

        /// <summary>
        /// Reconstruye un objeto de Dominio a partir de un objeto de Datos.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El parámetro 'dato' no es nulo. <br/>
        /// <b>POST:</b> Devuelve una nueva instancia de PersonalAdquisiciones reconstruida.
        /// </remarks>
        /// <param name="dato">Objeto de datos recuperado de la persistencia.</param>
        /// <returns>Objeto del dominio PersonalAdquisiciones.</returns>
        internal static PersonalAdquisiciones ToObject(PersonalAdquisicionDato dato)
        {
            return new PersonalAdquisiciones(dato.Nss);
        }
    }
}