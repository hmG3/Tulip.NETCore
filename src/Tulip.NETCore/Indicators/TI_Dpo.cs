using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int DpoStart(double[] options) => (int) options[0] - 1;

        private static int DpoStart(decimal[] options) => (int) options[0] - 1;

        private static int Dpo(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= DpoStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            double sum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
            }

            double scale = 1.0 / period;
            var back = period / 2 + 1;
            int outputIndex = default;
            output[outputIndex++] = input[period - 1 - back] - sum * scale;
            for (var i = period; i < size; ++i)
            {
                sum = sum + input[i] - input[i - period];
                output[outputIndex++] = input[i - back] - sum * scale;
            }

            return TI_OKAY;
        }

        private static int Dpo(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= DpoStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            decimal sum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
            }

            decimal scale = Decimal.One / period;
            var back = period / 2 + 1;
            int outputIndex = default;
            output[outputIndex++] = input[period - 1 - back] - sum * scale;
            for (var i = period; i < size; ++i)
            {
                sum = sum + input[i] - input[i - period];
                output[outputIndex++] = input[i - back] - sum * scale;
            }

            return TI_OKAY;
        }
    }
}
