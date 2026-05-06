using ModeloDominio;
using System.Collections.Generic;

namespace Persistencia.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de persistencia para Ejemplares físicos.
    /// <br/>
    /// Desacopla la Lógica de Negocio de la implementación concreta de datos.
    /// </summary>
    public interface IPersistenciaEjemplar
    {
        /// <summary>
        /// Registra un nuevo ejemplar en el sistema.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar no debe existir previamente. <br/>
        /// <b>POST:</b> El ejemplar queda registrado y asociado al personal.
        /// </remarks>
        /// <param name="ejemplar">El objeto Ejemplar a guardar.</param>
        /// <param name="personal">El personal que realiza la adquisición (para auditoría).</param>
        /// <returns>True si el ejemplar se guardó correctamente.</returns>
        bool AltaEjemplar(Ejemplar ejemplar, Personal personal);

        /// <summary>
        /// Elimina un ejemplar del sistema.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar debe existir.
        /// </remarks>
        /// <param name="ejemplar">El objeto Ejemplar a eliminar.</param>
        /// <returns>True si el ejemplar fue eliminado correctamente.</returns>
        bool BajaEjemplar(Ejemplar ejemplar);

        /// <summary>
        /// Actualiza los datos de un ejemplar.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar debe existir.
        /// </remarks>
        /// <param name="ejemplar">El objeto Ejemplar con los datos modificados.</param>
        /// <param name="personal">El personal que realiza la modificación.</param>
        void ModificarEjemplar(Ejemplar ejemplar, Personal personal);

        /// <summary>
        /// Busca un ejemplar por su código único.
        /// </summary>
        /// <param name="codigo">Código identificador del ejemplar.</param>
        /// <returns>El objeto Ejemplar encontrado o null si no existe.</returns>
        Ejemplar ObtenerEjemplar(string codigo);

        /// <summary>
        /// Verifica si existe un ejemplar con ese código.
        /// </summary>
        /// <param name="codigo">Código a verificar.</param>
        /// <returns>True si existe, False en caso contrario.</returns>
        bool ExisteEjemplar(string codigo);

        /// <summary>
        /// Obtiene todos los ejemplares asociados a un documento (Libro o AudioLibro) concreto.
        /// </summary>
        /// <param name="documento">Documento padre (objeto completo).</param>
        /// <returns>Lista de ejemplares asociados a ese documento.</returns>
        List<Ejemplar> ObtenerEjemplaresDeDocumento(Documento documento);

        /// <summary>
        /// Obtiene el listado completo de todos los ejemplares de la biblioteca.
        /// </summary>
        /// <returns>Lista global de ejemplares.</returns>
        List<Ejemplar> ObtenerTodosEjemplares();


        /// <summary>
        /// Obtiene el miembro del personal que registró un ejemplar.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El 'ejemplar' no es nulo y existe en el sistema. <br/>
        /// <b>POST:</b> Devuelve el objeto Personal que dio de alta el ejemplar. Si no se encuentra, devuelve null.
        /// </remarks>
        /// <param name="ejemplar">El ejemplar a consultar.</param>
        /// <returns>El objeto Personal que registró el ejemplar, o null si no se encuentra.</returns>
        Personal QuienDioAlta(Ejemplar ejemplar);

    }
}