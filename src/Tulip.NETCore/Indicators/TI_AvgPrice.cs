namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AvgPriceStart(double[] options) => 0;

        private static int AvgPriceStart(decimal[] options) => 0;

        private static int AvgPrice(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] open = inputs[0];
            double[] high = inputs[1];
            double[] low = inputs[2];
            double[] close = inputs[3];
            double[] output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = (open[i] + high[i] + low[i] + close[i]) * 0.25;
            }

            return TI_OKAY;
        }

        private static int AvgPrice(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] open = inputs[0];
            decimal[] high = inputs[1];
            decimal[] low = inputs[2];
            decimal[] close = inputs[3];
            decimal[] output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = (open[i] + high[i] + low[i] + close[i]) * 0.25m;
            }

            return TI_OKAY;
        }
    }
}
