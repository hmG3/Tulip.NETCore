using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int MdStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int MdStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Md(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MdStart(options))
            {
                return TI_OKAY;
            }

            double div = 1.0 / period;
            double sum = default;
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                double today = input[i];
                sum += today;
                if (i >= period)
                {
                    sum -= input[i - period];
                }

                double avg = sum * div;
                if (i >= period - 1)
                {
                    double acc = default;
                    for (var j = 0; j < period; ++j)
                    {
                        acc += Math.Abs(avg - input[i - j]);
                    }

                    output[outputIndex++] = acc * div;
                }
            }

            return TI_OKAY;
        }

        private static int Md(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MdStart(options))
            {
                return TI_OKAY;
            }

            decimal div = Decimal.One / period;
            decimal sum = default;
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                decimal today = input[i];
                sum += today;
                if (i >= period)
                {
                    sum -= input[i - period];
                }

                decimal avg = sum * div;
                if (i >= period - 1)
                {
                    decimal acc = default;
                    for (var j = 0; j < period; ++j)
                    {
                        acc += Math.Abs(avg - input[i - j]);
                    }

                    output[outputIndex++] = acc * div;
                }
            }

            return TI_OKAY;
        }
    }
}
