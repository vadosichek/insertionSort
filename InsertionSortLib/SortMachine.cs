using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortLib {
    public class SortMachine {
        private State _state;
        public Routine[] RoutineList { get; private set; } = {
            new ForEachRoutine(), //routine 0
            new SavePointerRoutine(), //routine 1
            new MovementRoutine(), //routine 2
            new InsertRoutine() //routine 3
        };

        public SortMachine(int[] arrayToSort) {
            _state = new State(arrayToSort, 0, 0, 0, 0);
        }

        public void Do() {
            if(!IsSorted()) {
                if(!RoutineList[_state.CurrentRoutine].Forward(ref _state)) {
                    IncrementCurrentRoutine();
                }
            }
        }
        public void Undo() {
            if(GetCurrentSorting() > 0) {
                if(!RoutineList[_state.CurrentRoutine].Backward(ref _state)) {
                    DecrementCurrentRoutine();
                }
            }
        }

        private void IncrementCurrentRoutine() {
            _state.SetCurrentRoutine((_state.CurrentRoutine + 1) % 4);
        }
        private void DecrementCurrentRoutine() {
            _state.SetCurrentRoutine(_state.CurrentRoutine - 1 < 0 ? 3 : _state.CurrentRoutine - 1);
        }

        public State GetState() => _state;

        public bool IsSorted() => _state.Array.Length == _state.SortedLength;
        public bool IsUnsorted() => _state.SortedLength == 0;

        public int[] GetArray() => _state.Array;

        public int GetTemp() => _state.Temp;

        public int GetCurrentElement() => _state.CurrentElement;

        public int GetCurrentSorting() => _state.CurrentSorting;

        public int GetSortedLength() => _state.SortedLength;

        public override string ToString() {
            return _state.ToString();
        }
    }
}
