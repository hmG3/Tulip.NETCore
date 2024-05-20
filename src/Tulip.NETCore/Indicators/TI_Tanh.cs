namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int TanhStart(T[] options) => 0;

    private static int Tanh(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], T.Tanh);

        return TI_OKAY;
    }
}
