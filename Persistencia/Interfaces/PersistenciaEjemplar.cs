using ModeloDominio;
using Persistencia.CRUD;
using Persistencia.Interfaces;
using System.Collections.Generic;

namespace Persistencia
{
    /// <summary>
    /// Fachada de persistencia para Ejemplares.
    /// <br/>
    /// Conecta la interfaz pública con el CRUD estático interno.
    /// </summary>
    public class PersistenciaEjemplar : IPersistenciaEjemplar
    {
        /// <summary>
        /// Registra un nuevo ejemplar delegando en el CRUD.
        /// </summary>
        public bool AltaEjemplar(Ejemplar ejemplar, Personal personal)
        {
            EjemplarCRUD.AltaEjemplar(ejemplar, personal);
            // Verificamos éxito consultando si existe
            return EjemplarCRUD.ExisteEjemplar(ejemplar.Codigo);
        }

        /// <summary>
        /// Elimina un ejemplar delegando en el CRUD.
        /// </summary>
        public bool BajaEjemplar(Ejemplar ejemplar)
        {
            EjemplarCRUD.BajaEjemplar(ejemplar);
            // Verificamos éxito confirmando que YA NO existe
            return !EjemplarCRUD.ExisteEjemplar(ejemplar.Codigo);
        }

        /// <summary>
        /// Actualiza un ejemplar delegando en el CRUD.
        /// </summary>
        public void ModificarEjemplar(Ejemplar ejemplar, Personal personal)
        {
            EjemplarCRUD.ModificarEjemplar(ejemplar, personal);
        }

        /// <summary>
        /// Obtiene un ejemplar por código delegando en el CRUD.
        /// </summary>
        public Ejemplar ObtenerEjemplar(string codigo)
        {
            return EjemplarCRUD.ObtenerEjemplar(codigo);
        }

        /// <summary>
        /// Verifica existencia por código delegando en el CRUD.
        /// </summary>
        public bool ExisteEjemplar(string codigo)
        {
            return EjemplarCRUD.ExisteEjemplar(codigo);
        }

        /// <summary>
        /// Obtiene ejemplares de un documento específico.
        /// </summary>
        public List<Ejemplar> ObtenerEjemplaresDeDocumento(Documento documento)
        {
            return EjemplarCRUD.ObtenerEjemplaresDeDocumento(documento);
        }

        /// <summary>
        /// Obtiene todos los ejemplares del sistema.
        /// </summary>
        public List<Ejemplar> ObtenerTodosEjemplares()
        {
            return EjemplarCRUD.ObtenerTodosEjemplares();
        }



        public Personal QuienDioAlta(Ejemplar ejemplar)
        {
            return EjemplarCRUD.QuienDioAlta(ejemplar);
        }

    }
}