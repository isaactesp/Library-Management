using System.Collections.Generic;
using ModeloDominio;
using Persistencia.BBDD;
using Persistencia.Transformers;

namespace Persistencia.CRUD
{
    /// <summary>
    /// Gestión de operaciones CRUD (Create, Read, Update, Delete) para el Personal de Sala.
    /// <br/>
    /// <b>NOTA:</b> Se asume que los datos de entrada han sido validados previamente por la Lógica de Negocio.
    /// </summary>
    internal static class PersonalSalaCRUD
    {
        /// <summary>
        /// Registra un nuevo Personal de Sala en la base de datos.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El objeto 'ps' no es nulo y su NSS no existe en la base de datos. <br/>
        /// <b>POST:</b> El personal queda guardado en el sistema.
        /// </remarks>
        /// <param name="ps">Objeto PersonalSala a registrar.</param>
        public static void AltaPersonalSala(PersonalSala ps)
        {
            BD.TablaPSala.Add(TransformerPSala.ToDato(ps));
        }

        /// <summary>
        /// Elimina un Personal de Sala del sistema.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El personal existe (se usa su NSS para localizarlo). <br/>
        /// <b>POST:</b> El personal es eliminado de la persistencia.
        /// </remarks>
        /// <param name="ps">Objeto PersonalSala a eliminar (basta con que tenga el NSS correcto).</param>
        public static void BajaPersonalSala(PersonalSala ps)
        {
            BD.TablaPSala.Remove(ps.NSS);
        }

        /// <summary>
        /// Actualiza los datos de un Personal de Sala existente.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El personal existe y los datos son válidos. <br/>
        /// <b>POST:</b> La información del personal se sobrescribe con la nueva.
        /// </remarks>
        /// <param name="ps">Objeto PersonalSala con los datos modificados.</param>
        public static void ModificarPersonalSala(PersonalSala ps)
        {
            BD.TablaPSala.Remove(ps.NSS);
            BD.TablaPSala.Add(TransformerPSala.ToDato(ps));
        }

        /// <summary>
        /// Busca un Personal de Sala por su NSS.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El NSS no es nulo. <br/>
        /// <b>POST:</b> Devuelve el objeto encontrado o null si no existe.
        /// </remarks>
        /// <param name="nss">NSS del personal a buscar.</param>
        /// <returns>Objeto PersonalSala o null.</returns>
        public static PersonalSala ObtenerPersonalSala(string nss)
        {
            if (BD.TablaPSala.Contains(nss))
            {
                return TransformerPSala.ToObject(BD.TablaPSala[nss]);
            }
            return null;
        }

        /// <summary>
        /// Verifica si existe un Personal de Sala con el NSS dado.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El NSS no es nulo. <br/>
        /// <b>POST:</b> Devuelve true si existe, false en caso contrario.
        /// </remarks>
        /// <param name="nss">NSS a comprobar.</param>
        /// <returns>True si existe, False si no.</returns>
        public static bool ExistePersonalSala(string nss)
        {
            return BD.TablaPSala.Contains(nss);
        }

        /// <summary>
        /// Obtiene una lista con todo el Personal de Sala registrado.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve una lista con todos los elementos (puede estar vacía).
        /// </remarks>
        /// <returns>Lista de PersonalSala.</returns>
        public static List<PersonalSala> ObtenerTodosPersonalSala()
        {
            List<PersonalSala> lista = new List<PersonalSala>();
            foreach (PersonalSalaDato psDato in BD.TablaPSala.obtenerTodos())
            {
                lista.Add(TransformerPSala.ToObject(psDato));
            }
            return lista;
        }
    }
}
