namespace Tulip
{
    internal static partial class Tinet
    {
        private static int ObvStart(double[] options) => 0;

        private static int ObvStart(decimal[] options) => 0;

        private static int Obv(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] close = inputs[0];
            double[] volume = inputs[1];
            double[] output = outputs[0];

            double prev = close[0];
            double sum = default;
            int outputIndex = default;
            output[outputIndex++] = sum;
            for (var i = 1; i < size; ++i)
            {
                if (close[i] > prev)
                {
                    sum += volume[i];
                }
                else if (close[i] < prev)
                {
                    sum -= volume[i];
                }

                prev = close[i];
                output[outputIndex++] = sum;
            }

            return TI_OKAY;
        }

        private static int Obv(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] close = inputs[0];
            decimal[] volume = inputs[1];
            decimal[] output = outputs[0];

            decimal prev = close[0];
            decimal sum = default;
            int outputIndex = default;
            output[outputIndex++] = sum;
            for (var i = 1; i < size; ++i)
            {
                if (close[i] > prev)
                {
                    sum += volume[i];
                }
                else if (close[i] < prev)
                {
                    sum -= volume[i];
                }

                prev = close[i];
                output[outputIndex++] = sum;
            }

            return TI_OKAY;
        }
    }
}
