using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek {
    public abstract class Personale {
        int Id;
        DateTime AnsatDato;
        Person person;

        public Personale(int id, DateTime ansatDato, Person personalePerson) {
            Id = id;
            AnsatDato = ansatDato;
            person = personalePerson;
        }

        public override string ToString() {
            return $"{person.ToString()}\nId: {Id}\nAnsættelsesdato: {AnsatDato.ToShortDateString()}";
        }
    }
}
