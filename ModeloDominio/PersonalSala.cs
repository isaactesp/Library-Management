using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    /// <summary>
    /// Representa a un trabajador del personal de sala de la biblioteca.
    /// </summary>
    public class PersonalSala : Personal
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Crea una instancia vacía de Personal de Sala.
        /// </remarks>
        public PersonalSala() : base() { }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Inicializa el Personal de Sala con el NSS proporcionado.
        /// </remarks>
        /// <param name="nss">Número de la Seguridad Social.</param>
        public PersonalSala(string nss) : base(nss) { }
    }
}
