using System.Collections.Generic;
using ModeloDominio;
using Persistencia.BBDD;
using Persistencia.Transformers;

namespace Persistencia.CRUD
{
	/// <summary>
	/// Gestión de operaciones CRUD (Create, Read, Update, Delete) para AudioLibros.
	/// <br/>
	/// <b>NOTA:</b> Se asume que los datos de entrada han sido validados previamente por la Lógica de Negocio.
	/// </summary>
	internal static class AudioLibroCRUD
	{
		/// <summary>
		/// Registra un nuevo AudioLibro en la base de datos.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> El objeto 'audioLibro' no es nulo y su ISBN no existe en la base de datos. <br/>
		/// <b>POST:</b> El audiolibro queda guardado en el sistema.
		/// </remarks>
		/// <param name="audioLibro">Objeto AudioLibro a registrar.</param>
		public static void AltaAudioLibro(AudioLibro audioLibro)
		{
			BD.TablaAudioLibro.Add(TransformerAudioLibro.ToDato(audioLibro));
		}

		/// <summary>
		/// Elimina un AudioLibro del sistema.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> El audiolibro existe (se usa su ISBN para localizarlo). <br/>
		/// <b>POST:</b> El audiolibro es eliminado de la persistencia.
		/// </remarks>
		/// <param name="audioLibro">Objeto AudioLibro a eliminar.</param>
		public static void BajaAudioLibro(AudioLibro audioLibro)
		{
			BD.TablaAudioLibro.Remove(audioLibro.ISBN);
		}

		/// <summary>
		/// Actualiza los datos de un AudioLibro existente.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> El audiolibro existe y los datos son válidos. <br/>
		/// <b>POST:</b> La información se sobrescribe con la nueva.
		/// </remarks>
		/// <param name="audioLibro">Objeto AudioLibro con los datos modificados.</param>
		public static void ModificarAudioLibro(AudioLibro audioLibro)
		{
			// Estrategia: Borrar y volver a insertar para asegurar la actualización
			BD.TablaAudioLibro.Remove(audioLibro.ISBN);
			BD.TablaAudioLibro.Add(TransformerAudioLibro.ToDato(audioLibro));
		}

		/// <summary>
		/// Busca un AudioLibro por su ISBN.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> El ISBN no es nulo. <br/>
		/// <b>POST:</b> Devuelve el objeto encontrado o null si no existe.
		/// </remarks>
		/// <param name="isbn">ISBN a buscar.</param>
		/// <returns>Objeto AudioLibro o null.</returns>
		public static AudioLibro ObtenerAudioLibro(string isbn)
		{
			if (BD.TablaAudioLibro.Contains(isbn))
			{
				return TransformerAudioLibro.ToObject(BD.TablaAudioLibro[isbn]);
			}
			return null;
		}

		/// <summary>
		/// Verifica si existe un AudioLibro con el ISBN dado.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> El ISBN no es nulo. <br/>
		/// <b>POST:</b> Devuelve true si existe, false en caso contrario.
		/// </remarks>
		/// <param name="isbn">ISBN a comprobar.</param>
		/// <returns>True si existe, False si no.</returns>
		public static bool ExisteAudioLibro(string isbn)
		{
			return BD.TablaAudioLibro.Contains(isbn);
		}

		/// <summary>
		/// Obtiene una lista con todos los AudioLibros registrados.
		/// </summary>
		/// <remarks>
		/// <b>PRE:</b> Ninguna. <br/>
		/// <b>POST:</b> Devuelve una lista con todos los elementos (puede estar vacía).
		/// </remarks>
		/// <returns>Lista de objetos AudioLibro.</returns>
		public static List<AudioLibro> ObtenerTodosAudioLibros()
		{
			List<AudioLibro> lista = new List<AudioLibro>();
			foreach (var dato in BD.TablaAudioLibro.obtenerTodos())
			{
				lista.Add(TransformerAudioLibro.ToObject(dato));
			}
			return lista;
		}
	}
}