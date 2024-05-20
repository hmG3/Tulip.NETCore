namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int CrossanyStart(T[] options) => 1;

    private static int Crossany(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var (a, b) = inputs;
        var output = outputs[0];

        int outputIndex = default;
        for (var i = 1; i < size; ++i)
        {
            output[outputIndex++] = a[i] > b[i] && a[i - 1] <= b[i - 1] || a[i] < b[i] && a[i - 1] >= b[i - 1] ? T.One : T.Zero;
        }

        return TI_OKAY;
    }
}
