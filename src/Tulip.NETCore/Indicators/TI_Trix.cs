namespace Tulip;

internal static partial class Tinet
{
    private static int TrixStart(double[] options) => ((int) options[0] - 1) * 3 + 1;

    private static int TrixStart(decimal[] options) => ((int) options[0] - 1) * 3 + 1;

    private static int Trix(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= TrixStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        int start = period * 3 - 2;
        double per = 2.0 / (period + 1);
        double ema1 = input[0];
        double ema2 = default;
        double ema3 = default;
        for (var i = 1; i < start; ++i)
        {
            ema1 = (input[i] - ema1) * per + ema1;
            if (i == period - 1)
            {
                ema2 = ema1;
            }
            else if (i > period - 1)
            {
                ema2 = (ema1 - ema2) * per + ema2;
                if (i == period * 2 - 2)
                {
                    ema3 = ema2;
                }
                else if (i > period * 2 - 2)
                {
                    ema3 = (ema2 - ema3) * per + ema3;
                }
            }
        }

        int outputIndex = default;
        for (int i = start; i < size; ++i)
        {
            ema1 = (input[i] - ema1) * per + ema1;
            ema2 = (ema1 - ema2) * per + ema2;
            double last = ema3;
            ema3 = (ema2 - ema3) * per + ema3;
            output[outputIndex++] = (ema3 - last) / ema3 * 100.0;
        }

        return TI_OKAY;
    }

    private static int Trix(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= TrixStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        int start = period * 3 - 2;
        decimal per = 2m / (period + 1);
        decimal ema1 = input[0];
        decimal ema2 = default;
        decimal ema3 = default;
        for (var i = 1; i < start; ++i)
        {
            ema1 = (input[i] - ema1) * per + ema1;
            if (i == period - 1)
            {
                ema2 = ema1;
            }
            else if (i > period - 1)
            {
                ema2 = (ema1 - ema2) * per + ema2;
                if (i == period * 2 - 2)
                {
                    ema3 = ema2;
                }
                else if (i > period * 2 - 2)
                {
                    ema3 = (ema2 - ema3) * per + ema3;
                }
            }
        }

        int outputIndex = default;
        for (int i = start; i < size; ++i)
        {
            ema1 = (input[i] - ema1) * per + ema1;
            ema2 = (ema1 - ema2) * per + ema2;
            decimal last = ema3;
            ema3 = (ema2 - ema3) * per + ema3;
            output[outputIndex++] = (ema3 - last) / ema3 * 100m;
        }

        return TI_OKAY;
    }
}
