namespace Tulip;

internal static partial class Tinet
{
    private static int SumStart(double[] options) => (int) options[0] - 1;

    private static int SumStart(decimal[] options) => (int) options[0] - 1;

    private static int Sum(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= SumStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        double sum = default;
        for (var i = 0; i < period; ++i)
        {
            sum += input[i];
        }

        int outputIndex = default;
        output[outputIndex++] = sum;
        for (var i = period; i < size; ++i)
        {
            sum = sum + input[i] - input[i - period];
            output[outputIndex++] = sum;
        }

        return TI_OKAY;
    }

    private static int Sum(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= SumStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        decimal sum = default;
        for (var i = 0; i < period; ++i)
        {
            sum += input[i];
        }

        int outputIndex = default;
        output[outputIndex++] = sum;
        for (var i = period; i < size; ++i)
        {
            sum = sum + input[i] - input[i - period];
            output[outputIndex++] = sum;
        }

        return TI_OKAY;
    }
}
