namespace Tulip
{
    internal static partial class Tinet
    {
        private static int SubStart(double[] options) => 0;

        private static int SubStart(decimal[] options) => 0;

        private static int Sub(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple2(size, inputs[0], inputs[1], outputs[0], (d1, d2) => d1 - d2);

            return TI_OKAY;
        }

        private static int Sub(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple2(size, inputs[0], inputs[1], outputs[0], (d1, d2) => d1 - d2);

            return TI_OKAY;
        }
    }
}
