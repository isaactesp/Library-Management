using ModeloDominio;
using System.Collections.Generic;

namespace LogicaNegocio.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de lógica de negocio para el Personal de Sala.
    /// <br/>
    /// Gestiona préstamos y devoluciones de ejemplares.
    /// </summary>
    public interface IPersonalSalaLN : IPersonalLN
    {
       
        
        /// <summary>
        /// Inicia un nuevo préstamo para un usuario.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El préstamo, los ejemplares y el usuario no son nulos.
        /// Los ejemplares deben estar disponibles (no prestados). <br/>
        /// <b>POST:</b> El préstamo queda registrado y los ejemplares marcados como prestados.
        /// </remarks>
        /// <param name="p">Objeto Préstamo a registrar.</param>
        /// <param name="ejemplares">Lista de ejemplares a prestar.</param>
        /// <param name="u">Usuario que recibe el préstamo.</param>
        /// <returns>True si el préstamo se inició correctamente, False en caso contrario.</returns>
        bool IniciarPrestamo(Prestamo p, List<Ejemplar> ejemplares, Usuario u);

        /// <summary>
        /// Registra la devolución de un ejemplar.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El préstamo y el ejemplar existen y el ejemplar pertenece al préstamo. <br/>
        /// <b>POST:</b> El ejemplar queda marcado como devuelto. Si era el último pendiente,
        /// el préstamo se marca como acabado.
        /// </remarks>
        /// <param name="p">Préstamo al que pertenece el ejemplar.</param>
        /// <param name="e">Ejemplar a devolver.</param>
        void DevolverEjemplar(Prestamo p, Ejemplar e);

        /// <summary>
        /// Busca todos los préstamos que contienen un documento.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El documento no es nulo. <br/>
        /// <b>POST:</b> Devuelve la lista de préstamos (puede estar vacía).
        /// </remarks>
        /// <param name="d">Documento a buscar.</param>
        /// <returns>Lista de préstamos que contienen el documento.</returns>
        List<Prestamo> BuscarPrestamosDeDocumento(Documento d);

        /// <summary>
        /// Consulta el estado de un préstamo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El préstamo existe en el sistema. <br/>
        /// <b>POST:</b> Devuelve el estado actual del préstamo.
        /// </remarks>
        /// <param name="p">Préstamo a consultar.</param>
        /// <returns>True si el préstamo está en proceso, False si está acabado.</returns>
        bool ConsultarEstadoPrestamo(Prestamo p);

        /// <summary>
        /// Obtiene todos los ejemplares asociados a un préstamo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El préstamo existe en el sistema. <br/>
        /// <b>POST:</b> Devuelve la lista de ejemplares del préstamo.
        /// </remarks>
        /// <param name="p">Préstamo del que obtener los ejemplares.</param>
        /// <returns>Lista de ejemplares del préstamo.</returns>
        List<Ejemplar> ConsultarEjemplaresPrestamo(Prestamo p);

        /// <summary>
        /// Obtiene los documentos que aún no han sido devueltos en un préstamo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El préstamo existe en el sistema. <br/>
        /// <b>POST:</b> Devuelve la lista de documentos pendientes de devolución (sin duplicados).
        /// </remarks>
        /// <param name="p">Préstamo del que consultar los documentos pendientes.</param>
        /// <returns>Lista de documentos no devueltos.</returns>
        List<Documento> ConsultarDocumentosNoDevueltos(Prestamo p);

        /// <summary>
        /// Consulta los préstamos que han superado el plazo de devolución (15 días).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve la lista de préstamos vencidos que siguen activos.
        /// </remarks>
        /// <returns>Lista de préstamos vencidos.</returns>
        List<Prestamo> ConsultarVencidos();

        /// <summary>
        /// Obtiene el usuario que realizó un préstamo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El préstamo existe en el sistema. <br/>
        /// <b>POST:</b> Devuelve el usuario asociado al préstamo.
        /// </remarks>
        /// <param name="p">Préstamo del que obtener el usuario.</param>
        /// <returns>Usuario que realizó el préstamo.</returns>
        Usuario ObtenerUsuarioDePrestamo(Prestamo p);

        /// <summary>
        /// Obtiene un préstamo por su identificador.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El idPrestamo no es nulo ni vacío. <br/>
        /// <b>POST:</b> Devuelve el préstamo si existe, null en caso contrario.
        /// </remarks>
        /// <param name="idPrestamo">Identificador del préstamo a buscar.</param>
        /// <returns>El préstamo encontrado o null si no existe.</returns>
        Prestamo ObtenerPrestamoPorId(string idPrestamo);

        /// <summary>
        /// Obtiene una lista de todos los ejemplares que no están actualmente prestados.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve una lista de objetos Ejemplar cuyo estado 'Prestado' es falso.
        /// </remarks>
        /// <returns>Una lista de ejemplares disponibles para préstamo.</returns>
        List<Ejemplar> ObtenerEjemplaresDisponibles();

        /// <summary>
        /// Obtiene una lista con todos los préstamos registrados en el sistema.
        /// </summary>
        /// <returns>Lista de todos los préstamos.</returns>
        List<Prestamo> ObtenerTodosPrestamos();

        /// <summary>
        /// Obtiene todos los préstamos (activos e históricos) de un usuario específico.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El objeto 'usuario' no debe ser nulo. <br/>
        /// <b>POST:</b> Devuelve una lista con todos los préstamos asociados al usuario. Si el usuario no tiene préstamos, devuelve una lista vacía.
        /// </remarks>
        /// <param name="usuario">El usuario del que se quieren obtener los préstamos.</param>
        /// <returns>Una lista de objetos Prestamo.</returns>
        List<Prestamo> ObtenerPrestamosDeUsuario(Usuario usuario);
    }
}
