using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int DiStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int DiStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Di(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] close = inputs[2];
            int period = (int) options[0];
            double[] plusDi = outputs[0];
            double[] minusDi = outputs[1];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= DiStart(options))
            {
                return TI_OKAY;
            }

            double per = (period - 1.0) / period;
            double atr = default;
            double dmUp = default;
            double dmDown = default;

            for (var i = 1; i < period; ++i)
            {
                CalcTrueRange(low, high, close, i, out double trueRange);
                atr += trueRange;

                CalcDirection(high, low, i, out double dp, out double dm);
                dmUp += dp;
                dmDown += dm;
            }

            int plusDiIndex = default;
            int minusDiIndex = default;
            plusDi[plusDiIndex++] = 100.0 * dmUp / atr;
            minusDi[minusDiIndex++] = 100.0 * dmDown / atr;
            for (int i = period; i < size; ++i)
            {
                CalcTrueRange(low, high, close, i, out double trueRange);
                atr = atr * per + trueRange;

                CalcDirection(high, low, i, out double dp, out double dm);
                dmUp = dmUp * per + dp;
                dmDown = dmDown * per + dm;

                plusDi[plusDiIndex++] = 100.0 * dmUp / atr;
                minusDi[minusDiIndex++] = 100.0 * dmDown / atr;
            }

            return TI_OKAY;
        }

        private static int Di(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] close = inputs[2];
            int period = (int) options[0];
            decimal[] plusDi = outputs[0];
            decimal[] minusDi = outputs[1];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= DiStart(options))
            {
                return TI_OKAY;
            }

            decimal per = (period - Decimal.One) / period;
            decimal atr = default;
            decimal dmUp = default;
            decimal dmDown = default;

            for (var i = 1; i < period; ++i)
            {
                CalcTrueRange(low, high, close, i, out decimal trueRange);
                atr += trueRange;

                CalcDirection(high, low, i, out decimal dp, out decimal dm);
                dmUp += dp;
                dmDown += dm;
            }

            int plusDiIndex = default;
            int minusDiIndex = default;
            plusDi[plusDiIndex++] = 100m * dmUp / atr;
            minusDi[minusDiIndex++] = 100m * dmDown / atr;
            for (int i = period; i < size; ++i)
            {
                CalcTrueRange(low, high, close, i, out decimal trueRange);
                atr = atr * per + trueRange;

                CalcDirection(high, low, i, out decimal dp, out decimal dm);
                dmUp = dmUp * per + dp;
                dmDown = dmDown * per + dm;

                plusDi[plusDiIndex++] = 100m * dmUp / atr;
                minusDi[minusDiIndex++] = 100m * dmDown / atr;
            }

            return TI_OKAY;
        }
    }
}
