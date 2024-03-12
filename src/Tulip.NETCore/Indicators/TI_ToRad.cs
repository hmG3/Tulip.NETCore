namespace Tulip
{
    internal static partial class Tinet
    {
        private static int ToRadStart(double[] options) => 0;

        private static int ToRadStart(decimal[] options) => 0;

        private static int ToRad(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], d => d * (Math.PI / 180.0));

            return TI_OKAY;
        }

        private static int ToRad(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], DecimalMath.ToRad);

            return TI_OKAY;
        }
    }
}
