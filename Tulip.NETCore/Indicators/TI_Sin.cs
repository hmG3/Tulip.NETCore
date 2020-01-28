using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int SinStart(double[] options)
        {
            return 0;
        }

        private static int SinStart(decimal[] options)
        {
            return 0;
        }

        private static int Sin(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, SinStart(options), Math.Sin);

            return TI_OKAY;
        }

        private static int Sin(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, SinStart(options), DecimalMath.Sin);

            return TI_OKAY;
        }
    }
}
