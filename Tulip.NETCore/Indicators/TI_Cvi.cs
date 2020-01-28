using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int CviStart(double[] options)
        {
            int n = (int) options[0];
            return n * 2 - 1;
        }

        private static int CviStart(decimal[] options)
        {
            int n = (int) options[0];
            return n * 2 - 1;
        }

        private static int Cvi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= CviStart(options))
            {
                return TI_OKAY;
            }

            double per = 2.0 / (period + 1.0);
            var lag = BufferDoubleNew(period);
            double val = high[0] - low[0];
            for (var i = 1; i < period * 2 - 1; ++i)
            {
                val = (high[i] - low[i] - val) * per + val;
                BufferQPush(ref lag, val);
            }

            int outputIndex = default;
            for (int i = period * 2 - 1; i < size; ++i)
            {
                val = (high[i] - low[i] - val) * per + val;
                double old = lag.vals[lag.index];
                output[outputIndex++] = 100.0 * (val - old) / old;
                BufferQPush(ref lag, val);
            }

            return TI_OKAY;
        }

        private static int Cvi(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= CviStart(options))
            {
                return TI_OKAY;
            }

            decimal per = 2m / (period + Decimal.One);
            var lag = BufferDecimalNew(period);
            decimal val = high[0] - low[0];
            for (var i = 1; i < period * 2 - 1; ++i)
            {
                val = (high[i] - low[i] - val) * per + val;
                BufferQPush(ref lag, val);
            }

            int outputIndex = default;
            for (int i = period * 2 - 1; i < size; ++i)
            {
                val = (high[i] - low[i] - val) * per + val;
                decimal old = lag.vals[lag.index];
                output[outputIndex++] = 100m * (val - old) / old;
                BufferQPush(ref lag, val);
            }

            return TI_OKAY;
        }
    }
}
