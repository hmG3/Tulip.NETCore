namespace Tulip
{
    internal static partial class Tinet
    {
        private static int MomStart(double[] options) => (int) options[0];

        private static int MomStart(decimal[] options) => (int) options[0];

        private static int Mom(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MomStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            int outputIndex = default;
            for (var i = period; i < size; ++i)
            {
                output[outputIndex++] = input[i] - input[i - period];
            }

            return TI_OKAY;
        }

        private static int Mom(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MomStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            int outputIndex = default;
            for (var i = period; i < size; ++i)
            {
                output[outputIndex++] = input[i] - input[i - period];
            }

            return TI_OKAY;
        }
    }
}
