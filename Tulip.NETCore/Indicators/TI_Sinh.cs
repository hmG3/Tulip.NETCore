using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int SinhStart(double[] options)
        {
            return 0;
        }

        private static int SinhStart(decimal[] options)
        {
            return 0;
        }

        private static int Sinh(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, SinhStart(options), Math.Sinh);

            return TI_OKAY;
        }

        private static int Sinh(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, SinhStart(options), DecimalMath.Sinh);

            return TI_OKAY;
        }
    }
}
