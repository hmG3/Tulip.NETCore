namespace Tulip;

internal static partial class Tinet
{
    private static int RsiStart(double[] options) => (int) options[0];

    private static int RsiStart(decimal[] options) => (int) options[0];

    private static int Rsi(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= RsiStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        double smoothUp = default;
        double smoothDown = default;
        for (var i = 1; i <= period; ++i)
        {
            double upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : 0.0;
            double downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : 0.0;
            smoothUp += upward;
            smoothDown += downward;
        }

        smoothUp /= period;
        smoothDown /= period;

        double per = 1.0 / period;
        int outputIndex = default;
        output[outputIndex++] = 100.0 * (smoothUp / (smoothUp + smoothDown));
        for (var i = period + 1; i < size; ++i)
        {
            double upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : 0.0;
            double downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : 0.0;
            smoothUp = (upward - smoothUp) * per + smoothUp;
            smoothDown = (downward - smoothDown) * per + smoothDown;
            output[outputIndex++] = 100.0 * (smoothUp / (smoothUp + smoothDown));
        }

        return TI_OKAY;
    }

    private static int Rsi(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= RsiStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        decimal smoothUp = default;
        decimal smoothDown = default;
        for (var i = 1; i <= period; ++i)
        {
            decimal upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : Decimal.Zero;
            decimal downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : Decimal.Zero;
            smoothUp += upward;
            smoothDown += downward;
        }

        smoothUp /= period;
        smoothDown /= period;

        decimal per = Decimal.One / period;
        int outputIndex = default;
        output[outputIndex++] = 100m * (smoothUp / (smoothUp + smoothDown));
        for (var i = period + 1; i < size; ++i)
        {
            decimal upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : Decimal.Zero;
            decimal downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : Decimal.Zero;
            smoothUp = (upward - smoothUp) * per + smoothUp;
            smoothDown = (downward - smoothDown) * per + smoothDown;
            output[outputIndex++] = 100m * (smoothUp / (smoothUp + smoothDown));
        }

        return TI_OKAY;
    }
}
