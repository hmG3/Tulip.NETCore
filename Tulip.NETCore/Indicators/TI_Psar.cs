using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int PsarStart(double[] options)
        {
            return 1;
        }

        private static int PsarStart(decimal[] options)
        {
            return 1;
        }

        private static int Psar(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] high = inputs[0];
            double[] low = inputs[1];
            double accelStep = options[0];
            double accelMax = options[1];
            double[] output = outputs[0];

            if (accelStep <= 0.0 || accelMax <= accelStep)
            {
                return TI_INVALID_OPTION;
            }

            if (size < 2)
            {
                return TI_OKAY;
            }

            // Try to choose if we start as short or long. There is really no right answer here.
            int lng = high[0] + low[0] > high[1] + low[1] ? 0 : 1;
            double extreme = lng != 0 ? high[0] : low[0];
            double sar = lng != 0 ? low[0] : high[0];

            double accel = accelStep;
            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                sar = (extreme - sar) * accel + sar;
                if (lng != 0)
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

                if (lng != 0 && low[i] < sar || lng == 0 && high[i] > sar)
                {
                    accel = accelStep;
                    sar = extreme;
                    lng = lng != 0 ? 0 : 1;
                    extreme = lng != 0 ? high[i] : low[i];
                }

                output[outputIndex++] = sar;
            }

            return TI_OKAY;
        }

        private static int Psar(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal accelStep = options[0];
            decimal accelMax = options[1];
            decimal[] output = outputs[0];

            if (accelStep <= Decimal.Zero || accelMax <= accelStep)
            {
                return TI_INVALID_OPTION;
            }

            if (size < 2)
            {
                return TI_OKAY;
            }

            // Try to choose if we start as short or long. There is really no right answer here.
            int lng = high[0] + low[0] > high[1] + low[1] ? 0 : 1;
            decimal extreme = lng != 0 ? high[0] : low[0];
            decimal sar = lng != 0 ? low[0] : high[0];

            decimal accel = accelStep;
            int outputIndex = default;
            for (var i = 1; i < size; ++i)
            {
                sar = (extreme - sar) * accel + sar;
                if (lng != 0)
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

                if (lng != 0 && low[i] < sar || lng == 0 && high[i] > sar)
                {
                    accel = accelStep;
                    sar = extreme;
                    lng = lng != 0 ? 0 : 1;
                    extreme = lng != 0 ? high[i] : low[i];
                }

                output[outputIndex++] = sar;
            }

            return TI_OKAY;
        }
    }
}
