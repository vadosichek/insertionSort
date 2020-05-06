using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortLib {
    public class Preset {
        public List<State> States { get; set; }

        public Preset() {
            States = new List<State>();
        }

        public Preset(List<State> states) {
            States = states;
        }

        public void AddState(State state) {
            States.Add(state);
        }

        public void RemoveState(State state) {
            States.Remove(state);
        }

        public void RemoveState(int id) {
            States.RemoveAt(id);
        }

        public State GetState(int id) => States[id];

        public int GetStatesCount() => States.Count();
    }
}
