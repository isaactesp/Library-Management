using ModeloDominio;
using Persistencia.BBDD; // Necesario para reconocer EjemplarPrestamoDato
using System;
using System.Collections.Generic;

namespace Persistencia.Interfaces
{
    /// <summary>
    /// Interfaz para la gestión de la relación N:M entre Préstamos y Ejemplares.
    /// <br/>
    /// <b>RESPONSABILIDAD:</b> Definir las operaciones de vinculación y consultas estadísticas.
    /// </summary>
    public interface IPersistenciaEjemplarPrestamo
    {
        // ==========================================
        // OPERACIONES DE ESCRITURA (Alta / Baja)
        // ==========================================

        /// <summary>
        /// Vincula un ejemplar específico a un préstamo existente.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Los objetos Prestamo y Ejemplar existen y son válidos. No están vinculados previamente. <br/>
        /// <b>POST:</b> Devuelve true si se crea un registro en la tabla intermedia vinculando ambas entidades.
        /// </remarks>
        /// <param name="prestamo">El objeto Préstamo cabecera.</param>
        /// <param name="ejemplar">El objeto Ejemplar que se añade al préstamo.</param>
        /// <returns>True si la operación fue exitosa.</returns>
        bool AltaEjemplarPrestamo(Prestamo prestamo, Ejemplar ejemplar);

        /// <summary>
        /// Desvincula un ejemplar de un préstamo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> La relación entre el préstamo y el ejemplar existe. <br/>
        /// <b>POST:</b> Devuelve true si se elimina el vínculo de la base de datos.
        /// </remarks>
        /// <param name="prestamo">El objeto Préstamo implicado.</param>
        /// <param name="ejemplar">El objeto Ejemplar a desvincular.</param>
        /// <returns>True si la operación fue exitosa.</returns>
        bool BajaEjemplarPrestamo(Prestamo prestamo, Ejemplar ejemplar);

        // ==========================================
        // OPERACIONES DE LECTURA (Consultas)
        // ==========================================

        /// <summary>
        /// Obtiene la lista completa de ejemplares asociados a un préstamo concreto.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El préstamo es válido. <br/>
        /// <b>POST:</b> Devuelve una lista de objetos Ejemplar reconstruidos (con sus datos de Documento).
        /// </remarks>
        /// <param name="prestamo">El préstamo del que se quieren consultar los ítems.</param>
        /// <returns>Lista de ejemplares asociados.</returns>
        List<Ejemplar> ListarEjemplaresDePrestamo(Prestamo prestamo);

        /// <summary>
        /// Obtiene el historial de préstamos en los que ha participado un ejemplar.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar es válido. <br/>
        /// <b>POST:</b> Devuelve la lista de objetos Préstamo en los que aparece este ejemplar.
        /// </remarks>
        /// <param name="ejemplar">El ejemplar a consultar.</param>
        /// <returns>Lista de préstamos históricos del ejemplar.</returns>
        List<Prestamo> ListarPrestamosDeEjemplar(Ejemplar ejemplar);
    
        /// <summary>
        /// Verifica si existe un vínculo específico entre un préstamo y un ejemplar.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Objetos válidos. <br/>
        /// <b>POST:</b> Devuelve true si la relación existe en la base de datos.
        /// </remarks>
        /// <param name="prestamo">El objeto Préstamo.</param>
        /// <param name="ejemplar">El objeto Ejemplar.</param>
        /// <returns>True si están vinculados, False en caso contrario.</returns>
        bool ExisteEjemplarPrestamo(Prestamo prestamo, Ejemplar ejemplar);

        /// <summary>
        /// Obtiene el Documento (Libro o AudioLibro) que más veces ha sido prestado en un periodo de tiempo.
        /// </summary>
        /// <remarks>
        /// Se calcula sumando las veces que aparece cualquier ejemplar de un documento en los préstamos realizados dentro del rango.
        /// </remarks>
        /// <param name="inicio">Fecha de inicio del periodo de consulta.</param>
        /// <param name="fin">Fecha de fin del periodo de consulta.</param>
        /// <returns>
        /// El objeto <b>Documento</b> más popular en ese rango. <br/>
        /// <b>null</b> si no se realizaron préstamos en ese periodo.
        /// </returns>
        Documento ObtenerDocumentoMasPrestado(DateTime inicio, DateTime fin);
    }
}