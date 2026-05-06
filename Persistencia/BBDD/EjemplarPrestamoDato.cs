using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.BBDD
{
    /// <summary>
    /// Representa la relación N:M entre un Préstamo y un Ejemplar (Tabla intermedia).
    /// <br/>
    /// <b>RESPONSABILIDAD:</b> Vincular un ejemplar físico específico con un préstamo realizado.
    /// <br/>
    /// <b>NOTA:</b> Esta entidad no guarda estado (si está prestado o no), solo la existencia del vínculo.
    /// </summary>
    internal class EjemplarPrestamoDato : Entity<ClaveCompuesta<string, string>>
    {

        // ==========================================
        // CONSTRUCTORES
        // ==========================================

        /// <summary>
        /// Constructor principal mediante IDs individuales.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> Los identificadores no deben ser nulos ni vacíos. <br/>
        /// <b>POST:</b> Crea una instancia que representa el vínculo entre el préstamo y el ejemplar.
        /// </remarks>
        /// <param name="idPrestamo">Identificador único del préstamo (FK).</param>
        /// <param name="codigoEjemplar">Código único del ejemplar (FK).</param>
        public EjemplarPrestamoDato(string idPrestamo, string codigoEjemplar)
            : base(new ClaveCompuesta<string, string>(idPrestamo, codigoEjemplar))
        {
        }

        /// <summary>
        /// Constructor mediante objeto de Clave Compuesta.
        /// </summary>
        /// <remarks>
        /// <b>PRE:</b> La clave compuesta debe estar instanciada y contener valores válidos. <br/>
        /// <b>POST:</b> Inicializa la entidad con la clave proporcionada.
        /// </remarks>
        /// <param name="cc">Objeto ClaveCompuesta con los IDs ya encapsulados.</param>
        public EjemplarPrestamoDato(ClaveCompuesta<string, string> cc)
            : base(cc)
        {
        }

        // ==========================================
        // PROPIEDADES "FACHADA" (Accessors)
        // ==========================================

        /// <summary>
        /// Obtiene o establece el ID del Préstamo (Parte 1 de la clave compuesta).
        /// </summary>
        /// <remarks>
        /// Facilita el acceso directo sin necesidad de invocar <i>this.Id.Id1</i>.
        /// </remarks>
        public string IdPrestamo
        {
            get { return this.Id.Id1; }
            set { this.Id.Id1 = value; }
        }

        /// <summary>
        /// Obtiene o establece el Código del Ejemplar (Parte 2 de la clave compuesta).
        /// </summary>
        /// <remarks>
        /// Facilita el acceso directo sin necesidad de invocar <i>this.Id.Id2</i>.
        /// </remarks>
        public string CodigoEjemplar
        {
            get { return this.Id.Id2; }
            set { this.Id.Id2 = value; }
        }
    }
}