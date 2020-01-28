using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AdoscStart(double[] options)
        {
            return (int) options[1] - 1;
        }

        private static int AdoscStart(decimal[] options)
        {
            return (int) options[1] - 1;
        }

        private static int Adosc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] close = inputs[2];
            double[] volume = inputs[3];
            var shortPeriod = (int) options[0];
            var longPeriod = (int) options[1];
            double[] output = outputs[0];

            if (shortPeriod < 1 || longPeriod < shortPeriod)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= AdoscStart(options))
            {
                return TI_OKAY;
            }

            int start = longPeriod - 1;
            double shortPer = 2.0 / (shortPeriod + 1.0);
            double longPer = 2.0 / (longPeriod + 1.0);
            double sum = default;
            double shortEma = default;
            double longEma = default;
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                double hl = high[i] - low[i];
                if (!hl.Equals(0.0))
                {
                    sum += (close[i] - low[i] - high[i] + close[i]) / hl * volume[i];
                }

                if (i == 0)
                {
                    shortEma = sum;
                    longEma = sum;
                }
                else
                {
                    shortEma = (sum - shortEma) * shortPer + shortEma;
                    longEma = (sum - longEma) * longPer + longEma;
                }

                if (i >= start)
                {
                    output[outputIndex++] = shortEma - longEma;
                }
            }

            return TI_OKAY;
        }

        private static int Adosc(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] close = inputs[2];
            decimal[] volume = inputs[3];
            var shortPeriod = (int) options[0];
            var longPeriod = (int) options[1];
            decimal[] output = outputs[0];

            if (shortPeriod < 1 || longPeriod < shortPeriod)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= AdoscStart(options))
            {
                return TI_OKAY;
            }

            int start = longPeriod - 1;
            decimal shortPer = 2m / (shortPeriod + Decimal.One);
            decimal longPer = 2m / (longPeriod + Decimal.One);
            decimal sum = default;
            decimal shortEma = default;
            decimal longEma = default;
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                decimal hl = high[i] - low[i];
                if (hl != Decimal.Zero)
                {
                    sum += (close[i] - low[i] - high[i] + close[i]) / hl * volume[i];
                }

                if (i == 0)
                {
                    shortEma = sum;
                    longEma = sum;
                }
                else
                {
                    shortEma = (sum - shortEma) * shortPer + shortEma;
                    longEma = (sum - longEma) * longPer + longEma;
                }

                if (i >= start)
                {
                    output[outputIndex++] = shortEma - longEma;
                }
            }

            return TI_OKAY;
        }
    }
}
