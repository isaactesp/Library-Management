using System.Collections.Generic;
using System.Linq; // Necesario para LINQ
using System.Windows.Forms;
using ModeloDominio;
using Persistencia.BBDD;
using Persistencia.Transformers;

namespace Persistencia.CRUD
{
    /// <summary>
    /// Gestión de operaciones CRUD (Create, Read, Update, Delete) para Ejemplares.
    /// <br/>
    /// <b>NOTA:</b> Implementa el patrón de <b>Baja Lógica</b> (los ejemplares no se borran físicamente).
    /// </summary>
    internal static class EjemplarCRUD
    {
        // ==========================================
        // OPERACIONES DE ESCRITURA
        // ==========================================

        /// <summary>
        /// Registra un nuevo Ejemplar en el sistema o reactiva uno dado de baja previamente.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar NO existe en el sistema, O BIEN existe pero tiene <i>BajaLogica = true</i>. El personal es válido. <br/>
        /// <b>POST:</b> El ejemplar queda registrado en base de datos con <i>BajaLogica = false</i> y los datos actualizados.
        /// </remarks>
        /// <param name="ejemplar">El objeto Ejemplar a guardar.</param>
        /// <param name="personal">El personal que realiza la adquisición (para auditoría).</param>
        /// <exception cref="System.Exception">Se lanza si el ejemplar ya existe y está activo (violación de la PRE).</exception>
        public static void AltaEjemplar(Ejemplar ejemplar, Personal personal)
        {
            // 1. Verificamos si ya existe la clave en la BBDD
            if (BD.TablaEjemplar.Contains(ejemplar.Codigo))
            {
                EjemplarDato datoExistente = BD.TablaEjemplar[ejemplar.Codigo];

                // CASO A: Existe y está de baja lógica -> LO REACTIVAMOS
                if (datoExistente.BajaLogica)
                {
                    datoExistente.BajaLogica = false; // Reactivar
                    datoExistente.Prestado = ejemplar.Prestado;
                    datoExistente.VecesPrestado = ejemplar.VecesPrestado;
                    datoExistente.Nss = personal.NSS;
                    datoExistente.Isbn = ejemplar.Documento.ISBN;
                }
                // CASO B: Existe y está activo -> ERROR (Duplicado)
                else
                {
                    throw new System.Exception($"El ejemplar con código {ejemplar.Codigo} ya existe.");
                }
            }
            else
            {
                // CASO C: No existe -> ALTA NUEVA
                EjemplarDato datoNuevo = TransformerEjemplar.ToDato(ejemplar, personal);
                BD.TablaEjemplar.Add(datoNuevo);
            }
        }

        /// <summary>
        /// Realiza la baja lógica de un Ejemplar (lo marca como eliminado).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar existe en el sistema. El ejemplar NO está prestado actualmente. <br/>
        /// <b>POST:</b> El registro permanece en BBDD pero marcado con <i>BajaLogica = true</i>.
        /// </remarks>
        /// <param name="ejemplar">Objeto Ejemplar a dar de baja.</param>
        public static void BajaEjemplar(Ejemplar ejemplar)
        {
            if (BD.TablaEjemplar.Contains(ejemplar.Codigo))
            {
                // NO hacemos Remove. Marcamos la baja lógica.
                BD.TablaEjemplar[ejemplar.Codigo].BajaLogica = true;
            }
        }

        /// <summary>
        /// Actualiza los datos de un Ejemplar.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar existe en el sistema y está ACTIVO (BajaLogica = false). <br/>
        /// <b>POST:</b> Se actualizan sus propiedades (estado prestado, contadores, etc.).
        /// </remarks>
        /// <param name="ejemplar">Objeto Ejemplar con los datos modificados.</param>
        /// <param name="personal">Personal responsable de la modificación.</param>
        public static void ModificarEjemplar(Ejemplar ejemplar, Personal personal)
        {
            if (BD.TablaEjemplar.Contains(ejemplar.Codigo))
            {
                EjemplarDato dato = BD.TablaEjemplar[ejemplar.Codigo];

                // Solo modificamos si no está de baja (Restricción de negocio)
                if (!dato.BajaLogica)
                {
                    dato.Prestado = ejemplar.Prestado;
                    dato.VecesPrestado = ejemplar.VecesPrestado;
                    dato.Nss = personal.NSS;
                    dato.Isbn = ejemplar.Documento.ISBN;
                }
            }
        }

