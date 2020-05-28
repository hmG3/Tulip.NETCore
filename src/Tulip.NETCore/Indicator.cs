using System;

namespace Tulip
{
    public sealed class Indicator
    {
        private readonly byte _index;

        internal Indicator(byte index, string name, string fullName, string inputs, string options, string outputs)
        {
            _index = index;
            Name = name;
            FullName = fullName;
            Inputs = inputs.Split('|');
            Options = !String.IsNullOrEmpty(options) ? options.Split('|') : Array.Empty<string>();
            Outputs = outputs.Split('|');
        }

        public string Name { get; }

        public string FullName { get; }

        public string[] Inputs { get; }

        public string[] Options { get; }

        public string[] Outputs { get; }

        public int Start(double[] options) => Tinet.IndicatorStart(_index, options);

        public int Start(decimal[] options) => Tinet.IndicatorStart(_index, options);

        public int Run(double[][] inputs, double[] options, double[][] outputs) => Tinet.IndicatorRun(_index, inputs, options, outputs);

        public int Run(decimal[][] inputs, decimal[] options, decimal[][] outputs) => Tinet.IndicatorRun(_index, inputs, options, outputs);
    }
}
