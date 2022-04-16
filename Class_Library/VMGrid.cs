namespace Class_Library
{
    public class VMGrid
    {
        public int ArgLength { get; set; }
        public double FirstPoint { get; set; }
        public double SecondPoint { get; set; }
        public double[] Interval { get; set; }
        public double GridStep { get; }
        public VMf Function { get; set; }

        public VMGrid(int _argLength, double _fp, double _sp, VMf _function)
        {
            ArgLength = _argLength;
            FirstPoint = _fp;
            SecondPoint = _sp;
            Interval = new double[2] { _fp, _sp};
            GridStep = (Interval[1] - Interval[0]) / ArgLength;
            Function = _function;
        }

        public override string ToString()
        {
            string final_str = "1) Interval:   [" + Interval[0].ToString() + ", " + Interval[1].ToString() + "],\n";
            final_str += "2) Argument length:   " + ArgLength.ToString() + ",\n";
            final_str += "3) Grid step:   " + GridStep.ToString() + ",\n";
            final_str += "4) Function:   " + Function + ".\n";
            return base.ToString();
        }
    }
}
