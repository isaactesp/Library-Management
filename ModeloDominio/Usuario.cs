using System;

namespace ModeloDominio
{
    /// <summary>
    /// Representa a un usuario (lector) de la biblioteca.
    /// </summary>
    public class Usuario
    {
        // ==========================================
        // PROPIEDADES (Auto-implementadas)
        // ==========================================

        /// <summary>
        /// Documento Nacional de Identidad. Identificador único e inmutable.
        /// </summary>
        public string DNI { get; private set; }

        /// <summary>
        /// Nombre completo del usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Indica si el usuario está activo (True = Alta) o inactivo (False = Baja).
        /// </summary>
        public bool Alta { get; set; }

        // ==========================================
        // CONSTRUCTORES
        // ==========================================

        /// <summary>
        /// Constructor principal para nuevos usuarios.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Inicializa el usuario en estado de ALTA por defecto.
        /// </remarks>
        /// <param name="dni">DNI del usuario.</param>
        /// <param name="nombre">Nombre completo.</param>
        public Usuario(string dni, string nombre)
        {
            // Happy Path: Asignación directa sin validaciones defensivas
            this.DNI = dni;
            this.Nombre = nombre;
            this.Alta = true;
        }

        /// <summary>
        /// Constructor completo (para reconstrucción desde Persistencia).
        /// </summary>
        public Usuario(string dni, string nombre, bool alta)
        {
            this.DNI = dni;
            this.Nombre = nombre;
            this.Alta = alta;
        }

        // ==========================================
        // MÉTODOS SOBRESCRITOS
        // ==========================================

        public override string ToString()
        {
            return $"Usuario: {Nombre}, DNI: {DNI}, Alta: {(Alta ? "Sí" : "No")}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Usuario otroUsuario)
            {
                // La identidad del usuario la define su DNI
                return this.DNI == otroUsuario.DNI;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return DNI != null ? DNI.GetHashCode() : 0;
        }
    }
}