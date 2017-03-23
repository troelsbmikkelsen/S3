using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil {
    public abstract class SpilleDims {
        private static Random random = new Random(DateTime.Now.Millisecond);

        private int værdi;
        private int laveste = 1;
        private int antalMuligeVærdier;
        public int forskydning = 0;

        public SpilleDims(int muligeVærdier) {
            antalMuligeVærdier = muligeVærdier;
        }

        public SpilleDims(int muligeVærdier, int forskydning) {
            antalMuligeVærdier = muligeVærdier;
            this.forskydning = forskydning;
        }

        public void kast() {
            setVærdi(random.Next(1+forskydning, antalMuligeVærdier+forskydning));
        }

        public int getVærdi() {
            return værdi;
        }

        public void setVærdi(int i) {
            værdi = i;
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
