namespace Tulip
{
    internal static partial class Tinet
    {
        private static int MedPriceStart(double[] options)
        {
            return 0;
        }

        private static int MedPriceStart(decimal[] options)
        {
            return 0;
        }

        private static int MedPrice(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = (high[i] + low[i]) * 0.5;
            }

            return TI_OKAY;
        }

        private static int MedPrice(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = (high[i] + low[i]) * 0.5m;
            }

            return TI_OKAY;
        }
    }
}
