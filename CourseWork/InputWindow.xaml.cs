using InsertionSortLib;
using System.Collections.Generic;
using System.Windows;

namespace CourseWork {

    public partial class InputWindow: Window {
        private SortMachine _sortMachine;
        private MainWindow _mainWindow;

        /// <summary>
        /// Constructor
        /// </summary>
        public InputWindow() {
            InitializeComponent();
            ErrorText.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Sets the sort machine instance
        /// </summary>
        /// <param name="sortMachine">sort machine to set</param>
        public void SetSortMachine(SortMachine sortMachine) {
            _sortMachine = sortMachine;
        }

        /// <summary>
        /// Sets the main window instance
        /// </summary>
        /// <param name="mainWindow">main window to set</param>
        public void SetMainWindow(MainWindow mainWindow) {
            _mainWindow = mainWindow;
        }

        /// <summary>
        /// Proceed button click function
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void Proceed_Click(object sender, RoutedEventArgs e) {
            string input = InputText.Text;
            input = input.Replace(" ","");
            string[] data = input.Split(',');
            List<int> array = new List<int>();
            foreach(string text in data) {
                int temp;
                if(!int.TryParse(text, out temp)) {
                    ErrorText.Visibility = Visibility.Visible;
                    return;
                }
                array.Add(temp);
            }
            _sortMachine.GeneratePreset(array.ToArray());
            _mainWindow.CreateArrayVisual();
            this.Close();
        }
    }
}
