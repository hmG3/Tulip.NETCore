using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int ExpStart(double[] options)
        {
            return 0;
        }

        private static int ExpStart(decimal[] options)
        {
            return 0;
        }

        private static int Exp(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, ExpStart(options), Math.Exp);

            return TI_OKAY;
        }

        private static int Exp(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, ExpStart(options), DecimalMath.Exp);

            return TI_OKAY;
        }
    }
}
