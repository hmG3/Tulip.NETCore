namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int Log10Start(T[] options) => 0;

    private static int Log10(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], T.Log10);

        return TI_OKAY;
    }
}
