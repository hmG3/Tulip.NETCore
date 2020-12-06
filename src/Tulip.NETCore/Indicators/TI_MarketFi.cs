namespace Tulip
{
    internal static partial class Tinet
    {
        private static int MarketFiStart(double[] options) => 0;

        private static int MarketFiStart(decimal[] options) => 0;

        private static int MarketFi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            if (size <= MarketFiStart(options))
            {
                return TI_OKAY;
            }

            var (high, low, volume) = inputs;
            var output = outputs[0];

            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                output[outputIndex++] = (high[i] - low[i]) / volume[i];
            }

            return TI_OKAY;
        }

        private static int MarketFi(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            if (size <= MarketFiStart(options))
            {
                return TI_OKAY;
            }

            var (high, low, volume) = inputs;
            var output = outputs[0];

            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                output[outputIndex++] = (high[i] - low[i]) / volume[i];
            }

            return TI_OKAY;
        }
    }
}
