using System;
using System.Collections.Generic;

namespace Persistencia.BBDD
{
    /// <summary>
    /// Clase base abstracta para todas las entidades de persistencia. Implementa la igualdad basada en el Identificador.
    /// <br/>
    /// <b>NOTA:</b> Se asume que todos los datos (especialmente el ID) se introducen correctamente y son válidos.
    /// </summary>
    /// <typeparam name="T">Tipo del Identificador (string, int, ClaveCompuesta...).</typeparam>
    internal abstract class Entity<T> : IEquatable<Entity<T>>
    {
        private T id;

        /// <summary>
        /// Constructor base de la entidad.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El parámetro id es un identificador único válido para este tipo de entidad. <br/>
        /// <b>POST:</b> Inicializa la entidad asignándole su identificador.
        /// </remarks>
        /// <param name="id">Identificador único de la entidad.</param>
        public Entity(T id)
        {
            this.id = id;
        }

        /// <summary>
        /// Identificador único de la entidad.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El valor asignado debe ser un identificador válido y único. <br/>
        /// <b>POST:</b> Devuelve o establece el valor del identificador.
        /// </remarks>
        public T Id
        {
            get { return id; }
            set { id = value; }
        }

        // --- MÉTODOS DE COMPARACIÓN ---

        /// <summary>
        /// Compara esta entidad con otra del mismo tipo basándose en su ID.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve true si ambos objetos tienen el mismo ID.
        /// </remarks>
        /// <param name="other">La otra entidad con la que comparar.</param>
        /// <returns>True si los IDs son iguales, False en caso contrario.</returns>
        public bool Equals(Entity<T> other)
        {
            if (other == null) return false;
            // Compara los IDs usando el comparador por defecto del tipo T
            return EqualityComparer<T>.Default.Equals(this.id, other.id);
        }

        /// <summary>
        /// Sobrescribe el método Equals base para permitir comparaciones con objetos genéricos.
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<T>);
        }

        /// <summary>
        /// Genera el código hash de la entidad basado en su ID.
        /// </summary>
        /// <returns>Hash code del ID.</returns>
        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(this.id);
        }
    }
}