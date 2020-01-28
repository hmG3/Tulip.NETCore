using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int DecayStart(double[] options)
        {
            return 0;
        }

        private static int DecayStart(decimal[] options)
        {
            return 0;
        }

        private static int Decay(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            double[] output = outputs[0];
            var period = (int) options[0];

            double div = 1.0 / period;
            int outputIndex = default;
            output[outputIndex++] = input[0];
            for (var i = 1; i < size; ++i)
            {
                //TODO
                double d = output[^1] - div;
                output[outputIndex++] = input[i] > d ? input[i] : d;
            }

            return TI_OKAY;
        }

        private static int Decay(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            decimal[] output = outputs[0];
            var period = (int) options[0];

            decimal div = Decimal.One / period;
            int outputIndex = default;
            output[outputIndex++] = input[0];
            for (var i = 1; i < size; ++i)
            {
                //TODO
                decimal d = output[^1] - div;
                output[outputIndex++] = input[i] > d ? input[i] : d;
            }

            return TI_OKAY;
        }
    }
}
