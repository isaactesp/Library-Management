using ModeloDominio;
using Persistencia.CRUD;
using Persistencia.Interfaces;
using System.Collections.Generic;

namespace Persistencia
{
    /// <summary>
    /// Fachada de persistencia para Personal de Adquisiciones.
    /// <br/>
    /// Conecta la interfaz pública con el CRUD estático interno.
    /// </summary>
    public class PersistenciaPersonalAdquisiciones : IPersistenciaPersonalAdquisiciones
    {
        /// <summary>
        /// Registra un nuevo personal delegando en el CRUD.
        /// </summary>
        /// <param name="personalAdquisiciones">Objeto a registrar.</param>
        /// <returns>True si el guardado fue exitoso (se verifica existencia).</returns>
        public bool AltaPersonalAdquisiciones(PersonalAdquisiciones personalAdquisiciones)
        {
            PersonalAdquisicionCRUD.AltaPersonalAdquisiciones(personalAdquisiciones);
            // Verificamos éxito consultando por su NSS
            return PersonalAdquisicionCRUD.ExistePersonalAdquisiciones(personalAdquisiciones.NSS);
        }

        /// <summary>
        /// Elimina un personal existente delegando en el CRUD.
        /// </summary>
        /// <param name="personalAdquisiciones">Objeto a eliminar.</param>
        /// <returns>True si el borrado fue exitoso (ya no existe).</returns>
        public bool BajaPersonalAdquisiciones(PersonalAdquisiciones personalAdquisiciones)
        {
            PersonalAdquisicionCRUD.BajaPersonalAdquisiciones(personalAdquisiciones);
            // Verificamos éxito confirmando que YA NO existe
            return !PersonalAdquisicionCRUD.ExistePersonalAdquisiciones(personalAdquisiciones.NSS);
        }

        /// <summary>
        /// Actualiza los datos de un personal delegando en el CRUD.
        /// </summary>
        public void ModificarPersonalAdquisiciones(PersonalAdquisiciones personalAdquisiciones)
        {
            PersonalAdquisicionCRUD.ModificarPersonalAdquisiciones(personalAdquisiciones);
        }

        /// <summary>
        /// Busca un personal por NSS delegando en el CRUD.
        /// </summary>
        public PersonalAdquisiciones ObtenerPersonalAdquisiciones(string nss)
        {
            return PersonalAdquisicionCRUD.ObtenerPersonalAdquisiciones(nss);
        }

        /// <summary>
        /// Comprueba existencia por NSS delegando en el CRUD.
        /// </summary>
        public bool ExistePersonalAdquisiciones(string nss)
        {
            return PersonalAdquisicionCRUD.ExistePersonalAdquisiciones(nss);
        }

        /// <summary>
        /// Recupera todos los registros delegando en el CRUD.
        /// </summary>
        public List<PersonalAdquisiciones> ObtenerTodosPersonalAdquisiciones()
        {
            return PersonalAdquisicionCRUD.ObtenerTodosPersonalAdquisiciones();
        }
    }
}