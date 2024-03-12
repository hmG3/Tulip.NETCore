namespace Tulip
{
    internal static partial class Tinet
    {
        private static int StochStart(double[] options) => (int) options[0] + (int) options[1] + (int) options[2] - 3;

        private static int StochStart(decimal[] options) => (int) options[0] + (int) options[1] + (int) options[2] - 3;

        private static int Stoch(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var kPeriod = (int) options[0];
            var kSlow = (int) options[1];
            var dPeriod = (int) options[2];

            if (kPeriod < 1 || kSlow < 1 || dPeriod < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= StochStart(options))
            {
                return TI_OKAY;
            }

            var (high, low, close) = inputs;
            var (stoch, stochMa) = outputs;

            double kPer = 1.0 / kSlow;
            double dPer = 1.0 / dPeriod;

            int trail = default;
            var maxi = -1;
            var mini = -1;
            double max = high[0];
            double min = low[0];
            var kSum = BufferDoubleFactory(kSlow);
            var dSum = BufferDoubleFactory(dPeriod);
            int stochIndex = default;
            int stochMaIndex = default;
            for (var i = 0; i < size; ++i)
            {
                if (i >= kPeriod)
                {
                    ++trail;
                }

                // Maintain highest.
                double bar = high[i];
                if (maxi < trail)
                {
                    maxi = trail;
                    max = high[maxi];
                    int j = trail;
                    while (++j <= i)
                    {
                        bar = high[j];
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
                bar = low[i];
                if (mini < trail)
                {
                    mini = trail;
                    min = low[mini];
                    int j = trail;
                    while (++j <= i)
                    {
                        bar = low[j];
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

                // Calculate it.
                double kDiff = max - min;
                double kFast = kDiff.Equals(0.0) ? 0.0 : 100.0 * ((close[i] - min) / kDiff);
                BufferPush(ref kSum, kFast);

                if (i >= kPeriod - 1 + kSlow - 1)
                {
                    double k = kSum.sum * kPer;
                    BufferPush(ref dSum, k);

                    if (i >= kPeriod - 1 + kSlow - 1 + dPeriod - 1)
                    {
                        stoch[stochIndex++] = k;
                        stochMa[stochMaIndex++] = dSum.sum * dPer;
                    }
                }
            }

            return TI_OKAY;
        }

        private static int Stoch(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var kPeriod = (int) options[0];
            var kSlow = (int) options[1];
            var dPeriod = (int) options[2];

            if (kPeriod < 1 || kSlow < 1 || dPeriod < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= StochStart(options))
            {
                return TI_OKAY;
            }

            var (high, low, close) = inputs;
            var (stoch, stochMa) = outputs;

            decimal kPer = Decimal.One / kSlow;
            decimal dPer = Decimal.One / dPeriod;

            int trail = default;
            var maxi = -1;
            var mini = -1;
            decimal max = high[0];
            decimal min = low[0];
            var kSum = BufferDecimalFactory(kSlow);
            var dSum = BufferDecimalFactory(dPeriod);
            int stochIndex = default;
            int stochMaIndex = default;
            for (var i = 0; i < size; ++i)
            {
                if (i >= kPeriod)
                {
                    ++trail;
                }

                // Maintain highest.
                decimal bar = high[i];
                if (maxi < trail)
                {
                    maxi = trail;
                    max = high[maxi];
                    int j = trail;
                    while (++j <= i)
                    {
                        bar = high[j];
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
                bar = low[i];
                if (mini < trail)
                {
                    mini = trail;
                    min = low[mini];
                    int j = trail;
                    while (++j <= i)
                    {
                        bar = low[j];
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

                // Calculate it.
                decimal kDiff = max - min;
                decimal kFast = kDiff == Decimal.Zero ? Decimal.Zero : 100m * ((close[i] - min) / kDiff);
                BufferPush(ref kSum, kFast);

                if (i >= kPeriod - 1 + kSlow - 1)
                {
                    decimal k = kSum.sum * kPer;
                    BufferPush(ref dSum, k);

                    if (i >= kPeriod - 1 + kSlow - 1 + dPeriod - 1)
                    {
                        stoch[stochIndex++] = k;
                        stochMa[stochMaIndex++] = dSum.sum * dPer;
                    }
                }
            }

            return TI_OKAY;
        }
    }
}
