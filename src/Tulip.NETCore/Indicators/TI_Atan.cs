using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AtanStart(double[] options) => 0;

        private static int AtanStart(decimal[] options) => 0;

        private static int Atan(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Atan);

            return TI_OKAY;
        }

        private static int Atan(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], DecimalMath.Atan);

            return TI_OKAY;
        }
    }
}
