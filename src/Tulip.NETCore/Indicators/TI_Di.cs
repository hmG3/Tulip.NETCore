namespace Tulip;

internal static partial class Tinet<T> where T : IFloatingPointIeee754<T>
{
    private static int DiStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Di(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= DiStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var (plusDi, minusDi) = outputs;

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
        int plusDiIndex = default;
        int minusDiIndex = default;
        plusDi[plusDiIndex++] = THundred * dmUp / atr;
        minusDi[minusDiIndex++] = THundred * dmDown / atr;
        for (var i = period; i < size; ++i)
        {
            CalcTrueRange(low, high, close, i, out T trueRange);
            atr = atr * per + trueRange;

            CalcDirection(high, low, i, out T dp, out T dm);
            dmUp = dmUp * per + dp;
            dmDown = dmDown * per + dm;

            plusDi[plusDiIndex++] = THundred * dmUp / atr;
            minusDi[minusDiIndex++] = THundred * dmDown / atr;
        }

        return TI_OKAY;
    }
}
