using System;
using System.IO;
using Newtonsoft.Json;

namespace InsertionSortLib {
    public class SortMachine {
        private Preset preset;
        private int currentState;
        public bool Loaded { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SortMachine() {
            currentState = 0;
            Loaded = false;
        }

        /// <summary>
        /// Use given preset
        /// </summary>
        /// <param name="preset">preset to use</param>
        public void LoadPreset(Preset preset) {
            currentState = 0;
            if(preset.States.Count > 0) {
                foreach(State state in preset.States) {
                    if(state.Array == null)
                        return;
                }
                this.preset = preset;
                Loaded = true;
            }
        }

        /// <summary>
        /// Generate preset from array
        /// </summary>
        /// <param name="array">array to generate from</param>
        public void GeneratePreset(int[] array) {
            currentState = 0;
            if(array.Length > 0) {
                preset = Sorter.GeneratePreset(array);
                Loaded = true;
            }
        }

        /// <summary>
        /// Load preset from file
        /// </summary>
        /// <param name="path">path to read from</param>
        /// <returns>error string</returns>
        public string LoadPresetFromFile(string path) {
            try {
                using(StreamReader sw = new StreamReader(path)) {
                    string input = sw.ReadToEnd();
                    LoadPreset((Preset) JsonConvert.DeserializeObject(input, typeof(Preset)));
                }
                return null;
            }
            catch(Exception e) {
                Loaded = false;
                return e.Message;
            }
        }

        /// <summary>
        /// Save preset to file
        /// </summary>
        /// <param name="path">path to save to</param>
        /// <returns>error string</returns>
        public string SavePresetToFile(string path) {
            try {
                using(StreamWriter sw = new StreamWriter(path)) {
                    string output = JsonConvert.SerializeObject(preset);
                    sw.Write(output);
                }
                return null;
            }
            catch(Exception e) {
                Loaded = false;
                return e.Message;
            }
        }

        /// <summary>
        /// Make step forward
        /// </summary>
        public void Do() {
            if(currentState < preset.GetStatesCount() - 1) {
                currentState++;
            }
        }

        /// <summary>
        /// Make step backward
        /// </summary>
        public void Undo() {
            if(currentState > 0) {
                currentState--;
            }
        }

        /// <summary>
        /// Get current state
        /// </summary>
        /// <returns>current state</returns>
        public State GetState()
            => preset.GetState(currentState);

        /// <summary>
        /// Get current state array
        /// </summary>
        /// <returns>current state array</returns>
        public int[] GetArray()
            => preset.GetState(currentState).Array;

        /// <summary>
        /// Get current state temp
        /// </summary>
        /// <returns>current state temp</returns>
        public int GetTemp()
            => preset.GetState(currentState).Temp;

        /// <summary>
        /// Get current state current element
        /// </summary>
        /// <returns>current state current element</returns>
        public int GetCurrentElement()
            => preset.GetState(currentState).CurrentElement;

        /// <summary>
        /// Get current state current sorting
        /// </summary>
        /// <returns>current state current sorting</returns>
        public int GetCurrentSorting()
            => preset.GetState(currentState).CurrentSorting;

        /// <summary>
        /// Get current state current routine
        /// </summary>
        /// <returns>current state current routine</returns>
        public int GetCurrentRoutine()
            => preset.GetState(currentState).CurrentRoutine;

        /// <summary>
        /// Get current state sorted length
        /// </summary>
        /// <returns>current state sorted length</returns>
        public int GetSortedLength()
            => preset.GetState(currentState).SortedLength;

        /// <summary>
        /// Get current state string form
        /// </summary>
        /// <returns>current state string form</returns>
        public override string ToString()
            => preset.GetState(currentState).ToString();
    }
}
