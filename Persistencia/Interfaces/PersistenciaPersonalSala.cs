using ModeloDominio;
using Persistencia.CRUD;
using System.Collections.Generic;

namespace Persistencia.Interfaces
{
    /// <summary>
    /// Fachada de persistencia para Personal de Sala.
    /// <br/>
    /// Conecta la interfaz pública con el CRUD estático interno.
    /// </summary>
    public class PersistenciaPersonalSala : IPersistenciaPersonalSala
    {
        /// <summary>
        /// Registra un nuevo personal delegando en el CRUD.
        /// </summary>
        /// <param name="personalSala">Objeto a registrar.</param>
        /// <returns>True si el guardado fue exitoso (se verifica existencia).</returns>
        public bool AltaPersonalSala(PersonalSala personalSala)
        {
            PersonalSalaCRUD.AltaPersonalSala(personalSala);
            // Verificamos éxito consultando por su NSS
            return PersonalSalaCRUD.ExistePersonalSala(personalSala.NSS);
        }

        /// <summary>
        /// Elimina un personal existente delegando en el CRUD.
        /// </summary>
        /// <param name="personalSala">Objeto a eliminar.</param>
        /// <returns>True si el borrado fue exitoso (ya no existe).</returns>
        public bool BajaPersonalSala(PersonalSala personalSala)
        {
            PersonalSalaCRUD.BajaPersonalSala(personalSala);
            // Verificamos éxito confirmando que YA NO existe
            return !PersonalSalaCRUD.ExistePersonalSala(personalSala.NSS);
        }

        /// <summary>
        /// Actualiza los datos de un personal delegando en el CRUD.
        /// </summary>
        public void ModificarPersonalSala(PersonalSala personalSala)
        {
            PersonalSalaCRUD.ModificarPersonalSala(personalSala);
        }

        /// <summary>
        /// Busca un personal por NSS delegando en el CRUD.
        /// </summary>
        public PersonalSala ObtenerPersonalSala(string nss)
        {
            return PersonalSalaCRUD.ObtenerPersonalSala(nss);
        }

        /// <summary>
        /// Comprueba existencia por NSS delegando en el CRUD.
        /// </summary>
        public bool ExistePersonalSala(string nss)
        {
            return PersonalSalaCRUD.ExistePersonalSala(nss);
        }

        /// <summary>
        /// Recupera todos los registros delegando en el CRUD.
        /// </summary>
        public List<PersonalSala> ObtenerTodosPersonalSala()
        {
            return PersonalSalaCRUD.ObtenerTodosPersonalSala();
        }
    }
}
