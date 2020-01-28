using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int WadStart(double[] options)
        {
            return 1;
        }

        private static int WadStart(decimal[] options)
        {
            return 1;
        }

        private static int Wad(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] close = inputs[2];

            if (size <= WadStart(options))
            {
                return TI_OKAY;
            }

            double[] output = outputs[0];
            double sum = default;
            double yc = close[0];
            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                double c = close[i];
                if (c > yc)
                {
                    sum += c - Math.Min(yc, low[i]);
                }
                else if (c < yc)
                {
                    sum += c - Math.Max(yc, high[i]);
                }

                output[outputIndex++] = sum;
                yc = close[i];
            }

            return TI_OKAY;
        }

        private static int Wad(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] close = inputs[2];

            if (size <= WadStart(options))
            {
                return TI_OKAY;
            }

            decimal[] output = outputs[0];
            decimal sum = default;
            decimal yc = close[0];
            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                decimal c = close[i];
                if (c > yc)
                {
                    sum += c - Math.Min(yc, low[i]);
                }
                else if (c < yc)
                {
                    sum += c - Math.Max(yc, high[i]);
                }

                output[outputIndex++] = sum;
                yc = close[i];
            }

            return TI_OKAY;
        }
    }
}
