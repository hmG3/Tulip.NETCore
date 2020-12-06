using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int BbandsStart(double[] options) => (int) options[0] - 1;

        private static int BbandsStart(decimal[] options) => (int) options[0] - 1;

        private static int Bbands(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= BbandsStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var (lower, middle, upper) = outputs;

            double sum = default;
            double sum2 = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];
            }

            double stddev = options[1];
            double scale = 1.0 / period;
            double sd = Math.Sqrt(sum2 * scale - sum * scale * (sum * scale));

            int lowerIndex = default;
            int middleIndex = default;
            int upperIndex = default;
            middle[middleIndex++] = sum * scale;
            lower[lowerIndex++] = middle[0] - stddev * sd;
            upper[upperIndex++] = middle[0] + stddev * sd;
            for (var i = period; i < size; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];

                sum -= input[i - period];
                sum2 -= input[i - period] * input[i - period];

                sd = Math.Sqrt(sum2 * scale - sum * scale * (sum * scale));
                middle[middleIndex] = sum * scale;
                upper[upperIndex++] = middle[middleIndex] + stddev * sd;
                lower[lowerIndex++] = middle[middleIndex] - stddev * sd;
                ++middleIndex;
            }

            return TI_OKAY;
        }

        private static int Bbands(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= BbandsStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var (lower, middle, upper) = outputs;

            decimal sum = default;
            decimal sum2 = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];
            }

            decimal stddev = options[1];
            decimal scale = Decimal.One / period;
            decimal sd = DecimalMath.Sqrt(sum2 * scale - sum * scale * sum * scale);

            int lowerIndex = default;
            int middleIndex = default;
            int upperIndex = default;
            middle[middleIndex++] = sum * scale;
            lower[lowerIndex++] = middle[0] - stddev * sd;
            upper[upperIndex++] = middle[0] + stddev * sd;
            for (var i = period; i < size; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];

                sum -= input[i - period];
                sum2 -= input[i - period] * input[i - period];

                sd = DecimalMath.Sqrt(sum2 * scale - sum * scale * sum * scale);
                middle[middleIndex] = sum * scale;
                upper[upperIndex++] = middle[middleIndex] + stddev * sd;
                lower[lowerIndex++] = middle[middleIndex] - stddev * sd;
                ++middleIndex;
            }

            return TI_OKAY;
        }
    }
}
