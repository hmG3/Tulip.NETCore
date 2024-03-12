namespace Tulip
{
    internal static partial class Tinet
    {
        private static int LnStart(double[] options) => 0;

        private static int LnStart(decimal[] options) => 0;

        private static int Ln(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Log);

            return TI_OKAY;
        }

        private static int Ln(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], DecimalMath.Log);

            return TI_OKAY;
        }
    }
}
