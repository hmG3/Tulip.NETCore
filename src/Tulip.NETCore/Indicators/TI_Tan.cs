using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int TanStart(double[] options) => 0;

        private static int TanStart(decimal[] options) => 0;

        private static int Tan(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Tan);

            return TI_OKAY;
        }

        private static int Tan(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], DecimalMath.Tan);

            return TI_OKAY;
        }
    }
}
