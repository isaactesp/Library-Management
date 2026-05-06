using ModeloDominio;
using System.Collections.Generic;

namespace Persistencia.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de persistencia para AudioLibros.
    /// <br/>
    /// Desacopla la Lógica de Negocio de la implementación concreta de datos.
    /// </summary>
    public interface IPersistenciaAudioLibro
    {
        /// <summary>
        /// Registra un nuevo audiolibro en el sistema.
        /// </summary>
        /// <param name="audioLibro">Objeto AudioLibro con los datos a persistir.</param>
        /// <returns>True si el audiolibro se guardó correctamente en el sistema.</returns>
        bool AltaAudioLibro(AudioLibro audioLibro);

        /// <summary>
        /// Elimina un audiolibro existente.
        /// </summary>
        /// <param name="audioLibro">Objeto AudioLibro a eliminar.</param>
        /// <returns>True si el audiolibro fue eliminado correctamente.</returns>
        bool BajaAudioLibro(AudioLibro audioLibro);

        /// <summary>
        /// Actualiza los datos de un audiolibro.
        /// </summary>
        /// <param name="audioLibro">Objeto AudioLibro con los datos modificados.</param>
        void ModificarAudioLibro(AudioLibro audioLibro);

        /// <summary>
        /// Busca un audiolibro por su ISBN.
        /// </summary>
        /// <param name="isbn">Identificador único del audiolibro.</param>
        /// <returns>El objeto AudioLibro encontrado o null si no existe.</returns>
        AudioLibro ObtenerAudioLibro(string isbn);

        /// <summary>
        /// Verifica si existe un audiolibro con ese ISBN.
        /// </summary>
        /// <param name="isbn">ISBN a verificar.</param>
        /// <returns>True si existe, False en caso contrario.</returns>
        bool ExisteAudioLibro(string isbn);

        /// <summary>
        /// Obtiene todos los audiolibros registrados.
        /// </summary>
        /// <returns>Lista completa de audiolibros.</returns>
        List<AudioLibro> ObtenerTodosAudioLibros();
    }
}