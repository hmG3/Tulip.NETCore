namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int AddStart(T[] options) => 0;

    private static int Add(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        Simple2(size, inputs[0], inputs[1], outputs[0], (d1, d2) => d1 + d2);

        return TI_OKAY;
    }
}
