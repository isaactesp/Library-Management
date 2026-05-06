using System;

namespace ModeloDominio
{
    /// <summary>
    /// Representa al personal encargado de las adquisiciones.
    /// </summary>
    public class PersonalAdquisiciones : Personal
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Crea una instancia vacía llamando al base.
        /// </remarks>
        public PersonalAdquisiciones() : base()
        {
        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Crea una instancia con el NSS asignado.
        /// </remarks>
        /// <param name="nss">Número de la Seguridad Social.</param>
        public PersonalAdquisiciones(string nss) : base(nss)
        {
        }

        /// <summary>
        /// Representación textual específica para Personal de Adquisiciones.
        /// </summary>
        /// <returns>Cadena formateada con el tipo de personal y su NSS.</returns>
        public override string ToString()
        {
            return $"[Personal Adquisiciones] {base.ToString()}";
        }

        // NOTA: Hereda el comportamiento de Equals de la clase Personal.
    }
}