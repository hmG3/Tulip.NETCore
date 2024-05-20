namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int DmStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Dm(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= DmStart(options))
        {
            return TI_OKAY;
        }

        var (high, low) = inputs;
        var (plusDm, minusDm) = outputs;

        T dmUp = T.Zero;
        T dmDown = T.Zero;
        for (var i = 1; i < period; ++i)
        {
            CalcDirection(high, low, i, out T dp, out T dm);

            dmUp += dp;
            dmDown += dm;
        }

        T per = T.CreateChecked(period - 1) / T.CreateChecked(period);
        int plusDmIndex = default;
        int minusDmIndex = default;
        plusDm[plusDmIndex++] = dmUp;
        minusDm[minusDmIndex++] = dmDown;
        for (var i = period; i < size; ++i)
        {
            CalcDirection(high, low, i, out T dp, out T dm);

            dmUp = dmUp * per + dp;
            dmDown = dmDown * per + dm;
            plusDm[plusDmIndex++] = dmUp;
            minusDm[minusDmIndex++] = dmDown;
        }

        return TI_OKAY;
    }
}
