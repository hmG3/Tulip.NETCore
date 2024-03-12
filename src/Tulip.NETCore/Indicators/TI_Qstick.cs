namespace Tulip;

internal static partial class Tinet
{
    private static int QstickStart(double[] options) => (int) options[0] - 1;

    private static int QstickStart(decimal[] options) => (int) options[0] - 1;

    private static int Qstick(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= QstickStart(options))
        {
            return TI_OKAY;
        }

        var (open, close) = inputs;
        var output = outputs[0];

        double sum = default;
        for (var i = 0; i < period; ++i)
        {
            sum += close[i] - open[i];
        }

        double scale = 1.0 / period;
        int outputIndex = default;
        output[outputIndex++] = sum * scale;
        for (var i = period; i < size; ++i)
        {
            sum = sum + (close[i] - open[i]) - (close[i - period] - open[i - period]);
            output[outputIndex++] = sum * scale;
        }

        return TI_OKAY;
    }

    private static int Qstick(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= QstickStart(options))
        {
            return TI_OKAY;
        }

        var (open, close) = inputs;
        var output = outputs[0];

        decimal sum = default;
        for (var i = 0; i < period; ++i)
        {
            sum += close[i] - open[i];
        }

        decimal scale = Decimal.One / period;
        int outputIndex = default;
        output[outputIndex++] = sum * scale;
        for (var i = period; i < size; ++i)
        {
            sum = sum + (close[i] - open[i]) - (close[i - period] - open[i - period]);
            output[outputIndex++] = sum * scale;
        }

        return TI_OKAY;
    }
}
