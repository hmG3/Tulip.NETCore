using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int NatrStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int NatrStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Natr(int size, double[][] inputs, double[] options, double[][] outputs)
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

            if (size <= NatrStart(options))
            {
                return TI_OKAY;
            }

            double per = 1.0 / period;
            double sum = high[0] - low[0];
            int outputIndex = default;
            for (var i = 1; i < period; ++i)
            {
                CalcTrueRange(low, high, close, i, out double trueRange);
                sum += trueRange;
            }

            double val = sum / period;
            output[outputIndex++] = 100.0 * val / close[period - 1];
            for (int i = period; i < size; ++i)
            {
                CalcTrueRange(low, high, close, i, out double trueRange);
                val = (trueRange - val) * per + val;
                output[outputIndex++] = 100.0 * val / close[i];
            }

            return TI_OKAY;
        }

        private static int Natr(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
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

            if (size <= NatrStart(options))
            {
                return TI_OKAY;
            }

            decimal per = Decimal.One / period;
            decimal sum = high[0] - low[0];
            int outputIndex = default;
            for (var i = 1; i < period; ++i)
            {
                CalcTrueRange(low, high, close, i, out decimal trueRange);
                sum += trueRange;
            }

            decimal val = sum / period;
            output[outputIndex++] = 100m * val / close[period - 1];
            for (int i = period; i < size; ++i)
            {
                CalcTrueRange(low, high, close, i, out decimal trueRange);
                val = (trueRange - val) * per + val;
                output[outputIndex++] = 100m * val / close[i];
            }

            return TI_OKAY;
        }
    }
}
