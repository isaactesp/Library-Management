using LogicaNegocio.Interfaces;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    /// <summary>
    /// Formulario principal para el Personal de Sala.
    /// <para>
    /// <b>RESPONSABILIDAD:</b> Extender el menú principal (heredado de <see cref="FPal"/>)
    /// con las funcionalidades específicas del personal de sala, como la gestión de préstamos
    /// y la consulta de préstamos por usuario.
    /// </para>
    /// </summary>
    public partial class FPalSala : FPal
    {
        private IPersonalSalaLN pSalaLN
        {
            get { return (IPersonalSalaLN)base.PersonalLN; }
        }

        private PersonalSala personalSala
        {             
            get { return (PersonalSala)base.Empleado; }
        }

        public FPalSala(IPersonalSalaLN pSalaLN,PersonalSala  personalSala, string nombreEmpleado):base(pSalaLN, nombreEmpleado, personalSala)
        {
            CrearMenuPSala();

        }

        private void CrearMenuPSala()
        {

            var menuPrestamos = new ToolStripMenuItem("Préstamos");

            var itemAlta = new ToolStripMenuItem("Alta");
            itemAlta.Click += new EventHandler(itemAlta_Click);

            var itemDevolver = new ToolStripMenuItem("Devolver Ejemplar");
            itemDevolver.Click += new EventHandler(itemDevolver_Click);

            var itemListado = new ToolStripMenuItem("Listado de Préstamos");
            itemListado.Click += new EventHandler(itemListado_Click);

            var itemBuscar = new ToolStripMenuItem("Buscar Préstamo");
            itemBuscar.Click += new EventHandler(itemBuscar_Click);

            menuPrestamos.DropDownItems.Add(itemAlta);
            menuPrestamos.DropDownItems.Add(itemDevolver);
            menuPrestamos.DropDownItems.Add(new ToolStripSeparator());
            menuPrestamos.DropDownItems.Add(itemListado);
            menuPrestamos.DropDownItems.Add(itemBuscar);
            menuPrincipal.Items.Add(menuPrestamos);

            // Añadir al menú de Usuarios (heredado de FPal)
            if (base.menuUsuarios != null)
            {
                base.menuUsuarios.DropDownItems.Add(new ToolStripSeparator());
                var itemConsultaUsuario = new ToolStripMenuItem("Consultar Préstamos de Usuario");
                itemConsultaUsuario.Click += new EventHandler(itemConsultaUsuario_Click);
                base.menuUsuarios.DropDownItems.Add(itemConsultaUsuario);
            }
        }

        private void itemConsultaUsuario_Click(Object sender, EventArgs e)
        {
            Form consulta = new FConsultaUsuarioPrestamos(pSalaLN);
            consulta.ShowDialog();
        }

        public void itemBuscar_Click(Object sender, EventArgs e)
        {
            Form buscar = new FBusquedaPrestamo(pSalaLN);
            buscar.ShowDialog();
        }

        private void itemAlta_Click(Object sender, EventArgs e)
        {
            // Pasamos ambas interfaces separadas (ISP)
            // pSalaLN: para operaciones de préstamos
            // personalLN: para operaciones de usuarios (heredado de FPal)
            Form alta = new FAltaPrestamo(pSalaLN);
            alta.ShowDialog();
        }

        private void itemDevolver_Click(Object sender, EventArgs e)
        {
            Form devolver = new FDevolverEjemplar(pSalaLN);
            devolver.ShowDialog();
        }

        private void itemListado_Click(Object sender, EventArgs e)
        {
            Form listado = new FListadoPrestamos(pSalaLN);
            listado.ShowDialog();
        }






    }
}
