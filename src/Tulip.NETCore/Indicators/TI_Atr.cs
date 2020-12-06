using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AtrStart(double[] options) => (int) options[0] - 1;

        private static int AtrStart(decimal[] options) => (int) options[0] - 1;

        private static int Atr(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= AtrStart(options))
            {
                return TI_OKAY;
            }

            var (high, low, close) = inputs;
            var output = outputs[0];

            double sum = high[0] - low[0];
            for (var i = 1; i < period; ++i)
            {
                CalcTrueRange(low, high, close, i, out double trueRange);
                sum += trueRange;
            }

            double per = 1.0 / period;
            double val = sum / period;
            int outputIndex = default;
            output[outputIndex++] = val;
            for (var i = period; i < size; ++i)
            {
                CalcTrueRange(low, high, close, i, out double trueRange);
                val = (trueRange - val) * per + val;
                output[outputIndex++] = val;
            }

            return TI_OKAY;
        }

        private static int Atr(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= AtrStart(options))
            {
                return TI_OKAY;
            }

            var (high, low, close) = inputs;
            var output = outputs[0];

            decimal sum = high[0] - low[0];
            for (var i = 1; i < period; ++i)
            {
                CalcTrueRange(low, high, close, i, out decimal trueRange);
                sum += trueRange;
            }

            decimal per = Decimal.One / period;
            decimal val = sum / period;
            int outputIndex = default;
            output[outputIndex++] = val;
            for (var i = period; i < size; ++i)
            {
                CalcTrueRange(low, high, close, i, out decimal trueRange);
                val = (trueRange - val) * per + val;
                output[outputIndex++] = val;
            }

            return TI_OKAY;
        }
    }
}
