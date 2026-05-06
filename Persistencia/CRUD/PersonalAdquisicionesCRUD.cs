using System.Collections.Generic;
using ModeloDominio;
using Persistencia.BBDD; // Necesario para acceder a BD y sus tablas
using Persistencia.Transformers;

namespace Persistencia.CRUD
{
    /// <summary>
    /// Gestión de operaciones CRUD (Create, Read, Update, Delete) para el Personal de Adquisiciones.
    /// <br/>
    /// <b>NOTA:</b> Se asume que los datos de entrada han sido validados previamente por la Lógica de Negocio.
    /// </summary>
    internal static class PersonalAdquisicionCRUD
    {
        /// <summary>
        /// Registra un nuevo Personal de Adquisiciones en la base de datos.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El objeto 'pa' no es nulo y su NSS no existe en la base de datos. <br/>
        /// <b>POST:</b> El personal queda guardado en el sistema.
        /// </remarks>
        /// <param name="pa">Objeto PersonalAdquisiciones a registrar.</param>
        public static void AltaPersonalAdquisiciones(PersonalAdquisiciones pa)
        {
            BD.TablaPAdquisiciones.Add(TransformerPAdquisiciones.ToDato(pa));
        }

        /// <summary>
        /// Elimina un Personal de Adquisiciones del sistema.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El personal existe (se usa su NSS para localizarlo). <br/>
        /// <b>POST:</b> El personal es eliminado de la persistencia.
        /// </remarks>
        /// <param name="pa">Objeto PersonalAdquisiciones a eliminar (basta con que tenga el NSS correcto).</param>
        public static void BajaPersonalAdquisiciones(PersonalAdquisiciones pa)
        {
            BD.TablaPAdquisiciones.Remove(pa.NSS);
        }

        /// <summary>
        /// Actualiza los datos de un Personal de Adquisiciones existente.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El personal existe y los datos son válidos. <br/>
        /// <b>POST:</b> La información del personal se sobrescribe con la nueva.
        /// </remarks>
        /// <param name="pa">Objeto PersonalAdquisiciones con los datos modificados.</param>
        public static void ModificarPersonalAdquisiciones(PersonalAdquisiciones pa)
        {
            // Estrategia: Borrar y volver a insertar para asegurar que se actualiza todo
            BD.TablaPAdquisiciones.Remove(pa.NSS);
            BD.TablaPAdquisiciones.Add(TransformerPAdquisiciones.ToDato(pa));
        }

        /// <summary>
        /// Busca un Personal de Adquisiciones por su NSS.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El NSS no es nulo. <br/>
        /// <b>POST:</b> Devuelve el objeto encontrado o null si no existe.
        /// </remarks>
        /// <param name="nss">NSS del personal a buscar.</param>
        /// <returns>Objeto PersonalAdquisiciones o null.</returns>
        public static PersonalAdquisiciones ObtenerPersonalAdquisiciones(string nss)
        {
            if (BD.TablaPAdquisiciones.Contains(nss))
            {
                return TransformerPAdquisiciones.ToObject(BD.TablaPAdquisiciones[nss]);
            }
            return null;
        }

        /// <summary>
        /// Verifica si existe un Personal de Adquisiciones con el NSS dado.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El NSS no es nulo. <br/>
        /// <b>POST:</b> Devuelve true si existe, false en caso contrario.
        /// </remarks>
        /// <param name="nss">NSS a comprobar.</param>
        /// <returns>True si existe, False si no.</returns>
        public static bool ExistePersonalAdquisiciones(string nss)
        {
            return BD.TablaPAdquisiciones.Contains(nss);
        }

        /// <summary>
        /// Obtiene una lista con todo el Personal de Adquisiciones registrado.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve una lista con todos los elementos (puede estar vacía).
        /// </remarks>
        /// <returns>Lista de PersonalAdquisiciones.</returns>
        public static List<PersonalAdquisiciones> ObtenerTodosPersonalAdquisiciones()
        {
            List<PersonalAdquisiciones> lista = new List<PersonalAdquisiciones>();
            foreach (var pad in BD.TablaPAdquisiciones.obtenerTodos())
            {
                lista.Add(TransformerPAdquisiciones.ToObject(pad));
            }
            return lista;
        }
    }
}