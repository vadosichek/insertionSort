using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsertionSortLib;

namespace ConsoleDevTool {
    class Program {
        static void Main(string[] args) {
            int[] ar = new int[10] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            SortMachine sm = new SortMachine();
            sm.GeneratePreset(ar);
            Console.WriteLine("preset loaded");
            while(sm.GetSortedLength() < sm.GetState().Array.Length - 1) {
                Console.WriteLine(sm);
                sm.Do();
            }
            Console.WriteLine(sm);
        }
    }
}
