using ModeloDominio;
using Persistencia.BBDD;

namespace Persistencia.Transformers
{
    /// <summary>
    /// Realiza la conversión entre la entidad de Dominio (Ejemplar) y la entidad de Persistencia (EjemplarDato).
    /// <br/>
    /// <b>NOTA:</b> Se asume que los datos de entrada son válidos.
    /// </summary>
    internal class TransformerEjemplar
    {
        /// <summary>
        /// Convierte un objeto de Dominio a un objeto de Datos.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Los objetos 'ejemplar' y 'personal' son válidos. <br/>
        /// <b>POST:</b> Devuelve una instancia de EjemplarDato con la Foreign Key del personal y del documento.
        /// </remarks>
        /// <param name="ejemplar">El ejemplar a guardar.</param>
        /// <param name="personal">El personal de adquisiciones que lo registró.</param>
        internal static EjemplarDato ToDato(Ejemplar ejemplar, Personal personal)
        {
            return new EjemplarDato(
                ejemplar.Codigo,
                ejemplar.Prestado,
                ejemplar.VecesPrestado,
                personal.NSS,         // Extraemos el NSS para la FK
                ejemplar.Documento.ISBN, // Extraemos el ISBN para la FK
                ejemplar.BajaLogica
            );
        }

        /// <summary>
        /// Reconstruye un objeto de Dominio a partir de un objeto de Datos y su Documento padre.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El 'dato' y el 'documento' no son nulos. <br/>
        /// <b>POST:</b> Devuelve el Ejemplar reconstruido con todo su estado (prestado, contador, etc.).
        /// </remarks>
        /// <param name="dato">Datos del ejemplar desde la BBDD.</param>
        /// <param name="documento">Objeto Documento (Libro o AudioLibro) al que pertenece.</param>
        internal static Ejemplar ToObject(EjemplarDato dato, Documento documento)
        {
            // 1. Instanciamos el ejemplar vinculándolo a su documento
            Ejemplar ejemplar = new Ejemplar(dato.Codigo, documento);

            // 2. IMPORTANTE: Restauramos el estado que tenía en la BBDD
            // Si no hacemos esto, el ejemplar parecería nuevo (no prestado y con contador a 0)
            ejemplar.Prestado = dato.Prestado;
            ejemplar.VecesPrestado = dato.VecesPrestado;
            ejemplar.BajaLogica = dato.BajaLogica;


            return ejemplar;
        }
    }
}