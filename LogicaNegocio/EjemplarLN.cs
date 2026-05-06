using System.Collections.Generic;
using ModeloDominio;
using Persistencia.Interfaces;

namespace LogicaNegocio
{
    /// <summary>
    /// Especialista en la gestión del Inventario (Ejemplares físicos).
    /// <br/>
    /// <b>RESPONSABILIDAD:</b> Gestionar las copias concretas, sus códigos de barras y estados.
    /// </summary>
    public class EjemplarLN
    {
        // Dependencia de persistencia (nombre limpio sin guion bajo)
        private readonly IPersistenciaEjemplar persistenciaEjemplar;

        /// <summary>
        /// Constructor que recibe las dependencias necesarias.
        /// </summary>
        /// <param name="persistenciaEjemplar">Fachada de persistencia para ejemplares.</param>
        public EjemplarLN(IPersistenciaEjemplar persistenciaEjemplar)
        {
            this.persistenciaEjemplar = persistenciaEjemplar;
        }

        // ==========================================
        // MÉTODOS DE ESCRITURA (ALTA/BAJA/MOD)
        // ==========================================

        /// <summary>
        /// Registra un nuevo ejemplar en el inventario.
        /// </summary>
        /// <param name="ejemplar">El objeto Ejemplar a registrar.</param>
        /// <param name="personal">El personal que realiza el alta (auditoría).</param>
        /// <returns>True si el registro fue exitoso.</returns>
        public bool AltaEjemplar(Ejemplar ejemplar, PersonalAdquisiciones personal)
        {
            return this.persistenciaEjemplar.AltaEjemplar(ejemplar, personal);
        }

        /// <summary>
        /// Da de baja un ejemplar del sistema.
        /// </summary>
        /// <param name="ejemplar">El objeto Ejemplar a eliminar.</param>
        /// <returns>True si se eliminó correctamente.</returns>
        public bool BajaEjemplar(Ejemplar ejemplar)
        {
            return this.persistenciaEjemplar.BajaEjemplar(ejemplar);
        }

        /// <summary>
        /// Modifica los datos de un ejemplar existente.
        /// </summary>
        /// <param name="ejemplar">El objeto Ejemplar con los cambios.</param>
        /// <param name="personal">El personal que realiza la modificación.</param>
        public void ModificarEjemplar(Ejemplar ejemplar, PersonalAdquisiciones personal)
        {
            this.persistenciaEjemplar.ModificarEjemplar(ejemplar, personal);
        }

        // ==========================================
        // MÉTODOS DE LECTURA (CONSULTAS)
        // ==========================================

        /// <summary>
        /// Busca un ejemplar por su código único.
        /// </summary>
        /// <param name="codigo">Código identificador.</param>
        /// <returns>El ejemplar encontrado o null.</returns>
        public Ejemplar BuscarEjemplar(string codigo)
        {
            return this.persistenciaEjemplar.ObtenerEjemplar(codigo);
        }

        /// <summary>
        /// Obtiene todos los ejemplares asociados a un documento específico.
        /// </summary>
        /// <param name="documento">Documento padre.</param>
        /// <returns>Lista de ejemplares del documento.</returns>
        public List<Ejemplar> ListarEjemplaresDeDocumento(Documento documento)
        {
            return this.persistenciaEjemplar.ObtenerEjemplaresDeDocumento(documento);
        }

        /// <summary>
        /// Obtiene todos los ejemplares de la biblioteca.
        /// </summary>
        /// <returns>Lista completa de ejemplares.</returns>
        public List<Ejemplar> ObtenerTodosEjemplares()
        {
            return this.persistenciaEjemplar.ObtenerTodosEjemplares();
        }


        public Personal QuienDioAlta(Ejemplar ejemplar)
        {
            return this.persistenciaEjemplar.QuienDioAlta(ejemplar);
        }
    }
}