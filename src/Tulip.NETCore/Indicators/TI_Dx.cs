namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int DxStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Dx(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= DxStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var output = outputs[0];

        T atr = T.Zero;
        T dmUp = T.Zero;
        T dmDown = T.Zero;
        for (var i = 1; i < period; ++i)
        {
            CalcTrueRange(low, high, close, i, out T trueRange);
            atr += trueRange;

            CalcDirection(high, low, i, out T dp, out T dm);
            dmUp += dp;
            dmDown += dm;
        }

        T per = T.CreateChecked(period - 1) / T.CreateChecked(period);
        T diUp = dmUp / atr;
        T diDown = dmDown / atr;
        T dx = T.Abs(diUp - diDown) / (diUp + diDown) * THundred;
        int outputIndex = default;
        output[outputIndex++] = dx;
        for (var i = period; i < size; ++i)
        {
            CalcTrueRange(low, high, close, i, out T trueRange);
            atr = atr * per + trueRange;

            CalcDirection(high, low, i, out T dp, out T dm);
            dmUp = dmUp * per + dp;
            dmDown = dmDown * per + dm;

            diUp = dmUp / atr;
            diDown = dmDown / atr;
            dx = T.Abs(diUp - diDown) / (diUp + diDown) * THundred;
            output[outputIndex++] = dx;
        }

        return TI_OKAY;
    }
}
