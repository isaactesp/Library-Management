using Persistencia.BBDD;
using System;
using System.Collections.Generic;

namespace Persistencia
{
    /// <summary>
    /// Base de Datos simulada en Memoria (Singleton/Estática).
    /// Contiene las tablas donde se almacenan todas las entidades del sistema.
    /// </summary>
    internal class BD
    {
        // Tablas estáticas (almacenamiento real)
        private static Tabla<string, PersonalAdquisicionDato> tablaPAdquisiciones;
        private static Tabla<string, PersonalSalaDato> tablaPSala;
        private static Tabla<string, UsuarioDato> tablaUsuario;
        private static Tabla<string, AudioLibroDato> tablaAudioLibro;
        private static Tabla<string, LibroDato> tablaLibro;
        private static Tabla<string, EjemplarDato> tablaEjemplar;
        private static Tabla<string, PrestamoDato> tablaPrestamo;

        // Tabla con Clave Compuesta para la relación N:M
        private static Tabla<ClaveCompuesta<string, string>, EjemplarPrestamoDato> tablaEjemplarPrestamo;

        // Constructor privado para evitar instancias
        private BD() { }

        // =================================================================
        // PROPIEDADES DE ACCESO LAZY (Se crean solo cuando se piden)
        // =================================================================

        public static Tabla<string, PersonalAdquisicionDato> TablaPAdquisiciones
        {
            get
            {
                if (tablaPAdquisiciones == null) tablaPAdquisiciones = new Tabla<string, PersonalAdquisicionDato>();
                return tablaPAdquisiciones;
            }
        }

        public static Tabla<string, PersonalSalaDato> TablaPSala
        {
            get
            {
                if (tablaPSala == null) tablaPSala = new Tabla<string, PersonalSalaDato>();
                return tablaPSala;
            }
        }

        public static Tabla<string, UsuarioDato> TablaUsuario
        {
            get
            {
                if (tablaUsuario == null) tablaUsuario = new Tabla<string, UsuarioDato>();
                return tablaUsuario;
            }
        }

        public static Tabla<string, AudioLibroDato> TablaAudioLibro
        {
            get
            {
                if (tablaAudioLibro == null) tablaAudioLibro = new Tabla<string, AudioLibroDato>();
                return tablaAudioLibro;
            }
        }

        public static Tabla<string, LibroDato> TablaLibro
        {
            get
            {
                if (tablaLibro == null) tablaLibro = new Tabla<string, LibroDato>();
                return tablaLibro;
            }
        }

        public static Tabla<string, EjemplarDato> TablaEjemplar
        {
            get
            {
                if (tablaEjemplar == null) tablaEjemplar = new Tabla<string, EjemplarDato>();
                return tablaEjemplar;
            }
        }

        public static Tabla<string, PrestamoDato> TablaPrestamo
        {
            get
            {
                if (tablaPrestamo == null) tablaPrestamo = new Tabla<string, PrestamoDato>();
                return tablaPrestamo;
            }
        }

        /// <summary>
        /// Tabla intermedia para la relación Préstamo-Ejemplar.
        /// Clave Compuesta: (IdPrestamo, CodigoEjemplar).
        /// </summary>
        public static Tabla<ClaveCompuesta<string, string>, EjemplarPrestamoDato> TablaEjemplarPrestamo
        {
            get
            {
                if (tablaEjemplarPrestamo == null)
                    tablaEjemplarPrestamo = new Tabla<ClaveCompuesta<string, string>, EjemplarPrestamoDato>();
                return tablaEjemplarPrestamo;
            }
        }
    }
}