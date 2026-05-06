using Persistencia.BBDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Transformers
{
    internal class TransformerPSala
    {
        public static PersonalSalaDato ToDato(ModeloDominio.PersonalSala ps)
        {
            return new PersonalSalaDato(ps.NSS);
        }

        public static ModeloDominio.PersonalSala ToObject(PersonalSalaDato psDato)
        {
            return new ModeloDominio.PersonalSala(psDato.Nss);
        }   

    }
}
