using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int FisherStart(double[] options) => (int) options[0] - 1;

        private static int FisherStart(decimal[] options) => (int) options[0] - 1;

        private static int Fisher(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= FisherStart(options))
            {
                return TI_OKAY;
            }

            double[] high = inputs[0];
            double[] low = inputs[1];
            double[] fisher = outputs[0];
            double[] signal = outputs[1];

            var maxi = -1;
            var mini = -1;
            double max = 0.5 * (high[0] + low[0]);
            double min = 0.5 * (high[0] + low[0]);
            double val1 = default;
            double fish = default;
            int fisherIndex = default;
            int signalIndex = default;
            for (int i = period - 1, trail = 0; i < size; ++i, ++trail)
            {
                // Maintain highest.
                double bar = 0.5 * (high[i] + low[i]);
                if (maxi < trail)
                {
                    maxi = trail;
                    max = 0.5 * (high[maxi] + low[maxi]);
                    int j = trail;
                    while (++j <= i)
                    {
                        bar = 0.5 * (high[j] + low[j]);
                        if (bar >= max)
                        {
                            max = bar;
                            maxi = j;
                        }
                    }
                }
                else if (bar >= max)
                {
                    maxi = i;
                    max = bar;
                }

                // Maintain lowest.
                bar = 0.5 * (high[i] + low[i]);
                if (mini < trail)
                {
                    mini = trail;
                    min = 0.5 * (high[mini] + low[mini]);
                    int j = trail;
                    while (++j <= i)
                    {
                        bar = 0.5 * (high[j] + low[j]);
                        if (bar <= min)
                        {
                            min = bar;
                            mini = j;
                        }
                    }
                }
                else if (bar <= min)
                {
                    mini = i;
                    min = bar;
                }

                double mm = max - min;
                if (mm.Equals(0.0))
                {
                    mm = 0.001;
                }

                val1 = 0.66 * ((0.5 * (high[i] + low[i]) - min) / mm - 0.5) + 0.67 * val1;
                if (val1 > 0.99)
                {
                    val1 = 0.999;
                }

                if (val1 < -0.99)
                {
                    val1 = -0.999;
                }

                signal[signalIndex++] = fish;
                fish = 0.5 * Math.Log((1.0 + val1) / (1.0 - val1)) + 0.5 * fish;
                fisher[fisherIndex++] = fish;
            }

            return TI_OKAY;
        }

        private static int Fisher(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= FisherStart(options))
            {
                return TI_OKAY;
            }

            decimal[] high = inputs[0];
            decimal[] low = inputs[1];
            decimal[] fisher = outputs[0];
            decimal[] signal = outputs[1];

            var maxi = -1;
            var mini = -1;
            decimal max = 0.5m * (high[0] + low[0]);
            decimal min = 0.5m * (high[0] + low[0]);
            decimal val1 = default;
            decimal fish = default;
            int fisherIndex = default;
            int signalIndex = default;
            for (int i = period - 1, trail = 0; i < size; ++i, ++trail)
            {
                // Maintain highest.
                decimal bar = 0.5m * (high[i] + low[i]);
                if (maxi < trail)
                {
                    maxi = trail;
                    max = 0.5m * (high[maxi] + low[maxi]);
                    int j = trail;
                    while (++j <= i)
                    {
                        bar = 0.5m * (high[j] + low[j]);
                        if (bar >= max)
                        {
                            max = bar;
                            maxi = j;
                        }
                    }
                }
                else if (bar >= max)
                {
                    maxi = i;
                    max = bar;
                }

                // Maintain lowest.
                bar = 0.5m * (high[i] + low[i]);
                if (mini < trail)
                {
                    mini = trail;
                    min = 0.5m * (high[mini] + low[mini]);
                    int j = trail;
                    while (++j <= i)
                    {
                        bar = 0.5m * (high[j] + low[j]);
                        if (bar <= min)
                        {
                            min = bar;
                            mini = j;
                        }
                    }
                }
                else if (bar <= min)
                {
                    mini = i;
                    min = bar;
                }

                decimal mm = max - min;
                if (mm == Decimal.Zero)
                {
                    mm = 0.001m;
                }

                val1 = 0.66m * ((0.5m * (high[i] + low[i]) - min) / mm - 0.5m) + 0.67m * val1;
                if (val1 > 0.99m)
                {
                    val1 = 0.999m;
                }

                if (val1 < -0.99m)
                {
                    val1 = -0.999m;
                }

                signal[signalIndex++] = fish;
                fish = 0.5m * DecimalMath.Log((Decimal.One + val1) / (Decimal.One - val1)) + 0.5m * fish;
                fisher[fisherIndex++] = fish;
            }

            return TI_OKAY;
        }
    }
}
