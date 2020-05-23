using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int VolatilityStart(double[] options) => (int) options[0];

        private static int VolatilityStart(decimal[] options) => (int) options[0];

        private static int Volatility(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= VolatilityStart(options))
            {
                return TI_OKAY;
            }

            double[] input = inputs[0];
            double[] output = outputs[0];

            double sum = default;
            double sum2 = default;
            for (var i = 1; i <= period; ++i)
            {
                double c = input[i] / input[i - 1] - 1.0;
                sum += c;
                sum2 += c * c;
            }

            double scale = 1.0 / period;
            double annual = Math.Sqrt(252.0); // Multiplier, number of trading days in year.
            int outputIndex = default;
            output[outputIndex++] = Math.Sqrt(sum2 * scale - sum * scale * (sum * scale)) * annual;
            for (var i = period + 1; i < size; ++i)
            {
                double c = input[i] / input[i - 1] - 1.0;
                sum += c;
                sum2 += c * c;

                double cp = input[i - period] / input[i - period - 1] - 1.0;
                sum -= cp;
                sum2 -= cp * cp;

                output[outputIndex++] = Math.Sqrt(sum2 * scale - sum * scale * (sum * scale)) * annual;
            }

            return TI_OKAY;
        }

        private static int Volatility(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= VolatilityStart(options))
            {
                return TI_OKAY;
            }

            decimal[] input = inputs[0];
            decimal[] output = outputs[0];

            decimal sum = default;
            decimal sum2 = default;
            for (var i = 1; i <= period; ++i)
            {
                decimal c = input[i] / input[i - 1] - Decimal.One;
                sum += c;
                sum2 += c * c;
            }

            decimal scale = Decimal.One / period;
            decimal annual = DecimalMath.Sqrt(252m); // Multiplier, number of trading days in year.
            int outputIndex = default;
            output[outputIndex++] = DecimalMath.Sqrt(sum2 * scale - sum * scale * sum * scale) * annual;
            for (var i = period + 1; i < size; ++i)
            {
                decimal c = input[i] / input[i - 1] - Decimal.One;
                sum += c;
                sum2 += c * c;

                decimal cp = input[i - period] / input[i - period - 1] - Decimal.One;
                sum -= cp;
                sum2 -= cp * cp;

                output[outputIndex++] = DecimalMath.Sqrt(sum2 * scale - sum * scale * sum * scale) * annual;
            }

            return TI_OKAY;
        }
    }
}
