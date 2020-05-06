using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortLib {
    public class State {
        public int[] Array { get; set; }
        public int CurrentRoutine { get; set; }
        public int CurrentElement { get; set; }
        public int CurrentSorting { get; set; }
        public int SortedLength { get; set; }
        public int Temp { get; set; }

        public State() {

        }

        public State(int[] Array, int CurrentRoutine, int CurrentElement, 
                                        int CurrentSorting, int SortedLength, int Temp) {
            this.Array = Array;
            this.CurrentRoutine = CurrentRoutine;
            this.CurrentElement = CurrentElement;
            this.CurrentSorting = CurrentSorting;
            this.SortedLength = SortedLength;
            this.Temp = Temp;
        }

        public void SetCurrentSorting(int newCurrentSorting) {
            if(newCurrentSorting < 0)
                CurrentSorting = 0;
            else
                CurrentSorting = newCurrentSorting;
        }

        public void SetCurrentRoutine(int newCurrentRoutine) {
            CurrentRoutine = newCurrentRoutine;
        }

        public void SetCurrentElement(int newCurrentElement) {
            if(newCurrentElement < 0)
                CurrentElement = 0;
            else
                CurrentElement = newCurrentElement;
        }

        public void SetTemp(int newTemp) {
            Temp = newTemp;
        }

        public void SetSortedLenght(int newSortedLenght) {
            if(newSortedLenght < 0)
                SortedLength = 0;
            else
                SortedLength = newSortedLenght;
        }

        public void SetArrayValue(int id, int value) {
            Array[id] = value;
        }

        public override string ToString() {
            return Commenter.Comment(this);
        }

    }
}
