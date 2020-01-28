using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int FloorStart(double[] options)
        {
            return 0;
        }

        private static int FloorStart(decimal[] options)
        {
            return 0;
        }

        private static int Floor(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, FloorStart(options), Math.Floor);

            return TI_OKAY;
        }

        private static int Floor(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, FloorStart(options), Math.Floor);

            return TI_OKAY;
        }
    }
}
