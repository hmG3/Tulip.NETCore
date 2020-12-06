namespace Tulip
{
    internal static partial class Tinet
    {
        private static int MedPriceStart(double[] options) => 0;

        private static int MedPriceStart(decimal[] options) => 0;

        private static int MedPrice(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var (high, low) = inputs;
            var output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = (high[i] + low[i]) * 0.5;
            }

            return TI_OKAY;
        }

        private static int MedPrice(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var (high, low) = inputs;
            var output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = (high[i] + low[i]) * 0.5m;
            }

            return TI_OKAY;
        }
    }
}
