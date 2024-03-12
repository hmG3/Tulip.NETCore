namespace Tulip
{
    internal static partial class Tinet
    {
        private static int SqrtStart(double[] options) => 0;

        private static int SqrtStart(decimal[] options) => 0;

        private static int Sqrt(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Sqrt);

            return TI_OKAY;
        }

        private static int Sqrt(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], d => DecimalMath.Sqrt(d));

            return TI_OKAY;
        }
    }
}
