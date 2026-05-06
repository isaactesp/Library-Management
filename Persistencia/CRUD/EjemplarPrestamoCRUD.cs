using System;
using System.Collections.Generic;
using System.Linq;
using ModeloDominio;
using Persistencia.BBDD;

namespace Persistencia.CRUD
{
    /// <summary>
    /// Gestión de operaciones CRUD para la relación N:M entre Préstamos y Ejemplares.
    /// <br/>
    /// <b>RESPONSABILIDAD:</b> Gestionar los vínculos y consultas estadísticas complejas.
    /// </summary>
    internal static class EjemplarPrestamoCRUD
    {
        // ==========================================
        // OPERACIONES DE ESCRITURA (Alta / Baja)
        // ==========================================

        /// <summary>
        /// Vincula un ejemplar a un préstamo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El préstamo y el ejemplar existen. No están vinculados previamente. <br/>
        /// <b>POST:</b> Se crea la relación en la base de datos.
        /// </remarks>
        /// <param name="prestamo">El objeto Préstamo cabecera.</param>
        /// <param name="ejemplar">El objeto Ejemplar a vincular.</param>
        public static void AltaEjemplarPrestamo(Prestamo prestamo, Ejemplar ejemplar)
        {
            var clave = new ClaveCompuesta<string, string>(prestamo.IdPrestamo, ejemplar.Codigo);

            if (!BD.TablaEjemplarPrestamo.Contains(clave))
            {
                var dato = new EjemplarPrestamoDato(clave);
                BD.TablaEjemplarPrestamo.Add(dato);
            }
        }

        /// <summary>
        /// Desvincula un ejemplar de un préstamo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> La relación existe. <br/>
        /// <b>POST:</b> Se elimina el vínculo de la base de datos.
        /// </remarks>
        /// <param name="prestamo">El objeto Préstamo.</param>
        /// <param name="ejemplar">El objeto Ejemplar a desvincular.</param>
        public static void BajaEjemplarPrestamo(Prestamo prestamo, Ejemplar ejemplar)
        {
            var clave = new ClaveCompuesta<string, string>(prestamo.IdPrestamo, ejemplar.Codigo);

            if (BD.TablaEjemplarPrestamo.Contains(clave))
            {
                BD.TablaEjemplarPrestamo.Remove(clave);
            }
        }

        /// <summary>
        /// Determina si existe un vínculo entre un préstamo y un ejemplar.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El préstamo y el ejemplar no son nulos. <br/>
        /// <b>POST:</b> Devuelve true si el vínculo existe en la tabla intermedia.
        /// </remarks>
        /// <param name="prestamo">El objeto Préstamo.</param>
        /// <param name="ejemplar">El objeto Ejemplar.</param>
        /// <returns>True si existe la relación, false en caso contrario.</returns>
        public static bool ExisteEjemplarPrestamo(Prestamo prestamo, Ejemplar ejemplar)
        {
            var clave = new ClaveCompuesta<string, string>(prestamo.IdPrestamo, ejemplar.Codigo);
            return BD.TablaEjemplarPrestamo.Contains(clave);
        }

        // ==========================================
        // OPERACIONES DE LECTURA (Consultas)
        // ==========================================

        /// <summary>
        /// Obtiene todos los objetos Ejemplar asociados a un Préstamo concreto.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El préstamo es válido. <br/>
        /// <b>POST:</b> Devuelve la lista de ejemplares completos (con sus datos de Documento reconstruidos).
        /// </remarks>
        /// <param name="prestamo">El objeto préstamo del que obtener los items.</param>
        /// <returns>Lista de ejemplares del préstamo.</returns>
        public static List<Ejemplar> ListarEjemplaresDePrestamo(Prestamo prestamo)
        {
            // 1. Obtenemos los vínculos (Datos intermedios) filtrando por el ID del préstamo
            var vinculos = BD.TablaEjemplarPrestamo.obtenerTodos()
                             .Where(ep => ep.IdPrestamo == prestamo.IdPrestamo)
                             .ToList();

            List<Ejemplar> resultados = new List<Ejemplar>();

            // 2. Por cada vínculo, recuperamos el Ejemplar completo usando su CRUD
            foreach (var vinculo in vinculos)
            {
                // Reutilizamos EjemplarCRUD para obtener el objeto reconstruido (con su Documento padre)
                // Respetamos la lógica del CRUD de ejemplares (activos/baja lógica según corresponda)
                Ejemplar e = EjemplarCRUD.ObtenerEjemplar(vinculo.CodigoEjemplar);

                if (e != null)
                {
                    resultados.Add(e);
                }
            }

            return resultados;
        }

