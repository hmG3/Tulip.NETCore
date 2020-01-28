using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int StdErrStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int StdErrStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int StdErr(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= StdErrStart(options))
            {
                return TI_OKAY;
            }

            double div = 1.0 / period;
            double sum = default;
            double sum2 = default;
            double mul = 1.0 / Math.Sqrt(period);
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];
            }

            double s2S2 = sum2 * div - sum * div * (sum * div);
            if (s2S2 > 0.0)
            {
                s2S2 = Math.Sqrt(s2S2);
            }

            int outputIndex = default;
            output[outputIndex++] = mul * s2S2;
            for (int i = period; i < size; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];

                sum -= input[i - period];
                sum2 -= input[i - period] * input[i - period];
                s2S2 = sum2 * div - sum * div * (sum * div);
                if (s2S2 > 0.0)
                {
                    s2S2 = Math.Sqrt(s2S2);
                }

                output[outputIndex++] = mul * s2S2;
            }

            return TI_OKAY;
        }

        private static int StdErr(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= StdErrStart(options))
            {
                return TI_OKAY;
            }

            decimal div = Decimal.One / period;
            decimal sum = default;
            decimal sum2 = default;
            decimal mul = Decimal.One / DecimalMath.Sqrt(period);
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];
            }

            decimal s2S2 = sum2 * div - sum * div * sum * div;
            if (s2S2 > Decimal.Zero)
            {
                s2S2 = DecimalMath.Sqrt(s2S2);
            }

            int outputIndex = default;
            output[outputIndex++] = mul * s2S2;
            for (int i = period; i < size; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];

                sum -= input[i - period];
                sum2 -= input[i - period] * input[i - period];
                s2S2 = sum2 * div - sum * div * sum * div;
                if (s2S2 > Decimal.Zero)
                {
                    s2S2 = DecimalMath.Sqrt(s2S2);
                }

                output[outputIndex++] = mul * s2S2;
            }

            return TI_OKAY;
        }
    }
}
