namespace InsertionSortLib {
    public static class Commenter {

        /// <summary>
        /// Comment given state
        /// </summary>
        /// <param name="state">state to comment</param>
        /// <returns>comment</returns>
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

        /// <summary>
        /// Comment for each routine state
        /// </summary>
        /// <param name="state">state to comment</param>
        /// <returns>comment</returns>
        private static string CommentForEach(State state) {
            return $"Сортируем элемент с индексом {state.CurrentSorting + 1}. Сохраняем его.";
        }

        /// <summary>
        /// Comment swap routine
        /// </summary>
        /// <param name="state">state to comment</param>
        /// <returns>comment</returns>
        private static string CommentSwap(State state) {
            return $"Копируем элемент с индексом {state.CurrentElement + 1} в ячейку справа.";
        }

        /// <summary>
        /// Comment insert routine
        /// </summary>
        /// <param name="state">state to comment</param>
        /// <returns>comment</returns>
        private static string CommentInsert(State state) {
            return $"Вставляем сохраненное значение в первую ячейку.";
        }

        /// <summary>
        /// Comment finish routine
        /// </summary>
        /// <returns>comment</returns>
        private static string CommentFinish() {
            return "Сортировка окончена.";
        }
    }
}
