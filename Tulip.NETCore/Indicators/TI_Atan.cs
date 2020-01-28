using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AtanStart(double[] options)
        {
            return 0;
        }

        private static int AtanStart(decimal[] options)
        {
            return 0;
        }

        private static int Atan(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, AtanStart(options), Math.Atan);

            return TI_OKAY;
        }

        private static int Atan(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, AtanStart(options), DecimalMath.Atan);

            return TI_OKAY;
        }
    }
}
