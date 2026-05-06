using System.Collections.Generic;
using ModeloDominio;
using Persistencia.BBDD;
using Persistencia.Transformers;

namespace Persistencia.CRUD
{
    /// <summary>
    /// Gestión de operaciones CRUD (Create, Read, Update, Delete) para Usuarios (Lectores).
    /// <br/>
    /// <b>ESTRATEGIA:</b> Happy Path. Se asume que los datos de entrada son válidos.
    /// </summary>
    internal static class UsuarioCRUD
    {
        /// <summary>
        /// Registra un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="u">Objeto Usuario a registrar.</param>
        public static void AltaUsuario(Usuario u)
        {
            BD.TablaUsuario.Add(TransformerUsuario.ToDato(u));
        }

        /// <summary>
        /// Actualiza los datos de un usuario existente.
        /// </summary>
        /// <remarks>
        /// El DNI no se modifica, se usa como clave para sustituir el registro.
        /// </remarks>
        /// <param name="u">Objeto Usuario con los datos nuevos.</param>
        public static void ModificarUsuario(Usuario u)
        {
            BD.TablaUsuario.Remove(u.DNI);
            BD.TablaUsuario.Add(TransformerUsuario.ToDato(u));
        }

        /// <summary>
        /// Elimina un usuario del sistema.
        /// </summary>
        /// <param name="u">Objeto Usuario a eliminar.</param>
        public static void BajaUsuario(Usuario u)
        {
            // CORREGIDO: Usamos la propiedad .DNI
            BD.TablaUsuario.Remove(u.DNI);
        }

        /// <summary>
        /// Busca un usuario por su DNI.
        /// </summary>
        /// <param name="dni">DNI a buscar.</param>
        /// <returns>El objeto Usuario o null si no existe.</returns>
        public static Usuario ObtenerUsuario(string dni)
        {
            if (BD.TablaUsuario.Contains(dni))
            {
                return TransformerUsuario.ToObject(BD.TablaUsuario[dni]);
            }
            return null;
        }

        /// <summary>
        /// Obtiene el listado completo de usuarios registrados.
        /// </summary>
        /// <returns>Lista de objetos Usuario.</returns>
        public static List<Usuario> ObtenerTodosUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            // Usamos obtenerTodos() de la clase Tabla para iterar sobre una copia segura
            foreach (var uDato in BD.TablaUsuario.obtenerTodos())
            {
                listaUsuarios.Add(TransformerUsuario.ToObject(uDato));
            }
            return listaUsuarios;
        }

        /// <summary>
        /// Verifica si existe un usuario con el DNI indicado.
        /// </summary>
        /// <returns>True si existe, False en caso contrario.</returns>
        public static bool ExisteUsuario(string dni)
        {
            return BD.TablaUsuario.Contains(dni);
        }
    }
}