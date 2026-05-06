using ModeloDominio;
using Persistencia.CRUD;
using Persistencia.Interfaces;
using System.Collections.Generic;

namespace Persistencia
{
    /// <summary>
    /// Fachada de persistencia para Usuarios.
    /// <br/>
    /// Conecta la interfaz pública con el CRUD estático interno.
    /// </summary>
    public class PersistenciaUsuario : IPersistenciaUsuario
    {
        /// <summary>
        /// Registra un nuevo usuario delegando en el CRUD.
        /// </summary>
        /// <param name="usuario">Objeto Usuario a registrar.</param>
        /// <returns>True si el guardado fue exitoso (se verifica existencia).</returns>
        public bool AltaUsuario(Usuario usuario)
        {
            UsuarioCRUD.AltaUsuario(usuario);
            // Verificamos éxito consultando por DNI
            return UsuarioCRUD.ExisteUsuario(usuario.DNI);
        }

        /// <summary>
        /// Elimina un usuario existente delegando en el CRUD.
        /// </summary>
        /// <param name="usuario">Objeto Usuario a eliminar.</param>
        /// <returns>True si el borrado fue exitoso (ya no existe).</returns>
        public bool BajaUsuario(Usuario usuario)
        {
            UsuarioCRUD.BajaUsuario(usuario);
            // Verificamos éxito confirmando que YA NO existe
            return !UsuarioCRUD.ExisteUsuario(usuario.DNI);
        }

        /// <summary>
        /// Actualiza los datos de un usuario delegando en el CRUD.
        /// </summary>
        public void ModificarUsuario(Usuario usuario)
        {
            UsuarioCRUD.ModificarUsuario(usuario);
        }

        /// <summary>
        /// Busca un usuario por DNI delegando en el CRUD.
        /// </summary>
        public Usuario ObtenerUsuario(string dni)
        {
            return UsuarioCRUD.ObtenerUsuario(dni);
        }

        /// <summary>
        /// Comprueba existencia por DNI delegando en el CRUD.
        /// </summary>
        public bool ExisteUsuario(string dni)
        {
            return UsuarioCRUD.ExisteUsuario(dni);
        }

        /// <summary>
        /// Recupera todos los usuarios delegando en el CRUD.
        /// </summary>
        public List<Usuario> ObtenerTodosUsuarios()
        {
            return UsuarioCRUD.ObtenerTodosUsuarios();
        }
    }
}