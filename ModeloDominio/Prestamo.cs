using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ModeloDominio
{
    /// <summary>
    /// Representa la entidad de un Préstamo dentro del sistema de la biblioteca.
    /// Gestiona la información básica sobre el identificador, el estado y la fecha de creación.
    /// </summary>
    public class Prestamo 
    {
        /// <summary>
        /// Identificador único del préstamo.
        /// </summary>
        private string idPrestamo;

        /// <summary>
        /// Estado actual del préstamo. 
        /// True indica que está en proceso (activo) y False que ha finalizado o no está activo.
        /// </summary>
        private bool estado; // true si está en proceso y false en caso contrario

        /// <summary>
        /// Fecha y hora en la que se realizó el préstamo.
        /// </summary>
        private DateTime fechaPrestado;

        /// <summary>
        /// Constructor por defecto.
        /// Inicializa el préstamo con valores vacíos y la fecha actual.
        /// </summary>
        public Prestamo()
        {
            idPrestamo = "";
            estado = false;
            fechaPrestado = DateTime.Now;
        }

        /// <summary>
        /// Constructor que inicializa el préstamo con un identificador.
        /// El estado se establece en falso y la fecha en el momento actual.
        /// </summary>
        /// <param name="idPrestamo">Identificador único para el préstamo.</param>
        public Prestamo(string idPrestamo)
        {
            this.idPrestamo = idPrestamo;
            this.estado = false;
            this.fechaPrestado = DateTime.Now;
        }
        
        /// <summary>
        /// Constructor completo para inicializar todas las propiedades del préstamo.
        /// </summary>
        /// <param name="idPrestamo">Identificador único del préstamo.</param>
        /// <param name="estado">Estado del préstamo (True: En proceso, False: Finalizado).</param>
        /// <param name="fechaPrestamo">Fecha en la que se realiza el préstamo.</param>
        public Prestamo(string idPrestamo, bool estado, DateTime fechaPrestamo)
        {
            this.idPrestamo = idPrestamo;
            this.estado = estado;
            this.fechaPrestado = fechaPrestamo;

        }

        /// <summary>
        /// Obtiene el identificador del préstamo.
        /// </summary>
        public string IdPrestamo { get { return idPrestamo; } }

        /// <summary>
        /// Obtiene o establece el estado del préstamo.
        /// </summary>
        /// <value>True si el préstamo está activo; False en caso contrario.</value>
        public bool Estado { get { return estado; } set { estado = value; } }

        /// <summary>
        /// Obtiene la fecha en la que se realizó el préstamo.
        /// </summary>
        public DateTime FechaPrestado { get { return fechaPrestado; } }


        /// <summary>
        /// Devuelve una cadena que representa el objeto actual.
        /// </summary>
        /// <returns>Una cadena con el ID, estado y fecha del préstamo.</returns>
        public override string ToString()
        {
            return "Prestamo con ID: " + this.idPrestamo + " en estado " + this.estado + " iniciado el " + this.fechaPrestado;
        }

        /// <summary>
        /// Determina si el objeto especificado es igual al objeto actual.
        /// </summary>
        /// <param name="obj">Objeto con el que se va a comparar.</param>
        /// <returns>True si los préstamos tienen el mismo ID; False en caso contrario.</returns>
        public override bool Equals(object obj)
        {
            // Si es null o de otro tipo, no son iguales
            if (obj == null || GetType() != obj.GetType())
                return false;

            // Convertimos a Prestamo
            Prestamo other = (Prestamo)obj;

            // Comparamos por el identificador único
            return this.idPrestamo ==other.idPrestamo;
        }

        /// <summary>
        /// Sirve como la función hash predeterminada.
        /// </summary>
        /// <returns>Un código hash para el préstamo actual, basado en su ID.</returns>
        public override int GetHashCode()
        {
            return idPrestamo != null ? idPrestamo.GetHashCode() : 0;
        }
    }
}
