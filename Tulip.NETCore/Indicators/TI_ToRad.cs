using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int ToRadStart(double[] options)
        {
            return 0;
        }

        private static int ToRadStart(decimal[] options)
        {
            return 0;
        }

        private static int ToRad(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            Simple1(inputs, outputs, ToRadStart(options), d => d * (Math.PI / 180.0));

            return TI_OKAY;
        }

        private static int ToRad(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            Simple1(inputs, outputs, ToRadStart(options), DecimalMath.ToRad);

            return TI_OKAY;
        }
    }
}
