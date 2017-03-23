using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek {
    public class Bibliotekar : Personale {
        string NoegleKompetencer;
        int LoenRamme;
        DateTime DimitteretAar;

        public Bibliotekar(int id, DateTime ansatDato, Person bibliotekarPerson, string noegleKompetencer, int loenRamme, DateTime dimitteretAar) : base(id, ansatDato, bibliotekarPerson) {
            NoegleKompetencer = noegleKompetencer;
            LoenRamme = loenRamme;
            DimitteretAar = dimitteretAar;
        }

        public override string ToString() {
            return $"{base.ToString()}\nNøglekompetencer: {NoegleKompetencer}\nLønramme: {LoenRamme}\nDimitteret år: {DimitteretAar}";
        }
    }
}
