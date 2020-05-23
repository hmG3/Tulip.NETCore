namespace Tulip
{
    internal static partial class Tinet
    {
        private static int WmaStart(double[] options) => (int) options[0] - 1;

        private static int WmaStart(decimal[] options) => (int) options[0] - 1;

        private static int Wma(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= WmaStart(options))
            {
                return TI_OKAY;
            }

            double[] input = inputs[0];
            double[] output = outputs[0];

            double weightSum = default; // Weighted sum of previous numbers.
            double sum = default; // Flat sum of previous numbers.
            for (var i = 0; i < period - 1; ++i)
            {
                weightSum += input[i] * (i + 1);
                sum += input[i];
            }

            double weights = period * (period + 1) / 2.0; // Weights for 6 period WMA: 1 2 3 4 5 6
            int outputIndex = default;
            for (var i = period - 1; i < size; ++i)
            {
                weightSum += input[i] * period;
                sum += input[i];

                output[outputIndex++] = weightSum / weights;

                weightSum -= sum;
                sum -= input[i - period + 1];
            }

            return TI_OKAY;
        }

        private static int Wma(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= WmaStart(options))
            {
                return TI_OKAY;
            }

            decimal[] input = inputs[0];
            decimal[] output = outputs[0];

            decimal weightSum = default; // Weighted sum of previous numbers.
            decimal sum = default; // Flat sum of previous numbers.
            for (var i = 0; i < period - 1; ++i)
            {
                weightSum += input[i] * (i + 1);
                sum += input[i];
            }

            decimal weights = period * (period + 1) / 2m; // Weights for 6 period WMA: 1 2 3 4 5 6
            int outputIndex = default;
            for (var i = period - 1; i < size; ++i)
            {
                weightSum += input[i] * period;
                sum += input[i];

                output[outputIndex++] = weightSum / weights;

                weightSum -= sum;
                sum -= input[i - period + 1];
            }

            return TI_OKAY;
        }
    }
}
