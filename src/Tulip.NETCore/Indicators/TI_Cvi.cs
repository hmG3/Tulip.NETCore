namespace Tulip
{
    internal static partial class Tinet
    {
        private static int CviStart(double[] options) => (int) options[0] * 2 - 1;

        private static int CviStart(decimal[] options) => (int) options[0] * 2 - 1;

        private static int Cvi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= CviStart(options))
            {
                return TI_OKAY;
            }

            var (high, low) = inputs;
            var output = outputs[0];

            double per = 2.0 / (period + 1);
            var lag = BufferDoubleFactory(period);
            double val = high[0] - low[0];
            for (var i = 1; i < period * 2 - 1; ++i)
            {
                val = (high[i] - low[i] - val) * per + val;
                BufferQPush(ref lag, val);
            }

            int outputIndex = default;
            for (var i = period * 2 - 1; i < size; ++i)
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
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= CviStart(options))
            {
                return TI_OKAY;
            }

            var (high, low) = inputs;
            var output = outputs[0];

            decimal per = 2m / (period + 1);
            var lag = BufferDecimalFactory(period);
            decimal val = high[0] - low[0];
            for (var i = 1; i < period * 2 - 1; ++i)
            {
                val = (high[i] - low[i] - val) * per + val;
                BufferQPush(ref lag, val);
            }

            int outputIndex = default;
            for (var i = period * 2 - 1; i < size; ++i)
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
