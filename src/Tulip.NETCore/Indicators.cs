using System;

namespace Tulip
{
    public static class Indicators
    {
        public static Indicator abs = new Indicator(0, nameof(abs), "Vector Absolute Value", "real", String.Empty, nameof(abs));

        public static Indicator acos = new Indicator(1, nameof(acos), "Vector Arccosine", "real", String.Empty, nameof(acos));

        public static Indicator ad =
            new Indicator(2, nameof(ad), "Accumulation/Distribution Line", "high|low|close|volume", String.Empty, nameof(ad));

        public static Indicator add = new Indicator(3, nameof(add), "Vector Addition", "real|real", String.Empty, nameof(add));

        public static Indicator adosc =
            new Indicator(4, nameof(adosc), "Accumulation/Distribution Oscillator", "high|low|close|volume", "short period|long period",
                nameof(adosc));

        public static Indicator adx = new Indicator(5, nameof(adx), "Average Directional Movement Index", "high|low|close", "period",
            nameof(dx));

        public static Indicator adxr = new Indicator(6, nameof(adxr), "Average Directional Movement Rating", "high|low|close", "period",
            nameof(dx));

        public static Indicator ao = new Indicator(7, nameof(ao), "Awesome Oscillator", "high|low", String.Empty, nameof(ao));

        public static Indicator apo =
            new Indicator(8, nameof(apo), "Absolute Price Oscillator", "real", "short period|long period", nameof(apo));

        public static Indicator aroon = new Indicator(9, nameof(aroon), "Aroon", "high|low", "period", "aroon_down|aroon_up");

        public static Indicator aroonosc = new Indicator(10, nameof(aroonosc), "Aroon Oscillator", "high|low", "period", nameof(aroonosc));

        public static Indicator asin = new Indicator(11, nameof(asin), "Vector Arcsine", "real", String.Empty, nameof(asin));

        public static Indicator atan = new Indicator(12, nameof(atan), "Vector Arctangent", "real", String.Empty, nameof(atan));

        public static Indicator atr = new Indicator(13, nameof(atr), "Average True Range", "high|low|close", "period", nameof(atr));

        public static Indicator avgprice =
            new Indicator(14, nameof(avgprice), "Average Price", "open|high|low|close", String.Empty, nameof(avgprice));

        public static Indicator bbands =
            new Indicator(15, nameof(bbands), "Bollinger Bands", "real", "period|stddev", "bbands_lower|bbands_middle|bbands_upper");

        public static Indicator bop = new Indicator(16, nameof(bop), "Balance of Power", "open|high|low|close", String.Empty, nameof(bop));

        public static Indicator cci = new Indicator(17, nameof(cci), "Commodity Channel Index", "high|low|close", "period", nameof(cci));

        public static Indicator ceil = new Indicator(18, nameof(ceil), "Vector Ceiling", "real", String.Empty, nameof(ceil));

        public static Indicator cmo = new Indicator(19, nameof(cmo), "Chande Momentum Oscillator", "real", "period", nameof(cmo));

        public static Indicator cos = new Indicator(20, nameof(cos), "Vector Cosine", "real", String.Empty, nameof(cos));

        public static Indicator cosh = new Indicator(21, nameof(cosh), "Vector Hyperbolic Cosine", "real", String.Empty, nameof(cosh));

        public static Indicator crossany = new Indicator(22, nameof(crossany), "Crossany", "real|real", String.Empty, nameof(crossany));

        public static Indicator crossover = new Indicator(23, nameof(crossover), "Crossover", "real|real", String.Empty, nameof(crossover));

        public static Indicator cvi = new Indicator(24, nameof(cvi), "Chaikins Volatility", "high|low", "period", nameof(cvi));

        public static Indicator decay = new Indicator(25, nameof(decay), "Linear Decay", "real", "period", nameof(decay));

        public static Indicator dema = new Indicator(26, nameof(dema), "Double Exponential Moving Average", "real", "period", nameof(dema));

        public static Indicator di = new Indicator(27, nameof(di), "Directional Indicator", "high|low|close", "period", "plus_di|minus_di");

        public static Indicator div = new Indicator(28, nameof(div), "Vector Division", "real|real", String.Empty, nameof(div));

        public static Indicator dm = new Indicator(29, nameof(dm), "Directional Movement", "high|low", "period", "plus_dm|minus_dm");

        public static Indicator dpo = new Indicator(30, nameof(dpo), "Detrended Price Oscillator", "real", "period", nameof(dpo));

        public static Indicator dx = new Indicator(31, nameof(dx), "Directional Movement Index", "high|low|close", "period", nameof(dx));

        public static Indicator edecay = new Indicator(32, nameof(edecay), "Exponential Decay", "real", "period", nameof(edecay));

        public static Indicator ema = new Indicator(33, nameof(ema), "Exponential Moving Average", "real", "period", nameof(ema));

