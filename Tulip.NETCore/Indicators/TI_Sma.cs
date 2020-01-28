using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int SmaStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int SmaStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Sma(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= SmaStart(options))
            {
                return TI_OKAY;
            }

            double div = 1.0 / period;
            double sum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
            }

            int outputIndex = default;
            output[outputIndex++] = sum * div;
            for (int i = period; i < size; ++i)
            {
                sum = sum + input[i] - input[i - period];
                output[outputIndex++] = sum * div;
            }

            return TI_OKAY;
        }

        private static int Sma(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= SmaStart(options))
            {
                return TI_OKAY;
            }

            decimal div = Decimal.One / period;
            decimal sum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
            }

            int outputIndex = default;
            output[outputIndex++] = sum * div;
            for (int i = period; i < size; ++i)
            {
                sum = sum + input[i] - input[i - period];
                output[outputIndex++] = sum * div;
            }

            return TI_OKAY;
        }
    }
}
