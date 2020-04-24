using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortLib {
    class InsertRoutine: Routine {
        public override bool Forward(ref State state) {
            state.SetArrayValue(state.CurrentElement, state.Temp);
            return false;
        }

        public override bool Backward(ref State state) {
            state.SetTemp(state.Array[state.CurrentElement]);
            state.SetArrayValue(state.CurrentElement, state.Array[state.CurrentElement+1]);
            return false;
        }
    }
}
