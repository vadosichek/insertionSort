using System;
using System.Collections.Generic;
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
            int[] array = {10,9,8,7,6,5,4,3,2,1};
            CreateArrayVisual(array);
        }

        private void CreateArrayVisual(int[] array) {
            _sortMachine = new SortMachine(array);
            _arrayButtons = new Button[array.Length];

            ArrayGrid.RowDefinitions.Add(new RowDefinition());
            ArrayGrid.RowDefinitions.Add(new RowDefinition { Height=new GridLength(8)});

            for(int i = 0; i < array.Length; i++) {
                ColumnDefinition cd = new ColumnDefinition {
                    MinWidth = 16,
                    MaxWidth = 64
                };
                ArrayGrid.ColumnDefinitions.Add(cd);

                Button tb = new Button();
                _arrayButtons[i] = tb;
                tb.Content = array[i].ToString();

                ArrayGrid.Children.Add(tb);
                tb.SetValue(Grid.ColumnProperty, i);
            }

            _sortedArea = new Button();
            ArrayGrid.Children.Add(_sortedArea);
            _sortedArea.SetValue(Grid.ColumnProperty, 0);
            _sortedArea.SetValue(Grid.RowProperty, 1);
            _sortedArea.SetValue(Grid.ColumnSpanProperty, 1);
            _sortedArea.Background = Brushes.Green;


            ArrayGrid.Measure(new Size(double.PositiveInfinity,
                                        double.PositiveInfinity));
            ArrayGrid.Arrange(new Rect(0, 0, 0, 0));
            Thickness margin = ArrayGrid.Margin;

            margin.Left = CodeText.Margin.Left / 2 - ArrayGrid.ActualWidth / 2;
            margin.Top = MessageText.Margin.Top / 2 - ArrayGrid.ActualHeight / 2;
            ArrayGrid.Margin = margin;

            MessageText.Text = _sortMachine.ToString();

            ColorArrayVisual();
        }

        private void UpdateArrayVisual() {
            for(int i = 0; i < _sortMachine.GetArray().Length; i++)
                _arrayButtons[i].Content = _sortMachine.GetArray()[i].ToString();
            _sortedArea.SetValue(Grid.ColumnSpanProperty, _sortMachine.GetSortedLength()+1);
            ColorArrayVisual();
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

        private void Load_Click(object sender, RoutedEventArgs e) {

        }

        private void Reset_Click(object sender, RoutedEventArgs e) {

        }
    }
}
