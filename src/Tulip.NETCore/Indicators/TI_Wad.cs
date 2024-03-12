namespace Tulip;

internal static partial class Tinet
{
    private static int WadStart(double[] options) => 1;

    private static int WadStart(decimal[] options) => 1;

    private static int Wad(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        if (size <= WadStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var output = outputs[0];

        double sum = default;
        double yc = close[0];
        int outputIndex = default;
        for (var i = 1; i < size; ++i)
        {
            double c = close[i];
            if (c > yc)
            {
                sum += c - Math.Min(yc, low[i]);
            }
            else if (c < yc)
            {
                sum += c - Math.Max(yc, high[i]);
            }

            output[outputIndex++] = sum;
            yc = close[i];
        }

        return TI_OKAY;
    }

    private static int Wad(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        if (size <= WadStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var output = outputs[0];

        decimal sum = default;
        decimal yc = close[0];
        int outputIndex = default;
        for (var i = 1; i < size; ++i)
        {
            decimal c = close[i];
            if (c > yc)
            {
                sum += c - Math.Min(yc, low[i]);
            }
            else if (c < yc)
            {
                sum += c - Math.Max(yc, high[i]);
            }

            output[outputIndex++] = sum;
            yc = close[i];
        }

        return TI_OKAY;
    }
}
