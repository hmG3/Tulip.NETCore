using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int CciStart(double[] options)
        {
            int period = (int) options[0];
            return (period - 1) * 2;
        }

        private static int CciStart(decimal[] options)
        {
            int period = (int) options[0];
            return (period - 1) * 2;
        }

        private static int Cci(int size, double[][] inputs, double[] options, double[][] outputs)
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

            if (size <= CciStart(options))
            {
                return TI_OKAY;
            }

            double div = 1.0 / period;
            var sum = BufferDoubleNew(period);
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                double today = (high[i] + low[i] + close[i]) * (1.0 / 3.0);
                BufferPush(ref sum, today);

                double avg = sum.sum * div;
                if (i >= period * 2 - 2)
                {
                    double acc = 0.0;
                    for (var j = 0; j < period; ++j)
                    {
                        acc += Math.Abs(avg - sum.vals[j]);
                    }

                    double cci = acc * div * 0.015;
                    cci = (today - avg) / cci;
                    output[outputIndex++] = cci;
                }
            }

            return TI_OKAY;
        }

        private static int Cci(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
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

            if (size <= CciStart(options))
            {
                return TI_OKAY;
            }

            decimal div = Decimal.One / period;
            var sum = BufferDecimalNew(period);
            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                decimal today = (high[i] + low[i] + close[i]) * (Decimal.One / 3m);
                BufferPush(ref sum, today);

                decimal avg = sum.sum * div;
                if (i >= period * 2 - 2)
                {
                    decimal acc = Decimal.Zero;
                    for (var j = 0; j < period; ++j)
                    {
                        acc += Math.Abs(avg - sum.vals[j]);
                    }

                    decimal cci = acc * div * 0.015m;
                    cci = (today - avg) / cci;
                    output[outputIndex++] = cci;
                }
            }

            return TI_OKAY;
        }
    }
}