        public static Indicator emv = new Indicator(34, nameof(emv), "Ease of Movement", "high|low|volume", String.Empty, nameof(emv));

        public static Indicator exp = new Indicator(35, nameof(exp), "Vector Exponential", "real", String.Empty, nameof(exp));

        public static Indicator fisher =
            new Indicator(36, nameof(fisher), "Fisher Transform", "high|low", "period", "fisher|fisher_signal");

        public static Indicator floor = new Indicator(37, nameof(floor), "Vector Floor", "real", String.Empty, nameof(floor));

        public static Indicator fosc = new Indicator(38, nameof(fosc), "Forecast Oscillator", "real", "period", nameof(fosc));

        public static Indicator hma = new Indicator(39, nameof(hma), "Hull Moving Average", "real", "period", nameof(hma));

        public static Indicator kama = new Indicator(40, nameof(kama), "Kaufman Adaptive Moving Average", "real", "period", nameof(kama));

        public static Indicator kvo =
            new Indicator(41, nameof(kvo), "Klinger Volume Oscillator", "high|low|close|volume", "short period|long period", nameof(kvo));

        public static Indicator lag = new Indicator(42, nameof(lag), "Lag", "real", "period", nameof(lag));

        public static Indicator linreg = new Indicator(43, nameof(linreg), "Linear Regression", "real", "period", nameof(linreg));

        public static Indicator linregintercept =
            new Indicator(44, nameof(linregintercept), "Linear Regression Intercept", "real", "period", nameof(linregintercept));

        public static Indicator linregslope =
            new Indicator(45, nameof(linregslope), "Linear Regression Slope", "real", "period", nameof(linregslope));

        public static Indicator ln = new Indicator(46, nameof(ln), "Vector Natural Log", "real", String.Empty, nameof(ln));

        public static Indicator log10 = new Indicator(47, nameof(log10), "Vector Base-10 Log", "real", String.Empty, nameof(log10));

        public static Indicator macd =
            new Indicator(48, nameof(macd), "Moving Average Convergence/Divergence", "real", "short period|long period|signal period",
                "macd|macd_signal|macd_histogram");

        public static Indicator marketfi =
            new Indicator(49, nameof(marketfi), "Market Facilitation Index", "high|low|volume", String.Empty, nameof(marketfi));

        public static Indicator mass = new Indicator(50, nameof(mass), "Mass Index", "high|low", "period", nameof(mass));

        public static Indicator max = new Indicator(51, nameof(max), "Maximum In Period", "real", "period", nameof(max));

        public static Indicator md = new Indicator(52, nameof(md), "Mean Deviation Over Period", "real", "period", nameof(md));

        public static Indicator medprice = new Indicator(53, nameof(medprice), "Median Price", "high|low", String.Empty, nameof(medprice));

        public static Indicator mfi = new Indicator(54, nameof(mfi), "Money Flow Index", "high|low|close|volume", "period", nameof(mfi));

        public static Indicator min = new Indicator(55, nameof(min), "Minimum In Period", "real", "period", nameof(min));

        public static Indicator mom = new Indicator(56, nameof(mom), "Momentum", "real", "period", nameof(mom));

        public static Indicator msw = new Indicator(57, nameof(msw), "Mesa Sine Wave", "real", "period", "msw_sine|msw_lead");

        public static Indicator mul = new Indicator(58, nameof(mul), "Vector Multiplication", "real|real", String.Empty, nameof(mul));

        public static Indicator natr =
            new Indicator(59, nameof(natr), "Normalized Average True Range", "high|low|close", "period", nameof(natr));

        public static Indicator nvi = new Indicator(60, nameof(nvi), "Negative Volume Index", "close|volume", String.Empty, nameof(nvi));

        public static Indicator obv = new Indicator(61, nameof(obv), "On Balance Volume", "close|volume", String.Empty, nameof(obv));

        public static Indicator ppo = new Indicator(62, nameof(ppo), "Percentage Price Oscillator", "real", "short period|long period",
            nameof(ppo));

        public static Indicator psar =
            new Indicator(63, nameof(psar), "Parabolic SAR", "high|low", "acceleration factor step|acceleration factor maximum",
                nameof(psar));

        public static Indicator pvi = new Indicator(64, nameof(pvi), "Positive Volume Index", "close|volume", String.Empty, nameof(pvi));

        public static Indicator qstick = new Indicator(65, nameof(qstick), "Qstick", "open|close", "period", nameof(qstick));

        public static Indicator roc = new Indicator(66, nameof(roc), "Rate of Change", "real", "period", nameof(roc));

        public static Indicator rocr = new Indicator(67, nameof(rocr), "Rate of Change Ratio", "real", "period", nameof(rocr));

        public static Indicator round = new Indicator(68, nameof(round), "Vector Round", "real", String.Empty, nameof(round));

        public static Indicator rsi = new Indicator(69, nameof(rsi), "Relative Strength Index", "real", "period", nameof(rsi));

