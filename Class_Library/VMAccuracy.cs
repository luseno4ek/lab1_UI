using System;


namespace Class_Library
{
    public struct VMAccuracy
    {
        public VMGrid Grid { get; set; }                      // Сетка параметров для функции
        public double MaxDifference { get; set; }              // Максимум модуля разности для VML_HA и VML_EP
        public double MaxDiffPoint { get; set; }               // Точка максимума модуля разности
        public double[] ValuesInMaxDiffPoint { get; set; }     // Значения VML_HA и VML_EP в точке MaxDiffPoint

        public VMAccuracy(VMGrid _grid, double _maxDiffPoint, double[] _values)
        {
            Grid = new VMGrid(_grid.ArgLength, _grid.FirstPoint, _grid.SecondPoint, _grid.Function);
            MaxDiffPoint = _maxDiffPoint;
            ValuesInMaxDiffPoint = new double[2] { _values[0], _values[1]};
            MaxDifference = Math.Abs(ValuesInMaxDiffPoint[0] - ValuesInMaxDiffPoint[1]);
        }

        public override string ToString()
        {
            string final_str = "-- VMAccuracy struct -- \n1) Grid:   \n" + Grid.ToString() + "\n";
            final_str += "2) Max difference b/ween VML_HA and VML_EP:   " + MaxDifference.ToString() + ".\n";
            final_str += "3) Max difference point:   " + MaxDiffPoint.ToString() + ".\n";
            final_str += "4) Values in max difference point:   \n1) Точность VML_HA:   " + ValuesInMaxDiffPoint[0].ToString() +
                "\n2) Точность VML_EP:   " + ValuesInMaxDiffPoint[1].ToString() + "\n";
            return final_str;
        }
    }
}
