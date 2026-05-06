using System;
using System.Collections.Generic; // Necesario para EqualityComparer

namespace Persistencia.BBDD
{
    /// <summary>
    /// Representa una clave primaria compuesta por dos valores genéricos.
    /// <br/>
    /// <b>NOTA:</b> Se asume que todos los datos se van a introducir correctamente antes de instanciar esta clase.
    /// </summary>
    /// <typeparam name="T1">Tipo del primer componente de la clave.</typeparam>
    /// <typeparam name="T2">Tipo del segundo componente de la clave.</typeparam>
    internal class ClaveCompuesta<T1, T2> : IEquatable<ClaveCompuesta<T1, T2>>
    {
        protected T1 id1;
        protected T2 id2;

        /// <summary>
        /// Constructor de la Clave Compuesta.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Los parámetros id1 e id2 son valores válidos y no nulos (si el tipo no admite nulls). <br/>
        /// <b>POST:</b> Crea una instancia de la clave con los valores iniciales.
        /// </remarks>
        /// <param name="id1">Primer componente del identificador.</param>
        /// <param name="id2">Segundo componente del identificador.</param>
        public ClaveCompuesta(T1 id1, T2 id2)
        {
            this.id1 = id1;
            this.id2 = id2;
        }

        /// <summary>
        /// Primer componente de la clave.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El valor asignado debe ser válido. <br/>
        /// <b>POST:</b> Devuelve o establece el primer valor de la clave.
        /// </remarks>
        public T1 Id1
        {
            get { return id1; }
            set { id1 = value; }
        }

        /// <summary>
        /// Segundo componente de la clave.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El valor asignado debe ser válido. <br/>
        /// <b>POST:</b> Devuelve o establece el segundo valor de la clave.
        /// </remarks>
        public T2 Id2
        {
            get { return id2; }
            set { id2 = value; }
        }

        // -----------------------------------------------------------------
        // MÉTODOS DE IGUALDAD (IEquatable + Object)
        // -----------------------------------------------------------------

        /// <summary>
        /// Compara esta clave con otra del mismo tipo (Comparación tipada rápida).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve true si ambos componentes son iguales.
        /// </remarks>
        public bool Equals(ClaveCompuesta<T1, T2> other)
        {
            if (other == null) return false;
            if (other == this) return true;

            // Uso de EqualityComparer para seguridad de tipos y nulos
            return EqualityComparer<T1>.Default.Equals(this.id1, other.id1) &&
                   EqualityComparer<T2>.Default.Equals(this.id2, other.id2);
        }

        /// <summary>
        /// Compara esta clave con cualquier objeto (necesario para colecciones antiguas).
        /// </summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ClaveCompuesta<T1, T2>);
        }

        /// <summary>
        /// Genera un código hash único combinado para los dos valores.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            // El operador ?. evita excepciones si T1 o T2 son tipos referencia y valen null
            hash = hash * 23 + (id1 != null ? id1.GetHashCode() : 0);
            hash = hash * 23 + (id2 != null ? id2.GetHashCode() : 0);
            return hash;
        }
    }
}