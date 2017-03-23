using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    public class Person
    {
        string CPRno;
        string Fornavn;
        string Efternavn;
        string Postnr;
        string Adresse;

        public Person(string CPRno, string Fornavn, string Efternavn, string Postnr, string Adresse) {
            this.CPRno = CPRno;
            this.Fornavn = Fornavn;
            this.Efternavn = Efternavn;
            this.Postnr = Postnr;
            this.Adresse = Adresse;
        }

        public override string ToString() {
            return $"{Fornavn} {Efternavn} -- {CPRno}\n{Postnr}, {Adresse}";
        }
    }
}
