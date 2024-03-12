namespace Tulip;

public sealed class Indicator
{
    internal Indicator(string name, string fullName, string inputs, string options, string outputs)
    {
        Name = name;
        FullName = fullName;
        Inputs = inputs.Split('|');
        Options = !String.IsNullOrEmpty(options) ? options.Split('|') : Array.Empty<string>();
        Outputs = outputs.Split('|');
    }

    private string Name { get; }

    public string FullName { get; }

    public string[] Inputs { get; }

    public string[] Options { get; }

    public string[] Outputs { get; }

    public int Start(double[] options) => Tinet.IndicatorStart(Name, options);

    public int Start(decimal[] options) => Tinet.IndicatorStart(Name, options);

    public int Run(double[][] inputs, double[] options, double[][] outputs) => Tinet.IndicatorRun(Name, inputs, options, outputs);

    public int Run(decimal[][] inputs, decimal[] options, decimal[][] outputs) => Tinet.IndicatorRun(Name, inputs, options, outputs);
}
