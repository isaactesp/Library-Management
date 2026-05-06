using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.BBDD
{
    /// <summary>
    /// Representa los datos del Personal de Adquisiciones en la capa de persistencia.
    /// <br/>
    /// <b>NOTA:</b> Se asume que todos los datos se van a introducir correctamente antes de instanciar esta clase.
    /// </summary>
    internal class PersonalAdquisicionDato : Entity<string>
    {
        /// <summary>
        /// Constructor de PersonalAdquisicionDato.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El parámetro nSS es un identificador válido y correcto. <br/>
        /// <b>POST:</b> Crea una instancia inicializada, utilizando el NSS como identificador de la entidad.
        /// </remarks>
        /// <param name="nSS">Número de la Seguridad Social.</param>
        public PersonalAdquisicionDato(string nSS)
            : base(nSS)
        {
        }

        /// <summary>
        /// Número de la Seguridad Social (NSS).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El valor es un NSS correcto. <br/>
        /// <b>POST:</b> Devuelve o establece el identificador.
        /// </remarks>
        public string Nss
        {
            get { return base.Id; } // 'this.Id' o 'base.Id' es lo mismo, prefiero 'base' para ser explícito
            set { base.Id = value; }
        }
    }
}