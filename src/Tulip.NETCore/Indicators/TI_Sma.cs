using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int SmaStart(double[] options) => (int) options[0] - 1;

        private static int SmaStart(decimal[] options) => (int) options[0] - 1;

        private static int Sma(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= SmaStart(options))
            {
                return TI_OKAY;
            }

            double[] input = inputs[0];
            double[] output = outputs[0];

            double sum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
            }

            double scale = 1.0 / period;
            int outputIndex = default;
            output[outputIndex++] = sum * scale;
            for (var i = period; i < size; ++i)
            {
                sum = sum + input[i] - input[i - period];
                output[outputIndex++] = sum * scale;
            }

            return TI_OKAY;
        }

        private static int Sma(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= SmaStart(options))
            {
                return TI_OKAY;
            }

            decimal[] input = inputs[0];
            decimal[] output = outputs[0];

            decimal sum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
            }

            decimal scale = Decimal.One / period;
            int outputIndex = default;
            output[outputIndex++] = sum * scale;
            for (var i = period; i < size; ++i)
            {
                sum = sum + input[i] - input[i - period];
                output[outputIndex++] = sum * scale;
            }

            return TI_OKAY;
        }
    }
}
