using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int StdDevStart(double[] options) => (int) options[0] - 1;

        private static int StdDevStart(decimal[] options) => (int) options[0] - 1;

        private static int StdDev(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= StdDevStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            double sum = default;
            double sum2 = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];
            }

            double scale = 1.0 / period;
            double s2S2 = sum2 * scale - sum * scale * (sum * scale);
            if (s2S2 > 0.0)
            {
                s2S2 = Math.Sqrt(s2S2);
            }

            int outputIndex = default;
            output[outputIndex++] = s2S2;
            for (var i = period; i < size; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];

                sum -= input[i - period];
                sum2 -= input[i - period] * input[i - period];
                s2S2 = sum2 * scale - sum * scale * (sum * scale);
                if (s2S2 > 0.0)
                {
                    s2S2 = Math.Sqrt(s2S2);
                }

                output[outputIndex++] = s2S2;
            }

            return TI_OKAY;
        }

        private static int StdDev(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= StdDevStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            decimal sum = default;
            decimal sum2 = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];
            }

            decimal scale = Decimal.One / period;
            decimal s2S2 = sum2 * scale - sum * scale * sum * scale;
            if (s2S2 > Decimal.Zero)
            {
                s2S2 = DecimalMath.Sqrt(s2S2);
            }

            int outputIndex = default;
            output[outputIndex++] = s2S2;
            for (var i = period; i < size; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];

                sum -= input[i - period];
                sum2 -= input[i - period] * input[i - period];
                s2S2 = sum2 * scale - sum * scale * sum * scale;
                if (s2S2 > Decimal.Zero)
                {
                    s2S2 = DecimalMath.Sqrt(s2S2);
                }

                output[outputIndex++] = s2S2;
            }

            return TI_OKAY;
        }
    }
}
