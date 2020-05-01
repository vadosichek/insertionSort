using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortLib {
    public class State {
        public int[] Array { get; private set; }
        public int CurrentRoutine { get; private set; }
        public int CurrentElement { get; private set; }
        public int CurrentSorting { get; private set; }
        public int SortedLength { get; private set; }
        public int Temp { get; private set; }


        public State(int[] Array, int CurrentRoutine, int CurrentElement, 
                                        int CurrentSorting, int SortedLength) {
            this.Array = Array;
            this.CurrentRoutine = CurrentRoutine;
            this.CurrentElement = CurrentElement;
            this.CurrentSorting = CurrentSorting;
            this.SortedLength = SortedLength;
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
            return $"{String.Join(" ", Array)} - sorting {CurrentSorting}, element {CurrentElement}, routine {CurrentRoutine}, temp {Temp}, sorted {SortedLength}";
        }

    }
}
