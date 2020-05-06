using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

        public MainWindow() {
            InitializeComponent();
            _sortMachine = new SortMachine();
            //_sortMachine.GeneratePreset(new int[1]);
            //CreateArrayVisual();
        }

        private void CreateArrayVisual() {
            ArrayGrid.Children.Clear();

            _arrayButtons = new Button[_sortMachine.GetArray().Length];

            ArrayGrid.RowDefinitions.Add(new RowDefinition());
            ArrayGrid.RowDefinitions.Add(new RowDefinition());
            ArrayGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(8) });

            for(int i = 0; i < _sortMachine.GetArray().Length; i++) {
                ColumnDefinition cd = new ColumnDefinition {
                    MinWidth = 16,
                    MaxWidth = 64
                };
                ArrayGrid.ColumnDefinitions.Add(cd);

                Button tb = new Button();
                _arrayButtons[i] = tb;
                tb.Content = _sortMachine.GetArray()[i].ToString();

                ArrayGrid.Children.Add(tb);
                tb.SetValue(Grid.ColumnProperty, i);
                tb.SetValue(Grid.RowProperty, 1);

                tb = new Button();
                tb.Content = i.ToString();

                ArrayGrid.Children.Add(tb);
                tb.SetValue(Grid.ColumnProperty, i);
                tb.SetValue(Grid.RowProperty, 0);
            }

            _sortedArea = new Button();
            ArrayGrid.Children.Add(_sortedArea);
            _sortedArea.SetValue(Grid.ColumnProperty, 0);
            _sortedArea.SetValue(Grid.RowProperty, 2);
            _sortedArea.SetValue(Grid.ColumnSpanProperty, 1);
            _sortedArea.Background = Brushes.Green;


            ArrayGrid.Measure(new Size(double.PositiveInfinity,
                                        double.PositiveInfinity));
            ArrayGrid.Arrange(new Rect(0, 0, 0, 0));
            Thickness margin = ArrayGrid.Margin;

            margin.Left = CodeText.Margin.Left / 2 - ArrayGrid.ActualWidth / 2;
            margin.Top = TempText.Margin.Top / 2 - ArrayGrid.ActualHeight / 2;
            ArrayGrid.Margin = margin;

            MessageText.Text = _sortMachine.ToString();

            ColorArrayVisual();
            UpdateArrayText();
        }

        private void UpdateArrayVisual() {
            for(int i = 0; i < _sortMachine.GetArray().Length; i++)
                _arrayButtons[i].Content = _sortMachine.GetArray()[i].ToString();
            _sortedArea.SetValue(Grid.ColumnSpanProperty, _sortMachine.GetSortedLength() + 1);
            ColorArrayVisual();
            UpdateArrayText();
        }

        public void UpdateArrayText() {
            MessageText.Text = _sortMachine.ToString();
            TempText.Text = $"Сохраненное значение: {_sortMachine.GetTemp()}";
        }

        private void ColorArrayVisual() {
            for(int i = 0; i < _sortMachine.GetArray().Length; i++) {
                if(i == _sortMachine.GetCurrentSorting())
                    _arrayButtons[i].Background = Brushes.Red;
                else if(i == _sortMachine.GetCurrentElement())
                    _arrayButtons[i].Background = Brushes.Blue;
                else
                    _arrayButtons[i].Background = Brushes.White;
            }
            switch(_sortMachine.GetCurrentRoutine()) {
                case 0:
                    CodeTextBlock0.Background = Brushes.Yellow;
                    CodeTextBlock1.Background = Brushes.White;
                    CodeTextBlock2.Background = Brushes.White;
                    break;
                case 1:
                    CodeTextBlock0.Background = Brushes.White;
                    CodeTextBlock1.Background = Brushes.Yellow;
                    CodeTextBlock2.Background = Brushes.White;
                    break;
                case 2:
                    CodeTextBlock0.Background = Brushes.White;
                    CodeTextBlock1.Background = Brushes.White;
                    CodeTextBlock2.Background = Brushes.Yellow;
                    break;
                default:
                    CodeTextBlock0.Background = Brushes.White;
                    CodeTextBlock1.Background = Brushes.White;
                    CodeTextBlock2.Background = Brushes.White;
                    break;
            }
        }

        private void Backward_Click(object sender, RoutedEventArgs e) {
            _sortMachine.Undo();
            UpdateArrayVisual();
        }

        private void Forward_Click(object sender, RoutedEventArgs e) {
            _sortMachine.Do();
            UpdateArrayVisual();
        }

        private void Fastforward_Click(object sender, RoutedEventArgs e) {

        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Preset file|*.ps";
            fileDialog.DefaultExt = ".ps";
            fileDialog.FileName = "*.ps";
            Nullable<bool> dialogResult = fileDialog.ShowDialog();
            if(dialogResult == true) {
                string path = fileDialog.FileName;
                _sortMachine.SavePresetToFile(path);
            }
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Preset file|*.ps";
            fileDialog.DefaultExt = ".ps";
            Nullable<bool> dialogResult = fileDialog.ShowDialog();
            if(dialogResult == true) {
                string path = fileDialog.FileName;
                _sortMachine.LoadPresetFromFile(path);
                CreateArrayVisual();
            }
        }
    }
}
