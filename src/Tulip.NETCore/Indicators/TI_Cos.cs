namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int CosStart(T[] options) => 0;

    private static int Cos(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], T.Cos);

        return TI_OKAY;
    }
}
