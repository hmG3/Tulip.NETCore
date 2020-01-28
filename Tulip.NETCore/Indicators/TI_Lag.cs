namespace Tulip
{
    internal static partial class Tinet
    {
        private static int LagStart(double[] options)
        {
            return (int) options[0];
        }

        private static int LagStart(decimal[] options)
        {
            return (int) options[0];
        }

        private static int Lag(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 0)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= LagStart(options))
            {
                return TI_OKAY;
            }

            int outputIndex = default;
            for (int i = period; i < size; ++i)
            {
                output[outputIndex++] = input[i - period];
            }

            return TI_OKAY;
        }

        private static int Lag(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 0)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= LagStart(options))
            {
                return TI_OKAY;
            }

            int outputIndex = default;
            for (int i = period; i < size; ++i)
            {
                output[outputIndex++] = input[i - period];
            }

            return TI_OKAY;
        }
    }
}
