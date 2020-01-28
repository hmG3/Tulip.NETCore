using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int ToDegStart(double[] options)
        {
            return 0;
        }

        private static int ToDegStart(decimal[] options)
        {
            return 0;
        }

        private static int ToDeg(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, ToDegStart(options), d => d * (180.0 / Math.PI));

            return TI_OKAY;
        }

        private static int ToDeg(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, ToDegStart(options), DecimalMath.ToDeg);

            return TI_OKAY;
        }
    }
}
