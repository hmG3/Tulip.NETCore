namespace Tulip;

internal static partial class Tinet
{
    private static int LagStart(double[] options) => (int) options[0];

    private static int LagStart(decimal[] options) => (int) options[0];

    private static int Lag(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var period = (int) options[0];

        if (period < 0)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= LagStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        int outputIndex = default;
        for (var i = period; i < size; ++i)
        {
            output[outputIndex++] = input[i - period];
        }

        return TI_OKAY;
    }

    private static int Lag(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var period = (int) options[0];

        if (period < 0)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= LagStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        int outputIndex = default;
        for (var i = period; i < size; ++i)
        {
            output[outputIndex++] = input[i - period];
        }

        return TI_OKAY;
    }
}
