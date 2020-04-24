using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortLib {
    class SavePointerRoutine: Routine {
        public override bool Forward(ref State state) {
            state.SetTemp(state.Array[state.CurrentSorting]);
            state.SetCurrentElement(state.CurrentSorting);
            return false;
        }

        public override bool Backward(ref State state) {
            state.SetCurrentElement(0);
            return false;
        }
    }
}
