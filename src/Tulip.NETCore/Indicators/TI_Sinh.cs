namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int SinhStart(T[] options) => 0;

    private static int Sinh(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], T.Sinh);

        return TI_OKAY;
    }
}
