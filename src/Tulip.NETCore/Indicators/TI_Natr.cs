namespace Tulip;

internal static partial class Tinet
{
    private static int NatrStart(double[] options) => (int) options[0] - 1;

    private static int NatrStart(decimal[] options) => (int) options[0] - 1;

    private static int Natr(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= NatrStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var output = outputs[0];

        double sum = high[0] - low[0];
        int outputIndex = default;
        for (var i = 1; i < period; ++i)
        {
            CalcTrueRange(low, high, close, i, out double trueRange);
            sum += trueRange;
        }

        double per = 1.0 / period;
        double val = sum / period;
        output[outputIndex++] = 100.0 * val / close[period - 1];
        for (var i = period; i < size; ++i)
        {
            CalcTrueRange(low, high, close, i, out double trueRange);
            val = (trueRange - val) * per + val;
            output[outputIndex++] = 100.0 * val / close[i];
        }

        return TI_OKAY;
    }

    private static int Natr(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= NatrStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var output = outputs[0];

        decimal sum = high[0] - low[0];
        int outputIndex = default;
        for (var i = 1; i < period; ++i)
        {
            CalcTrueRange(low, high, close, i, out decimal trueRange);
            sum += trueRange;
        }

        decimal per = Decimal.One / period;
        decimal val = sum / period;
        output[outputIndex++] = 100m * val / close[period - 1];
        for (var i = period; i < size; ++i)
        {
            CalcTrueRange(low, high, close, i, out decimal trueRange);
            val = (trueRange - val) * per + val;
            output[outputIndex++] = 100m * val / close[i];
        }

        return TI_OKAY;
    }
}
