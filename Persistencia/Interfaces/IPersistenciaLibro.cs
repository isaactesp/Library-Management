using ModeloDominio;
using System.Collections.Generic;

namespace Persistencia.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de persistencia para Libros (formato papel).
    /// <br/>
    /// Desacopla la Lógica de Negocio de la implementación concreta de datos.
    /// </summary>
    public interface IPersistenciaLibro
    {
        /// <summary>
        /// Registra un nuevo libro en el sistema.
        /// </summary>
        /// <param name="libro">Objeto Libro a registrar.</param>
        /// <returns>True si el libro se guardó correctamente.</returns>
        bool AltaLibro(Libro libro);

        /// <summary>
        /// Elimina un libro existente.
        /// </summary>
        /// <param name="libro">Objeto Libro a eliminar.</param>
        /// <returns>True si el libro fue eliminado correctamente.</returns>
        bool BajaLibro(Libro libro);

        /// <summary>
        /// Actualiza los datos de un libro.
        /// </summary>
        /// <param name="libro">Objeto Libro con los datos modificados.</param>
        void ModificarLibro(Libro libro);

        /// <summary>
        /// Busca un libro por su ISBN.
        /// </summary>
        /// <param name="isbn">Identificador único del libro.</param>
        /// <returns>El objeto Libro encontrado o null si no existe.</returns>
        Libro ObtenerLibro(string isbn);

        /// <summary>
        /// Verifica si existe un libro con ese ISBN.
        /// </summary>
        /// <param name="isbn">ISBN a verificar.</param>
        /// <returns>True si existe, False en caso contrario.</returns>
        bool ExisteLibro(string isbn);

        /// <summary>
        /// Obtiene todos los libros registrados.
        /// </summary>
        /// <returns>Lista completa de libros.</returns>
        List<Libro> ObtenerTodosLibros();

    }
}