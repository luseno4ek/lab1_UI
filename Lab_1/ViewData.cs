using System;
using System.IO;
using System.Windows;
using System.ComponentModel;
using Class_Library;

namespace Lab_1
{
    public class ViewData : INotifyPropertyChanged
    {
        private bool _VMBenchmarkChanged;
        public bool VMBenchmarkChanged
        {
            get { return _VMBenchmarkChanged; }
            set
            {
                if (value != _VMBenchmarkChanged)
                {
                    _VMBenchmarkChanged = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VMBenchmarkChanged)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Collection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            VMBenchmarkChanged = true;
        }

        public ViewData()
        {
            VMBenchmarkChanged = false;
            Benchmark = new VMBenchmark();
            Benchmark.TimeResults.CollectionChanged += Collection_CollectionChanged;
            Benchmark.AccuracyResults.CollectionChanged += Collection_CollectionChanged;
        }

        public VMBenchmark Benchmark { get; set; }
        public void AddVMResults(VMGrid grid)
        {
            Benchmark.AddVMResults(grid);
        }
        public void AddVMTime(VMGrid grid)
        {
            Benchmark.AddVMTime(grid);
        }
        public void AddVMAccuracy(VMGrid grid)
        {
            Benchmark.AddVMAccuracy(grid);
        }
        public bool Save(string filename)
        {
            try
            {
                StreamWriter writer = new(filename, false);
                BenchmarkSaverAndLoader saver = new();
                saver.Save(Benchmark, writer);
            }
            catch (Exception e)
            {
                Benchmark.TimeResults.Clear();
                Benchmark.AccuracyResults.Clear();
                MessageBox.Show($"Unable to save file: {e.Message}.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public bool Load(string filename)
        {
            try
            {
                StreamReader reader = new StreamReader(filename);
                BenchmarkSaverAndLoader loader = new();
                loader.Load(Benchmark, reader);
            }
            catch (Exception e)
            {
                Benchmark.TimeResults.Clear();
                Benchmark.AccuracyResults.Clear();
                MessageBox.Show($"Unable to load file: {e.Message}.", "Load error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
