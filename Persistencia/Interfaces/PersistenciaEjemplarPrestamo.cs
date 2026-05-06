using System;
using System.Collections.Generic;
using ModeloDominio;
using Persistencia.CRUD; // Necesario para acceder a EjemplarPrestamoCRUD
using Persistencia.Interfaces;

namespace Persistencia
{
    /// <summary>
    /// Fachada de persistencia para la gestión de vínculos Préstamo-Ejemplar.
    /// <br/>
    /// Conecta la interfaz pública (IPersistenciaEjemplarPrestamo) con el CRUD estático interno.
    /// </summary>
    public class PersistenciaEjemplarPrestamo : IPersistenciaEjemplarPrestamo
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public PersistenciaEjemplarPrestamo()
        {
        }

        /// <summary>
        /// Vincula un ejemplar a un préstamo delegando en el CRUD.
        /// </summary>
        public bool AltaEjemplarPrestamo(Prestamo prestamo, Ejemplar ejemplar)
        {
            // Delegamos en el método estático del CRUD
            EjemplarPrestamoCRUD.AltaEjemplarPrestamo(prestamo, ejemplar);

            // Verificamos éxito consultando si existe el vínculo
            return EjemplarPrestamoCRUD.ExisteEjemplarPrestamo(prestamo, ejemplar);
        }

        /// <summary>
        /// Desvincula un ejemplar de un préstamo delegando en el CRUD.
        /// </summary>
        public bool BajaEjemplarPrestamo(Prestamo prestamo, Ejemplar ejemplar)
        {
            // Delegamos en el método estático del CRUD
            EjemplarPrestamoCRUD.BajaEjemplarPrestamo(prestamo, ejemplar);

            // Verificamos éxito confirmando que YA NO existe
            return !EjemplarPrestamoCRUD.ExisteEjemplarPrestamo(prestamo, ejemplar);
        }

        /// <summary>
        /// Obtiene los ejemplares de un préstamo delegando en el CRUD.
        /// </summary>
        public List<Ejemplar> ListarEjemplaresDePrestamo(Prestamo prestamo)
        {
            return EjemplarPrestamoCRUD.ListarEjemplaresDePrestamo(prestamo);
        }

        /// <summary>
        /// Obtiene los préstamos de un ejemplar delegando en el CRUD.
        /// </summary>
        public List<Prestamo> ListarPrestamosDeEjemplar(Ejemplar ejemplar)
        {
            return EjemplarPrestamoCRUD.ListarPrestamosDeEjemplar(ejemplar);
        }

        /// <summary>
        /// Verifica la existencia de un vínculo delegando en el CRUD.
        /// </summary>
        public bool ExisteEjemplarPrestamo(Prestamo prestamo, Ejemplar ejemplar)
        {
            return EjemplarPrestamoCRUD.ExisteEjemplarPrestamo(prestamo, ejemplar);
        }

        /// <summary>
        /// Obtiene el documento más prestado delegando en el CRUD.
        /// </summary>
        public Documento ObtenerDocumentoMasPrestado(DateTime inicio, DateTime fin)
        {
            return EjemplarPrestamoCRUD.ObtenerDocumentoMasPrestado(inicio, fin);
        }
    }
}