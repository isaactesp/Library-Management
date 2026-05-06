using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModeloDominio;
using Persistencia.BBDD;


namespace Persistencia.CRUD
{
    static class PrestamoCRUD
    {

        // PRE: prestamo, pSala, u, ejemplares != null
        // POST: Añade un nuevo préstamo a la base de datos, registra los ejemplares prestados,
        // y actualiza el estado de cada ejemplar (prestado = true, vecesPrestado++)
        // CREATE
        public static void iniciarPrestamo(Prestamo prestamo, PersonalSala pSala, Usuario u, List<Ejemplar> ejemplares)
        {
            // Añadir el préstamo
            PrestamoDato prestamoDato = Transformers.TransformerPrestamo.ToDato(prestamo, pSala, u);
            BD.TablaPrestamo.Add(prestamoDato);

            // Añadir cada ejemplar prestado y actualizar su estado
            foreach (Ejemplar ej in ejemplares)
            {
                // Delegar en EjemplarPrestamoCRUD para crear el vínculo
                EjemplarPrestamoCRUD.AltaEjemplarPrestamo(prestamo, ej);

                // Actualizar el ejemplar
                EjemplarDato ejDato = BD.TablaEjemplar[ej.Codigo];
                ejDato.Prestado = true;
                ejDato.VecesPrestado++;
            }
        }

        public static bool existePrestamoID(string idPrestamo)
        {
            return BD.TablaPrestamo.Contains(idPrestamo);
        }

        public static bool existePrestamo(Prestamo p)
        {
            return BD.TablaPrestamo.Contains(p.IdPrestamo);
        }

        // PRE: p != null y existe
        // POST: Devuelve el préstamo correspondiente al idPrestamo
        // READ
        public static Prestamo obtenerPrestamo(string idPrestamo)
        {
            PrestamoDato prestamoDato = BD.TablaPrestamo[idPrestamo];
            Prestamo prestamo = Transformers.TransformerPrestamo.ToObject(prestamoDato);
            return prestamo;
        }

        //PRE: p y ej != null y existen, p está en curso (Estado = true), ej está prestado (Prestado = true)
        //POST: Marca el ejemplar como devuelto (Prestado = false),
        // y si era el último pendiente, marca el préstamo como acabado (Estado = false)
        //UPDATE
        public static void devolverEjemplar(Prestamo p, Ejemplar ej)
        {
            // Marcar el ejemplar como devuelto
            EjemplarDato ejDato = BD.TablaEjemplar[ej.Codigo];
            ejDato.Prestado = false;

            List<Ejemplar> ejemplaresDelPrestamo = EjemplarPrestamoCRUD.ListarEjemplaresDePrestamo(p);

            // Verificamos si alguno sigue prestado consultando EjemplarDato
            bool quedanPendientes = ejemplaresDelPrestamo
                .Any(e => BD.TablaEjemplar[e.Codigo].Prestado);

            if (!quedanPendientes)
            {
                BD.TablaPrestamo[p.IdPrestamo].Estado = false;
            }
        }

        // PRE: p != null y existe
        // POST: Elimina el préstamo y todos los registros de ejemplares prestados asociados.
        // REMOVE
        public static void eliminarPrestamo(Prestamo p)
        {
            // Obtener los ejemplares del préstamo delegando en EjemplarPrestamoCRUD
            List<Ejemplar> ejemplaresDelPrestamo = EjemplarPrestamoCRUD.ListarEjemplaresDePrestamo(p);

            // Eliminar los vínculos delegando en EjemplarPrestamoCRUD
            foreach (Ejemplar ej in ejemplaresDelPrestamo)
            {
                EjemplarPrestamoCRUD.BajaEjemplarPrestamo(p, ej);
            }

            // Eliminar el préstamo
            BD.TablaPrestamo.Remove(p.IdPrestamo);
        }

        //PRE: p != null y existe
        //POST: Devuelve la lista de ejemplares asociados al préstamo
        public static List<Ejemplar> obtenerEjemplaresPrestamo(Prestamo p)
        {
            // Se delega completamente la responsabilidad a la clase que gestiona la relación N:M
            return EjemplarPrestamoCRUD.ListarEjemplaresDePrestamo(p);
        }




        // POST: Devuelve una lista con todos los préstamos almacenados en la base de datos.
        public static List<Prestamo> obtenerTodosPrestamos()
        {
            List<Prestamo> listaPrestamos = new List<Prestamo>();
            foreach (PrestamoDato prestamoDato in BD.TablaPrestamo.obtenerTodos())
            {
                Prestamo prestamo = Transformers.TransformerPrestamo.ToObject(prestamoDato);
                listaPrestamos.Add(prestamo);
            }
            return listaPrestamos;
        }

        //PRE: u!=null que existe en el sistema
        //POST: devuelve todos los préstamos del usuario
        public static List<Prestamo> obtenerPrestamosDeUsuario(Usuario u)
        {
            List<PrestamoDato> todos = BD.TablaPrestamo.obtenerTodos();
            IEnumerable<PrestamoDato> filtrados = todos.Where(p => p.Dni.Equals(u.DNI));
            IEnumerable<Prestamo> lObjetos = filtrados.Select(p => Transformers.TransformerPrestamo.ToObject(p));
            return lObjetos.ToList();
        }

        //PRE: d!=null que existe en el sistema
        //POST: devuelve todos los préstamos en los que aparece un documento
        public static List<Prestamo> obtenerPrestamosDeDocumento(Documento d)
        {
            List<Ejemplar> ejemplaresDelDocumento = EjemplarCRUD.ObtenerEjemplaresDeDocumento(d); 
            
            List<Prestamo> todosLosPrestamos = new List<Prestamo>();
            foreach(var ejemplar in ejemplaresDelDocumento)
            {
                todosLosPrestamos.AddRange(EjemplarPrestamoCRUD.ListarPrestamosDeEjemplar(ejemplar));
            }

            return todosLosPrestamos.GroupBy(p => p.IdPrestamo)
                                     .Select(g => g.First()) 
                                     .ToList();
        }

        //PRE: p!=null y existe
        //POST: devuelve true si el préstamo está EN PROCESO y false en caso contrario
        public static bool estaEnProceso(Prestamo p)
        {
            return BD.TablaPrestamo[p.IdPrestamo].Estado;
        }

        //PRE: p!=null y existe
        //POST: Devuelve el usuario que realizó el préstamo
        public static Usuario obtenerUsuarioDePrestamo(Prestamo p)
        {
            string dni = BD.TablaPrestamo[p.IdPrestamo].Dni;
            return UsuarioCRUD.ObtenerUsuario(dni);
        }

        //PRE: p!=null y existe
        //POST: Devuelve la lista de documentos(sin duplicados) asociados al préstamo
        public static List<Documento> obtenerDocumentosDePrestamo(Prestamo p)
        {
            List<Ejemplar> ejemplaresDelPrestamo = EjemplarPrestamoCRUD.ListarEjemplaresDePrestamo(p);

            return ejemplaresDelPrestamo
                .Select(ejemplar => ejemplar.Documento)
                .Distinct()
                .ToList();
        }








    }
}
