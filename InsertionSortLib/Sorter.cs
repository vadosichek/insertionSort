using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortLib {
    public class Sorter {
        public static Preset GeneratePreset(int[] array) {
            Preset preset = new Preset();
            Sort(array, ref preset);

            return preset;
        }

        private static void Sort(int[] array, ref Preset preset) {
            int temp;
            int pointer;
            for(int i = 1; i < array.Length; ++i) {
                temp = array[i];
                preset.AddState(new State((int[]) array.Clone(),
                    0, i, i, i - 1, temp));

                MovePointer(array, i, temp, out pointer, ref preset);
                Insert(array, i, pointer, temp, ref preset);
            }
            preset.AddState(new State((int[]) array.Clone(),
                3, array.Length-1, array.Length - 1, array.Length - 1, 0));
        }

        private static void MovePointer(int[] array, int i, int temp,
            out int pointer, ref Preset preset) {
            for(pointer = i - 1;
                    pointer >= 0 && array[pointer] > temp;
                    pointer--) {
                array[pointer + 1] = array[pointer];
                preset.AddState(new State((int[]) array.Clone(), 
                    1, pointer, i, i - 1, temp));
            }
        }

        private static void Insert(int[] array, int i, int pointer, int temp, ref Preset preset) {
            array[pointer + 1] = temp;
            preset.AddState(new State((int[]) array.Clone(), 
                2, pointer, i, i, temp));
        }
    }
}
