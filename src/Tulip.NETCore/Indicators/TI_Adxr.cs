namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int AdxrStart(T[] options) => (Int32.CreateTruncating(options[0]) - 1) * 3;

    private static int Adxr(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 2)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= AdxrStart(options))
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
        T invPer = T.One / T.CreateChecked(period);
        T adx = T.Zero;
        T diUp = dmUp / atr;
        T diDown = dmDown / atr;
        T dx = T.Abs(diUp - diDown) / (diUp + diDown) * THundred;
        adx += dx;

        var adxr = BufferFactory(period - 1);
        int firstAdxr = AdxrStart(options);

        int outputIndex = default;
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
            if (i - period < period - 2)
            {
                adx += dx;
            }
            else if (i - period == period - 2)
            {
                adx += dx;
                BufferQPush(ref adxr, adx * invPer);
            }
            else
            {
                adx = adx * per + dx;
                if (i >= firstAdxr)
                {
                    output[outputIndex++] = T.CreateChecked(0.5) * (adx * invPer + BufferGet(adxr, 1));
                }

                BufferQPush(ref adxr, adx * invPer);
            }
        }

        return TI_OKAY;
    }
}
