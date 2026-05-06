using System;
using System.Collections.Generic;
using System.Linq;
using ModeloDominio;
using Persistencia;
using Persistencia.Interfaces;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio
{
    public class PersonalSalaLN : PersonalLN, IPersonalSalaLN
    {
        // Inyección de dependencias
        private readonly IPersistenciaPrestamo persistenciaPrestamo;
        private readonly IPersistenciaEjemplar perEjemplar;
        private readonly IPersistenciaPersonalSala perPersonalSala;
        private PersonalSala personalSala;

        public PersonalSalaLN(IPersistenciaUsuario perUsuario, IPersistenciaPrestamo perPrestamo, IPersistenciaEjemplar perEjemplar, IPersistenciaPersonalSala perPersonalSala) : base(perUsuario)
        {
            this.persistenciaPrestamo = perPrestamo;
            this.perEjemplar = perEjemplar;
            this.perPersonalSala = perPersonalSala;
        }


        public override void RegistrarPersonal(Personal personal)
        {
            this.perPersonalSala.AltaPersonalSala((PersonalSala)personal);
        }

        public PersonalSala PersonalActual 
        { 
            get { return this.personalSala; }
            set { this.personalSala = value; } 
        }



        public List<Ejemplar> ObtenerEjemplaresDisponibles()
        {            
            List<Ejemplar> todosEjemplares = perEjemplar.ObtenerTodosEjemplares();
            // Filtrar los que no están prestados y los que no estan de baja logica.
            return todosEjemplares.Where(e => !e.Prestado && !e.BajaLogica).ToList();
        }

        public bool IniciarPrestamo(Prestamo p, List<Ejemplar> ejemplares, Usuario u)
        {
            // Comprobar que los parámetros no son nulos
            if (p == null || ejemplares == null || u == null)
                return false;

            // Comprobar que hay al menos un ejemplar
            if (ejemplares.Count == 0)
                return false;

            // Comprobar que el usuario existe en el sistema
            if (!ExisteUsuario(u.DNI))
                return false;

            // Comprobar que ningún ejemplar está ya prestado
            if (ejemplares.Any(e => e.Prestado))
                return false;

            return persistenciaPrestamo.IniciarPrestamo(p, PersonalActual, u, ejemplares);
        }

        public void DevolverEjemplar(Prestamo p, Ejemplar e)
        {
            // Comprobar que los parámetros no son nulos
            if (p == null || e == null)
                return;

            // Comprobar que el préstamo existe
            if (!persistenciaPrestamo.ExistePrestamo(p))
                return;

            // Comprobar que el préstamo está en proceso
            if (!persistenciaPrestamo.EstaEnProceso(p))
                return;

            // Comprobar que el ejemplar está prestado
            if (!e.Prestado)
                return;

            // Comprobar que el ejemplar pertenece a este préstamo
            List<Ejemplar> ejemplaresDelPrestamo = persistenciaPrestamo.ObtenerEjemplaresPrestamo(p);
            if (!ejemplaresDelPrestamo.Any(ej => ej.Codigo == e.Codigo))
                return;

            persistenciaPrestamo.DevolverEjemplar(p, e);
        }

        public List<Prestamo> BuscarPrestamosDeDocumento(Documento d)
        {
            // Comprobar que el documento no es nulo
            if (d == null)
                return new List<Prestamo>();

            return persistenciaPrestamo.ObtenerPrestamosDeDocumento(d);
        }

        public bool ConsultarEstadoPrestamo(Prestamo p)
        {
            // Comprobar que el préstamo no es nulo
            if (p == null)
                return false;

            // Comprobar que el préstamo existe
            if (!persistenciaPrestamo.ExistePrestamo(p))
                return false;

            return persistenciaPrestamo.EstaEnProceso(p);
        }

        public List<Ejemplar> ConsultarEjemplaresPrestamo(Prestamo p)
        {
            // Comprobar que el préstamo no es nulo
            if (p == null)
                return new List<Ejemplar>();

            // Comprobar que el préstamo existe
            if (!persistenciaPrestamo.ExistePrestamo(p))
                return new List<Ejemplar>();

            return persistenciaPrestamo.ObtenerEjemplaresPrestamo(p);
        }

        public List<Documento> ConsultarDocumentosNoDevueltos(Prestamo p)
        {
            // Comprobar que el préstamo no es nulo
            if (p == null)
                return new List<Documento>();

            // Comprobar que el préstamo existe
            if (!persistenciaPrestamo.ExistePrestamo(p) || !persistenciaPrestamo.EstaEnProceso(p))
                return new List<Documento>();

            return persistenciaPrestamo.ObtenerEjemplaresPrestamo(p)
                .Where(e => e.Prestado == true)
                .Select(e => e.Documento)
                .Distinct()
                .ToList();
        }

        public List<Prestamo> ConsultarVencidos()
        {
            List<Prestamo> todos = persistenciaPrestamo.ObtenerTodosPrestamos();
            DateTime limite = DateTime.Now.AddDays(-15);

            return todos
                .Where(p => persistenciaPrestamo.EstaEnProceso(p) && p.FechaPrestado < limite)
                .ToList();
        }

        public Usuario ObtenerUsuarioDePrestamo(Prestamo p)
        {
            // Comprobar que el préstamo no es nulo
            if (p == null)
                return null;

            // Comprobar que el préstamo existe
            if (!persistenciaPrestamo.ExistePrestamo(p))
                return null;

            return persistenciaPrestamo.ObtenerUsuarioDePrestamo(p);
        }

        public Prestamo ObtenerPrestamoPorId(string idPrestamo)
        {
            // Comprobar que el idPrestamo no es nulo ni vacío
            if (string.IsNullOrWhiteSpace(idPrestamo) || !this.persistenciaPrestamo.ExistePrestamoID(idPrestamo))
                return null;

            return persistenciaPrestamo.ObtenerPrestamo(idPrestamo);
        }

        public List<Prestamo> ObtenerTodosPrestamos()
        {
            return persistenciaPrestamo.ObtenerTodosPrestamos();
        }

        public List<Prestamo> ObtenerPrestamosDeUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return new List<Prestamo>();
            }
            return persistenciaPrestamo.ObtenerPrestamosDeUsuario(usuario);
        }
    }
}
