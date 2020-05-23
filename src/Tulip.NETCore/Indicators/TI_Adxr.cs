using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AdxrStart(double[] options) => ((int) options[0] - 1) * 3;

        private static int AdxrStart(decimal[] options) => ((int) options[0] - 1) * 3;

        private static int Adxr(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 2)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= AdxrStart(options))
            {
                return TI_OKAY;
            }

            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] close = inputs[2];
            double[] output = outputs[0];

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

            double per = (period - 1.0) / period;
            double invPer = 1.0 / period;
            double adx = default;
            double diUp = dmUp / atr;
            double diDown = dmDown / atr;
            double dx = Math.Abs(diUp - diDown) / (diUp + diDown) * 100.0;
            adx += dx;

            var adxr = BufferDoubleFactory(period - 1);
            int firstAdxr = AdxrStart(options);

            int outputIndex = default;
            for (var i = period; i < size; ++i)
            {
                CalcTrueRange(low, high, close, i, out double trueRange);
                atr = atr * per + trueRange;

                CalcDirection(high, low, i, out double dp, out double dm);
                dmUp = dmUp * per + dp;
                dmDown = dmDown * per + dm;

                diUp = dmUp / atr;
                diDown = dmDown / atr;
                dx = Math.Abs(diUp - diDown) / (diUp + diDown) * 100.0;
                if (i - period < period - 2)
                {
                    adx += dx;
                }
                else if (i - period == period - 2)
                {
                    adx += dx;
                    BufferQPush(ref adxr, adx * invPer);
                }
                else
                {
                    adx = adx * per + dx;
                    if (i >= firstAdxr)
                    {
                        output[outputIndex++] = 0.5 * (adx * invPer + BufferGet(adxr, 1));
                    }

                    BufferQPush(ref adxr, adx * invPer);
                }
            }

            return TI_OKAY;
        }

        private static int Adxr(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 2)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= AdxrStart(options))
            {
                return TI_OKAY;
            }

            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] close = inputs[2];
            decimal[] output = outputs[0];

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

            decimal per = (period - Decimal.One) / period;
            decimal invPer = Decimal.One / period;
            decimal adx = default;
            decimal diUp = dmUp / atr;
            decimal diDown = dmDown / atr;
            decimal dx = Math.Abs(diUp - diDown) / (diUp + diDown) * 100m;
            adx += dx;

            var adxr = BufferDecimalFactory(period - 1);
            int firstAdxr = AdxrStart(options);

            int outputIndex = default;
            for (var i = period; i < size; ++i)
            {
                CalcTrueRange(low, high, close, i, out decimal trueRange);
                atr = atr * per + trueRange;

                CalcDirection(high, low, i, out decimal dp, out decimal dm);
                dmUp = dmUp * per + dp;
                dmDown = dmDown * per + dm;

                diUp = dmUp / atr;
                diDown = dmDown / atr;
                dx = Math.Abs(diUp - diDown) / (diUp + diDown) * 100m;
                if (i - period < period - 2)
                {
                    adx += dx;
                }
                else if (i - period == period - 2)
                {
                    adx += dx;
                    BufferQPush(ref adxr, adx * invPer);
                }
                else
                {
                    adx = adx * per + dx;
                    if (i >= firstAdxr)
                    {
                        output[outputIndex++] = 0.5m * (adx * invPer + BufferGet(adxr, 1));
                    }

                    BufferQPush(ref adxr, adx * invPer);
                }
            }

            return TI_OKAY;
        }
    }
}
