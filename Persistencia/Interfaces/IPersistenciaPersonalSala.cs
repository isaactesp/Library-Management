using ModeloDominio;
using System.Collections.Generic;

namespace Persistencia.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de persistencia para el Personal de Sala.
    /// <br/>
    /// Desacopla la Lógica de Negocio de la implementación concreta de datos.
    /// </summary>
    public interface IPersistenciaPersonalSala
    {
        /// <summary>
        /// Registra un nuevo personal de sala en el sistema.
        /// </summary>
        /// <param name="personalSala">Objeto PersonalSala a registrar.</param>
        /// <returns>True si el registro se realizó correctamente.</returns>
        bool AltaPersonalSala(PersonalSala personalSala);

        /// <summary>
        /// Elimina un personal de sala existente.
        /// </summary>
        /// <param name="personalSala">Objeto PersonalSala a dar de baja.</param>
        /// <returns>True si la baja se realizó correctamente.</returns>
        bool BajaPersonalSala(PersonalSala personalSala);

        /// <summary>
        /// Actualiza los datos de un personal de sala.
        /// </summary>
        /// <param name="personalSala">Objeto con los datos actualizados.</param>
        void ModificarPersonalSala(PersonalSala personalSala);

        /// <summary>
        /// Busca un personal de sala por su NSS.
        /// </summary>
        /// <param name="nss">Número de la Seguridad Social.</param>
        /// <returns>El objeto encontrado o null si no existe.</returns>
        PersonalSala ObtenerPersonalSala(string nss);

        /// <summary>
        /// Verifica si existe un personal con el NSS indicado.
        /// </summary>
        /// <param name="nss">NSS a verificar.</param>
        /// <returns>True si existe, False en caso contrario.</returns>
        bool ExistePersonalSala(string nss);

        /// <summary>
        /// Recupera todos los miembros del personal de sala registrados.
        /// </summary>
        /// <returns>Lista completa del personal de sala.</returns>
        List<PersonalSala> ObtenerTodosPersonalSala();
    }
}
