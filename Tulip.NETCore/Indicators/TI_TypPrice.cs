using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int TypPriceStart(double[] options)
        {
            return 0;
        }

        private static int TypPriceStart(decimal[] options)
        {
            return 0;
        }

        private static int TypPrice(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] close = inputs[2];
            double[] output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = (high[i] + low[i] + close[i]) * (1.0 / 3.0);
            }

            return TI_OKAY;
        }

        private static int TypPrice(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] close = inputs[2];
            decimal[] output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = (high[i] + low[i] + close[i]) * (Decimal.One / 3m);
            }

            return TI_OKAY;
        }
    }
}
