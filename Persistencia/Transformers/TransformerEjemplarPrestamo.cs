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
    /// Transforma objetos de Dominio a Datos para la relación Préstamo-Ejemplar.
    /// <br/>
    /// <b>NOTA:</b> Se asume que los datos de entrada son válidos (Happy Path).
    /// </summary>
    internal class TransformerEjemplarPrestamo
    {
        /// <summary>
        /// Convierte la relación entre un Préstamo y un Ejemplar (Dominio) a su entidad de persistencia.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Los objetos 'prestamo' y 'ejemplar' no son nulos y tienen identificadores válidos. <br/>
        /// <b>POST:</b> Devuelve el objeto dato con la clave compuesta configurada correctamente.
        /// </remarks>
        /// <param name="p">Objeto Préstamo (contiene el IdPrestamo).</param>
        /// <param name="ej">Objeto Ejemplar (contiene el Codigo).</param>
        /// <returns>Instancia de EjemplarPrestamoDato lista para guardar en BD.</returns>
        public static EjemplarPrestamoDato ToDato(Prestamo p, Ejemplar ej)
        {
            return new EjemplarPrestamoDato(p.IdPrestamo, ej.Codigo);
        }
    }
}