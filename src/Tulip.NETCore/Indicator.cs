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

    public string Name { get; }

    public string FullName { get; }

    public string[] Inputs { get; }

    public string[] Options { get; }

    public string[] Outputs { get; }

    public int Run<T>(T[][] inputs, T[] options, T[][] outputs) where T : IFloatingPointIeee754<T> =>
        Tinet<T>.IndicatorRun(Name, inputs, options, outputs);

    public int Start<T>(T[] options) where T : IFloatingPointIeee754<T> => Tinet<T>.IndicatorStart(Name, options);

    public override string ToString() => Name;
}
