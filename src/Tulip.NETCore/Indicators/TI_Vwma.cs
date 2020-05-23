namespace Tulip
{
    internal static partial class Tinet
    {
        private static int VwmaStart(double[] options) => (int) options[0] - 1;

        private static int VwmaStart(decimal[] options) => (int) options[0] - 1;

        private static int Vwma(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= VwmaStart(options))
            {
                return TI_OKAY;
            }

            double[] input = inputs[0];
            double[] volume = inputs[1];
            double[] output = outputs[0];

            double sum = default;
            double vSum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i] * volume[i];
                vSum += volume[i];
            }

            int outputIndex = default;
            output[outputIndex++] = sum / vSum;
            for (var i = period; i < size; ++i)
            {
                sum += input[i] * volume[i];
                sum -= input[i - period] * volume[i - period];
                vSum += volume[i];
                vSum -= volume[i - period];

                output[outputIndex++] = sum / vSum;
            }

            return TI_OKAY;
        }

        private static int Vwma(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= VwmaStart(options))
            {
                return TI_OKAY;
            }

            decimal[] input = inputs[0];
            decimal[] volume = inputs[1];
            decimal[] output = outputs[0];

            decimal sum = default;
            decimal vSum = default;
            for (var i = 0; i < period; ++i)
            {
                sum += input[i] * volume[i];
                vSum += volume[i];
            }

            int outputIndex = default;
            output[outputIndex++] = sum / vSum;
            for (var i = period; i < size; ++i)
            {
                sum += input[i] * volume[i];
                sum -= input[i - period] * volume[i - period];
                vSum += volume[i];
                vSum -= volume[i - period];

                output[outputIndex++] = sum / vSum;
            }

            return TI_OKAY;
        }
    }
}
