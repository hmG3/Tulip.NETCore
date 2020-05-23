using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int CeilStart(double[] options) => 0;

        private static int CeilStart(decimal[] options) => 0;

        private static int Ceil(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Ceiling);

            return TI_OKAY;
        }

        private static int Ceil(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Ceiling);

            return TI_OKAY;
        }
    }
}
