using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int KvoStart(double[] options)
        {
            return 1;
        }

        private static int KvoStart(decimal[] options)
        {
            return 1;
        }

        private static int Kvo(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] close = inputs[2];
            double[] volume = inputs[3];
            int shortPeriod = (int) options[0];
            int longPeriod = (int) options[1];

            if (shortPeriod < 1 || longPeriod < shortPeriod)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= KvoStart(options))
            {
                return TI_OKAY;
            }

            double shortPer = 2.0 / (shortPeriod + 1.0);
            double longPer = 2.0 / (longPeriod + 1.0);
            double[] output = outputs[0];
            double cm = default;
            double prevHlc = high[0] + low[0] + close[0];
            int trend = -1;
            double shortEma = default;
            double longEma = default;
            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                double hlc = high[i] + low[i] + close[i];
                double dm = high[i] - low[i];
                if (hlc > prevHlc && trend != 1)
                {
                    trend = 1;
                    cm = high[i - 1] - low[i - 1];
                }
                else if (hlc < prevHlc && trend != 0)
                {
                    trend = 0;
                    cm = high[i - 1] - low[i - 1];
                }

                cm += dm;
                double vf = volume[i] * Math.Abs(dm / cm * 2.0 - 1.0) * 100.0 * (trend == 0 ? -1.0 : 1.0);
                if (i == 1)
                {
                    shortEma = vf;
                    longEma = vf;
                }
                else
                {
                    shortEma = (vf - shortEma) * shortPer + shortEma;
                    longEma = (vf - longEma) * longPer + longEma;
                }

                output[outputIndex++] = shortEma - longEma;
                prevHlc = hlc;
            }

            return TI_OKAY;
        }

        private static int Kvo(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] close = inputs[2];
            decimal[] volume = inputs[3];
            int shortPeriod = (int) options[0];
            int longPeriod = (int) options[1];

            if (shortPeriod < 1 || longPeriod < shortPeriod)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= KvoStart(options))
            {
                return TI_OKAY;
            }

            decimal shortPer = 2m / (shortPeriod + Decimal.One);
            decimal longPer = 2m / (longPeriod + Decimal.One);
            decimal[] output = outputs[0];
            decimal cm = default;
            decimal prevHlc = high[0] + low[0] + close[0];
            int trend = -1;
            decimal shortEma = default;
            decimal longEma = default;
            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                decimal hlc = high[i] + low[i] + close[i];
                decimal dm = high[i] - low[i];
                if (hlc > prevHlc && trend != 1)
                {
                    trend = 1;
                    cm = high[i - 1] - low[i - 1];
                }
                else if (hlc < prevHlc && trend != 0)
                {
                    trend = 0;
                    cm = high[i - 1] - low[i - 1];
                }

                cm += dm;
                decimal vf = volume[i] * Math.Abs(dm / cm * 2m - Decimal.One) * 100m * (trend == 0 ? Decimal.MinusOne : Decimal.One);
                if (i == 1)
                {
                    shortEma = vf;
                    longEma = vf;
                }
                else
                {
                    shortEma = (vf - shortEma) * shortPer + shortEma;
                    longEma = (vf - longEma) * longPer + longEma;
                }

                output[outputIndex++] = shortEma - longEma;
                prevHlc = hlc;
            }

            return TI_OKAY;
        }
    }
}
