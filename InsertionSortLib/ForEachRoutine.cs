using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortLib {
    public class ForEachRoutine: Routine {

        public override bool Forward(ref State state) {
            state.SetCurrentSorting(state.CurrentSorting + 1);
            state.SetSortedLenght(state.SortedLength + 1);
            return false;
        }

        public override bool Backward(ref State state) {
            state.SetCurrentSorting(state.CurrentSorting - 1);
            state.SetSortedLenght(state.SortedLength - 1);
            if(state.CurrentSorting == 0)
                return true;
            return false;
        }
    }
}
