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
            SortMachine sm = new SortMachine(ar);

            while(!sm.IsSorted()){
                if(true) Console.WriteLine(sm);
                if(!sm.IsSorted())sm.Do();
            }

            Console.WriteLine(sm);
            Console.WriteLine();

            while(!sm.IsUnsorted()) {
                if(true)
                    Console.WriteLine(sm);
                if(!sm.IsUnsorted())
                    sm.Undo();
            }

            Console.WriteLine(sm);
            Console.WriteLine();


        }
    }
}
