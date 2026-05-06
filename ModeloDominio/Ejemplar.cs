using System;

namespace ModeloDominio
{
    /// <summary>
    /// Representa un ejemplar físico o archivo concreto de un documento.
    /// </summary>
    public class Ejemplar
    {
        // ===== Propiedades Auto-implementadas =====

        /// <summary>
        /// Código único del ejemplar (Identificador).
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Indica si el ejemplar está actualmente prestado.
        /// </summary>
        public bool Prestado { get; set; }

        /// <summary>
        /// Contador histórico de préstamos.
        /// </summary>
        public int VecesPrestado { get; set; }

        /// <summary>
        /// Referencia al Documento (Libro o AudioLibro) al que pertenece este ejemplar.
        /// </summary>
        public Documento Documento { get; set; }

        /// <summary>
        /// Indica si el ejemplar ha sido dado de baja lógicamente (borrado virtual).
        /// </summary>
        public bool BajaLogica { get; set; }

        // ===== Constructores =====

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <remarks>
        /// <b>POST:</b> Crea una instancia vacía y activa (no baja).
        /// </remarks>
        public Ejemplar()
        {
            this.Codigo = string.Empty;
            this.Prestado = false;
            this.VecesPrestado = 0;
            this.Documento = null;
            this.BajaLogica = false; // Por defecto activo
        }

        /// <summary>
        /// Constructor parametrizado principal.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Se asume que el documento existe y el código es válido. <br/>
        /// <b>POST:</b> Crea un ejemplar disponible (no prestado), con contador a cero y activo.
        /// </remarks>
        /// <param name="codigo">Código único del ejemplar.</param>
        /// <param name="documento">Documento asociado.</param>
        public Ejemplar(string codigo, Documento documento)
        {
            this.Codigo = codigo;
            this.Documento = documento;
            this.Prestado = false; // Por defecto, nace disponible
            this.VecesPrestado = 0;
            this.BajaLogica = false; // Por defecto, nace activo
        }

        // ===== Sobrescrituras =====

        /// <summary>
        /// Representación textual del Ejemplar.
        /// </summary>
        public override string ToString()
        {
            // Usamos el operador ?. para evitar fallos si Documento es null
            string tituloDoc = Documento != null ? Documento.Titulo : "Desconocido";
            string estado = Prestado ? "[Prestado]" : "[Disponible]";

            if (BajaLogica) estado = "[BAJA]";

            return $"{Codigo} - {tituloDoc} {estado}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Ejemplar otro)
            {
                return this.Codigo == otro.Codigo;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Codigo != null ? Codigo.GetHashCode() : 0;
        }
    }
}