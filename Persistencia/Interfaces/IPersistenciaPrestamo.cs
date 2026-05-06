using ModeloDominio;
using System.Collections.Generic;

namespace Persistencia.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de persistencia para los Préstamos.
    /// <br/>
    /// Desacopla la Lógica de Negocio de la implementación concreta de datos.
    /// </summary>
    public interface IPersistenciaPrestamo
    {
        /// <summary>
        /// Registra un nuevo préstamo en el sistema, vinculando al usuario, al personal de sala y a los ejemplares prestados.
        /// </summary>
        /// <remarks>
        /// PRE:
        /// - Los objetos <paramref name="prestamo"/>, <paramref name="pSala"/>, <paramref name="u"/> y la lista <paramref name="ejemplares"/> no son nulos.
        /// - El <paramref name="prestamo"/>.IdPrestamo no debe existir previamente en la base de datos.
        /// - El <paramref name="u"/> no debe estar sancionado.
        /// - Cada <see cref="Ejemplar"/> en la lista <paramref name="ejemplares"/> debe existir y no estar prestado (<c>Prestado == false</c>).
        /// POST:
        /// - Se crea un nuevo registro para el préstamo en la base de datos.
        /// - Se crean los vínculos entre el préstamo, el usuario y los ejemplares.
        /// - El estado de cada <see cref="Ejemplar"/> en la base de datos se actualiza a <c>Prestado = true</c>.
        /// - Devuelve <c>true</c> si la operación completa fue exitosa.
        /// </remarks>
        /// <param name="prestamo">Objeto Prestamo a registrar.</param>
        /// <param name="pSala">Personal de Sala que realiza el préstamo.</param>
        /// <param name="u">Usuario que recibe el préstamo.</param>
        /// <param name="ejemplares">Lista de ejemplares prestados.</param>
        /// <returns><c>true</c> si el préstamo se inició correctamente; <c>false</c> en caso contrario.</returns>
        bool IniciarPrestamo(Prestamo prestamo, PersonalSala pSala, Usuario u, List<Ejemplar> ejemplares);

        /// <summary>
        /// Verifica si un préstamo, basado en su objeto, existe en el sistema.
        /// </summary>
        /// <remarks>
        /// PRE: El objeto <paramref name="p"/> no es nulo.
        /// POST: Devuelve <c>true</c> si un préstamo con el mismo IdPrestamo que <paramref name="p"/> existe en la base de datos. En caso contrario, devuelve <c>false</c>. La base de datos no sufre modificaciones.
        /// </remarks>
        /// <param name="p">Préstamo a verificar.</param>
        /// <returns><c>true</c> si existe, <c>false</c> en caso contrario.</returns>
        bool ExistePrestamo(Prestamo p);

        /// <summary>
        /// Verifica si existe un préstamo con un identificador específico.
        /// </summary>
        /// <remarks>
        /// PRE: El <paramref name="idPrestamo"/> no es nulo ni vacío.
        /// POST: Devuelve <c>true</c> si un préstamo con ese <paramref name="idPrestamo"/> existe en la base de datos. En caso contrario, devuelve <c>false</c>. La base de datos no sufre modificaciones.
        /// </remarks>
        /// <param name="idPrestamo">Identificador del préstamo.</param>
        /// <returns><c>true</c> si existe, <c>false</c> en caso contrario.</returns>
        bool ExistePrestamoID(string idPrestamo);

        /// <summary>
        /// Busca y devuelve un objeto Préstamo a partir de su identificador.
        /// </summary>
        /// <remarks>
        /// PRE: El <paramref name="idPrestamo"/> no es nulo ni vacío.
        /// POST: Devuelve el objeto <see cref="Prestamo"/> completamente reconstruido (con su Usuario, Personal y lista de Ejemplares) si se encuentra. Si no existe, devuelve <c>null</c>.
        /// </remarks>
        /// <param name="idPrestamo">Identificador del préstamo.</param>
        /// <returns>El objeto <see cref="Prestamo"/> encontrado o <c>null</c> si no existe.</returns>
        Prestamo ObtenerPrestamo(string idPrestamo);

        /// <summary>
        /// Registra la devolución de un ejemplar específico dentro de un préstamo.
        /// </summary>
        /// <remarks>
        /// PRE:
        /// - Los objetos <paramref name="p"/> y <paramref name="ej"/> no son nulos y existen en la base de datos.
        /// - El préstamo <paramref name="p"/> debe estar en proceso (<c>Acabado == false</c>).
        /// - El ejemplar <paramref name="ej"/> debe pertenecer a la lista de ejemplares del préstamo <paramref name="p"/>.
        /// POST:
        /// - El estado del <see cref="Ejemplar"/> <paramref name="ej"/> se actualiza a <c>Prestado = false</c> en la base de datos.
        /// - Si este era el último ejemplar pendiente de devolución del préstamo, el préstamo <paramref name="p"/> se marca como finalizado (<c>Acabado = true</c>) y se establece su <c>FechaFin</c>.
        /// </remarks>
        /// <param name="p">Préstamo al que pertenece el ejemplar.</param>
        /// <param name="ej">Ejemplar a devolver.</param>
        void DevolverEjemplar(Prestamo p, Ejemplar ej);

        /// <summary>
        /// Elimina un préstamo del sistema.
        /// </summary>
        /// <remarks>
        /// PRE: El objeto <paramref name="p"/> no es nulo y el préstamo existe en la base de datos.
        /// POST: El registro del préstamo <paramref name="p"/> y todas sus asociaciones en la tabla intermedia (con ejemplares) son eliminados de la base de datos.
        /// </remarks>
        /// <param name="p">Préstamo a eliminar.</param>
        void EliminarPrestamo(Prestamo p);

        /// <summary>
        /// Obtiene todos los ejemplares asociados a un préstamo concreto.
        /// </summary>
        /// <remarks>
        /// PRE: El objeto <paramref name="p"/> no es nulo y el préstamo existe.
        /// POST: Devuelve una lista con todos los objetos <see cref="Ejemplar"/> que fueron prestados en el préstamo <paramref name="p"/>. Si no tiene ejemplares, devuelve una lista vacía.
        /// </remarks>
        /// <param name="p">Préstamo del que obtener los ejemplares.</param>
        /// <returns>Lista de ejemplares del préstamo.</returns>
        List<Ejemplar> ObtenerEjemplaresPrestamo(Prestamo p);

        /// <summary>
        /// Recupera todos los préstamos registrados en el sistema.
        /// </summary>
        /// <remarks>
        /// PRE: - (Ninguna)
        /// POST: Devuelve una lista con todos los préstamos de la base de datos. Si no hay ninguno, devuelve una lista vacía.
        /// </remarks>
        /// <returns>Lista completa de préstamos.</returns>
        List<Prestamo> ObtenerTodosPrestamos();

        /// <summary>
        /// Obtiene todos los préstamos (históricos y activos) realizados por un usuario.
        /// </summary>
        /// <remarks>
        /// PRE: El objeto <paramref name="u"/> no es nulo.
        /// POST: Devuelve una lista con todos los préstamos asociados al usuario <paramref name="u"/>.
        /// </remarks>
        /// <param name="u">Usuario del que obtener los préstamos.</param>
        /// <returns>Lista de préstamos del usuario.</returns>
        List<Prestamo> ObtenerPrestamosDeUsuario(Usuario u);

        /// <summary>
        /// Obtiene todos los préstamos en los que se ha prestado al menos un ejemplar de un documento específico.
        /// </summary>
        /// <remarks>
        /// PRE: El objeto <paramref name="d"/> no es nulo.
        /// POST: Devuelve una lista de préstamos que contienen al menos un ejemplar cuyo <see cref="Documento"/> padre coincide con <paramref name="d"/>.
        /// </remarks>
        /// <param name="d">Documento del que obtener los préstamos.</param>
        /// <returns>Lista de préstamos que contienen el documento.</returns>
        List<Prestamo> ObtenerPrestamosDeDocumento(Documento d);

        /// <summary>
        /// Verifica si un préstamo está activo (no finalizado).
        /// </summary>
        /// <remarks>
        /// PRE: El objeto <paramref name="p"/> no es nulo y el préstamo existe.
        /// POST: Devuelve <c>true</c> si la propiedad <c>Acabado</c> del préstamo es <c>false</c>. En caso contrario, devuelve <c>false</c>.
        /// </remarks>
        /// <param name="p">Préstamo a verificar.</param>
        /// <returns><c>true</c> si está en proceso, <c>false</c> si está acabado.</returns>
        bool EstaEnProceso(Prestamo p);

        /// <summary>
        /// Obtiene una lista de los documentos únicos asociados a los ejemplares de un préstamo.
        /// </summary>
        /// <remarks>
        /// PRE: El objeto <paramref name="p"/> no es nulo y el préstamo existe.
        /// POST: Devuelve una lista de objetos <see cref="Documento"/> sin duplicados, correspondiente a cada <see cref="Ejemplar"/> del préstamo <paramref name="p"/>.
        /// </remarks>
        /// <param name="p">Préstamo del que obtener los documentos.</param>
        /// <returns>Lista de documentos del préstamo.</returns>
        List<Documento> ObtenerDocumentosDePrestamo(Prestamo p);

        /// <summary>
        /// Obtiene el usuario que realizó el préstamo.
        /// </summary>
        /// <remarks>
        /// PRE: El objeto <paramref name="p"/> no es nulo y el préstamo existe.
        /// POST: Devuelve el objeto <see cref="Usuario"/> asociado al préstamo <paramref name="p"/>.
        /// </remarks>
        /// <param name="p">Préstamo del que obtener el usuario.</param>
        /// <returns>El usuario que realizó el préstamo.</returns>
        Usuario ObtenerUsuarioDePrestamo(Prestamo p);
    }
}
