using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using InsertionSortLib;
using Microsoft.Win32;

namespace CourseWork {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window {

        private SortMachine _sortMachine;
        private Button[] _arrayButtons;
        private Button _sortedArea;
        private TextBlock[] CodeParts;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow() {
            InitializeComponent();
            _sortMachine = new SortMachine();
            CodeParts = new TextBlock[3] { CodeTextBlock0,
                                            CodeTextBlock1,
                                            CodeTextBlock2};
        }

        /// <summary>
        /// Generates the visuals for current state of sort machine
        /// </summary>
        public void CreateArrayVisual() {
            if(_sortMachine.Loaded) {
                ClearVisual();
                _arrayButtons = new Button[_sortMachine.GetArray().Length];

                for(int i = 0; i < _sortMachine.GetArray().Length; i++) {
                    CreateColumns();
                    CreateButtons(i);
                }

                CreateSortedArea();
                PositionVisual();
                ColorArrayVisual();
                UpdateArrayText();
            }
            else {
                MessageText.Text = "Ошибка при загрузке данных";
            }
        }

        /// <summary>
        /// Clears the visuals
        /// </summary>
        private void ClearVisual() {
            ArrayGrid.Children.Clear();
            ArrayGrid.RowDefinitions.Add(new RowDefinition {
                Height = new GridLength(20)
            });
            ArrayGrid.RowDefinitions.Add(new RowDefinition {
                Height = new GridLength(20)
            });
            ArrayGrid.RowDefinitions.Add(new RowDefinition { 
                Height = new GridLength(8) 
            });
        }

        /// <summary>
        /// Adds column definition
        /// </summary>
        private void CreateColumns() {
            ColumnDefinition cd = new ColumnDefinition {
                MinWidth = 16,
                MaxWidth = 64
            };
            ArrayGrid.ColumnDefinitions.Add(cd);
        }

        /// <summary>
        /// Adds the buttons
        /// </summary>
        /// <param name="i"></param>
        private void CreateButtons(int i) {
            Button tb = new Button();
            _arrayButtons[i] = tb;
            tb.Content = _sortMachine.GetArray()[i].ToString();

            ArrayGrid.Children.Add(tb);
            tb.SetValue(Grid.ColumnProperty, i);
            tb.SetValue(Grid.RowProperty, 1);

            tb = new Button();
            tb.Content = (i + 1).ToString();

            ArrayGrid.Children.Add(tb);
            tb.SetValue(Grid.ColumnProperty, i);
            tb.SetValue(Grid.RowProperty, 0);
        }

        /// <summary>
        /// Adds green line under the array
        /// </summary>
        private void CreateSortedArea() {
            _sortedArea = new Button();
            ArrayGrid.Children.Add(_sortedArea);
            _sortedArea.SetValue(Grid.ColumnProperty, 0);
            _sortedArea.SetValue(Grid.RowProperty, 2);
            _sortedArea.SetValue(Grid.ColumnSpanProperty, 1);
            _sortedArea.Background = Brushes.Green;
        }

        /// <summary>
        /// Position all the visuals in the center
        /// </summary>
        private void PositionVisual() {
            ArrayGrid.Measure(new Size(double.PositiveInfinity,
                                            double.PositiveInfinity));
            ArrayGrid.Arrange(new Rect(0, 0, 100, 100));
            Thickness margin = new Thickness();

            double totalWidth = 0;
            foreach(Button button in _arrayButtons) {
                totalWidth += button.ActualWidth;
            }

            margin.Left = CodeText.Margin.Left / 2 - totalWidth / 2;
            margin.Top = TempText.Margin.Top / 2 - 24;
            ArrayGrid.Margin = margin;
        }

        /// <summary>
        /// Update visuals for current state of sort machine
        /// </summary>
        private void UpdateArrayVisual() {
            if(_sortMachine.Loaded) {
                for(int i = 0; i < _sortMachine.GetArray().Length; i++)
                    _arrayButtons[i].Content = _sortMachine.GetArray()[i].ToString();
                _sortedArea.SetValue(Grid.ColumnSpanProperty, _sortMachine.GetSortedLength() + 1);
                ColorArrayVisual();
                UpdateArrayText();
            }
            else {
                MessageText.Text = "Ошибка выполнения";
            }
        }

        /// <summary>
        /// Update text blocks
        /// </summary>
        public void UpdateArrayText() {
            MessageText.Text = _sortMachine.ToString();
            TempText.Text = $"Сохраненное значение: {_sortMachine.GetTemp()}";
        }

        /// <summary>
        /// Select color for buttons and code parts
        /// </summary>
        private void ColorArrayVisual() {
            for(int i = 0; i < _sortMachine.GetArray().Length; i++) {
                if(i == _sortMachine.GetCurrentSorting())
                    _arrayButtons[i].Background = Brushes.Red;
                else if(i == _sortMachine.GetCurrentElement())
                    _arrayButtons[i].Background = Brushes.Blue;
                else
                    _arrayButtons[i].Background = Brushes.White;
            }
            ColorCode();
        }

        /// <summary>
        /// Select color for code parts
        /// </summary>
        private void ColorCode() {
            for(int i=0; i<CodeParts.Length; i++) {
                if(i == _sortMachine.GetCurrentRoutine())
                    CodeParts[i].Background = Brushes.Yellow;
                else
                    CodeParts[i].Background = Brushes.White;
            }
        }

        /// <summary>
        /// Backward button click - move backward
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void Backward_Click(object sender, RoutedEventArgs e) {
            if(_sortMachine.Loaded)
                _sortMachine.Undo();
            UpdateArrayVisual();
        }

        /// <summary>
        /// Forward button click - move forward
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void Forward_Click(object sender, RoutedEventArgs e) {
            if(_sortMachine.Loaded)
                _sortMachine.Do();
            UpdateArrayVisual();
        }

        /// <summary>
        /// Fastforward button click - move forward automatically
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void Fastforward_Click(object sender, RoutedEventArgs e) {

        }

        /// <summary>
        /// Save button click - save preset to file
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void MenuItemSave_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Preset file|*.ps";
            fileDialog.DefaultExt = ".ps";
            fileDialog.FileName = "*.ps";
            Nullable<bool> dialogResult = fileDialog.ShowDialog();
            if(dialogResult == true) {
                string path = fileDialog.FileName;
                string res = _sortMachine.SavePresetToFile(path);
                if(res != null)
                    MessageText.Text = res;
            }
        }

        /// <summary>
        /// Open button click - open preset file
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void MenuItemOpen_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Preset file|*.ps";
            fileDialog.DefaultExt = ".ps";
            Nullable<bool> dialogResult = fileDialog.ShowDialog();
            if(dialogResult == true) {
                string path = fileDialog.FileName;
                string res = _sortMachine.LoadPresetFromFile(path);
                if(res != null)
                    MessageText.Text = res;
                else {
                    CreateArrayVisual();
                }
            }
        }

        /// <summary>
        /// Create button click - create new preset
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void MenuItemCreate_Click(object sender, RoutedEventArgs e) {
            InputWindow inputWindow = new InputWindow();
            inputWindow.SetSortMachine(_sortMachine);
            inputWindow.SetMainWindow(this);
            inputWindow.Show();
        }
    }
}
