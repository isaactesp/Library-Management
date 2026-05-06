using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.BBDD
{
    /// <summary>
    /// Representa los datos de un Préstamo en la capa de persistencia.
    /// <br/>
    /// <b>NOTA:</b> Se asume que todos los datos se van a introducir correctamente antes de instanciar esta clase.
    /// </summary>
    internal class PrestamoDato : Entity<string>
    {

        private string nSS;             // NSS del personal que realizó el préstamo
        private DateTime fechaPrestamo;
        private bool estado;            // true = En proceso, false = Finalizado
        private string dni;             // DNI del usuario que solicita el préstamo

        /// <summary>
        /// Constructor de PrestamoDato.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Todos los parámetros son válidos (idPrestamo no nulo, fechas correctas, referencias existentes). <br/>
        /// <b>POST:</b> Crea una instancia inicializada del préstamo.
        /// </remarks>
        /// <param name="idPrestamo">Identificador único del préstamo.</param>
        /// <param name="nSS">NSS del personal que lo tramita.</param>
        /// <param name="fechaPrestamo">Fecha de realización.</param>
        /// <param name="estado">Estado del préstamo (true: activo, false: finalizado).</param>
        /// <param name="dni">DNI del usuario.</param>
        public PrestamoDato(string idPrestamo, string nSS, DateTime fechaPrestamo, bool estado, string dni)
            : base(idPrestamo) // Pasamos el ID al padre
        {
            this.nSS = nSS;
            this.fechaPrestamo = fechaPrestamo;
            this.estado = estado;
            this.dni = dni;
        }

        /// <summary>
        /// Identificador del Préstamo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El ID es válido. <br/>
        /// <b>POST:</b> Devuelve o establece el ID.
        /// </remarks>
        public string IdPrestamo
        {
            get { return base.Id; } // Usamos el del padre
            set { base.Id = value; }
        }

        /// <summary>
        /// NSS del personal responsable.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El NSS es correcto. <br/>
        /// <b>POST:</b> Devuelve o establece el NSS.
        /// </remarks>
        public string Nss
        {
            get { return nSS; }
            set { nSS = value; }
        }

        /// <summary>
        /// Fecha en la que se realizó el préstamo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Es una fecha válida. <br/>
        /// <b>POST:</b> Devuelve o establece la fecha.
        /// </remarks>
        public DateTime FechaPrestamo
        {
            get { return fechaPrestamo; }
            set { fechaPrestamo = value; }
        }

        /// <summary>
        /// Estado del préstamo.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Ninguna. <br/>
        /// <b>POST:</b> Devuelve true si está activo/en proceso, false si está finalizado.
        /// </remarks>
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        /// <summary>
        /// DNI del usuario asociado.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> El DNI es correcto. <br/>
        /// <b>POST:</b> Devuelve o establece el DNI.
        /// </remarks>
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
    }
}