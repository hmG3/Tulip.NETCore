using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AbsStart(double[] options) => 0;

        private static int AbsStart(decimal[] options) => 0;

        private static int Abs(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Abs);

            return TI_OKAY;
        }

        public static int Abs(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(size, inputs[0], outputs[0], Math.Abs);

            return TI_OKAY;
        }
    }
}
