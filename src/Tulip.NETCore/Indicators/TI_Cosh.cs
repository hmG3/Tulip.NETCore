using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int CoshStart(double[] options) => 0;

        private static int CoshStart(decimal[] options) => 0;

        private static int Cosh(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Cosh);

            return TI_OKAY;
        }

        private static int Cosh(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], DecimalMath.Cosh);

            return TI_OKAY;
        }
    }
}
