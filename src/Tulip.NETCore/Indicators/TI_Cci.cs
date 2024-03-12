namespace Tulip;

internal static partial class Tinet
{
    private static int CciStart(double[] options) => ((int) options[0] - 1) * 2;

    private static int CciStart(decimal[] options) => ((int) options[0] - 1) * 2;

    private static int Cci(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= CciStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var output = outputs[0];

        double scale = 1.0 / period;
        var sum = BufferDoubleFactory(period);
        int outputIndex = default;
        for (var i = 0; i < size; ++i)
        {
            double today = (high[i] + low[i] + close[i]) * (1.0 / 3.0);
            BufferPush(ref sum, today);

            double avg = sum.sum * scale;
            if (i >= period * 2 - 2)
            {
                double acc = 0.0;
                for (var j = 0; j < period; ++j)
                {
                    acc += Math.Abs(avg - sum.vals[j]);
                }

                double cci = acc * scale * 0.015;
                cci = (today - avg) / cci;
                output[outputIndex++] = cci;
            }
        }

        return TI_OKAY;
    }

    private static int Cci(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        var period = (int) options[0];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= CciStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var output = outputs[0];

        decimal scale = Decimal.One / period;
        var sum = BufferDecimalFactory(period);
        int outputIndex = default;
        for (var i = 0; i < size; ++i)
        {
            decimal today = (high[i] + low[i] + close[i]) * (Decimal.One / 3m);
            BufferPush(ref sum, today);

            decimal avg = sum.sum * scale;
            if (i >= period * 2 - 2)
            {
                decimal acc = Decimal.Zero;
                for (var j = 0; j < period; ++j)
                {
                    acc += Math.Abs(avg - sum.vals[j]);
                }

                decimal cci = acc * scale * 0.015m;
                cci = (today - avg) / cci;
                output[outputIndex++] = cci;
            }
        }

        return TI_OKAY;
    }
}
