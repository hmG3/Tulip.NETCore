using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int BopStart(double[] options) => 0;

        private static int BopStart(decimal[] options) => 0;

        private static int Bop(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] open = inputs[0];
            double[] high = inputs[1];
            double[] low = inputs[2];
            double[] close = inputs[3];
            double[] output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                double hl = high[i] - low[i];
                output[i] = hl > 0.0 ? (close[i] - open[i]) / hl : 0.0;
            }

            return TI_OKAY;
        }

        private static int Bop(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] open = inputs[0];
            decimal[] high = inputs[1];
            decimal[] low = inputs[2];
            decimal[] close = inputs[3];
            decimal[] output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                decimal hl = high[i] - low[i];
                output[i] = hl > Decimal.Zero ? (close[i] - open[i]) / hl : Decimal.Zero;
            }

            return TI_OKAY;
        }
    }
}
