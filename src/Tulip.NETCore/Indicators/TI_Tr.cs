namespace Tulip;

internal static partial class Tinet
{
    private static int TrStart(double[] options) => 0;

    private static int TrStart(decimal[] options) => 0;

    private static int Tr(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var (high, low, close) = inputs;
        var output = outputs[0];

        output[0] = high[0] - low[0];
        for (var i = 1; i < size; ++i)
        {
            CalcTrueRange(low, high, close, i, out double trueRange);
            output[i] = trueRange;
        }

        return TI_OKAY;
    }

    private static int Tr(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var (high, low, close) = inputs;
        var output = outputs[0];

        output[0] = high[0] - low[0];
        for (var i = 1; i < size; ++i)
        {
            CalcTrueRange(low, high, close, i, out decimal trueRange);
            output[i] = trueRange;
        }

        return TI_OKAY;
    }
}
