using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek {
    public class Studentermedhjaelper : Personale {
        double Loen;

        public Studentermedhjaelper(int id, DateTime ansatDato, Person studentPersonale, double loen) : base(id, ansatDato, studentPersonale) {
            Loen = loen;
        }

        public override string ToString() {
            return $"{base.ToString()}\nLøn: {Loen}";
        }
    }
}
