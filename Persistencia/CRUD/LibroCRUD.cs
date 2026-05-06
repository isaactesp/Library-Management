using System.Collections.Generic;
using ModeloDominio;
using Persistencia.BBDD;
using Persistencia.Transformers;

namespace Persistencia.CRUD
{
    /// <summary>
    /// Gestión de operaciones CRUD (Create, Read, Update, Delete) para Libros (Papel).
    /// <br/>
    /// <b>NOTA:</b> Se asume que los datos de entrada han sido validados previamente por la Lógica de Negocio.
    /// </summary>
    internal static class LibroCRUD
    {
        /// <summary>
        /// Registra un nuevo Libro en la base de datos.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El objeto 'libro' no es nulo y su ISBN no existe en la base de datos. <br/>
        /// <b>POST:</b> El libro queda guardado en el sistema.
        /// </remarks>
        /// <param name="libro">Objeto Libro a registrar.</param>
        public static void AltaLibro(Libro libro)
        {
            BD.TablaLibro.Add(TransformerLibro.ToDato(libro));
        }

        /// <summary>
        /// Elimina un Libro del sistema.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El libro existe (se usa su ISBN para localizarlo). <br/>
        /// <b>POST:</b> El libro es eliminado de la persistencia.
        /// </remarks>
        /// <param name="libro">Objeto Libro a eliminar.</param>
        public static void BajaLibro(Libro libro)
        {
            BD.TablaLibro.Remove(libro.ISBN);
        }

        /// <summary>
        /// Actualiza los datos de un Libro existente.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El libro existe y los datos son válidos. <br/>
        /// <b>POST:</b> La información del libro se sobrescribe con la nueva.
        /// </remarks>
        /// <param name="libro">Objeto Libro con los datos modificados.</param>
        public static void ModificarLibro(Libro libro)
        {
            // Estrategia: Borrar y volver a insertar para asegurar la actualización
            BD.TablaLibro.Remove(libro.ISBN);
            BD.TablaLibro.Add(TransformerLibro.ToDato(libro));
        }

        /// <summary>
        /// Busca un Libro por su ISBN.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ISBN no es nulo. <br/>
        /// <b>POST:</b> Devuelve el objeto encontrado o null si no existe.
        /// </remarks>
        /// <param name="isbn">ISBN del libro a buscar.</param>
        /// <returns>Objeto Libro o null.</returns>
        public static Libro ObtenerLibro(string isbn)
        {
            if (BD.TablaLibro.Contains(isbn))
            {
                return TransformerLibro.ToObject(BD.TablaLibro[isbn]);
            }
            return null;
        }
       



        /// <summary>
        /// Verifica si existe un Libro con el ISBN dado.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ISBN no es nulo. <br/>
        /// <b>POST:</b> Devuelve true si existe, false en caso contrario.
        /// </remarks>
        /// <param name="isbn">ISBN a comprobar.</param>
        /// <returns>True si existe, False si no.</returns>
        public static bool ExisteLibro(string isbn)
        {
            return BD.TablaLibro.Contains(isbn);
        }

        /// <summary>
        /// Obtiene una lista con todos los Libros registrados.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve una lista con todos los elementos (puede estar vacía).
        /// </remarks>
        /// <returns>Lista de objetos Libro.</returns>
        public static List<Libro> ObtenerTodosLibros()
        {
            List<Libro> lista = new List<Libro>();
            foreach (var lDato in BD.TablaLibro.obtenerTodos())
            {
                lista.Add(TransformerLibro.ToObject(lDato));
            }
            return lista;
        }
    }
}