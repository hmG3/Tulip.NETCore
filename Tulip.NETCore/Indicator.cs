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
            return Tinet.indicator_run(_index, inputs, options, outputs);
        }

        public int Start(double[] options)
        {
            return Tinet.indicator_start(_index, options);
        }
    }
}
