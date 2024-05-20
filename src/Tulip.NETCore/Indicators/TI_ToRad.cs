namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int ToRadStart(T[] options) => 0;

    private static int ToRad(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], T.DegreesToRadians);

        return TI_OKAY;
    }
}