        public static Indicator sin = new Indicator(70, nameof(sin), "Vector Sine", "real", String.Empty, nameof(sin));

        public static Indicator sinh = new Indicator(71, nameof(sinh), "Vector Hyperbolic Sine", "real", String.Empty, nameof(sinh));

        public static Indicator sma = new Indicator(72, nameof(sma), "Simple Moving Average", "real", "period", nameof(sma));

        public static Indicator sqrt = new Indicator(73, nameof(sqrt), "Vector Square Root", "real", String.Empty, nameof(sqrt));

        public static Indicator stddev =
            new Indicator(74, nameof(stddev), "Standard Deviation Over Period", "real", "period", nameof(stddev));

        public static Indicator stderr =
            new Indicator(75, nameof(stderr), "Standard Error Over Period", "real", "period", nameof(stderr));

        public static Indicator stoch =
            new Indicator(76, nameof(stoch), "Stochastic Oscillator", "high|low|close", "%k period|%k slowing period|%d period",
                "stoch_k|stoch_d");

        public static Indicator stochrsi =
            new Indicator(77, nameof(stochrsi), "Stochastic RSI", "real", "period", nameof(stochrsi));

        public static Indicator sub = new Indicator(78, nameof(sub), "Vector Subtraction", "real|real", String.Empty, nameof(sub));

        public static Indicator sum = new Indicator(79, nameof(sum), "Sum Over Period", "real", "period", nameof(sum));

        public static Indicator tan = new Indicator(80, nameof(tan), "Vector Tangent", "real", String.Empty, nameof(tan));

        public static Indicator tanh = new Indicator(81, nameof(tanh), "Vector Hyperbolic Tangent", "real", String.Empty, nameof(tanh));

        public static Indicator tema = new Indicator(82, nameof(tema), "Triple Exponential Moving Average", "real", "period", nameof(tema));

        public static Indicator todeg = new Indicator(83, nameof(todeg), "Vector Degree Conversion", "real", String.Empty, "degrees");

        public static Indicator torad = new Indicator(84, nameof(torad), "Vector Radian Conversion", "real", String.Empty, "radians");

        public static Indicator tr = new Indicator(85, nameof(tr), "True Range", "high|low|close", String.Empty, nameof(tr));

        public static Indicator trima = new Indicator(86, nameof(trima), "Triangular Moving Average", "real", "period", nameof(trima));

        public static Indicator trix = new Indicator(87, nameof(trix), "Trix", "real", "period", nameof(trix));

        public static Indicator trunc = new Indicator(88, nameof(trunc), "Vector Truncate", "real", String.Empty, nameof(trunc));

        public static Indicator tsf = new Indicator(89, nameof(tsf), "Time Series Forecast", "real", "period", nameof(tsf));

        public static Indicator typprice =
            new Indicator(90, nameof(typprice), "Typical Price", "high|low|close", String.Empty, nameof(typprice));

        public static Indicator ultosc =
            new Indicator(91, nameof(ultosc), "Ultimate Oscillator", "high|low|close", "short period|medium period|long period",
                nameof(ultosc));

        public static Indicator var = new Indicator(92, nameof(var), "Variance Over Period", "real", "period", nameof(var));

        public static Indicator vhf = new Indicator(93, nameof(vhf), "Vertical Horizontal Filter", "real", "period", nameof(vhf));

        public static Indicator vidya =
            new Indicator(94, nameof(vidya), "Variable Index Dynamic Average", "real", "short period|long period|alpha", nameof(vidya));

        public static Indicator volatility =
            new Indicator(95, nameof(volatility), "Annualized Historical Volatility", "real", "period", nameof(volatility));

        public static Indicator vosc =
            new Indicator(96, nameof(vosc), "Volume Oscillator", "volume", "short period|long period", nameof(vosc));

        public static Indicator vwma =
            new Indicator(97, nameof(vwma), "Volume Weighted Moving Average", "close|volume", "period", nameof(vwma));

        public static Indicator wad =
            new Indicator(98, nameof(wad), "Williams Accumulation/Distribution", "high|low|close", String.Empty, nameof(wad));

        public static Indicator wcprice =
            new Indicator(99, nameof(wcprice), "Weighted Close Price", "high|low|close", String.Empty, nameof(wcprice));

        public static Indicator wilders = new Indicator(100, nameof(wilders), "Wilders Smoothing", "real", "period", nameof(wilders));

        public static Indicator willr = new Indicator(101, nameof(willr), "Williams %R", "high|low|close", "period", nameof(willr));

        public static Indicator wma = new Indicator(102, nameof(wma), "Weighted Moving Average", "real", "period", nameof(wma));

        public static Indicator zlema =
            new Indicator(103, nameof(zlema), "Zero-Lag Exponential Moving Average", "real", "period", nameof(zlema));
    }
}
