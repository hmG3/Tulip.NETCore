namespace Tulip
{
    internal static partial class Tinet
    {
        private static int WmaStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int WmaStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Wma(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= WmaStart(options))
            {
                return TI_OKAY;
            }

            // Weights for 6 period WMA: 1 2 3 4 5 6

            double weights = period * (period + 1) / 2.0;
            double sum = default; // Flat sum of previous numbers.
            double weightSum = default; // Weighted sum of previous numbers.
            for (var i = 0; i < period - 1; ++i)
            {
                weightSum += input[i] * (i + 1);
                sum += input[i];
            }

            int outputIndex = default;
            for (int i = period - 1; i < size; ++i)
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
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= WmaStart(options))
            {
                return TI_OKAY;
            }

            // Weights for 6 period WMA: 1 2 3 4 5 6

            decimal weights = period * (period + 1) / 2m;
            decimal sum = default; // Flat sum of previous numbers.
            decimal weightSum = default; // Weighted sum of previous numbers.
            for (var i = 0; i < period - 1; ++i)
            {
                weightSum += input[i] * (i + 1);
                sum += input[i];
            }

            int outputIndex = default;
            for (int i = period - 1; i < size; ++i)
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
