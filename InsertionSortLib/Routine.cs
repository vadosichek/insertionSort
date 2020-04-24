using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortLib {
    public abstract class Routine {
        public abstract bool Forward(ref State state);
        public abstract bool Backward(ref State state);
    }
}
