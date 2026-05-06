using System.Collections.Generic;
using ModeloDominio;
using Persistencia;
using Persistencia.Interfaces;
using LogicaNegocio.Interfaces; // Necesario para ver IPersonalLN

namespace LogicaNegocio
{
    /// <summary>
    /// Clase base abstracta para la lógica de negocio del personal.
    /// </summary>
    public abstract class PersonalLN : IPersonalLN
    {
        // 'protected' para que las clases hijas puedan acceder si fuera necesario.
        protected IPersistenciaUsuario persistenciaUsuario;

        protected PersonalLN(IPersistenciaUsuario persistenciaUsuario)
        {
            this.persistenciaUsuario = persistenciaUsuario;
        }

        public bool RegistrarUsuario(string dni, string nombre)
        {
            if (persistenciaUsuario.ExisteUsuario(dni)) return false;

            Usuario nuevoUsuario = new Usuario(dni, nombre);
            persistenciaUsuario.AltaUsuario(nuevoUsuario);

            return persistenciaUsuario.ExisteUsuario(dni);
        }

        // CORREGIDO: Renombrado de 'DarBajaUsuario' a 'BajaUsuario' para cumplir la interfaz
        public bool BajaUsuario(string dni)
        {
            Usuario usuario = persistenciaUsuario.ObtenerUsuario(dni);

            if (usuario != null)
            {
                persistenciaUsuario.BajaUsuario(usuario);
                return !persistenciaUsuario.ExisteUsuario(dni);
            }
            return false;
        }

        public void ModificarUsuario(Usuario usuario)
        {
            if (usuario != null && persistenciaUsuario.ExisteUsuario(usuario.DNI))
            {
                persistenciaUsuario.ModificarUsuario(usuario);
            }
        }

        public Usuario BuscarUsuario(string dni)
        {
            return persistenciaUsuario.ObtenerUsuario(dni);
        }

        public List<Usuario> ListarUsuarios()
        {
            return persistenciaUsuario.ObtenerTodosUsuarios();
        }

        public bool ExisteUsuario(string dni)
        {
            return persistenciaUsuario.ExisteUsuario(dni);
        }

        public virtual void RegistrarPersonal(Personal personal)
        {
            // Implementación vacía en la clase base.
            // Las clases derivadas pueden sobrescribir este método si es necesario.
        }
    }
}