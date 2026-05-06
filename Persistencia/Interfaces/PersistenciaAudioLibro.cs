using ModeloDominio;
using Persistencia.CRUD;
using Persistencia.Interfaces;
using System.Collections.Generic;

namespace Persistencia
{
    /// <summary>
    /// Fachada de persistencia para AudioLibros.
    /// <br/>
    /// Conecta la interfaz pública con el CRUD estático interno.
    /// </summary>
    public class PersistenciaAudioLibro : IPersistenciaAudioLibro
    {
        /// <summary>
        /// Registra un nuevo audiolibro delegando en el CRUD.
        /// </summary>
        /// <param name="audioLibro">Objeto AudioLibro a registrar.</param>
        /// <returns>True si el guardado fue exitoso (se verifica su existencia posterior).</returns>
        public bool AltaAudioLibro(AudioLibro audioLibro)
        {
            AudioLibroCRUD.AltaAudioLibro(audioLibro);
            // Verificamos si realmente se guardó para devolver el bool
            return AudioLibroCRUD.ExisteAudioLibro(audioLibro.ISBN);
        }

        /// <summary>
        /// Elimina un audiolibro delegando en el CRUD.
        /// </summary>
        /// <param name="audioLibro">Objeto AudioLibro a eliminar.</param>
        /// <returns>True si el borrado fue exitoso (ya no existe).</returns>
        public bool BajaAudioLibro(AudioLibro audioLibro)
        {
            AudioLibroCRUD.BajaAudioLibro(audioLibro);
            // Devolvemos true si YA NO existe
            return !AudioLibroCRUD.ExisteAudioLibro(audioLibro.ISBN);
        }

        /// <summary>
        /// Actualiza un audiolibro delegando en el CRUD.
        /// </summary>
        /// <param name="audioLibro">Objeto AudioLibro modificado.</param>
        public void ModificarAudioLibro(AudioLibro audioLibro)
        {
            AudioLibroCRUD.ModificarAudioLibro(audioLibro);
        }

        /// <summary>
        /// Obtiene un audiolibro por ISBN delegando en el CRUD.
        /// </summary>
        /// <param name="isbn">ISBN a buscar.</param>
        /// <returns>El objeto AudioLibro o null.</returns>
        public AudioLibro ObtenerAudioLibro(string isbn)
        {
            return AudioLibroCRUD.ObtenerAudioLibro(isbn);
        }

        /// <summary>
        /// Verifica existencia por ISBN delegando en el CRUD.
        /// </summary>
        /// <param name="isbn">ISBN a verificar.</param>
        /// <returns>True si existe.</returns>
        public bool ExisteAudioLibro(string isbn)
        {
            return AudioLibroCRUD.ExisteAudioLibro(isbn);
        }

        /// <summary>
        /// Obtiene todos los audiolibros delegando en el CRUD.
        /// </summary>
        /// <returns>Lista de audiolibros.</returns>
        public List<AudioLibro> ObtenerTodosAudioLibros()
        {
            return AudioLibroCRUD.ObtenerTodosAudioLibros();
        }
    }
}