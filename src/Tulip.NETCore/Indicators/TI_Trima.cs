using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int TrimaStart(double[] options) => (int) options[0] - 1;

        private static int TrimaStart(decimal[] options) => (int) options[0] - 1;

        private static int Trima(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= TrimaStart(options))
            {
                return TI_OKAY;
            }

            if (period <= 2)
            {
                return Sma(size, inputs, options, outputs);
            }

            double[] input = inputs[0];
            double[] output = outputs[0];

            double weightSum = default; // Weighted sum of previous numbers, spans one period back.
            double leadSum = default; // Flat sum of most recent numbers.
            double trailSum = default; // Flat sum of oldest numbers.
            int leadPeriod = period % 2 == 0 ? period / 2 - 1 : period / 2;
            int trailPeriod = leadPeriod + 1;
            int w = 1;
            for (var i = 0; i < period - 1; ++i)
            {
                weightSum += input[i] * w;
                if (i + 1 > period - leadPeriod)
                {
                    leadSum += input[i];
                }

                if (i + 1 <= trailPeriod)
                {
                    trailSum += input[i];
                }

                if (i + 1 < trailPeriod)
                {
                    ++w;
                }

                if (i + 1 >= period - leadPeriod)
                {
                    --w;
                }
            }

            // Weights for 6 period TRIMA: 1 2 3 3 2 1 = 12
            // Weights for 7 period TRIMA: 1 2 3 4 3 2 1 = 16
            double weights = 1.0 / (period % 2 != 0 ? (period / 2 + 1) * (period / 2 + 1) : (period / 2 + 1) * (period / 2));
            int lsi = period - leadPeriod;
            int tsi1 = period - period + trailPeriod;
            int tsi2 = period - period;
            int outputIndex = default;
            // Initialize until before the first value.
            for (var i = period - 1; i < size; ++i)
            {
                weightSum += input[i];
                output[outputIndex++] = weightSum * weights;

                leadSum += input[i];

                // 1 2 3 4 5 4 3 2 1
                weightSum += leadSum;
                // 1 2 3 4 5 5 4 3 2
                weightSum -= trailSum;
                //   1 2 3 4 5 4 3 2

                /* weightSum      1 2 3 4 5 4 3 2 1
                   leadSum                  1 1 1 1
                   trailSum       1 1 1 1 1         */
                leadSum -= input[lsi++];
                trailSum += input[tsi1++];
                trailSum -= input[tsi2++];
            }

            return TI_OKAY;
        }

        private static int Trima(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= TrimaStart(options))
            {
                return TI_OKAY;
            }

            if (period <= 2)
            {
                return Sma(size, inputs, options, outputs);
            }

            decimal[] input = inputs[0];
            decimal[] output = outputs[0];

            decimal weightSum = default; // Weighted sum of previous numbers, spans one period back.
            decimal leadSum = default; // Flat sum of most recent numbers.
            decimal trailSum = default; // Flat sum of oldest numbers.
            int leadPeriod = period % 2 == 0 ? period / 2 - 1 : period / 2;
            int trailPeriod = leadPeriod + 1;
            int w = 1;
            for (var i = 0; i < period - 1; ++i)
            {
                weightSum += input[i] * w;
                if (i + 1 > period - leadPeriod)
                {
                    leadSum += input[i];
                }

                if (i + 1 <= trailPeriod)
                {
                    trailSum += input[i];
                }

                if (i + 1 < trailPeriod)
                {
                    ++w;
                }

                if (i + 1 >= period - leadPeriod)
                {
                    --w;
                }
            }

            // Weights for 6 period TRIMA: 1 2 3 3 2 1 = 12
            // Weights for 7 period TRIMA: 1 2 3 4 3 2 1 = 16
            decimal weights = Decimal.One / (period % 2 != 0 ? (period / 2 + 1) * (period / 2 + 1) : (period / 2 + 1) * (period / 2));
            int lsi = period - leadPeriod;
            int tsi1 = period - period + trailPeriod;
            int tsi2 = period - period;
            int outputIndex = default;
            // Initialize until before the first value.
            for (var i = period - 1; i < size; ++i)
            {
                weightSum += input[i];
                output[outputIndex++] = weightSum * weights;

                leadSum += input[i];

                // 1 2 3 4 5 4 3 2 1
                weightSum += leadSum;
                // 1 2 3 4 5 5 4 3 2
                weightSum -= trailSum;
                //   1 2 3 4 5 4 3 2

                /* weightSum      1 2 3 4 5 4 3 2 1
                   leadSum                  1 1 1 1
                   trailSum       1 1 1 1 1         */
                leadSum -= input[lsi++];
                trailSum += input[tsi1++];
                trailSum -= input[tsi2++];
            }

            return TI_OKAY;
        }
    }
}
