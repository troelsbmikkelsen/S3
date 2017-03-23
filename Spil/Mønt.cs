using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil {
    public class Mønt : SpilleDims {
        public enum Side{
            Plat = 1,
            Krone = 2
        }

        public Mønt() : base(2) {

        }
    }
}
