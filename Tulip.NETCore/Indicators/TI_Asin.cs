using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AsinStart(double[] options)
        {
            return 0;
        }

        private static int AsinStart(decimal[] options)
        {
            return 0;
        }

        private static int Asin(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, AsinStart(options), Math.Asin);

            return TI_OKAY;
        }

        private static int Asin(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, AsinStart(options), DecimalMath.Asin);

            return TI_OKAY;
        }
    }
}
