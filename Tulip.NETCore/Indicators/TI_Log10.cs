using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int Log10Start(double[] options)
        {
            return 0;
        }

        private static int Log10Start(decimal[] options)
        {
            return 0;
        }

        private static int Log10(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, Log10Start(options), Math.Log10);

            return TI_OKAY;
        }

        private static int Log10(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, Log10Start(options), DecimalMath.Log10);

            return TI_OKAY;
        }
    }
}
