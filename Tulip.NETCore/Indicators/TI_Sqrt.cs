using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int SqrtStart(double[] options)
        {
            return 0;
        }

        private static int SqrtStart(decimal[] options)
        {
            return 0;
        }

        private static int Sqrt(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, SqrtStart(options), Math.Sqrt);

            return TI_OKAY;
        }

        private static int Sqrt(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, SqrtStart(options), d => DecimalMath.Sqrt(d));

            return TI_OKAY;
        }
    }
}
