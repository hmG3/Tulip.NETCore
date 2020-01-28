using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int QstickStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int QstickStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Qstick(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] open = inputs[0];
            double[] close = inputs[1];
            double[] output = outputs[0];
            int period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= QstickStart(options))
            {
                return TI_OKAY;
            }

            double div = 1.0 / period;
            double sum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += close[i] - open[i];
            }

            int outputIndex = default;
            output[outputIndex++] = sum * div;
            for (int i = period; i < size; ++i)
            {
                sum = sum + (close[i] - open[i]) - (close[i - period] - open[i - period]);
                output[outputIndex++] = sum * div;
            }

            return TI_OKAY;
        }

        private static int Qstick(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] open = inputs[0];
            decimal[] close = inputs[1];
            decimal[] output = outputs[0];
            int period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= QstickStart(options))
            {
                return TI_OKAY;
            }

            decimal div = Decimal.One / period;
            decimal sum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += close[i] - open[i];
            }

            int outputIndex = default;
            output[outputIndex++] = sum * div;
            for (int i = period; i < size; ++i)
            {
                sum = sum + (close[i] - open[i]) - (close[i - period] - open[i - period]);
                output[outputIndex++] = sum * div;
            }

            return TI_OKAY;
        }
    }
}
