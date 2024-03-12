namespace Tulip;

internal static partial class Tinet
{
    private static int BopStart(double[] options) => 0;

    private static int BopStart(decimal[] options) => 0;

    private static int Bop(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var (open, high, low, close) = inputs;
        var output = outputs[0];

        for (var i = 0; i < size; ++i)
        {
            double hl = high[i] - low[i];
            output[i] = hl > 0.0 ? (close[i] - open[i]) / hl : 0.0;
        }

        return TI_OKAY;
    }

    private static int Bop(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var (open, high, low, close) = inputs;
        var output = outputs[0];

        for (var i = 0; i < size; ++i)
        {
            decimal hl = high[i] - low[i];
            output[i] = hl > Decimal.Zero ? (close[i] - open[i]) / hl : Decimal.Zero;
        }

        return TI_OKAY;
    }
}
