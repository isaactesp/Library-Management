using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.BBDD
{
    /// <summary>
    /// Representa los datos de un Ejemplar físico en la capa de persistencia.
    /// <br/>
    /// <b>NOTA:</b> Se asume que todos los datos se van a introducir correctamente antes de instanciar esta clase.
    /// </summary>
    internal class EjemplarDato : Entity<string>
    {
        // TRUE: El ejemplar está actualmente prestado.
        // FALSE: El ejemplar ha sido devuelto (ya no está prestado).
        private bool prestado;

        private int vecesPrestado;
        private string nss;
        private string isbn;

        // TRUE: si está de baja lógica.
        // FALSE: si está activo.
        private bool bajaLogica;

        // ==========================================
        // CONSTRUCTORES
        // ==========================================

        /// <summary>
        /// Constructor COMPLETO (Usado por Transformers y recuperación de BBDD).
        /// </summary>
        /// <remarks>
        /// Permite restaurar el estado exacto de la baja lógica.
        /// </remarks>
        /// <param name="codigo">Código único del ejemplar.</param>
        /// <param name="prestado">Estado de préstamo.</param>
        /// <param name="vecesPrestado">Histórico de préstamos.</param>
        /// <param name="nss">NSS del personal.</param>
        /// <param name="isbn">ISBN del documento.</param>
        /// <param name="bajaLogica">Estado de baja lógica (true/false).</param>
        public EjemplarDato(string codigo, bool prestado, int vecesPrestado, string nss, string isbn, bool bajaLogica)
            : base(codigo)
        {
            this.prestado = prestado;
            this.vecesPrestado = vecesPrestado;
            this.nss = nss;
            this.isbn = isbn;
            this.bajaLogica = bajaLogica;
        }

        /// <summary>
        /// Constructor "POR DEFECTO" (Usado para Altas nuevas).
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Se asume que es un ejemplar nuevo o reactivado. <br/>
        /// <b>POST:</b> Inicializa la instancia marcando <b>BajaLogica = false</b> automáticamente.
        /// </remarks>
        /// <param name="codigo">Código único del ejemplar.</param>
        /// <param name="prestado">Estado de préstamo.</param>
        /// <param name="vecesPrestado">Histórico de préstamos.</param>
        /// <param name="nss">NSS del personal.</param>
        /// <param name="isbn">ISBN del documento.</param>
        public EjemplarDato(string codigo, bool prestado, int vecesPrestado, string nss, string isbn)
            : this(codigo, prestado, vecesPrestado, nss, isbn, false)
        {
            // Este constructor llama al principal pasando 'false' en bajaLogica.
            // Esto evita repetir código y asegura la consistencia.
        }

        // ==========================================
        // PROPIEDADES
        // ==========================================

        /// <summary>
        /// Código único del ejemplar (Identificador).
        /// </summary>
        public string Codigo
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        /// <summary>
        /// Estado de préstamo (True=Prestado, False=Disponible).
        /// </summary>
        public bool Prestado
        {
            get { return prestado; }
            set { prestado = value; }
        }

        /// <summary>
        /// Número de veces que se ha prestado este ejemplar.
        /// </summary>
        public int VecesPrestado
        {
            get { return vecesPrestado; }
            set { vecesPrestado = value; }
        }

        /// <summary>
        /// NSS del personal de adquisiciones (Foreign Key).
        /// </summary>
        public string Nss
        {
            get { return nss; }
            set { nss = value; }
        }

        /// <summary>
        /// ISBN del documento asociado (Foreign Key).
        /// </summary>
        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        /// <summary>
        /// Estado de Baja Lógica del ejemplar.
        /// </summary>
        public bool BajaLogica
        {
            get { return bajaLogica; }
            set { bajaLogica = value; }
        }
    }
}