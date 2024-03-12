namespace Tulip;

internal static partial class Tinet
{
    private static int TypPriceStart(double[] options) => 0;

    private static int TypPriceStart(decimal[] options) => 0;

    private static int TypPrice(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var (high, low, close) = inputs;
        var output = outputs[0];

        for (var i = 0; i < size; ++i)
        {
            output[i] = (high[i] + low[i] + close[i]) * (1.0 / 3.0);
        }

        return TI_OKAY;
    }

    private static int TypPrice(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var (high, low, close) = inputs;
        var output = outputs[0];

        for (var i = 0; i < size; ++i)
        {
            output[i] = (high[i] + low[i] + close[i]) * (Decimal.One / 3m);
        }

        return TI_OKAY;
    }
}
