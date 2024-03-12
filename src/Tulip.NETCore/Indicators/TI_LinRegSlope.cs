namespace Tulip;

internal static partial class Tinet
{
    private static int LinRegSlopeStart(double[] options) => (int) options[0] - 1;

    private static int LinRegSlopeStart(decimal[] options) => (int) options[0] - 1;

    private static int LinRegSlope(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= LinRegStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        double x = default; // Sum of Xs.
        double x2 = default; // Sum of square of Xs.
        double y = default; // Flat sum of previous numbers.
        double xy = default; // Weighted sum of previous numbers.
        for (var i = 0; i < period - 1; ++i)
        {
            x += i + 1;
            x2 += (i + 1) * (i + 1);
            xy += input[i] * (i + 1);
            y += input[i];
        }

        x += period;
        x2 += period * period;

        double bd = 1.0 / (period * x2 - x * x);
        int outputIndex = default;
        for (var i = period - 1; i < size; ++i)
        {
            xy += input[i] * period;
            y += input[i];
            double b = (period * xy - x * y) * bd;
            output[outputIndex++] = b;
            xy -= y;
            y -= input[i - period + 1];
        }

        return TI_OKAY;
    }

    private static int LinRegSlope(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= LinRegStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        decimal x = default; // Sum of Xs.
        decimal x2 = default; // Sum of square of Xs.
        decimal y = default; // Flat sum of previous numbers.
        decimal xy = default; // Weighted sum of previous numbers.
        for (var i = 0; i < period - 1; ++i)
        {
            x += i + 1;
            x2 += (i + 1) * (i + 1);
            xy += input[i] * (i + 1);
            y += input[i];
        }

        x += period;
        x2 += period * period;

        decimal bd = Decimal.One / (period * x2 - x * x);
        int outputIndex = default;
        for (var i = period - 1; i < size; ++i)
        {
            xy += input[i] * period;
            y += input[i];
            decimal b = (period * xy - x * y) * bd;
            output[outputIndex++] = b;
            xy -= y;
            y -= input[i - period + 1];
        }

        return TI_OKAY;
    }
}
