using ModeloDominio;
using System.Collections.Generic;

namespace Persistencia.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de persistencia para Usuarios (Lectores).
    /// <br/>
    /// Desacopla la Lógica de Negocio de la implementación concreta de datos.
    /// </summary>
    public interface IPersistenciaUsuario
    {
        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="usuario">Objeto Usuario a registrar.</param>
        /// <returns>True si el usuario se guardó correctamente.</returns>
        bool AltaUsuario(Usuario usuario);

        /// <summary>
        /// Elimina un usuario existente.
        /// </summary>
        /// <param name="usuario">Objeto Usuario a dar de baja.</param>
        /// <returns>True si la baja se realizó correctamente.</returns>
        bool BajaUsuario(Usuario usuario);

        /// <summary>
        /// Actualiza los datos de un usuario.
        /// </summary>
        /// <param name="usuario">Objeto Usuario con los datos modificados.</param>
        void ModificarUsuario(Usuario usuario);

        /// <summary>
        /// Busca un usuario por su DNI.
        /// </summary>
        /// <param name="dni">Documento Nacional de Identidad.</param>
        /// <returns>El objeto Usuario encontrado o null si no existe.</returns>
        Usuario ObtenerUsuario(string dni);

        /// <summary>
        /// Verifica si existe un usuario con el DNI indicado.
        /// </summary>
        /// <param name="dni">DNI a verificar.</param>
        /// <returns>True si existe, False en caso contrario.</returns>
        bool ExisteUsuario(string dni);

        /// <summary>
        /// Recupera todos los usuarios registrados en el sistema.
        /// </summary>
        /// <returns>Lista completa de usuarios.</returns>
        List<Usuario> ObtenerTodosUsuarios();
    }
}