namespace Tulip
{
    internal static partial class Tinet
    {
        private static int SubStart(double[] options)
        {
            return 0;
        }

        private static int SubStart(decimal[] options)
        {
            return 0;
        }

        private static int Sub(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] in1 = inputs[0];
            double[] in2 = inputs[1];
            double[] output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = in1[i] - in2[i];
            }

            return TI_OKAY;
        }

        private static int Sub(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] in1 = inputs[0];
            decimal[] in2 = inputs[1];
            decimal[] output = outputs[0];

            for (var i = 0; i < size; ++i)
            {
                output[i] = in1[i] - in2[i];
            }

            return TI_OKAY;
        }
    }
}
