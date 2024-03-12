namespace Tulip
{
    internal static partial class Tinet
    {
        private static int WildersStart(double[] options) => (int) options[0] - 1;

        private static int WildersStart(decimal[] options) => (int) options[0] - 1;

        private static int Wilders(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= WildersStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            double sum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
            }

            double per = 1.0 / period;
            double val = sum / period;
            int outputIndex = default;
            output[outputIndex++] = val;
            for (var i = period; i < size; ++i)
            {
                val = (input[i] - val) * per + val;
                output[outputIndex++] = val;
            }

            return TI_OKAY;
        }

        private static int Wilders(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= WildersStart(options))
            {
                return TI_OKAY;
            }

            var input = inputs[0];
            var output = outputs[0];

            decimal sum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i];
            }

            decimal per = Decimal.One / period;
            decimal val = sum / period;
            int outputIndex = default;
            output[outputIndex++] = val;
            for (var i = period; i < size; ++i)
            {
                val = (input[i] - val) * per + val;
                output[outputIndex++] = val;
            }

            return TI_OKAY;
        }
    }
}
