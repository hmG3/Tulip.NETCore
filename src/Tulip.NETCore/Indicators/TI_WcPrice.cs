namespace Tulip
{
    internal static partial class Tinet
    {
        private static int WcPriceStart(double[] options) => 0;

        private static int WcPriceStart(decimal[] options) => 0;

        private static int WcPrice(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] close = inputs[2];
            double[] output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = (high[i] + low[i] + close[i] + close[i]) * 0.25;
            }

            return TI_OKAY;
        }

        private static int WcPrice(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] close = inputs[2];
            decimal[] output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = (high[i] + low[i] + close[i] + close[i]) * 0.25m;
            }

            return TI_OKAY;
        }
    }
}
