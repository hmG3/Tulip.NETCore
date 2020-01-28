using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int TruncStart(double[] options)
        {
            return 0;
        }

        private static int TruncStart(decimal[] options)
        {
            return 0;
        }

        private static int Trunc(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, TruncStart(options), Math.Truncate);

            return TI_OKAY;
        }

        private static int Trunc(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, TruncStart(options), Math.Truncate);

            return TI_OKAY;
        }
    }
}
