namespace Tulip
{
    internal static partial class Tinet
    {
        private static int SinStart(double[] options) => 0;

        private static int SinStart(decimal[] options) => 0;

        private static int Sin(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Sin);

            return TI_OKAY;
        }

        private static int Sin(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], DecimalMath.Sin);

            return TI_OKAY;
        }
    }
}
