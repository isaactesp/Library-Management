using ModeloDominio;
using Persistencia.CRUD;
using Persistencia.Interfaces;
using System.Collections.Generic;

namespace Persistencia
{
    /// <summary>
    /// Fachada de persistencia para Libros.
    /// <br/>
    /// Conecta la interfaz pública con el CRUD estático interno.
    /// </summary>
    public class PersistenciaLibro : IPersistenciaLibro
    {
        /// <summary>
        /// Registra un nuevo libro delegando en el CRUD.
        /// </summary>
        /// <param name="libro">Objeto Libro a registrar.</param>
        /// <returns>True si el guardado fue exitoso (se verifica existencia).</returns>
        public bool AltaLibro(Libro libro)
        {
            LibroCRUD.AltaLibro(libro);
            // Verificamos éxito
            return LibroCRUD.ExisteLibro(libro.ISBN);
        }

        /// <summary>
        /// Elimina un libro delegando en el CRUD.
        /// </summary>
        /// <param name="libro">Objeto Libro a eliminar.</param>
        /// <returns>True si el borrado fue exitoso (ya no existe).</returns>
        public bool BajaLibro(Libro libro)
        {
            LibroCRUD.BajaLibro(libro);
            // Verificamos éxito (que ya NO exista)
            return !LibroCRUD.ExisteLibro(libro.ISBN);
        }

        /// <summary>
        /// Actualiza un libro delegando en el CRUD.
        /// </summary>
        /// <param name="libro">Objeto Libro modificado.</param>
        public void ModificarLibro(Libro libro)
        {
            LibroCRUD.ModificarLibro(libro);
        }

        /// <summary>
        /// Obtiene un libro por ISBN delegando en el CRUD.
        /// </summary>
        /// <param name="isbn">ISBN a buscar.</param>
        /// <returns>El objeto Libro o null.</returns>
        public Libro ObtenerLibro(string isbn)
        {
            return LibroCRUD.ObtenerLibro(isbn);
        }

        /// <summary>
        /// Verifica existencia por ISBN delegando en el CRUD.
        /// </summary>
        /// <param name="isbn">ISBN a verificar.</param>
        /// <returns>True si existe.</returns>
        public bool ExisteLibro(string isbn)
        {
            return LibroCRUD.ExisteLibro(isbn);
        }

        /// <summary>
        /// Obtiene todos los libros delegando en el CRUD.
        /// </summary>
        /// <returns>Lista de libros.</returns>
        public List<Libro> ObtenerTodosLibros()
        {
            return LibroCRUD.ObtenerTodosLibros();
        }
    }
}