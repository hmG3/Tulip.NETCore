using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int SinhStart(double[] options) => 0;

        private static int SinhStart(decimal[] options) => 0;

        private static int Sinh(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Sinh);

            return TI_OKAY;
        }

        private static int Sinh(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], DecimalMath.Sinh);

            return TI_OKAY;
        }
    }
}
