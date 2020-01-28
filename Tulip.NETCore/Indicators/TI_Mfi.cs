using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int MfiStart(double[] options)
        {
            return (int) options[0];
        }

        private static int MfiStart(decimal[] options)
        {
            return (int) options[0];
        }

        private static int Mfi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] close = inputs[2];
            double[] volume = inputs[3];
            int period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MfiStart(options))
            {
                return TI_OKAY;
            }

            double[] output = outputs[0];
            double yTyp = (high[0] + low[0] + close[0]) * (1.0 / 3.0);
            var up = BufferDoubleNew(period);
            var down = BufferDoubleNew(period);
            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                double typ = (high[i] + low[i] + close[i]) * (1.0 / 3.0);
                double bar = typ * volume[i];
                if (typ > yTyp)
                {
                    BufferPush(ref up, bar);
                    BufferPush(ref down, 0.0);
                }
                else if (typ < yTyp)
                {
                    BufferPush(ref down, bar);
                    BufferPush(ref up, 0.0);
                }
                else
                {
                    BufferPush(ref up, 0.0);
                    BufferPush(ref down, 0.0);
                }

                yTyp = typ;
                if (i >= period)
                {
                    output[outputIndex++] = up.sum / (up.sum + down.sum) * 100.0;
                }
            }

            return TI_OKAY;
        }

        private static int Mfi(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] close = inputs[2];
            decimal[] volume = inputs[3];
            int period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MfiStart(options))
            {
                return TI_OKAY;
            }

            decimal[] output = outputs[0];
            decimal yTyp = (high[0] + low[0] + close[0]) * (Decimal.One / 3m);
            var up = BufferDecimalNew(period);
            var down = BufferDecimalNew(period);
            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                decimal typ = (high[i] + low[i] + close[i]) * (Decimal.One / 3m);
                decimal bar = typ * volume[i];
                if (typ > yTyp)
                {
                    BufferPush(ref up, bar);
                    BufferPush(ref down, Decimal.Zero);
                }
                else if (typ < yTyp)
                {
                    BufferPush(ref down, bar);
                    BufferPush(ref up, Decimal.Zero);
                }
                else
                {
                    BufferPush(ref up, Decimal.Zero);
                    BufferPush(ref down, Decimal.Zero);
                }

                yTyp = typ;
                if (i >= period)
                {
                    output[outputIndex++] = up.sum / (up.sum + down.sum) * 100m;
                }
            }

            return TI_OKAY;
        }
    }
}
