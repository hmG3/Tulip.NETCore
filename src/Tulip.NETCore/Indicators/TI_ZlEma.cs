namespace Tulip
{
    internal static partial class Tinet
    {
        private static int ZlEmaStart(double[] options) => ((int) options[0] - 1) / 2 - 1;

        private static int ZlEmaStart(decimal[] options) => ((int) options[0] - 1) / 2 - 1;

        private static int ZlEma(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= ZlEmaStart(options))
            {
                return TI_OKAY;
            }

            double[] input = inputs[0];
            double[] output = outputs[0];

            int lag = (period - 1) / 2;
            double per = 2.0 / (period + 1);
            double val = input[lag - 1];
            int outputIndex = default;
            output[outputIndex++] = val;
            for (int i = lag; i < size; ++i)
            {
                double c = input[i];
                double l = input[i - lag];
                val = (c + (c - l) - val) * per + val;
                output[outputIndex++] = val;
            }

            return TI_OKAY;
        }

        private static int ZlEma(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= ZlEmaStart(options))
            {
                return TI_OKAY;
            }

            decimal[] input = inputs[0];
            decimal[] output = outputs[0];

            int lag = (period - 1) / 2;
            decimal per = 2m / (period + 1);
            decimal val = input[lag - 1];
            int outputIndex = default;
            output[outputIndex++] = val;
            for (int i = lag; i < size; ++i)
            {
                decimal c = input[i];
                decimal l = input[i - lag];
                val = (c + (c - l) - val) * per + val;
                output[outputIndex++] = val;
            }

            return TI_OKAY;
        }
    }
}
