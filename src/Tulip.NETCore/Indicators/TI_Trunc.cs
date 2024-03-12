namespace Tulip
{
    internal static partial class Tinet
    {
        private static int TruncStart(double[] options) => 0;

        private static int TruncStart(decimal[] options) => 0;

        private static int Trunc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Truncate);

            return TI_OKAY;
        }

        private static int Trunc(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Truncate);

            return TI_OKAY;
        }
    }
}
