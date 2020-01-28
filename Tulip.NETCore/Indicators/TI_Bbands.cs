using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int BbandsStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int BbandsStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Bbands(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] lower = outputs[0];
            double[] middle = outputs[1];
            double[] upper = outputs[2];
            int period = (int) options[0];
            double stddev = options[1];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= BbandsStart(options))
            {
                return TI_OKAY;
            }

            double div = 1.0 / period;
            double sum = default;
            double sum2 = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];
            }

            double sd = Math.Sqrt(sum2 * div - sum * div * (sum * div));

            int lowerIndex = default;
            int middleIndex = default;
            int upperIndex = default;
            middle[middleIndex++] = sum * div;
            lower[lowerIndex++] = middle[0] - stddev * sd;
            upper[upperIndex++] = middle[0] + stddev * sd;
            for (int i = period; i < size; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];

                sum -= input[i - period];
                sum2 -= input[i - period] * input[i - period];

                sd = Math.Sqrt(sum2 * div - sum * div * (sum * div));
                middle[middleIndex] = sum * div;
                upper[upperIndex++] = middle[middleIndex] + stddev * sd;
                lower[lowerIndex++] = middle[middleIndex] - stddev * sd;
                ++middleIndex;
            }

            return TI_OKAY;
        }

        private static int Bbands(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            decimal[] lower = outputs[0];
            decimal[] middle = outputs[1];
            decimal[] upper = outputs[2];
            int period = (int) options[0];
            decimal stddev = options[1];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= BbandsStart(options))
            {
                return TI_OKAY;
            }

            decimal div = Decimal.One / period;
            decimal sum = default;
            decimal sum2 = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];
            }

            decimal sd = DecimalMath.Sqrt(sum2 * div - sum * div * sum * div);

            int lowerIndex = default;
            int middleIndex = default;
            int upperIndex = default;
            middle[middleIndex++] = sum * div;
            lower[lowerIndex++] = middle[0] - stddev * sd;
            upper[upperIndex++] = middle[0] + stddev * sd;
            for (int i = period; i < size; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];

                sum -= input[i - period];
                sum2 -= input[i - period] * input[i - period];

                sd = DecimalMath.Sqrt(sum2 * div - sum * div * sum * div);
                middle[middleIndex] = sum * div;
                upper[upperIndex++] = middle[middleIndex] + stddev * sd;
                lower[lowerIndex++] = middle[middleIndex] - stddev * sd;
                ++middleIndex;
            }

            return TI_OKAY;
        }
    }
}
