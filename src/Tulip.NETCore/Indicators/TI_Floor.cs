namespace Tulip;

internal static partial class Tinet
{
    private static int FloorStart(double[] options) => 0;

    private static int FloorStart(decimal[] options) => 0;

    private static int Floor(int size, double[][] inputs, double[] options, double[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], Math.Floor);

        return TI_OKAY;
    }

    private static int Floor(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], Math.Floor);

        return TI_OKAY;
    }
}
