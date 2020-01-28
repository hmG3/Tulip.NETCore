using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int DxStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int DxStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Dx(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] close = inputs[2];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= DxStart(options))
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

            double diUp = dmUp / atr;
            double diDown = dmDown / atr;
            double dx = Math.Abs(diUp - diDown) / (diUp + diDown) * 100.0;
            int outputIndex = default;
            output[outputIndex++] = dx;
            for (int i = period; i < size; ++i)
            {
                CalcTrueRange(low, high, close, i, out double trueRange);
                atr = atr * per + trueRange;

                CalcDirection(high, low, i, out double dp, out double dm);
                dmUp = dmUp * per + dp;
                dmDown = dmDown * per + dm;

                diUp = dmUp / atr;
                diDown = dmDown / atr;
                dx = Math.Abs(diUp - diDown) / (diUp + diDown) * 100.0;
                output[outputIndex++] = dx;
            }

            return TI_OKAY;
        }

        private static int Dx(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] close = inputs[2];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= DxStart(options))
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

            decimal diUp = dmUp / atr;
            decimal diDown = dmDown / atr;
            decimal dx = Math.Abs(diUp - diDown) / (diUp + diDown) * 100m;
            int outputIndex = default;
            output[outputIndex++] = dx;
            for (int i = period; i < size; ++i)
            {
                CalcTrueRange(low, high, close, i, out decimal trueRange);
                atr = atr * per + trueRange;

                CalcDirection(high, low, i, out decimal dp, out decimal dm);
                dmUp = dmUp * per + dp;
                dmDown = dmDown * per + dm;

                diUp = dmUp / atr;
                diDown = dmDown / atr;
                dx = Math.Abs(diUp - diDown) / (diUp + diDown) * 100m;
                output[outputIndex++] = dx;
            }

            return TI_OKAY;
        }
    }
}
