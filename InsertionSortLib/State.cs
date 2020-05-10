namespace InsertionSortLib {
    public class State {
        public int[] Array { get; set; }
        public int CurrentRoutine { get; set; }
        public int CurrentElement { get; set; }
        public int CurrentSorting { get; set; }
        public int SortedLength { get; set; }
        public int Temp { get; set; }

        /// <summary>
        /// Constructor for serialization
        /// </summary>
        public State() {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Array">array to set</param>
        /// <param name="CurrentRoutine">current routine to set</param>
        /// <param name="CurrentElement">current element to set</param>
        /// <param name="CurrentSorting">current sorting to set</param>
        /// <param name="SortedLength">sorted length to set</param>
        /// <param name="Temp">temp to set</param>
        public State(int[] Array, int CurrentRoutine, int CurrentElement, 
                                        int CurrentSorting, int SortedLength, int Temp) {
            this.Array = Array;
            this.CurrentRoutine = CurrentRoutine;
            this.CurrentElement = CurrentElement;
            this.CurrentSorting = CurrentSorting;
            this.SortedLength = SortedLength;
            this.Temp = Temp;
        }

        /// <summary>
        /// Set current sorting
        /// </summary>
        /// <param name="newCurrentSorting">new current sorting</param>
        public void SetCurrentSorting(int newCurrentSorting) {
            if(newCurrentSorting < 0)
                CurrentSorting = 0;
            else
                CurrentSorting = newCurrentSorting;
        }

        /// <summary>
        /// Set current routine
        /// </summary>
        /// <param name="newCurrentRoutine">new current routine</param>
        public void SetCurrentRoutine(int newCurrentRoutine) {
            CurrentRoutine = newCurrentRoutine;
        }

        /// <summary>
        /// Set current element
        /// </summary>
        /// <param name="newCurrentElement">new current element</param>
        public void SetCurrentElement(int newCurrentElement) {
            if(newCurrentElement < 0)
                CurrentElement = 0;
            else
                CurrentElement = newCurrentElement;
        }

        /// <summary>
        /// Set temp
        /// </summary>
        /// <param name="newTemp">new temp</param>
        public void SetTemp(int newTemp) {
            Temp = newTemp;
        }

        /// <summary>
        /// Set sorted length
        /// </summary>
        /// <param name="newSortedLenght">new sorted length</param>
        public void SetSortedLenght(int newSortedLenght) {
            if(newSortedLenght < 0)
                SortedLength = 0;
            else
                SortedLength = newSortedLenght;
        }

        /// <summary>
        /// Set array value
        /// </summary>
        /// <param name="id">index</param>
        /// <param name="value">value</param>
        public void SetArrayValue(int id, int value) {
            Array[id] = value;
        }

        /// <summary>
        /// String form
        /// </summary>
        /// <returns>string form of this state</returns>
        public override string ToString() {
            return Commenter.Comment(this);
        }

    }
}
