namespace Tulip
{
    internal static partial class Tinet
    {
        private static int DecayStart(double[] options) => 0;

        private static int DecayStart(decimal[] options) => 0;

        private static int Decay(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var input = inputs[0];
            var output = outputs[0];
            var period = (int) options[0];

            double scale = 1.0 / period;
            int outputIndex = default;
            output[outputIndex++] = input[0];
            for (var i = 1; i < size; ++i)
            {
                double d = output[i - 1] - scale;
                output[outputIndex++] = input[i] > d ? input[i] : d;
            }

            return TI_OKAY;
        }

        private static int Decay(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var input = inputs[0];
            var output = outputs[0];
            var period = (int) options[0];

            decimal scale = Decimal.One / period;
            int outputIndex = default;
            output[outputIndex++] = input[0];
            for (var i = 1; i < size; ++i)
            {
                decimal d = output[i - 1] - scale;
                output[outputIndex++] = input[i] > d ? input[i] : d;
            }

            return TI_OKAY;
        }
    }
}
