using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int TsfStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int TsfStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Tsf(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= TsfStart(options))
            {
                return TI_OKAY;
            }

            double x = default; // Sum of Xs.
            double x2 = default; // Sum of square of Xs.
            double y = default; // Flat sum of previous numbers.
            double xy = default; // Weighted sum of previous numbers.
            double p = 1.0 / period;
            for (var i = 0; i < period - 1; ++i)
            {
                x += i + 1;
                x2 += (i + 1) * (i + 1);
                xy += input[i] * (i + 1);
                y += input[i];
            }

            x += period;
            x2 += period * period;
            double bd = 1.0 / (period * x2 - x * x);
            int outputIndex = default;
            for (int i = period - 1; i < size; ++i)
            {
                xy += input[i] * period;
                y += input[i];
                double b = (period * xy - x * y) * bd;
                double a = (y - b * x) * p;
                output[outputIndex++] = a + b * (period + 1);
                xy -= y;
                y -= input[i - period + 1];
            }

            return TI_OKAY;
        }

        private static int Tsf(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= TsfStart(options))
            {
                return TI_OKAY;
            }

            decimal x = default; // Sum of Xs.
            decimal x2 = default; // Sum of square of Xs.
            decimal y = default; // Flat sum of previous numbers.
            decimal xy = default; // Weighted sum of previous numbers.
            decimal p = Decimal.One / period;
            for (var i = 0; i < period - 1; ++i)
            {
                x += i + 1;
                x2 += (i + 1) * (i + 1);
                xy += input[i] * (i + 1);
                y += input[i];
            }

            x += period;
            x2 += period * period;
            decimal bd = Decimal.One / (period * x2 - x * x);
            int outputIndex = default;
            for (int i = period - 1; i < size; ++i)
            {
                xy += input[i] * period;
                y += input[i];
                decimal b = (period * xy - x * y) * bd;
                decimal a = (y - b * x) * p;
                output[outputIndex++] = a + b * (period + 1);
                xy -= y;
                y -= input[i - period + 1];
            }

            return TI_OKAY;
        }
    }
}
