using System;
using System.Windows;
using Class_Library;

namespace Lab_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewData ViewData { get; set; }

        public VMGrid CurrentGrid { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewData = new ViewData();
            CurrentGrid = new VMGrid(10, 0, 2, VMf.vmdExp);
            DataContext = this;
        }
        private void OnNew(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BenchmarkIsSaved())
                {
                    ViewData.Benchmark.TimeResults.Clear();
                    ViewData.Benchmark.AccuracyResults.Clear();
                    ViewData.VMBenchmarkChanged = false;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnOpen(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BenchmarkIsSaved())
                {
                    Microsoft.Win32.OpenFileDialog dlgo = new Microsoft.Win32.OpenFileDialog
                    {
                        FileName = "VMBenchmark",
                        DefaultExt = ".txt",
                        Filter = "Text documents (.txt)|*.txt"
                    };

                    bool? result;
                    result = dlgo.ShowDialog();

                    if (result == true)
                    {
                        string filename = dlgo.FileName;
                        bool errors = ViewData.Load(filename);
                        ViewData.VMBenchmarkChanged = false;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog dlgs = new Microsoft.Win32.SaveFileDialog
                {
                    FileName = "VMBenchmark",
                    DefaultExt = ".txt", 
                    Filter = "Text documents (.txt)|*.txt" 
                };

                bool? result;
                result = dlgs.ShowDialog();

                if (result == true)
                {
                    string filename = dlgs.FileName;
                    bool errors = ViewData.Save(filename);
                    ViewData.VMBenchmarkChanged = false;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnAddVMResults(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewData.AddVMResults(CurrentGrid);
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnAddVMTime(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewData.AddVMTime(CurrentGrid);
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OnAddVMAccuracy(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewData.AddVMAccuracy(CurrentGrid);
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public bool BenchmarkIsSaved()
        {
            try
            {
                if (ViewData.VMBenchmarkChanged)
                {
                    MessageBoxResult UserChoice = MessageBox.Show($"Do you want to save changes?", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    switch (UserChoice)
                    {
                        case MessageBoxResult.Cancel:
                            return false;
                        case MessageBoxResult.Yes:
                            Microsoft.Win32.SaveFileDialog dlgs = new Microsoft.Win32.SaveFileDialog();
                            dlgs.FileName = "VMBenchmark"; 
                            dlgs.DefaultExt = ".txt";
                            dlgs.Filter = "Text documents (.txt)|*.txt"; 

                            bool? result = dlgs.ShowDialog();

                            if (result == true)
                            {
                                string filename = dlgs.FileName;
                                bool errors = ViewData.Save(filename);
                                return errors;
                            }
                            else
                            {
                                return false;
                            }
                        case MessageBoxResult.No:
                            return true;
                    }
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (BenchmarkIsSaved())
            {
                base.OnClosing(e);
            }
        }
    }
}
