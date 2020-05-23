using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int HmaStart(double[] options) => (int) options[0] + (int) Math.Sqrt((int) options[0]) - 2;

        private static int HmaStart(decimal[] options) => (int) options[0] + (int) Math.Sqrt((int) options[0]) - 2;

        private static int Hma(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= HmaStart(options))
            {
                return TI_OKAY;
            }

            double[] input = inputs[0];
            double[] output = outputs[0];

            // HMA(input, N) = WMA((2 * WMA(input, N/2) - WMA(input, N)), sqrt(N))
            // Need to do three WMAs, with periods N, N/2, and sqrt N.

            var period2 = period / 2;
            double sum = default; // Flat sum of previous numbers.
            double weightSum = default; // Weighted sum of previous numbers.
            double sum2 = default;
            double weightSum2 = default;
            // Setup up the WMA(period) and WMA(period/2) on the input.
            for (var i = 0; i < period - 1; ++i)
            {
                weightSum += input[i] * (i + 1);
                sum += input[i];
                if (i >= period - period2)
                {
                    weightSum2 += input[i] * (i + 1 - (period - period2));
                    sum2 += input[i];
                }
            }

            var periodSqrt = (int) Math.Sqrt(period);
            double weights = period * (period + 1) / 2.0;
            double weights2 = period2 * (period2 + 1) / 2.0;
            double weightsSqrt = periodSqrt * (periodSqrt + 1) / 2.0;
            double sumSqrt = default;
            double weightSumSqrt = default;
            var buff = BufferDoubleFactory(periodSqrt);
            int outputIndex = default;
            for (var i = period - 1; i < size; ++i)
            {
                weightSum += input[i] * period;
                sum += input[i];

                weightSum2 += input[i] * period2;
                sum2 += input[i];

                double wma = weightSum / weights;
                double wma2 = weightSum2 / weights2;
                double diff = 2 * wma2 - wma;

                weightSumSqrt += diff * periodSqrt;
                sumSqrt += diff;
                BufferQPush(ref buff, diff);

                if (i >= period - 1 + (periodSqrt - 1))
                {
                    output[outputIndex++] = weightSumSqrt / weightsSqrt;

                    weightSumSqrt -= sumSqrt;
                    sumSqrt -= BufferGet(buff, 1);
                }
                else
                {
                    weightSumSqrt -= sumSqrt;
                }


                weightSum -= sum;
                sum -= input[i - period + 1];

                weightSum2 -= sum2;
                sum2 -= input[i - period2 + 1];
            }

            return TI_OKAY;
        }

        private static int Hma(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= HmaStart(options))
            {
                return TI_OKAY;
            }

            decimal[] input = inputs[0];
            decimal[] output = outputs[0];

            // HMA(input, N) = WMA((2 * WMA(input, N/2) - WMA(input, N)), sqrt(N))
            // Need to do three WMAs, with periods N, N/2, and sqrt N.

            var period2 = period / 2;
            decimal sum = default; // Flat sum of previous numbers.
            decimal weightSum = default; // Weighted sum of previous numbers.
            decimal sum2 = default;
            decimal weightSum2 = default;
            // Setup up the WMA(period) and WMA(period/2) on the input.
            for (var i = 0; i < period - 1; ++i)
            {
                weightSum += input[i] * (i + 1);
                sum += input[i];
                if (i >= period - period2)
                {
                    weightSum2 += input[i] * (i + 1 - (period - period2));
                    sum2 += input[i];
                }
            }

            var periodSqrt = (int) Math.Sqrt(period);
            decimal weights = period * (period + 1) / 2m;
            decimal weights2 = period2 * (period2 + 1) / 2m;
            decimal weightsSqrt = periodSqrt * (periodSqrt + 1) / 2m;
            decimal sumSqrt = default;
            decimal weightSumSqrt = default;
            var buff = BufferDecimalFactory(periodSqrt);
            int outputIndex = default;
            for (var i = period - 1; i < size; ++i)
            {
                weightSum += input[i] * period;
                sum += input[i];

                weightSum2 += input[i] * period2;
                sum2 += input[i];

                decimal wma = weightSum / weights;
                decimal wma2 = weightSum2 / weights2;
                decimal diff = 2 * wma2 - wma;

                weightSumSqrt += diff * periodSqrt;
                sumSqrt += diff;
                BufferQPush(ref buff, diff);

                if (i >= period - 1 + (periodSqrt - 1))
                {
                    output[outputIndex++] = weightSumSqrt / weightsSqrt;

                    weightSumSqrt -= sumSqrt;
                    sumSqrt -= BufferGet(buff, 1);
                }
                else
                {
                    weightSumSqrt -= sumSqrt;
                }


                weightSum -= sum;
                sum -= input[i - period + 1];

                weightSum2 -= sum2;
                sum2 -= input[i - period2 + 1];
            }

            return TI_OKAY;
        }
    }
}
