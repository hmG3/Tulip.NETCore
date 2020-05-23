using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int CosStart(double[] options) => 0;

        private static int CosStart(decimal[] options) => 0;

        private static int Cos(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Cos);

            return TI_OKAY;
        }

        private static int Cos(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], DecimalMath.Cos);

            return TI_OKAY;
        }
    }
}
