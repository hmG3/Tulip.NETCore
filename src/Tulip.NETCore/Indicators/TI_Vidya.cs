using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int VidyaStart(double[] options) => (int) options[1] - 2;

        private static int VidyaStart(decimal[] options) => (int) options[1] - 2;

        private static int Vidya(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            int shortPeriod = (int) options[0];
            int longPeriod = (int) options[1];
            double alpha = options[2];

            if (shortPeriod < 1 || longPeriod < shortPeriod || longPeriod < 2 || alpha < 0.0 || alpha > 1.0)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= VidyaStart(options))
            {
                return TI_OKAY;
            }

            double[] input = inputs[0];
            double[] output = outputs[0];

            double shortSum = default;
            double shortSum2 = default;
            double longSum = default;
            double longSum2 = default;
            for (var i = 0; i < longPeriod; ++i)
            {
                longSum += input[i];
                longSum2 += input[i] * input[i];
                if (i >= longPeriod - shortPeriod)
                {
                    shortSum += input[i];
                    shortSum2 += input[i] * input[i];
                }
            }

            double shortDiv = 1.0 / shortPeriod;
            double longDiv = 1.0 / longPeriod;
            double val = input[longPeriod - 2];
            int outputIndex = default;
            output[outputIndex++] = val;
            if (longPeriod - 1 < size)
            {
                var shortStdDev = Math.Sqrt(shortSum2 * shortDiv - shortSum * shortDiv * (shortSum * shortDiv));
                var longStdDev = Math.Sqrt(longSum2 * longDiv - longSum * longDiv * (longSum * longDiv));
                double k = shortStdDev / longStdDev;

                k *= alpha;
                val = (input[longPeriod - 1] - val) * k + val;
                output[outputIndex++] = val;
            }

            for (var i = longPeriod; i < size; ++i)
            {
                longSum += input[i];
                longSum2 += input[i] * input[i];

                shortSum += input[i];
                shortSum2 += input[i] * input[i];

                longSum -= input[i - longPeriod];
                longSum2 -= input[i - longPeriod] * input[i - longPeriod];

                shortSum -= input[i - shortPeriod];
                shortSum2 -= input[i - shortPeriod] * input[i - shortPeriod];

                double shortStdDev = Math.Sqrt(shortSum2 * shortDiv - shortSum * shortDiv * (shortSum * shortDiv));
                double longStdDev = Math.Sqrt(longSum2 * longDiv - longSum * longDiv * (longSum * longDiv));
                double k = shortStdDev / longStdDev;

                k *= alpha;
                val = (input[i] - val) * k + val;
                output[outputIndex++] = val;
            }

            return TI_OKAY;
        }

        private static int Vidya(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            int shortPeriod = (int) options[0];
            int longPeriod = (int) options[1];
            decimal alpha = options[2];

            if (shortPeriod < 1 || longPeriod < shortPeriod || longPeriod < 2 || alpha < Decimal.Zero || alpha > Decimal.One)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= VidyaStart(options))
            {
                return TI_OKAY;
            }

            decimal[] input = inputs[0];
            decimal[] output = outputs[0];

            decimal shortSum = default;
            decimal shortSum2 = default;
            decimal longSum = default;
            decimal longSum2 = default;
            for (var i = 0; i < longPeriod; ++i)
            {
                longSum += input[i];
                longSum2 += input[i] * input[i];
                if (i >= longPeriod - shortPeriod)
                {
                    shortSum += input[i];
                    shortSum2 += input[i] * input[i];
                }
            }

            decimal shortDiv = Decimal.One / shortPeriod;
            decimal longDiv = Decimal.One / longPeriod;
            decimal val = input[longPeriod - 2];
            int outputIndex = default;
            output[outputIndex++] = val;
            if (longPeriod - 1 < size)
            {
                var shortStdDev = DecimalMath.Sqrt(shortSum2 * shortDiv - shortSum * shortDiv * shortSum * shortDiv);
                var longStdDev = DecimalMath.Sqrt(longSum2 * longDiv - longSum * longDiv * longSum * longDiv);
                decimal k = shortStdDev / longStdDev;

                k *= alpha;
                val = (input[longPeriod - 1] - val) * k + val;
                output[outputIndex++] = val;
            }

            for (var i = longPeriod; i < size; ++i)
            {
                longSum += input[i];
                longSum2 += input[i] * input[i];

                shortSum += input[i];
                shortSum2 += input[i] * input[i];

                longSum -= input[i - longPeriod];
                longSum2 -= input[i - longPeriod] * input[i - longPeriod];

                shortSum -= input[i - shortPeriod];
                shortSum2 -= input[i - shortPeriod] * input[i - shortPeriod];

                decimal shortStdDev = DecimalMath.Sqrt(shortSum2 * shortDiv - shortSum * shortDiv * shortSum * shortDiv);
                decimal longStdDev = DecimalMath.Sqrt(longSum2 * longDiv - longSum * longDiv * longSum * longDiv);
                decimal k = shortStdDev / longStdDev;

                k *= alpha;
                val = (input[i] - val) * k + val;
                output[outputIndex++] = val;
            }

            return TI_OKAY;
        }
    }
}
