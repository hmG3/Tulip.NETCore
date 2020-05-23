namespace Tulip
{
    internal static partial class Tinet
    {
        private static int RocStart(double[] options) => (int) options[0];

        private static int RocStart(decimal[] options) => (int) options[0];

        private static int Roc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= RocStart(options))
            {
                return TI_OKAY;
            }

            double[] input = inputs[0];
            double[] output = outputs[0];

            int outputIndex = default;
            for (var i = period; i < size; ++i)
            {
                output[outputIndex++] = (input[i] - input[i - period]) / input[i - period];
            }

            return TI_OKAY;
        }

        private static int Roc(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= RocStart(options))
            {
                return TI_OKAY;
            }

            decimal[] input = inputs[0];
            decimal[] output = outputs[0];

            int outputIndex = default;
            for (var i = period; i < size; ++i)
            {
                output[outputIndex++] = (input[i] - input[i - period]) / input[i - period];
            }

            return TI_OKAY;
        }
    }
}
