using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int RsiStart(double[] options)
        {
            return (int) options[0];
        }

        private static int RsiStart(decimal[] options)
        {
            return (int) options[0];
        }

        private static int Rsi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= RsiStart(options))
            {
                return TI_OKAY;
            }

            double per = 1.0 / period;
            double smoothUp = default;
            double smoothDown = default;
            for (var i = 1; i <= period; ++i)
            {
                double upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : 0.0;
                double downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : 0.0;
                smoothUp += upward;
                smoothDown += downward;
            }

            smoothUp /= period;
            smoothDown /= period;
            int outputIndex = default;
            output[outputIndex++] = 100.0 * (smoothUp / (smoothUp + smoothDown));
            for (int i = period + 1; i < size; ++i)
            {
                double upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : 0.0;
                double downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : 0.0;
                smoothUp = (upward - smoothUp) * per + smoothUp;
                smoothDown = (downward - smoothDown) * per + smoothDown;
                output[outputIndex++] = 100.0 * (smoothUp / (smoothUp + smoothDown));
            }

            return TI_OKAY;
        }

        private static int Rsi(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= RsiStart(options))
            {
                return TI_OKAY;
            }

            decimal per = Decimal.One / period;
            decimal smoothUp = default;
            decimal smoothDown = default;
            for (var i = 1; i <= period; ++i)
            {
                decimal upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : Decimal.Zero;
                decimal downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : Decimal.Zero;
                smoothUp += upward;
                smoothDown += downward;
            }

            smoothUp /= period;
            smoothDown /= period;
            int outputIndex = default;
            output[outputIndex++] = 100m * (smoothUp / (smoothUp + smoothDown));
            for (int i = period + 1; i < size; ++i)
            {
                decimal upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : Decimal.Zero;
                decimal downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : Decimal.Zero;
                smoothUp = (upward - smoothUp) * per + smoothUp;
                smoothDown = (downward - smoothDown) * per + smoothDown;
                output[outputIndex++] = 100m * (smoothUp / (smoothUp + smoothDown));
            }

            return TI_OKAY;
        }
    }
}
