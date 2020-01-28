using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int KamaStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int KamaStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Kama(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= KamaStart(options))
            {
                return TI_OKAY;
            }

            // The caller selects the period used in the efficiency ratio.
            // The fast and slow periods are hard set by the algorithm.
            const double shortPer = 2 / (2.0 + 1);
            const double longPer = 2 / (30.0 + 1);

            double sum = default;
            for (var i = 1; i < period; ++i)
            {
                sum += Math.Abs(input[i] - input[i - 1]);
            }

            double kama = input[period - 1];
            int outputIndex = default;
            output[outputIndex++] = kama;
            for (int i = period; i < size; ++i)
            {
                sum += Math.Abs(input[i] - input[i - 1]);
                if (i > period)
                {
                    sum -= Math.Abs(input[i - period] - input[i - period - 1]);
                }

                double er = !sum.Equals(0.0) ? Math.Abs(input[i] - input[i - period]) / sum : 1.0;
                double sc = Math.Pow(er * (shortPer - longPer) + longPer, 2);

                kama += sc * (input[i] - kama);
                output[outputIndex++] = kama;
            }

            return TI_OKAY;
        }

        private static int Kama(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= KamaStart(options))
            {
                return TI_OKAY;
            }

            // The caller selects the period used in the efficiency ratio.
            // The fast and slow periods are hard set by the algorithm.
            const decimal shortPer = 2m / (2m + Decimal.One);
            const decimal longPer = 2m / (30m + Decimal.One);

            decimal sum = default;
            for (var i = 1; i < period; ++i)
            {
                sum += Math.Abs(input[i] - input[i - 1]);
            }

            decimal kama = input[period - 1];
            int outputIndex = default;
            output[outputIndex++] = kama;
            for (int i = period; i < size; ++i)
            {
                sum += Math.Abs(input[i] - input[i - 1]);
                if (i > period)
                {
                    sum -= Math.Abs(input[i - period] - input[i - period - 1]);
                }

                decimal er = sum != Decimal.Zero ? Math.Abs(input[i] - input[i - period]) / sum : Decimal.One;
                decimal sc = DecimalMath.PowerN(er * (shortPer - longPer) + longPer, 2);

                kama += sc * (input[i] - kama);
                output[outputIndex++] = kama;
            }

            return TI_OKAY;
        }
    }
}
