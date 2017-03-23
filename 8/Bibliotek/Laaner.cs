using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek {
    public class Laaner {
        bool EmailNyhedsbrev;
        string Interesser;
        string ReturProfil;
        DateTime LaanerKortDato;
        Person person;

        public Laaner(bool emailNyhedsbrev, string interesser, string returProfil, DateTime laanerKortDato, Person laanerPerson) {
            EmailNyhedsbrev = emailNyhedsbrev;
            Interesser = interesser;
            ReturProfil = returProfil;
            LaanerKortDato = laanerKortDato;
            person = laanerPerson;
        }

        public override string ToString() {
            return $"{person.ToString()}\nNyhedsbrev: {EmailNyhedsbrev}\nInteresser: {Interesser}\nRetur profil: {ReturProfil}\nLånerkort dato: {LaanerKortDato.ToShortDateString()}";
        }
    }
}
