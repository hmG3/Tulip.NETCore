namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int CeilStart(T[] options) => 0;

    private static int Ceil(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], T.Ceiling);

        return TI_OKAY;
    }
}
