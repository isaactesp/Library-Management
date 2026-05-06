using System.Collections.Generic;
using ModeloDominio;

namespace LogicaNegocio.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones comunes de negocio para todo el personal.
    /// <br/>
    /// <b>RESPONSABILIDAD:</b> Gestión de Usuarios (Lectores).
    /// </summary>
    public interface IPersonalLN
    {
        /// <summary>
        /// Registra un nuevo usuario en el sistema con el DNI y nombre proporcionados.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El <paramref name="dni"/> no debe ser nulo o vacío, y no debe corresponder a un usuario ya existente. El <paramref name="nombre"/> no debe ser nulo o vacío. <br/>
        /// <b>POST:</b> Se crea un nuevo objeto <see cref="Usuario"/> y se almacena en el sistema en estado de "alta".
        /// </remarks>
        /// <param name="dni">El Documento Nacional de Identidad del nuevo usuario.</param>
        /// <param name="nombre">El nombre completo del nuevo usuario.</param>
        /// <returns> <c>true</c> si el usuario se registró exitosamente; <c>false</c> en caso contrario (por ejemplo, DNI duplicado o datos inválidos).</returns>
        bool RegistrarUsuario(string dni, string nombre);

        /// <summary>
        /// Da de baja lógica a un usuario existente en el sistema.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El <paramref name="dni"/> no debe ser nulo o vacío y debe corresponder a un usuario existente. El usuario no debe tener préstamos activos pendientes de devolución. <br/>
        /// <b>POST:</b> El estado del usuario se marca como "baja" (inactivo) en el sistema. El usuario no se elimina físicamente para mantener la integridad histórica.
        /// </remarks>
        /// <param name="dni">El Documento Nacional de Identidad del usuario a dar de baja.</param>
        /// <returns> <c>true</c> si el usuario se dio de baja exitosamente; <c>false</c> en caso contrario (por ejemplo, usuario no encontrado, DNI inválido, o préstamos activos).</returns>
        bool BajaUsuario(string dni);

        /// <summary>
        /// Modifica los datos de un usuario existente en el sistema.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El objeto <paramref name="usuario"/> no debe ser nulo. Su <paramref name="usuario"/>.DNI debe corresponder a un usuario existente. El <paramref name="usuario"/>.Nombre no debe ser nulo o vacío. <br/>
        /// <b>POST:</b> Los datos del usuario (principalmente el nombre y el estado de alta) se actualizan en el sistema. El DNI del usuario no puede ser modificado a través de esta operación.
        /// </remarks>
        /// <param name="usuario">El objeto <see cref="Usuario"/> con los datos actualizados. Se utiliza su DNI para identificar el usuario a modificar.</param>
        void ModificarUsuario(Usuario usuario);

        /// <summary>
        /// Busca y devuelve un objeto Usuario a partir de su Documento Nacional de Identidad.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El <paramref name="dni"/> no debe ser nulo o vacío. <br/>
        /// <b>POST:</b> Devuelve el objeto <see cref="Usuario"/> si se encuentra.
        /// </remarks>
        /// <param name="dni">El Documento Nacional de Identidad del usuario a buscar.</param>
        /// <returns>El objeto <see cref="Usuario"/> encontrado; <c>null</c> si no existe ningún usuario con ese DNI.</returns>
        Usuario BuscarUsuario(string dni);

        /// <summary>
        /// Obtiene una lista de todos los usuarios registrados en el sistema.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve una lista de objetos <see cref="Usuario"/>. La lista puede estar vacía si no hay usuarios registrados.
        /// </remarks>
        /// <returns>Una <see cref="List{T}"/> de <see cref="Usuario"/> con todos los usuarios registrados.</returns>
        List<Usuario> ListarUsuarios();

        /// <summary>
        /// Verifica si un usuario con el Documento Nacional de Identidad especificado existe en el sistema.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El <paramref name="dni"/> no debe ser nulo o vacío. <br/>
        /// <b>POST:</b> Devuelve <c>true</c> si se encuentra un usuario con el DNI.
        /// </remarks>
        /// <param name="dni">El Documento Nacional de Identidad del usuario a verificar.</param>
        /// <returns> <c>true</c> si un usuario con el DNI existe; <c>false</c> en caso contrario.</returns>
        bool ExisteUsuario(string dni);


        /// <summary>
        /// Registra un nuevo miembro del personal de adquisiciones en el sistema.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El objeto 'personal' no debe ser nulo y su NSS no debe existir previamente en el sistema. <br/>
        /// <b>POST:</b> El nuevo miembro del personal queda registrado en la base de datos.
        /// </remarks>
        /// <param name="personal">El objeto Personal a registrar, con todos sus datos válidos.</param>
        void RegistrarPersonal(Personal personal);
    }
}