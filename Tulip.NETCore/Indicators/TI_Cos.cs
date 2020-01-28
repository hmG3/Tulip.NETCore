using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int CosStart(double[] options)
        {
            return 0;
        }

        private static int CosStart(decimal[] options)
        {
            return 0;
        }

        private static int Cos(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, CosStart(options), Math.Cos);

            return TI_OKAY;
        }

        private static int Cos(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, CosStart(options), DecimalMath.Cos);

            return TI_OKAY;
        }
    }
}