        /// <summary>
        /// Obtiene todos los Préstamos en los que ha participado un Ejemplar.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ejemplar es válido. <br/>
        /// <b>POST:</b> Devuelve la lista de préstamos históricos de este ejemplar.
        /// </remarks>
        /// <param name="ejemplar">El objeto ejemplar a consultar.</param>
        /// <returns>Lista de préstamos asociados.</returns>
        public static List<Prestamo> ListarPrestamosDeEjemplar(Ejemplar ejemplar)
        {
            // 1. Obtenemos los vínculos (Datos intermedios) filtrando por el código del ejemplar
            var vinculos = BD.TablaEjemplarPrestamo.obtenerTodos()
                             .Where(ep => ep.CodigoEjemplar == ejemplar.Codigo)
                             .ToList();

            List<Prestamo> resultados = new List<Prestamo>();

            // 2. Por cada vínculo, recuperamos el Préstamo completo usando su CRUD
            foreach (var vinculo in vinculos)
            {
                // Reutilizamos PrestamoCRUD para obtener el objeto reconstruido
                Prestamo p = PrestamoCRUD.obtenerPrestamo(vinculo.IdPrestamo);
                if (p != null)
                {
                    resultados.Add(p);
                }
            }
            return resultados;
        }

        /// <summary>
        /// Obtiene todos los registros de la tabla intermedia (Datos crudos).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve la lista completa de relaciones ID_Prestamo - Codigo_Ejemplar.
        /// </remarks>
        /// <returns>Lista de datos de persistencia.</returns>
        public static List<EjemplarPrestamoDato> obtenerTodos()
        {
            return BD.TablaEjemplarPrestamo.obtenerTodos();
        }

        /// <summary>
        /// Obtiene el Documento (Libro o AudioLibro) que más veces ha sido prestado en un periodo de tiempo.
        /// </summary>
        /// <remarks>
        /// Se calcula sumando las veces que aparece cualquier ejemplar de un documento en los préstamos realizados dentro del rango.
        /// </remarks>
        /// <param name="inicio">Fecha de inicio del periodo.</param>
        /// <param name="fin">Fecha de fin del periodo.</param>
        /// <returns>El Documento más popular o null si no hubo préstamos en ese periodo.</returns>
        public static Documento ObtenerDocumentoMasPrestado(DateTime inicio, DateTime fin)
        {
            // PASO 1: Obtener los IDs de los préstamos realizados en el rango de fechas
            var idsPrestamosEnFecha = BD.TablaPrestamo.obtenerTodos()
                                        .Where(p => p.FechaPrestamo >= inicio && p.FechaPrestamo <= fin)
                                        .Select(p => p.IdPrestamo)
                                        .ToList();

            if (idsPrestamosEnFecha.Count == 0) return null;

            // PASO 2: Obtener todos los vínculos (Ejemplar-Prestamo) que coincidan con esos préstamos
            var vecesPrestadoPorEjemplar = BD.TablaEjemplarPrestamo.obtenerTodos()
                                             .Where(ep => idsPrestamosEnFecha.Contains(ep.IdPrestamo))
                                             .ToList();

            if (vecesPrestadoPorEjemplar.Count == 0) return null;

            // PASO 3: Agrupar por ISBN para contar popularidad del Documento
            var conteoPorIsbn = new Dictionary<string, int>();

            foreach (var vinculo in vecesPrestadoPorEjemplar)
            {
                // Buscamos el dato del ejemplar para sacar su ISBN
                if (BD.TablaEjemplar.Contains(vinculo.CodigoEjemplar))
                {
                    string isbn = BD.TablaEjemplar[vinculo.CodigoEjemplar].Isbn;

                    if (conteoPorIsbn.ContainsKey(isbn))
                        conteoPorIsbn[isbn]++;
                    else
                        conteoPorIsbn[isbn] = 1;
                }
            }

            if (conteoPorIsbn.Count == 0) return null;

            // PASO 4: Encontrar el ISBN con el valor máximo
            string isbnGanador = conteoPorIsbn.OrderByDescending(pair => pair.Value)
                                              .First()
                                              .Key;

            // PASO 5: Recuperar el objeto Documento final
            if (LibroCRUD.ExisteLibro(isbnGanador))
            {
                return LibroCRUD.ObtenerLibro(isbnGanador);
            }
            else if (AudioLibroCRUD.ExisteAudioLibro(isbnGanador))
            {
                return AudioLibroCRUD.ObtenerAudioLibro(isbnGanador);
            }

            return null;
        }
    }
}