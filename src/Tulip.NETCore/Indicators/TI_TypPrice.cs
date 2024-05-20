namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int TypPriceStart(T[] options) => 0;

    private static int TypPrice(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var (high, low, close) = inputs;
        var output = outputs[0];

        for (var i = 0; i < size; ++i)
        {
            output[i] = (high[i] + low[i] + close[i]) * (T.One / TThree);
        }

        return TI_OKAY;
    }
}
