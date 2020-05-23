using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AsinStart(double[] options) => 0;

        private static int AsinStart(decimal[] options) => 0;

        private static int Asin(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Asin);

            return TI_OKAY;
        }

        private static int Asin(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], DecimalMath.Asin);

            return TI_OKAY;
        }
    }
}
