using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.BBDD
{
	/// <summary>
	/// Representa los datos de un AudioLibro en la capa de persistencia.
	/// <br/>
	/// <b>NOTA:</b> Se asume que todos los datos se van a introducir correctamente antes de instanciar esta clase.
	/// </summary>
	internal class AudioLibroDato : Entity<string>
	{
		// Eliminado 'private string isbn' porque ya existe en base.Id
		private int duracion;   // Duración en minutos
		private string formato; // Formato del archivo (mp3, wav, etc.)
		private string titulo;
		private string autor;
		private string editorial;
		private int anioPublicacion;

		/// <summary>
		/// Constructor de AudioLibroDato.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> Todos los parámetros son válidos y el ISBN es correcto. <br/>
		/// <b>POST:</b> Crea una instancia inicializada, utilizando el ISBN como identificador.
		/// </remarks>
		/// <param name="titulo">Título del audiolibro.</param>
		/// <param name="autor">Autor principal.</param>
		/// <param name="editorial">Editorial responsable.</param>
		/// <param name="anioPublicacion">Año de edición.</param>
		/// <param name="isbn">Identificador único (ISBN).</param>
		/// <param name="duracion">Duración en minutos.</param>
		/// <param name="formato">Formato del archivo (mp3, wav, etc.).</param>
		public AudioLibroDato(string titulo, string autor, string editorial, int anioPublicacion, string isbn, int duracion, string formato)
			: base(isbn) // Pasamos el ISBN al padre Entity
		{
			this.titulo = titulo;
			this.autor = autor;
			this.editorial = editorial;
			this.anioPublicacion = anioPublicacion;
			this.duracion = duracion;
			this.formato = formato;
		}

		/// <summary>
		/// Duración en minutos.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> Valor > 0. <br/>
		/// <b>POST:</b> Devuelve o establece la duración.
		/// </remarks>
		public int Duracion
		{
			get { return duracion; }
			set { duracion = value; }
		}

		/// <summary>
		/// Formato del archivo.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> Formato válido (no vacío). <br/>
		/// <b>POST:</b> Devuelve o establece el formato.
		/// </remarks>
		public string Formato
		{
			get { return formato; }
			set { formato = value; }
		}

		/// <summary>
		/// Título del audiolibro.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> No vacío. <br/>
		/// <b>POST:</b> Devuelve o establece el título.
		/// </remarks>
		public string Titulo
		{
			get { return titulo; }
			set { titulo = value; }
		}

		/// <summary>
		/// Autor del audiolibro.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> Válido. <br/>
		/// <b>POST:</b> Devuelve o establece el autor.
		/// </remarks>
		public string Autor
		{
			get { return autor; }
			set { autor = value; }
		}

		/// <summary>
		/// Editorial responsable.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> Válida. <br/>
		/// <b>POST:</b> Devuelve o establece la editorial.
		/// </remarks>
		public string Editorial
		{
			get { return editorial; }
			set { editorial = value; }
		}

		/// <summary>
		/// Año de publicación.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> Año válido. <br/>
		/// <b>POST:</b> Devuelve o establece el año.
		/// </remarks>
		public int AnioPublicacion
		{
			get { return anioPublicacion; }
			set { anioPublicacion = value; }
		}

		/// <summary>
		/// ISBN del audiolibro (Identificador único).
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> ISBN válido. <br/>
		/// <b>POST:</b> Devuelve o establece el identificador.
		/// </remarks>
		public string Isbn
		{
			get { return base.Id; } // Accedemos a la propiedad del padre
			set { base.Id = value; }
		}
	}
}