        // ==========================================
        // OPERACIONES DE LECTURA
        // ==========================================

        /// <summary>
        /// Busca un Ejemplar por su código único, independientemente de su estado (Activo o Baja).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El código proporcionado es válido (no nulo). <br/>
        /// <b>POST:</b> Devuelve el Ejemplar reconstruido si existe en BBDD. Devuelve null si no existe.
        /// </remarks>
        /// <param name="codigo">El código único del ejemplar a buscar.</param>
        /// <returns>El objeto Ejemplar con la propiedad BajaLogica informada, o null.</returns>
        public static Ejemplar ObtenerEjemplar(string codigo)
        {
            if (BD.TablaEjemplar.Contains(codigo))
            {
                EjemplarDato dato = BD.TablaEjemplar[codigo];

                Documento doc = (Documento)LibroCRUD.ObtenerLibro(dato.Isbn)
                                ?? AudioLibroCRUD.ObtenerAudioLibro(dato.Isbn);

                if (doc != null)
                {
                    return TransformerEjemplar.ToObject(dato, doc);
                }
            }
            return null;
        }

        /// <summary>
        /// Verifica si existe un ejemplar con ese código en el sistema (incluso si está dado de baja).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Código válido. <br/>
        /// <b>POST:</b> Devuelve true si la clave existe en la tabla. False en caso contrario.
        /// </remarks>
        /// <param name="codigo">Código a verificar.</param>
        /// <returns>True si existe (activo o baja). False si no existe.</returns>
        public static bool ExisteEjemplar(string codigo)
        {
            // CAMBIO: Ahora contamos como "Existente" incluso los que tienen baja lógica.
            return BD.TablaEjemplar.Contains(codigo);
        }

        /// <summary>
        /// Obtiene todos los ejemplares (Activos y Bajas) de un Documento específico.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El documento no es nulo. <br/>
        /// <b>POST:</b> Devuelve una lista de ejemplares asociados al documento.
        /// </remarks>
        /// <param name="doc">El documento del cual se quieren consultar los ejemplares.</param>
        /// <returns>Lista completa de ejemplares del documento.</returns>
        public static List<Ejemplar> ObtenerEjemplaresDeDocumento(Documento doc)
        {
            if (doc == null) return new List<Ejemplar>();

            // CAMBIO: Eliminamos filtro !BajaLogica para devolver todo el historial
            return BD.TablaEjemplar.obtenerTodos()
                     .Where(dato => dato.Isbn == doc.ISBN)
                     .Select(dato => TransformerEjemplar.ToObject(dato, doc))
                     .ToList();
        }

