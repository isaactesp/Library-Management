using ModeloDominio;
using System.Collections.Generic;

namespace Persistencia.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de persistencia para el Personal de Adquisiciones.
    /// <br/>
    /// Desacopla la Lógica de Negocio de la implementación concreta de datos.
    /// </summary>
    public interface IPersistenciaPersonalAdquisiciones
    {
        /// <summary>
        /// Registra un nuevo personal de adquisiciones en el sistema.
        /// </summary>
        /// <param name="personalAdquisiciones">Objeto PersonalAdquisiciones a registrar.</param>
        /// <returns>True si el registro se realizó correctamente.</returns>
        bool AltaPersonalAdquisiciones(PersonalAdquisiciones personalAdquisiciones);

        /// <summary>
        /// Elimina un personal de adquisiciones existente.
        /// </summary>
        /// <param name="personalAdquisiciones">Objeto PersonalAdquisiciones a dar de baja.</param>
        /// <returns>True si la baja se realizó correctamente.</returns>
        bool BajaPersonalAdquisiciones(PersonalAdquisiciones personalAdquisiciones);

        /// <summary>
        /// Actualiza los datos de un personal de adquisiciones.
        /// </summary>
        /// <param name="personalAdquisiciones">Objeto con los datos actualizados.</param>
        void ModificarPersonalAdquisiciones(PersonalAdquisiciones personalAdquisiciones);

        /// <summary>
        /// Busca un personal de adquisiciones por su NSS.
        /// </summary>
        /// <param name="nss">Número de la Seguridad Social.</param>
        /// <returns>El objeto encontrado o null si no existe.</returns>
        PersonalAdquisiciones ObtenerPersonalAdquisiciones(string nss);

        /// <summary>
        /// Verifica si existe un personal con el NSS indicado.
        /// </summary>
        /// <param name="nss">NSS a verificar.</param>
        /// <returns>True si existe, False en caso contrario.</returns>
        bool ExistePersonalAdquisiciones(string nss);

        /// <summary>
        /// Recupera todos los miembros del personal de adquisiciones registrados.
        /// </summary>
        /// <returns>Lista completa del personal de adquisiciones.</returns>
        List<PersonalAdquisiciones> ObtenerTodosPersonalAdquisiciones();
    }
}