namespace Tulip
{
    internal static partial class Tinet
    {
        private static int EmaStart(double[] options) => 0;

        private static int EmaStart(decimal[] options) => 0;

        private static int Ema(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= EmaStart(options))
            {
                return TI_OKAY;
            }

            double[] input = inputs[0];
            double[] output = outputs[0];

            double per = 2.0 / (period + 1);
            double val = input[0];
            int outputIndex = default;
            output[outputIndex++] = val;
            for (var i = 1; i < size; ++i)
            {
                val = (input[i] - val) * per + val;
                output[outputIndex++] = val;
            }

            return TI_OKAY;
        }

        private static int Ema(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= EmaStart(options))
            {
                return TI_OKAY;
            }

            decimal[] input = inputs[0];
            decimal[] output = outputs[0];

            decimal per = 2m / (period + 1);
            decimal val = input[0];
            int outputIndex = default;
            output[outputIndex++] = val;
            for (var i = 1; i < size; ++i)
            {
                val = (input[i] - val) * per + val;
                output[outputIndex++] = val;
            }

            return TI_OKAY;
        }
    }
}
