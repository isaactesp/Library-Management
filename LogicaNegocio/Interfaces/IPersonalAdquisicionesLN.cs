using ModeloDominio;
using System;
using System.Collections.Generic;

namespace LogicaNegocio.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de negocio específicas para el Personal de Adquisiciones.
    /// <br/>
    /// <b>RESPONSABILIDAD:</b> Gestión del Catálogo (Documentos), del Inventario (Ejemplares) y Consultas Estadísticas.
    /// </summary>
    public interface IPersonalAdquisicionesLN : IPersonalLN
    {

        // ==========================================
        // GESTIÓN DE DOCUMENTOS (CATÁLOGO)
        // ==========================================

        /// <summary>
        /// Registra un nuevo documento (Libro o AudioLibro) en el catálogo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El documento debe tener un ISBN válido y no existir previamente. <br/>
        /// <b>POST:</b> El documento queda disponible en el sistema para asociarle ejemplares.
        /// </remarks>
        /// <param name="documento">El objeto Documento a registrar.</param>
        /// <returns>
        /// <b>True</b> si el registro fue exitoso. <br/>
        /// <b>False</b> si el documento ya existe o si el parámetro es nulo.
        /// </returns>
        bool AltaDocumento(Documento documento);

        /// <summary>
        /// Da de baja un documento del catálogo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El documento debe existir y NO debe tener ejemplares activos ni préstamos pendientes. <br/>
        /// <b>POST:</b> El documento se elimina del sistema.
        /// </remarks>
        /// <param name="documento">El objeto Documento a eliminar.</param>
        /// <returns>
        /// <b>True</b> si se eliminó correctamente. <br/>
        /// <b>False</b> si el documento no existe, es nulo, o tiene dependencias que impiden el borrado.
        /// </returns>
        bool BajaDocumento(Documento documento);

        /// <summary>
        /// Busca un documento por su ISBN.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> ISBN no nulo. <br/>
        /// <b>POST:</b> Devuelve la ficha del documento sin sus ejemplares.
        /// </remarks>
        /// <param name="isbn">Identificador único del documento.</param>
        /// <returns>
        /// El objeto <b>Documento</b> encontrado. <br/>
        /// <b>null</b> si no existe ningún documento con ese ISBN.
        /// </returns>
        Documento BuscarDocumento(string isbn);

        /// <summary>
        /// Obtiene la lista completa de documentos registrados (mezcla de Libros y AudioLibros).
        /// </summary>
        /// <returns>
        /// Una <b>List&lt;Documento&gt;</b> con todos los registros. <br/>
        /// Devuelve una <b>lista vacía</b> (Count=0) si no hay documentos en el sistema.
        /// </returns>
        List<Documento> ListarDocumentos();

        /// <summary>
        /// Obtiene únicamente la lista de Libros en papel.
        /// </summary>
        /// <returns>
        /// Una <b>List&lt;Libro&gt;</b> con los libros registrados. <br/>
        /// Devuelve una <b>lista vacía</b> si no hay libros.
        /// </returns>
        List<Libro> ListarLibros();

        /// <summary>
        /// Obtiene únicamente la lista de AudioLibros.
        /// </summary>
        /// <returns>
        /// Una <b>List&lt;AudioLibro&gt;</b> con los audiolibros registrados. <br/>
        /// Devuelve una <b>lista vacía</b> si no hay audiolibros.
        /// </returns>
        List<AudioLibro> ListarAudioLibros();

        // ==========================================
        // GESTIÓN DE EJEMPLARES (INVENTARIO)
        // ==========================================

        /// <summary>
        /// Registra un nuevo ejemplar físico asociado a un documento.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El documento padre debe existir. El código del ejemplar debe ser único. <br/>
        /// <b>POST:</b> El ejemplar se añade al inventario vinculado al personal que lo registró.
        /// </remarks>
        /// <param name="ejemplar">El objeto Ejemplar a añadir al inventario.</param>
        /// <param name="personalAdquisiones">El personal responsable del alta (para Auditoría).</param>
        /// <returns>
        /// <b>True</b> si el registro fue exitoso. <br/>
        /// <b>False</b> si el ejemplar ya existe, el documento padre no existe, o los parámetros son nulos.
        /// </returns>
        bool RegistrarEjemplar(Ejemplar ejemplar, PersonalAdquisiciones personalAdquisiones);

        /// <summary>
        /// Da de baja un ejemplar específico por deterioro o pérdida.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar existe y NO debe estar prestado actualmente. <br/>
        /// <b>POST:</b> El ejemplar se marca con baja lógica o se retira, según la implementación de persistencia.
        /// </remarks>
        /// <param name="ejemplar">El objeto Ejemplar a eliminar.</param>
        /// <returns>
        /// <b>True</b> si la operación fue exitosa. <br/>
        /// <b>False</b> si el ejemplar no existe, es nulo, o está actualmente prestado (Baja prohibida).
        /// </returns>
        bool BajaEjemplar(Ejemplar ejemplar);

        /// <summary>
        /// Busca un ejemplar concreto por su código único de barras/etiqueta.
        /// </summary>
        /// <param name="codigo">Código único del ejemplar.</param>
        /// <returns>
        /// El objeto <b>Ejemplar</b> encontrado. <br/>
        /// <b>null</b> si no existe ningún ejemplar con ese código.
        /// </returns>
        Ejemplar BuscarEjemplar(string codigo);

        /// <summary>
        /// Obtiene todos los ejemplares asociados a un documento específico.
        /// </summary>
        /// <param name="isbn">ISBN del documento padre.</param>
        /// <returns>
        /// Una <b>List&lt;Ejemplar&gt;</b> con las copias físicas del documento. <br/>
        /// Devuelve una <b>lista vacía</b> si el documento no existe o no tiene ejemplares registrados.
        /// </returns>
        List<Ejemplar> ConsultarEjemplares(string isbn);

        /// <summary>
        /// Identifica qué miembro del personal registró un ejemplar específico.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar existe. <br/>
        /// <b>POST:</b> Devuelve el personal asociado al alta del ejemplar.
        /// </remarks>
        /// <param name="ejemplar">El ejemplar a consultar.</param>
        /// <returns>El objeto Personal encontrado o null.</returns>
        Personal QuienDioAlta(Ejemplar ejemplar);

        /// <summary>
        /// Obtiene una lista con todos los ejemplares registrados en el sistema.
        /// </summary>
        /// <returns>Lista completa de ejemplares.</returns>
        List<Ejemplar> ObtenerTodosEjemplares();

        // ==========================================
        // CONSULTAS DE NEGOCIO Y ESTADÍSTICAS
        // ==========================================

        /// <summary>
        /// Verifica si hay disponibilidad inmediata de ejemplares para préstamo de un documento.
        /// </summary>
        /// <remarks>
        /// Consulta si existe al menos un ejemplar asociado cuyo estado sea "No Prestado".
        /// </remarks>
        /// <param name="isbn">ISBN del documento a consultar.</param>
        /// <returns>
        /// <b>True</b> si hay al menos un ejemplar disponible (stock > 0). <br/>
        /// <b>False</b> si todos están prestados, si no hay ejemplares, o si el documento no existe.
        /// </returns>
        bool HayDisponibilidad(string isbn);

        /// <summary>
        /// Calcula cuándo estará disponible un documento que actualmente no tiene stock.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El documento existe. <br/>
        /// <b>POST:</b> Devuelve la fecha prevista de devolución más próxima entre todos los préstamos activos.
        /// </remarks>
        /// <param name="isbn">ISBN del documento.</param>
        /// <returns>
        /// <b>DateTime.MinValue</b> si hay disponibilidad inmediata (HayDisponibilidad = True). <br/>
        /// La <b>Fecha estimada</b> más próxima si todo está prestado. <br/>
        /// <b>DateTime.MaxValue</b> si el documento no existe o no hay ejemplares/préstamos activos para calcular.
        /// </returns>
        DateTime CuandoDisponible(string isbn);

        /// <summary>
        /// Obtiene el documento más popular del catálogo basándose en el histórico total.
        /// </summary>
        /// <remarks>
        /// Se calcula sumando el contador histórico de préstamos (VecesPrestado) de todos los ejemplares de cada documento.
        /// </remarks>
        /// <returns>
        /// El objeto <b>Documento</b> con mayor histórico de préstamos. <br/>
        /// <b>null</b> si el sistema no tiene ejemplares o no hay historial de préstamos.
        /// </returns>
        Documento ObtenerDocumentoPopular();

        /// <summary>
        /// Obtiene el documento más popular (más prestado) en el último mes.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve el documento con más préstamos en los últimos 30 días.
        /// </remarks>
        /// <returns>Documento más popular del mes o null si no hubo actividad.</returns>
        Documento ObtenerDocumentoPopularUltimoMes();

        /// <summary>
        /// Obtiene el documento más popular en un rango de fechas personalizado.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> La fecha de inicio debe ser anterior o igual a la fecha de fin. <br/>
        /// <b>POST:</b> Devuelve el documento con mayor número de préstamos en ese intervalo.
        /// </remarks>
        /// <param name="inicio">Fecha de inicio del periodo.</param>
        /// <param name="fin">Fecha de fin del periodo.</param>
        /// <returns>Documento más popular en el rango o null.</returns>
        Documento ObtenerDocumentoPopularIntervaloDeTiempo(DateTime inicio, DateTime fin);
    }
}