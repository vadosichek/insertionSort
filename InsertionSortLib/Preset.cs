using System.Collections.Generic;
using System.Linq;

namespace InsertionSortLib {
    public class Preset {
        public List<State> States { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Preset() {
            States = new List<State>();
        }

        /// <summary>
        /// Constructor from list of states
        /// </summary>
        /// <param name="states">states to use</param>
        public Preset(List<State> states) {
            States = states;
        }

        /// <summary>
        /// Add new state to the list
        /// </summary>
        /// <param name="state">state to add</param>
        public void AddState(State state) {
            States.Add(state);
        }

        /// <summary>
        /// Remove state from list
        /// </summary>
        /// <param name="state">state to remove</param>
        public void RemoveState(State state) {
            States.Remove(state);
        }

        /// <summary>
        /// Remove state with given id
        /// </summary>
        /// <param name="id">state id to remove</param>
        public void RemoveState(int id) {
            States.RemoveAt(id);
        }

        /// <summary>
        /// Get state with given index
        /// </summary>
        /// <param name="id">state's index</param>
        /// <returns></returns>
        public State GetState(int id) => States[id];

        /// <summary>
        /// Get states count
        /// </summary>
        /// <returns>number of states</returns>
        public int GetStatesCount() => States.Count();
    }
}