        /// <summary>
        /// Obtiene TODOS los ejemplares del sistema que están ACTIVOS.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Devuelve únicamente los ejemplares que no tienen marca de baja lógica.
        /// </remarks>
        /// <returns>Lista de ejemplares activos.</returns>
        public static List<Ejemplar> ObtenerTodosEjemplares()
        {
            // Mantenemos el filtro aquí porque el nombre del método suele implicar "disponibles/visibles"
            // Si necesitas TODOS absolutos, usa ObtenerEjemplaresActivos + ObtenerEjemplaresDadosDeBaja
            var datosActivos = BD.TablaEjemplar.obtenerTodos()
                                 .Where(d => !d.BajaLogica);

            List<Ejemplar> resultado = new List<Ejemplar>();

            foreach (var dato in datosActivos)
            {
                Ejemplar e = ObtenerEjemplar(dato.Codigo);
                if (e != null)
                {
                    resultado.Add(e);
                }
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene una lista explícita de todos los ejemplares que están ACTIVOS.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Devuelve lista de ejemplares donde BajaLogica es false.
        /// </remarks>
        /// <returns>Lista de ejemplares activos.</returns>
        public static List<Ejemplar> ObtenerEjemplaresActivos()
        {
            return BD.TablaEjemplar.obtenerTodos()
                     .Where(dato => !dato.BajaLogica)
                     .Select(dato =>
                     {
                         Documento doc = (Documento)LibroCRUD.ObtenerLibro(dato.Isbn)
                                          ?? AudioLibroCRUD.ObtenerAudioLibro(dato.Isbn);
                         return TransformerEjemplar.ToObject(dato, doc);
                     })
                     .Where(ejemplar => ejemplar != null)
                     .ToList();
        }

        /// <summary>
        /// Obtiene una lista de los ejemplares que han sido dados de baja (Histórico).
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Devuelve los ejemplares marcados con BajaLogica = true.
        /// </remarks>
        /// <returns>Lista de ejemplares eliminados lógicamente.</returns>
        public static List<Ejemplar> ObtenerEjemplaresDadosDeBaja()
        {
            return BD.TablaEjemplar.obtenerTodos()
                     .Where(dato => dato.BajaLogica)
                     .Select(dato =>
                     {
                         Documento doc = (Documento)LibroCRUD.ObtenerLibro(dato.Isbn)
                                          ?? AudioLibroCRUD.ObtenerAudioLibro(dato.Isbn);
                         return TransformerEjemplar.ToObject(dato, doc);
                     })
                     .Where(ejemplar => ejemplar != null)
                     .ToList();
        }

        /// <summary>
        /// Identifica qué miembro del personal registró un ejemplar específico.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar tiene un código válido y existe en la base de datos. <br/>
        /// <b>POST:</b> Devuelve el objeto Personal correspondiente al NSS registrado.
        /// </remarks>
        public static Personal QuienDioAlta(Ejemplar ejemplar)
        {
            if (ejemplar == null)
            {
                //MessageBox.Show("DEBUG QuienDioAlta:\nEl ejemplar recibido es NULL");
                return null;
            }

            if (string.IsNullOrWhiteSpace(ejemplar.Codigo))
            {
                //MessageBox.Show("DEBUG QuienDioAlta:\nEl código del ejemplar es nulo o vacío");
                return null;
            }

            string codigo = ejemplar.Codigo.Trim();

            if (!BD.TablaEjemplar.Contains(codigo))
            {
                /*
                MessageBox.Show(
                    "DEBUG QuienDioAlta:\n" +
                    $"No existe ningún Ejemplar con código [{codigo}] en TablaEjemplar"
                );*/
                return null;
            }

            var dato = BD.TablaEjemplar[codigo];
            string nss = (dato.Nss ?? "").Trim();

            if (string.IsNullOrWhiteSpace(nss))
            {
                /*MessageBox.Show(
                    "DEBUG QuienDioAlta:\n" +
                    $"El Ejemplar [{codigo}] existe, pero su NSS está vacío"
                );*/
                return null;
            }

            
            // Comprobamos en qué tabla está el personal
            bool enSala = BD.TablaPSala.Contains(nss);
            bool enAdq = BD.TablaPAdquisiciones.Contains(nss);
            /*
            MessageBox.Show(
                "DEBUG QuienDioAlta:\n" +
                $"Código ejemplar: [{codigo}]\n" +
                $"NSS guardado: [{nss}]\n" +
                $"¿Existe en TablaPSala?: {enSala}\n" +
                $"¿Existe en TablaPAdquisiciones?: {enAdq}"
            );*/

            if (enSala)
                return PersonalSalaCRUD.ObtenerPersonalSala(nss);

            if (enAdq)
                return PersonalAdquisicionCRUD.ObtenerPersonalAdquisiciones(nss);
            /*
            MessageBox.Show(
                "DEBUG QuienDioAlta:\n" +
                $"El NSS [{nss}] NO existe en ninguna tabla de Personal"
            );*/

            return null;
        }


        /*
        public static Personal QuienDioAlta(Ejemplar ejemplar)
        {
            if (BD.TablaEjemplar.Contains(ejemplar.Codigo))
            {
                string nss = BD.TablaEjemplar[ejemplar.Codigo].Nss;

                if (BD.TablaPSala.Contains(nss))
                    return PersonalSalaCRUD.ObtenerPersonalSala(nss);
                else if (BD.TablaPAdquisiciones.Contains(nss))
                    return PersonalAdquisicionCRUD.ObtenerPersonalAdquisiciones(nss);
            }

            return null;
        }
        */
    }
}