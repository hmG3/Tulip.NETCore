using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int LnStart(double[] options)
        {
            return 0;
        }

        private static int LnStart(decimal[] options)
        {
            return 0;
        }

        private static int Ln(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, LnStart(options), Math.Log);

            return TI_OKAY;
        }

        private static int Ln(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, LnStart(options), DecimalMath.Log);

            return TI_OKAY;
        }
    }
}
