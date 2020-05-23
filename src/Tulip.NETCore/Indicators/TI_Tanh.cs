using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int TanhStart(double[] options) => 0;

        private static int TanhStart(decimal[] options) => 0;

        private static int Tanh(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Tanh);

            return TI_OKAY;
        }

        private static int Tanh(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], DecimalMath.Tanh);

            return TI_OKAY;
        }
    }
}
