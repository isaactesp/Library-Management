using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.BBDD
{
	/// <summary>
	/// Representa los datos de un Usuario en la capa de persistencia.
	/// <br/>
	/// <b>NOTA:</b> Se asume que todos los datos se van a introducir correctamente antes de instanciar esta clase.
	/// </summary>
	internal class UsuarioDato : Entity<string>
	{
		private string nombre;
		private bool alta;

		/// <summary>
		/// Constructor de UsuarioDato.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> Los parámetros dNI, nombre y alta contienen datos correctos y válidos. <br/>
		/// <b>POST:</b> Crea una instancia inicializada, asignando el DNI como Identificador de la Entidad.
		/// </remarks>
		/// <param name="dNI">DNI del usuario (actúa como ID).</param>
		/// <param name="nombre">Nombre completo.</param>
		/// <param name="alta">Estado de alta en el sistema.</param>
		public UsuarioDato(string dNI, string nombre, bool alta)
			: base(dNI) // Pasamos el DNI al padre para que lo guarde en 'Id'
		{
			this.nombre = nombre;
			this.alta = alta;
		}

		/// <summary>
		/// Identificador único del usuario (DNI).
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> El valor asignado es un DNI correcto. <br/>
		/// <b>POST:</b> Devuelve o modifica el ID de la entidad.
		/// </remarks>
		public string DNI
		{
			get { return base.Id; } // Accedemos a la propiedad del padre
			set { base.Id = value; }
		}

		/// <summary>
		/// Nombre del usuario.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> El nombre es correcto. <br/>
		/// <b>POST:</b> Devuelve o establece el nombre.
		/// </remarks>
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		/// <summary>
		/// Estado de alta del usuario.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> Ninguna. <br/>
		/// <b>POST:</b> Devuelve o establece si el usuario está de alta.
		/// </remarks>
		public bool Alta
		{
			get { return alta; }
			set { alta = value; }
		}
	}
}