using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Class_Library
{
    public class VMBenchmark : INotifyPropertyChanged
    {
        [DllImport("..\\..\\..\\..\\x64\\Debug\\MKL_DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MKL_vmdExp(int n, double[] a, ref double time_1, ref double time_2,
                                             ref double time_3, ref double res_1, ref double res_2, ref double point);
        [DllImport("..\\..\\..\\..\\x64\\Debug\\MKL_DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MKL_vmsExp(int n, float[] a, ref double time_1, ref double time_2,
                                            ref double time_3, ref double res_1, ref double res_2, ref double point);
        [DllImport("..\\..\\..\\..\\x64\\Debug\\MKL_DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MKL_vmdErf(int n, double[] a, ref double time_1, ref double time_2,
                                             ref double time_3, ref double res_1, ref double res_2, ref double point);
        [DllImport("..\\..\\..\\..\\x64\\Debug\\MKL_DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MKL_vmsErf(int n, float[] a, ref double time_1, ref double time_2,
                                     ref double time_3, ref double res_1, ref double res_2, ref double point);
        public ObservableCollection<VMTime> TimeResults { get; set; }
        public ObservableCollection<VMAccuracy> AccuracyResults { get; set; }
        public VMBenchmark()
        {
            TimeResults = new ObservableCollection<VMTime>();
            TimeResults.CollectionChanged += Collection_CollectionChanged;
            AccuracyResults = new ObservableCollection<VMAccuracy>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Collection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MinTimeScores)));
        }

        public void AddVMResults(VMGrid grid)
        {
            VMGrid currGrid = new VMGrid(grid.ArgLength, grid.FirstPoint, grid.SecondPoint, grid.Function);

            double[] timeParams = new double[3];
            double[] accurParams = new double[2];
            double maxDiffPoint = 0;

            if ((currGrid.Function == VMf.vmsExp) | (currGrid.Function == VMf.vmsErf))
            {
                float[] args = new float[currGrid.ArgLength];
                float gridStep = (float)currGrid.GridStep;

                args[0] = (float)currGrid.Interval[0];
                for (int i = 1; i < args.Length; i++)
                {
                    args[i] = args[i - 1] + gridStep;
                }

                if (currGrid.Function == VMf.vmsExp)
                {
                    MKL_vmsExp(currGrid.ArgLength, args, ref timeParams[0], ref timeParams[1], ref timeParams[2],
                    ref accurParams[0], ref accurParams[1], ref maxDiffPoint);
                }
                else
                {
                    MKL_vmsErf(currGrid.ArgLength, args, ref timeParams[0], ref timeParams[1], ref timeParams[2],
                    ref accurParams[0], ref accurParams[1], ref maxDiffPoint);
                }
            }
            else
            {
                double[] args = new double[currGrid.ArgLength];
                double gridStep = currGrid.GridStep;

                args[0] = currGrid.Interval[0];
                for (int i = 1; i < args.Length; i++)
                {
                    args[i] = args[i - 1] + gridStep;
                }

                if (currGrid.Function == VMf.vmdExp)
                {
                    MKL_vmdExp(currGrid.ArgLength, args, ref timeParams[0], ref timeParams[1], ref timeParams[2],
                    ref accurParams[0], ref accurParams[1], ref maxDiffPoint);
                }
                else
                {
                    MKL_vmdErf(currGrid.ArgLength, args, ref timeParams[0], ref timeParams[1], ref timeParams[2],
                    ref accurParams[0], ref accurParams[1], ref maxDiffPoint);
                }
            }

            TimeResults.Add(new VMTime(currGrid, timeParams));
            AccuracyResults.Add(new VMAccuracy(currGrid, maxDiffPoint, accurParams));
        }

        public void AddVMTime(VMGrid grid)
        {
            VMGrid currGrid = new VMGrid(grid.ArgLength, grid.FirstPoint, grid.SecondPoint, grid.Function);

            double[] timeParams = new double[3];
            double[] accurParams = new double[2];
            double maxDiffPoint = 0;

            if ((currGrid.Function == VMf.vmsExp) | (currGrid.Function == VMf.vmsErf))
            {
                float[] args = new float[currGrid.ArgLength];
                float gridStep = (float)currGrid.GridStep;

                args[0] = (float)currGrid.Interval[0];
                for (int i = 1; i < args.Length; i++)
                {
                    args[i] = args[i - 1] + gridStep;
                }

                if (currGrid.Function == VMf.vmsExp)
                {
                    MKL_vmsExp(currGrid.ArgLength, args, ref timeParams[0], ref timeParams[1], ref timeParams[2],
                    ref accurParams[0], ref accurParams[1], ref maxDiffPoint);
                }
                else
                {
                    MKL_vmsErf(currGrid.ArgLength, args, ref timeParams[0], ref timeParams[1], ref timeParams[2],
                    ref accurParams[0], ref accurParams[1], ref maxDiffPoint);
                }
            }
            else
            {
                double[] args = new double[currGrid.ArgLength];
                double gridStep = currGrid.GridStep;

                args[0] = currGrid.Interval[0];
                for (int i = 1; i < args.Length; i++)
                {
                    args[i] = args[i - 1] + gridStep;
                }

                if (currGrid.Function == VMf.vmdExp)
                {
                    MKL_vmdExp(currGrid.ArgLength, args, ref timeParams[0], ref timeParams[1], ref timeParams[2],
                    ref accurParams[0], ref accurParams[1], ref maxDiffPoint);
                }
                else
                {
                    MKL_vmdErf(currGrid.ArgLength, args, ref timeParams[0], ref timeParams[1], ref timeParams[2],
                    ref accurParams[0], ref accurParams[1], ref maxDiffPoint);
                }
            }

            TimeResults.Add(new VMTime(currGrid, timeParams));
        }

        public void AddVMAccuracy(VMGrid grid)
        {
            VMGrid currGrid = new VMGrid(grid.ArgLength, grid.FirstPoint, grid.SecondPoint, grid.Function);

            double[] timeParams = new double[3];
            double[] accurParams = new double[2];
            double maxDiffPoint = 0;

            if ((currGrid.Function == VMf.vmsExp) | (currGrid.Function == VMf.vmsErf))
            {
                float[] args = new float[currGrid.ArgLength];
                float gridStep = (float)currGrid.GridStep;

                args[0] = (float)currGrid.Interval[0];
                for (int i = 1; i < args.Length; i++)
                {
                    args[i] = args[i - 1] + gridStep;
                }

                if (currGrid.Function == VMf.vmsExp)
                {
                    MKL_vmsExp(currGrid.ArgLength, args, ref timeParams[0], ref timeParams[1], ref timeParams[2],
                    ref accurParams[0], ref accurParams[1], ref maxDiffPoint);
                }
                else
                {
                    MKL_vmsErf(currGrid.ArgLength, args, ref timeParams[0], ref timeParams[1], ref timeParams[2],
                    ref accurParams[0], ref accurParams[1], ref maxDiffPoint);
                }
            }
            else
            {
                double[] args = new double[currGrid.ArgLength];
                double gridStep = currGrid.GridStep;

                args[0] = currGrid.Interval[0];
                for (int i = 1; i < args.Length; i++)
                {
                    args[i] = args[i - 1] + gridStep;
                }

                if (currGrid.Function == VMf.vmdExp)
                {
                    MKL_vmdExp(currGrid.ArgLength, args, ref timeParams[0], ref timeParams[1], ref timeParams[2],
                    ref accurParams[0], ref accurParams[1], ref maxDiffPoint);
                }
                else
                {
                    MKL_vmdErf(currGrid.ArgLength, args, ref timeParams[0], ref timeParams[1], ref timeParams[2],
                    ref accurParams[0], ref accurParams[1], ref maxDiffPoint);
                }
            }

            AccuracyResults.Add(new VMAccuracy(currGrid, maxDiffPoint, accurParams));
        }

        public double[] MinTimeScores
        {
            get 
            {
                if (TimeResults.Count() == 0)
                {
                    return new double[2]{ -1, -1 };
                }
                double[] minValues = new double[2];
                minValues[0] = float.MaxValue;
                minValues[1] = float.MaxValue;
                foreach (VMTime item in TimeResults)
                {
                    if (item.TimeScore[0] < minValues[0])
                    {
                        minValues[0] = item.TimeScore[0];
                    }
                    if (item.TimeScore[1] < minValues[1])
                    {
                        minValues[1] = item.TimeScore[1];
                    }
                }
                return minValues;
            }
        }

        public override string ToString()
        {
            string final_str = "------- VMBenchmark struct -------\n";
            for (int i = 0; i < TimeResults.Count; i++)
            {
                final_str += TimeResults[i].ToString();
                final_str += AccuracyResults[i].ToString();
            }
            return final_str;
        }
    }
}
