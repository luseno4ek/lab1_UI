using Class_Library;
using System.IO;
using System;
using System.Windows;

namespace Lab_1
{
    public class BenchmarkSaverAndLoader
    {
        public bool Save(VMBenchmark Benchmark, StreamWriter writer)
        {
            try
            {
                writer.WriteLine(Benchmark.TimeResults.Count);
                foreach (VMTime item in Benchmark.TimeResults)
                {
                    writer.WriteLine(item.Grid.ArgLength);
                    writer.WriteLine($"{item.Grid.FirstPoint:0.00000000}");
                    writer.WriteLine($"{item.Grid.SecondPoint:0.00000000}");
                    writer.WriteLine((int)item.Grid.Function);
                    writer.WriteLine($"{item.TimeResults[0]:0.00000000}");
                    writer.WriteLine($"{item.TimeResults[1]:0.00000000}");
                    writer.WriteLine($"{item.TimeResults[2]:0.00000000}");
                }
                writer.WriteLine(Benchmark.AccuracyResults.Count);
                foreach (VMAccuracy item in Benchmark.AccuracyResults)
                {
                    writer.WriteLine(item.Grid.ArgLength);
                    writer.WriteLine($"{item.Grid.FirstPoint:0.00000000}");
                    writer.WriteLine($"{item.Grid.SecondPoint:0.00000000}");
                    writer.WriteLine((int)item.Grid.Function);
                    writer.WriteLine($"{item.MaxDiffPoint:0.00000000}");
                    writer.WriteLine($"{item.ValuesInMaxDiffPoint[0]:0.00000000}");
                    writer.WriteLine($"{item.ValuesInMaxDiffPoint[1]:0.00000000}");
                }
            }
            catch (Exception e)
            {
                Benchmark.TimeResults.Clear();
                Benchmark.AccuracyResults.Clear();
                MessageBox.Show($"Unable to save file: {e.Message}.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                writer.Close();
                return false;
            }
            finally
            {
                writer.Close();
            }
            return true;
        }

       public bool Load(VMBenchmark Benchmark, StreamReader reader)
        {
            try
            {
                Benchmark.TimeResults.Clear();
                Benchmark.AccuracyResults.Clear();
                int count1 = Int32.Parse(reader.ReadLine());
                for (int i = 0; i < count1; i++)
                {
                    int Grid_Length = Int32.Parse(reader.ReadLine());
                    double Grid_LeftEnd = double.Parse(reader.ReadLine());
                    double Grid_RightEnd = double.Parse(reader.ReadLine());
                    VMf Grid_CurFunction = (VMf)int.Parse(reader.ReadLine());
                    VMGrid Grid = new(Grid_Length, Grid_LeftEnd, Grid_RightEnd, Grid_CurFunction);
                    double[] TimeResults = new double[3];
                    TimeResults[0] = double.Parse(reader.ReadLine());
                    TimeResults[1] = double.Parse(reader.ReadLine());
                    TimeResults[2] = double.Parse(reader.ReadLine());
                    VMTime item = new VMTime(Grid, TimeResults);
                    Benchmark.TimeResults.Add(item);
                }
                int count2 = Int32.Parse(reader.ReadLine());
                for (int i = 0; i < count2; i++)
                {
                    int Grid_Length = Int32.Parse(reader.ReadLine());
                    double Grid_LeftEnd = double.Parse(reader.ReadLine());
                    double Grid_RightEnd = double.Parse(reader.ReadLine());
                    VMf Grid_CurFunction = (VMf)int.Parse(reader.ReadLine());
                    VMGrid Grid = new(Grid_Length, Grid_LeftEnd, Grid_RightEnd, Grid_CurFunction);
                    double MaxDiffPoint = double.Parse(reader.ReadLine());
                    double[] ValuesInMaxDiffPoint = new double[2];
                    ValuesInMaxDiffPoint[0] = double.Parse(reader.ReadLine());
                    ValuesInMaxDiffPoint[1] = double.Parse(reader.ReadLine());
                    VMAccuracy item = new VMAccuracy(Grid, MaxDiffPoint, ValuesInMaxDiffPoint);
                    Benchmark.AccuracyResults.Add(item);
                }
            }
            catch (Exception e)
            {
                Benchmark.TimeResults.Clear();
                Benchmark.AccuracyResults.Clear();
                MessageBox.Show($"Unable to load file: {e.Message}.", "Load error", MessageBoxButton.OK, MessageBoxImage.Error);
                reader.Close();
                return false;
            }
            finally
            {
                reader.Close();
            }
            return true;
        }
    }
}
