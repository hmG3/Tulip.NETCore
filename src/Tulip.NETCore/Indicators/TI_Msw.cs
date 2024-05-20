namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int MswStart(T[] options) => Int32.CreateTruncating(options[0]);

    private static int Msw(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= MswStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var (sine, lead) = outputs;

        T tpi = TTwo * T.Pi;
        int sineIndex = default;
        int leadIndex = default;
        for (var i = period; i < size; ++i)
        {
            T rp = T.Zero;
            T ip = T.Zero;
            for (var j = 0; j < period; ++j)
            {
                T weight = input[i - j];
                rp += T.Cos(tpi * T.CreateChecked(j) / T.CreateChecked(period)) * weight;
                ip += T.Sin(tpi * T.CreateChecked(j) / T.CreateChecked(period)) * weight;
            }

            T phase;
            if (T.Abs(rp) > T.CreateChecked(0.001))
            {
                phase = T.Atan(ip / rp);
            }
            else
            {
                phase = tpi / TTwo * (ip < T.Zero ? T.NegativeZero : T.Zero);
            }

            if (rp < T.Zero)
            {
                phase += T.Pi;
            }

            phase += T.Pi / TTwo;
            if (phase < T.Zero)
            {
                phase += tpi;
            }

            if (phase > tpi)
            {
                phase -= tpi;
            }

            sine[sineIndex++] = T.Sin(phase);
            lead[leadIndex++] = T.Sin(phase + T.Pi / T.CreateChecked(4));
        }

        return TI_OKAY;
    }
}
