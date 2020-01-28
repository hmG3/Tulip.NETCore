using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AoStart(double[] options)
        {
            return 33;
        }

        private static int AoStart(decimal[] options)
        {
            return 33;
        }

        private static int Ao(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] output = outputs[0];

            if (size <= AoStart(options))
            {
                return TI_OKAY;
            }

            double sum34 = default;
            double sum5 = default;
            double per34 = 1.0 / 34.0;
            double per5 = 1.0 / 5.0;
            for (var i = 0; i < 34; ++i)
            {
                double hl = 0.5 * (high[i] + low[i]);
                sum34 += hl;
                if (i >= 29)
                {
                    sum5 += hl;
                }
            }

            int outputIndex = default;
            output[outputIndex++] = per5 * sum5 - per34 * sum34;

            for (var i = 34; i < size; ++i)
            {
                double hl = 0.5 * (high[i] + low[i]);
                sum34 += hl;
                sum5 += hl;

                sum34 -= 0.5 * (high[i - 34] + low[i - 34]);
                sum5 -= 0.5 * (high[i - 5] + low[i - 5]);
                output[outputIndex++] = per5 * sum5 - per34 * sum34;
            }

            return TI_OKAY;
        }

        private static int Ao(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] output = outputs[0];

            if (size <= AoStart(options))
            {
                return TI_OKAY;
            }

            decimal sum34 = default;
            decimal sum5 = default;
            decimal per34 = Decimal.One / 34m;
            decimal per5 = Decimal.One / 5m;
            for (var i = 0; i < 34; ++i)
            {
                decimal hl = 0.5m * (high[i] + low[i]);
                sum34 += hl;
                if (i >= 29)
                {
                    sum5 += hl;
                }
            }

            int outputIndex = default;
            output[outputIndex++] = per5 * sum5 - per34 * sum34;

            for (var i = 34; i < size; ++i)
            {
                decimal hl = 0.5m * (high[i] + low[i]);
                sum34 += hl;
                sum5 += hl;

                sum34 -= 0.5m * (high[i - 34] + low[i - 34]);
                sum5 -= 0.5m * (high[i - 5] + low[i - 5]);
                output[outputIndex++] = per5 * sum5 - per34 * sum34;
            }

            return TI_OKAY;
        }
    }
}
