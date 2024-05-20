namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int WcPriceStart(T[] options) => 0;

    private static int WcPrice(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var (high, low, close) = inputs;
        var output = outputs[0];

        for (var i = 0; i < size; ++i)
        {
            output[i] = (high[i] + low[i] + close[i] + close[i]) * T.CreateChecked(0.25);
        }

        return TI_OKAY;
    }
}
