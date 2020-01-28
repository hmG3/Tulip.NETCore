namespace Tulip
{
    internal static partial class Tinet
    {
        private static int PviStart(double[] options)
        {
            return 0;
        }

        private static int PviStart(decimal[] options)
        {
            return 0;
        }

        private static int Pvi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] close = inputs[0];
            double[] volume = inputs[1];
            double[] output = outputs[0];

            if (size <= PviStart(options))
            {
                return TI_OKAY;
            }

            double pvi = 1000.0;
            int outputIndex = default;
            output[outputIndex++] = pvi;
            for (var i = 1; i < size; ++i)
            {
                if (volume[i] > volume[i - 1])
                {
                    pvi += (close[i] - close[i - 1]) / close[i - 1] * pvi;
                }

                output[outputIndex++] = pvi;
            }

            return TI_OKAY;
        }

        private static int Pvi(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] close = inputs[0];
            decimal[] volume = inputs[1];
            decimal[] output = outputs[0];

            if (size <= PviStart(options))
            {
                return TI_OKAY;
            }

            decimal pvi = 1000m;
            int outputIndex = default;
            output[outputIndex++] = pvi;
            for (var i = 1; i < size; ++i)
            {
                if (volume[i] > volume[i - 1])
                {
                    pvi += (close[i] - close[i - 1]) / close[i - 1] * pvi;
                }

                output[outputIndex++] = pvi;
            }

            return TI_OKAY;
        }
    }
}
