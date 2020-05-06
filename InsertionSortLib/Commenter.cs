using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortLib {
    public static class Commenter {
        public static string Comment(State state) {
            if(state.CurrentRoutine == 0)
                return CommentForEach(state);
            else if(state.CurrentRoutine == 1)
                return CommentSwap(state);
            else if(state.CurrentRoutine == 2)
                return CommentInsert(state);
            else
                return CommentFinish();
        }

        private static string CommentForEach(State state) {
            return $"Сортируем элемент с индексом {state.CurrentSorting}. Сохраняем его.";
        }

        private static string CommentSwap(State state) {
            return $"Копируем элемент с индексом {state.CurrentElement} в ячейку справа.";
        }

        private static string CommentInsert(State state) {
            return $"Вставляем сохраненное значение в нулевую ячейку.";
        }

        private static string CommentFinish() {
            return "Сортировка окончена.";
        }
    }
}
