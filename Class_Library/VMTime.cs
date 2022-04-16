namespace Class_Library
{
    public struct VMTime
    {
        public VMGrid Grid { get; set; }            // Сетка параметров для функции
        public double[] TimeResults { get; set; }    // Время работы: [0] -- VML_HA, [1] -- VML_EP, [2] -- код С++
        public double[] TimeScore { get; set; }      // Отношения времени работы: [0] -- VML_HA / C++, [1] -- VML_EP / C++

        public VMTime(VMGrid _grid, double[] _timeRes)
        {
            Grid = new VMGrid(_grid.ArgLength, _grid.FirstPoint, _grid.SecondPoint, _grid.Function);
            TimeResults = _timeRes;
            TimeScore = new double[2];
            TimeScore[0] = TimeResults[0] / TimeResults[2];
            TimeScore[1] = TimeResults[1] / TimeResults[2];
        }
        public override string ToString()
        {
            string final_str = "-- VMTime struct -- \n1) Grid:   \n" + Grid.ToString() + ".\n";
            final_str += "2) Relative time of VML_HA:   " + TimeScore[0].ToString() + ".\n\n";
            final_str += "3) Relative time of VML_EP:   " + TimeScore[1].ToString() + ".\n";
            return final_str;
        }

    }
}
