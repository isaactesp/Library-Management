using Persistencia.BBDD;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Persistencia
{
    /// <summary>
    /// Representa una tabla genérica en la base de datos simulada en memoria.
    /// <br/>
    /// Hereda de <see cref="KeyedCollection{TKey, TItem}"/> para ofrecer acceso rápido por Clave (ID) e iteración secuencial.
    /// </summary>
    /// <typeparam name="T">Tipo del Identificador (clave primaria: string, int, ClaveCompuesta...).</typeparam>
    /// <typeparam name="U">Tipo de la Entidad almacenada (debe heredar de <see cref="Entity{T}"/>).</typeparam>
    internal class Tabla<T, U> : KeyedCollection<T, U> where U : Entity<T>
    {
        // ==========================================
        // CONSTRUCTORES
        // ==========================================

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Inicializa una tabla vacía lista para almacenar entidades.
        /// </remarks>
        public Tabla() : base() { }

        /// <summary>
        /// Constructor que permite definir un comparador específico para las claves.
        /// </summary>
        /// <remarks>
        /// Útil cuando la clave es compleja (ej. ClaveCompuesta) o requiere comparación especial (ej. CaseInsensitive).
        /// </remarks>
        /// <param name="ieq">Comparador de igualdad para el tipo T.</param>
        public Tabla(IEqualityComparer<T> ieq) : base(ieq) { }

        // ==========================================
        // MÉTODOS DE SOPORTE (KeyedCollection)
        // ==========================================

        /// <summary>
        /// Método abstracto implementado para extraer la clave de un elemento.
        /// </summary>
        /// <remarks>
        /// Es llamado automáticamente por la colección al insertar un elemento.
        /// </remarks>
        /// <param name="item">La entidad de la que se extraerá la clave.</param>
        /// <returns>El identificador (Id) de la entidad.</returns>
        protected override T GetKeyForItem(U item)
        {
            // Gracias a la restricción 'where U : Entity<T>', sabemos que item tiene propiedad Id.
            return item.Id;
        }

        // ==========================================
        // MÉTODOS PROPIOS
        // ==========================================

        /// <summary>
        /// Devuelve una copia de todos los elementos almacenados en la tabla.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve una nueva lista con los elementos actuales. 
        /// Devolver una copia evita excepciones de "Colección modificada" si se itera y modifica la tabla simultáneamente.
        /// </remarks>
        /// <returns>Lista genérica con todas las entidades.</returns>
        public List<U> obtenerTodos()
        {
            // 'this.Items' es la propiedad protegida de KeyedCollection que contiene la lista subyacente.
            return new List<U>(this.Items);
        }
    }
}