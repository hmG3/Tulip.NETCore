using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int WildersStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int WildersStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Wilders(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= WildersStart(options))
            {
                return TI_OKAY;
            }

            double per = 1.0 / period;
            double sum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
            }

            double val = sum / period;
            int outputIndex = default;
            output[outputIndex++] = val;
            for (int i = period; i < size; ++i)
            {
                val = (input[i] - val) * per + val;
                output[outputIndex++] = val;
            }

            return TI_OKAY;
        }

        private static int Wilders(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= WildersStart(options))
            {
                return TI_OKAY;
            }

            decimal per = Decimal.One / period;
            decimal sum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
            }

            decimal val = sum / period;
            int outputIndex = default;
            output[outputIndex++] = val;
            for (int i = period; i < size; ++i)
            {
                val = (input[i] - val) * per + val;
                output[outputIndex++] = val;
            }

            return TI_OKAY;
        }
    }
}
