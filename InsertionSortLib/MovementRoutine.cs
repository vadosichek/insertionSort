using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortLib {
    class MovementRoutine: Routine {
        public override bool Forward(ref State state) {
            if(state.CurrentElement > 0 && state.Array[state.CurrentElement-1] > state.Temp) {
                state.SetArrayValue(state.CurrentElement, state.Array[state.CurrentElement-1]);
                state.SetCurrentElement(state.CurrentElement - 1);
                
            }
            if(state.CurrentElement > 0 && state.Array[state.CurrentElement - 1] > state.Temp)
                return true;
            return false;
        }

        public override bool Backward(ref State state) {
            if(state.CurrentElement < state.CurrentSorting) {
                
                state.SetArrayValue(state.CurrentElement, state.Array[state.CurrentElement + 1]);
                state.SetCurrentElement(state.CurrentElement + 1);
            }
            if(state.CurrentElement < state.CurrentSorting) {
                return true;
            }
            else {
                state.SetArrayValue(state.CurrentElement, state.Temp);
                return false;
            }
            
        }
    }
}
