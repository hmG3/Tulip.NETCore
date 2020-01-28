using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int TanStart(double[] options)
        {
            return 0;
        }

        private static int TanStart(decimal[] options)
        {
            return 0;
        }

        private static int Tan(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, TanStart(options), Math.Tan);

            return TI_OKAY;
        }

        private static int Tan(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, TanStart(options), DecimalMath.Tan);

            return TI_OKAY;
        }
    }
}
