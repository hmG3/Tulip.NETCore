using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int CoshStart(double[] options)
        {
            return 0;
        }

        private static int CoshStart(decimal[] options)
        {
            return 0;
        }

        private static int Cosh(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, CoshStart(options), Math.Cosh);

            return TI_OKAY;
        }

        private static int Cosh(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, CoshStart(options), DecimalMath.Cosh);

            return TI_OKAY;
        }
    }
}
