namespace Tulip
{
    internal static partial class Tinet
    {
        private static int MarketFiStart(double[] options)
        {
            return 0;
        }

        private static int MarketFiStart(decimal[] options)
        {
            return 0;
        }

        private static int MarketFi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] volume = inputs[2];
            double[] output = outputs[0];

            if (size <= MarketFiStart(options))
            {
                return TI_OKAY;
            }

            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                output[outputIndex++] = (high[i] - low[i]) / volume[i];
            }

            return TI_OKAY;
        }

        private static int MarketFi(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] volume = inputs[2];
            decimal[] output = outputs[0];

            if (size <= MarketFiStart(options))
            {
                return TI_OKAY;
            }

            int outputIndex = default;
            for (var i = 0; i < size; ++i)
            {
                output[outputIndex++] = (high[i] - low[i]) / volume[i];
            }

            return TI_OKAY;
        }
    }
}
