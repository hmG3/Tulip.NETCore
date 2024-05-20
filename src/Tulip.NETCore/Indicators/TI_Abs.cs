namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int AbsStart(T[] options) => 0;

    private static int Abs(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        Simple1(size, inputs[0], outputs[0], T.Abs);

        return TI_OKAY;
    }
}
