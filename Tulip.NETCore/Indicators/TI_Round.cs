using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int RoundStart(double[] options)
        {
            return 0;
        }

        private static int RoundStart(decimal[] options)
        {
            return 0;
        }

        private static int Round(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, RoundStart(options), Math.Round);

            return TI_OKAY;
        }

        private static int Round(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, RoundStart(options), Math.Round);

            return TI_OKAY;
        }
    }
}
