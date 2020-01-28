using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int CeilStart(double[] options)
        {
            return 0;
        }

        private static int CeilStart(decimal[] options)
        {
            return 0;
        }

        private static int Ceil(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, CeilStart(options), Math.Ceiling);

            return TI_OKAY;
        }

        private static int Ceil(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, CeilStart(options), Math.Ceiling);

            return TI_OKAY;
        }
    }
}
