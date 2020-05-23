using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AdStart(double[] options) => 0;

        private static int AdStart(decimal[] options) => 0;

        private static int Ad(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] close = inputs[2];
            double[] volume = inputs[3];
            double[] output = outputs[0];

            double sum = default;
            for (var i = 0; i < size; ++i)
            {
                double hl = high[i] - low[i];
                if (!hl.Equals(0.0))
                {
                    sum += (close[i] - low[i] - high[i] + close[i]) / hl * volume[i];
                }

                output[i] = sum;
            }

            return TI_OKAY;
        }

        private static int Ad(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] close = inputs[2];
            decimal[] volume = inputs[3];
            decimal[] output = outputs[0];

            decimal sum = default;
            for (var i = 0; i < size; ++i)
            {
                decimal hl = high[i] - low[i];
                if (hl != Decimal.Zero)
                {
                    sum += (close[i] - low[i] - high[i] + close[i]) / hl * volume[i];
                }

                output[i] = sum;
            }

            return TI_OKAY;
        }
    }
}
