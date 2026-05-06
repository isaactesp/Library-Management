using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.BBDD
{
    /// <summary>
    /// Representa los datos del Personal de Sala en la capa de persistencia.
    /// <br/>
    /// <b>NOTA:</b> Se asume que todos los datos se van a introducir correctamente antes de instanciar esta clase.
    /// </summary>
    internal class PersonalSalaDato : Entity<string>
    {
        /// <summary>
        /// Constructor de PersonalSalaDato.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El parámetro nSS es válido y correcto. <br/>
        /// <b>POST:</b> Crea una instancia inicializada, utilizando el NSS como identificador.
        /// </remarks>
        /// <param name="nSS">Número de la Seguridad Social (Identificador único).</param>
        public PersonalSalaDato(string nSS)
            : base(nSS) // Pasamos el valor al padre
        {
        }

        /// <summary>
        /// Número de la Seguridad Social (NSS).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El valor asignado es un NSS correcto. <br/>
        /// <b>POST:</b> Devuelve o establece el identificador del personal.
        /// </remarks>
        public string Nss
        {
            get { return base.Id; } // Accedemos a la propiedad del padre
            set { base.Id = value; }
        }
    }
}