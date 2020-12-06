namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AvgPriceStart(double[] options) => 0;

        private static int AvgPriceStart(decimal[] options) => 0;

        private static int AvgPrice(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var (open, high, low, close) = inputs;
            var output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = (open[i] + high[i] + low[i] + close[i]) * 0.25;
            }

            return TI_OKAY;
        }

        private static int AvgPrice(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var (open, high, low, close) = inputs;
            var output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = (open[i] + high[i] + low[i] + close[i]) * 0.25m;
            }

            return TI_OKAY;
        }
    }
}
