namespace Tulip
{
    internal static partial class Tinet
    {
        private static int ToDegStart(double[] options) => 0;

        private static int ToDegStart(decimal[] options) => 0;

        private static int ToDeg(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], d => d * (180.0 / Math.PI));

            return TI_OKAY;
        }

        private static int ToDeg(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], DecimalMath.ToDeg);

            return TI_OKAY;
        }
    }
}
