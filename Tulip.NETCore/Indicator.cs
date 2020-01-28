namespace Tulip
{
    public sealed class Indicator
    {
        private readonly int _index;

        internal Indicator(int index, string name, string fullName, string inputs, string options, string outputs)
        {
            _index = index;
            Name = name;
            FullName = fullName;
            Inputs = inputs.Split('|');
            Options = options.Split('|');
            Outputs = outputs.Split('|');
        }

        public string Name { get; }

        public string FullName { get; }

        public string[] Inputs { get; }

        public string[] Options { get; }

        public string[] Outputs { get; }

        public int Run(double[][] inputs, double[] options, double[][] outputs)
        {
            return Tinet.IndicatorRun(_index, inputs, options, outputs);
        }

        public int Run(decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            return Tinet.IndicatorRun(_index, inputs, options, outputs);
        }

        public int Start(double[] options)
        {
            return Tinet.IndicatorStart(_index, options);
        }

        public int Start(decimal[] options)
        {
            return Tinet.IndicatorStart(_index, options);
        }
    }
}
