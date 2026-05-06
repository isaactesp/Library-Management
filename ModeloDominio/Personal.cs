using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    /// <summary>
    /// Clase base abstracta que representa a un trabajador de la biblioteca.
    /// </summary>
    public abstract class Personal
    {
        /// <summary>
        /// Campo interno para el Número de la Seguridad Social.
        /// </summary>
        protected string nSS;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Inicializa el NSS como una cadena vacía.
        /// </remarks>
        protected Personal()
        {
            this.nSS = string.Empty;
        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Inicializa el Personal con el NSS proporcionado.
        /// </remarks>
        /// <param name="nSS">Número de la Seguridad Social.</param>
        protected Personal(string nSS)
        {
            this.nSS = nSS;
        }

        /// <summary>
        /// Propiedad para acceder al Número de la Seguridad Social.
        /// </summary>
        /// <remarks>
        /// El 'set' es protegido para evitar modificaciones externas directas.
        /// </remarks>
        public string NSS
        {
            get { return nSS; }
            protected set { nSS = value; }
        }

        /// <summary>
        /// Compara este personal con otro basándose en el NSS.
        /// </summary>
        /// <param name="otroPersonal">Objeto Personal a comparar.</param>
        /// <returns>True si tienen el mismo NSS, False en caso contrario.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Personal otro)
            {
                return this.nSS == otro.nSS;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return nSS != null ? nSS.GetHashCode() : 0;
        }

       /// <summary>
       /// Devuelve una representación textual del personal.
       /// </summary>
       /// <returns>Cadena con el NSS.</returns>
       public override string ToString()
       {
           return $" {nSS}";
       }
    }
}
