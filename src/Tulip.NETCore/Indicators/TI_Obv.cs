namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int ObvStart(T[] options) => 0;

    private static int Obv(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var (close, volume) = inputs;
        var output = outputs[0];

        T prev = close[0];
        T sum = T.Zero;
        int outputIndex = default;
        output[outputIndex++] = sum;
        for (var i = 1; i < size; ++i)
        {
            if (close[i] > prev)
            {
                sum += volume[i];
            }
            else if (close[i] < prev)
            {
                sum -= volume[i];
            }

            prev = close[i];
            output[outputIndex++] = sum;
        }

        return TI_OKAY;
    }
}
