namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int PsarStart(T[] options) => 1;

    private static int Psar(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var accelStep = options[0];
        var accelMax = options[1];

        if (accelStep <= T.Zero || accelMax <= accelStep)
        {
            return TI_INVALID_OPTION;
        }

        if (size < 2)
        {
            return TI_OKAY;
        }

        var (high, low) = inputs;
        var output = outputs[0];

        // Try to choose if we start as short or long. There is really no right answer here.
        bool lng = high[0] + low[0] <= high[1] + low[1];
        T extreme = lng ? high[0] : low[0];
        T sar = lng ? low[0] : high[0];

        T accel = accelStep;
        int outputIndex = default;
        for (var i = 1; i < size; ++i)
        {
            sar = (extreme - sar) * accel + sar;
            if (lng)
            {
                if (i >= 2 && sar > low[i - 2])
                {
                    sar = low[i - 2];
                }

                if (sar > low[i - 1])
                {
                    sar = low[i - 1];
                }

                if (accel < accelMax && high[i] > extreme)
                {
                    accel += accelStep;
                    if (accel > accelMax)
                    {
                        accel = accelMax;
                    }
                }

                if (high[i] > extreme)
                {
                    extreme = high[i];
                }
            }
            else
            {
                if (i >= 2 && sar < high[i - 2])
                {
                    sar = high[i - 2];
                }

                if (sar < high[i - 1])
                {
                    sar = high[i - 1];
                }

                if (accel < accelMax && low[i] < extreme)
                {
                    accel += accelStep;
                    if (accel > accelMax)
                    {
                        accel = accelMax;
                    }
                }

                if (low[i] < extreme)
                {
                    extreme = low[i];
                }
            }

            if (lng && low[i] < sar || lng == false && high[i] > sar)
            {
                accel = accelStep;
                sar = extreme;
                lng = !lng;
                extreme = lng ? high[i] : low[i];
            }

            output[outputIndex++] = sar;
        }

        return TI_OKAY;
    }
}
