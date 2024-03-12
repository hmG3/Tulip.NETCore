namespace Tulip;

internal static partial class Tinet
{
    private static int PviStart(double[] options) => 0;

    private static int PviStart(decimal[] options) => 0;

    private static int Pvi(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        if (size <= PviStart(options))
        {
            return TI_OKAY;
        }

        var (close, volume) = inputs;
        var output = outputs[0];

        double pvi = 1000.0;
        int outputIndex = default;
        output[outputIndex++] = pvi;
        for (var i = 1; i < size; ++i)
        {
            if (volume[i] > volume[i - 1])
            {
                pvi += (close[i] - close[i - 1]) / close[i - 1] * pvi;
            }

            output[outputIndex++] = pvi;
        }

        return TI_OKAY;
    }

    private static int Pvi(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        if (size <= PviStart(options))
        {
            return TI_OKAY;
        }

        var (close, volume) = inputs;
        var output = outputs[0];

        decimal pvi = 1000m;
        int outputIndex = default;
        output[outputIndex++] = pvi;
        for (var i = 1; i < size; ++i)
        {
            if (volume[i] > volume[i - 1])
            {
                pvi += (close[i] - close[i - 1]) / close[i - 1] * pvi;
            }

            output[outputIndex++] = pvi;
        }

        return TI_OKAY;
    }
}
