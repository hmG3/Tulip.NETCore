using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int VarStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int VarStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Var(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= VarStart(options))
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

            int outputIndex = default;
            output[outputIndex++] = sum2 * div - sum * div * (sum * div);
            for (int i = period; i < size; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];

                sum -= input[i - period];
                sum2 -= input[i - period] * input[i - period];

                output[outputIndex++] = sum2 * div - sum * div * (sum * div);
            }

            return TI_OKAY;
        }

        private static int Var(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= VarStart(options))
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

            int outputIndex = default;
            output[outputIndex++] = sum2 * div - sum * div * sum * div;
            for (int i = period; i < size; ++i)
            {
                sum += input[i];
                sum2 += input[i] * input[i];

                sum -= input[i - period];
                sum2 -= input[i - period] * input[i - period];

                output[outputIndex++] = sum2 * div - sum * div * sum * div;
            }

            return TI_OKAY;
        }
    }
}
