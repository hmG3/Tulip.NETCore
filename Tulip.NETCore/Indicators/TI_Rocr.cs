namespace Tulip
{
    internal static partial class Tinet
    {
        private static int RocRStart(double[] options)
        {
            return (int) options[0];
        }

        private static int RocRStart(decimal[] options)
        {
            return (int) options[0];
        }

        private static int RocR(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= RocRStart(options))
            {
                return TI_OKAY;
            }

            int outputIndex = default;
            for (int i = period; i < size; ++i)
            {
                output[outputIndex++] = input[i] / input[i - period];
            }

            return TI_OKAY;
        }

        private static int RocR(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= RocRStart(options))
            {
                return TI_OKAY;
            }

            int outputIndex = default;
            for (int i = period; i < size; ++i)
            {
                output[outputIndex++] = input[i] / input[i - period];
            }

            return TI_OKAY;
        }
    }
}
