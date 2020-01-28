using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int AbsStart(double[] options)
        {
            return 0;
        }

        private static int AbsStart(decimal[] options)
        {
            return 0;
        }

        private static int Abs(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, AbsStart(options), Math.Abs);

            return TI_OKAY;
        }

        public static int Abs(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, AbsStart(options), Math.Abs);

            return TI_OKAY;
        }
    }
}
