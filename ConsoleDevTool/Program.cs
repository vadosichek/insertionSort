using System;
using InsertionSortLib;

namespace ConsoleDevTool {
    class Program {
        /// <summary>
        /// main function
        /// </summary>
        /// <param name="args">args</param>
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
