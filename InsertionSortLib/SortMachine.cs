using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InsertionSortLib {
    public class SortMachine {
        private Preset preset;
        private int currentState;

        public SortMachine() {
            currentState = 0;
        }

        public void LoadPreset(Preset preset) {
            currentState = 0;
            this.preset = preset;
        }

        public void GeneratePreset(int[] array) {
            currentState = 0;
            preset = Sorter.GeneratePreset(array);
        }

        public string LoadPresetFromFile(string path) {
            try {
                using(StreamReader sw = new StreamReader(path)) {
                    string input = sw.ReadToEnd();
                    LoadPreset((Preset) JsonConvert.DeserializeObject(input, typeof(Preset)));
                }
                return null;
            }
            catch(Exception e) {
                return e.Message;
            }
        }

        public string SavePresetToFile(string path) {
            try {
                using(StreamWriter sw = new StreamWriter(path)) {
                    string output = JsonConvert.SerializeObject(preset);
                    sw.Write(output);
                }
                return null;
            }
            catch(Exception e) {
                return e.Message;
            }
        }

        public void Do() {
            if(currentState < preset.GetStatesCount() - 1) {
                currentState++;
            }
        }
        public void Undo() {
            if(currentState > 0) {
                currentState--;
            }
        }

        public State GetState()
            => preset.GetState(currentState);

        public int[] GetArray()
            => preset.GetState(currentState).Array;

        public int GetTemp()
            => preset.GetState(currentState).Temp;

        public int GetCurrentElement()
            => preset.GetState(currentState).CurrentElement;

        public int GetCurrentSorting()
            => preset.GetState(currentState).CurrentSorting;

        public int GetCurrentRoutine()
            => preset.GetState(currentState).CurrentRoutine;

        public int GetSortedLength()
            => preset.GetState(currentState).SortedLength;

        public override string ToString()
            => preset.GetState(currentState).ToString();
    }
}
