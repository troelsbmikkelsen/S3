using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil {
    public class FemFingret {
        public List<SpilleDims> dims = new List<SpilleDims>();

        public void tilføjDims(SpilleDims dims) {
            this.dims.Add(dims);
        }

        public void spil() {
            foreach(SpilleDims sd in dims) {
                sd.kast();
            }
        }

        public int sum() {
            int s = 0;
            foreach(SpilleDims sd in dims) {
                s += sd.getVærdi();
            }
            return s;
        }

        public int antalXere(int x) {
            return new int();
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
