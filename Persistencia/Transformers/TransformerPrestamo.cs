using ModeloDominio;
using Persistencia.BBDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Transformers
{
    internal class TransformerPrestamo
    {
        internal static PrestamoDato ToDato(Prestamo prestamo, PersonalSala pSala, Usuario us)
        {
            return new PrestamoDato(
                prestamo.IdPrestamo,
                pSala.NSS,
                prestamo.FechaPrestado,
                prestamo.Estado,
                us.DNI
                );
        }

        internal static Prestamo ToObject(PrestamoDato pDato)
        {
            return new Prestamo(
                pDato.IdPrestamo,
                pDato.Estado,
                pDato.FechaPrestamo
                );
        }
    }
}
