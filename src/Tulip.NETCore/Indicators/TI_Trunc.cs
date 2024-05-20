namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int TruncStart(T[] options) => 0;

    private static int Trunc(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], T.Truncate);

        return TI_OKAY;
    }
}
