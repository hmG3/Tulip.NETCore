namespace Tulip;

internal static partial class Tinet
{
    private static int Log10Start(double[] options) => 0;

    private static int Log10Start(decimal[] options) => 0;

    private static int Log10(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], Math.Log10);

        return TI_OKAY;
    }

    private static int Log10(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], DecimalMath.Log10);

        return TI_OKAY;
    }
}
