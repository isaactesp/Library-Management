using ModeloDominio;
using Persistencia.BBDD;

namespace Persistencia.Transformers
{
    /// <summary>
    /// Realiza la conversión entre la entidad de Dominio (Usuario) y la entidad de Persistencia (UsuarioDato).
    /// </summary>
    internal class TransformerUsuario
    {
        /// <summary>
        /// Convierte un objeto de Dominio a un objeto de Datos.
        /// </summary>
        internal static UsuarioDato ToDato(Usuario u)
        {
            
            return new UsuarioDato(u.DNI, u.Nombre, u.Alta);
        }

        /// <summary>
        /// Reconstruye un objeto de Dominio a partir de un objeto de Datos.
        /// </summary>
        internal static Usuario ToObject(UsuarioDato uDato)
        {
            return new Usuario(uDato.DNI, uDato.Nombre, uDato.Alta);
        }
    }
}