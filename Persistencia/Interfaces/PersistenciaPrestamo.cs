using ModeloDominio;
using Persistencia.CRUD;
using System.Collections.Generic;

namespace Persistencia.Interfaces
{
    /// <summary>
    /// Fachada de persistencia para Préstamos.
    /// <br/>
    /// Conecta la interfaz pública con el CRUD estático interno.
    /// </summary>
    public class PersistenciaPrestamo : IPersistenciaPrestamo
    {
        /// <summary>
        /// Registra un nuevo préstamo delegando en el CRUD.
        /// Devuelve true en caso de que el prestamo se haya iniciado correctamente y false en caso contrario
        /// </summary>
        public bool IniciarPrestamo(Prestamo prestamo, PersonalSala pSala, Usuario u, List<Ejemplar> ejemplares)
        {
            PrestamoCRUD.iniciarPrestamo(prestamo, pSala, u, ejemplares);
            return PrestamoCRUD.existePrestamo(prestamo);   
        }

        /// <summary>
        /// Verifica si existe un préstamo delegando en el CRUD.
        /// </summary>
        public bool ExistePrestamo(Prestamo p)
        {
            return PrestamoCRUD.existePrestamo(p);
        }


        public bool ExistePrestamoID(string idPrestamo)
        {
            return PrestamoCRUD.existePrestamoID(idPrestamo);
        }

        /// <summary>
        /// Busca un préstamo por ID delegando en el CRUD.
        /// </summary>
        public Prestamo ObtenerPrestamo(string idPrestamo)
        {
            return PrestamoCRUD.obtenerPrestamo(idPrestamo);
        }

        /// <summary>
        /// Registra la devolución de un ejemplar delegando en el CRUD.
        /// </summary>
        public void DevolverEjemplar(Prestamo p, Ejemplar ej)
        {
            PrestamoCRUD.devolverEjemplar(p, ej);
        }

        /// <summary>
        /// Elimina un préstamo delegando en el CRUD.
        /// </summary>
        public void EliminarPrestamo(Prestamo p)
        {
            PrestamoCRUD.eliminarPrestamo(p);
        }

        /// <summary>
        /// Obtiene los ejemplares de un préstamo delegando en el CRUD.
        /// </summary>
        public List<Ejemplar> ObtenerEjemplaresPrestamo(Prestamo p)
        {
            return PrestamoCRUD.obtenerEjemplaresPrestamo(p);
        }

        /// <summary>
        /// Recupera todos los préstamos delegando en el CRUD.
        /// </summary>
        public List<Prestamo> ObtenerTodosPrestamos()
        {
            return PrestamoCRUD.obtenerTodosPrestamos();
        }

        /// <summary>
        /// Obtiene los préstamos de un usuario delegando en el CRUD.
        /// </summary>
        public List<Prestamo> ObtenerPrestamosDeUsuario(Usuario u)
        {
            return PrestamoCRUD.obtenerPrestamosDeUsuario(u);
        }

        /// <summary>
        /// Obtiene los préstamos de un documento delegando en el CRUD.
        /// </summary>
        public List<Prestamo> ObtenerPrestamosDeDocumento(Documento d)
        {
            return PrestamoCRUD.obtenerPrestamosDeDocumento(d);
        }

        /// <summary>
        /// Verifica si el préstamo está en proceso delegando en el CRUD.
        /// </summary>
        public bool EstaEnProceso(Prestamo p)
        {
            return PrestamoCRUD.estaEnProceso(p);
        }

        /// <summary>
        /// Obtiene los documentos de un préstamo delegando en el CRUD.
        /// </summary>
        public List<Documento> ObtenerDocumentosDePrestamo(Prestamo p)
        {
            return PrestamoCRUD.obtenerDocumentosDePrestamo(p);
        }

        /// <summary>
        /// Obtiene el usuario que realizó el préstamo delegando en el CRUD.
        /// </summary>
        public Usuario ObtenerUsuarioDePrestamo(Prestamo p)
        {
            return PrestamoCRUD.obtenerUsuarioDePrestamo(p);
        }
    }
}
