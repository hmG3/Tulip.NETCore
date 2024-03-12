using System.Collections;
using System.Collections.Generic;

namespace Tulip
{
    public static class Indicators
    {
        internal static readonly IDictionary<string, Indicator> IndicatorsDefinition = new Dictionary<string, Indicator>
        {
            { nameof(abs), new Indicator("Abs", "Vector Absolute Value", "real", String.Empty, nameof(abs)) },
            { nameof(acos), new Indicator("Acos", "Vector Arccosine", "real", String.Empty, nameof(acos)) },
            { nameof(ad), new Indicator("Ad", "Accumulation/Distribution Line", "high|low|close|volume", String.Empty, nameof(ad)) },
            { nameof(add), new Indicator("Add", "Vector Addition", "real|real", String.Empty, nameof(add)) },
            { nameof(adosc), new Indicator("AdOsc", "Accumulation/Distribution Oscillator", "high|low|close|volume", "short period|long period", nameof(adosc)) },
            { nameof(adx), new Indicator("Adx", "Average Directional Movement Index", "high|low|close", "period", nameof(dx)) },
            { nameof(adxr), new Indicator("Adxr", "Average Directional Movement Rating", "high|low|close", "period", nameof(dx)) },
            { nameof(ao), new Indicator("Ao", "Awesome Oscillator", "high|low", String.Empty, nameof(ao)) },
            { nameof(apo), new Indicator("Apo", "Absolute Price Oscillator", "real", "short period|long period", nameof(apo)) },
            { nameof(aroon), new Indicator("Aroon", "Aroon", "high|low", "period", "aroon_down|aroon_up") },
            { nameof(aroonosc), new Indicator("AroonOsc", "Aroon Oscillator", "high|low", "period", nameof(aroonosc)) },
            { nameof(asin), new Indicator("Asin", "Vector Arcsine", "real", String.Empty, nameof(asin)) },
            { nameof(atan), new Indicator("Atan", "Vector Arctangent", "real", String.Empty, nameof(atan)) },
            { nameof(atr), new Indicator("Atr", "Average True Range", "high|low|close", "period", nameof(atr)) },
            { nameof(avgprice), new Indicator("AvgPrice", "Average Price", "open|high|low|close", String.Empty, nameof(avgprice)) },
            { nameof(bbands), new Indicator("Bbands", "Bollinger Bands", "real", "period|stddev", "bbands_lower|bbands_middle|bbands_upper") },
            { nameof(bop), new Indicator("Bop", "Balance of Power", "open|high|low|close", String.Empty, nameof(bop)) },
            { nameof(cci), new Indicator("Cci", "Commodity Channel Index", "high|low|close", "period", nameof(cci)) },
            { nameof(ceil), new Indicator("Ceil", "Vector Ceiling", "real", String.Empty, nameof(ceil)) },
            { nameof(cmo), new Indicator("Cmo", "Chande Momentum Oscillator", "real", "period", nameof(cmo)) },
            { nameof(cos), new Indicator("Cos", "Vector Cosine", "real", String.Empty, nameof(cos)) },
            { nameof(cosh), new Indicator("Cosh", "Vector Hyperbolic Cosine", "real", String.Empty, nameof(cosh)) },
            { nameof(crossany), new Indicator("Crossany", "Crossany", "real|real", String.Empty, nameof(crossany)) },
            { nameof(crossover), new Indicator("Crossover", "Crossover", "real|real", String.Empty, nameof(crossover)) },
            { nameof(cvi), new Indicator("Cvi", "Chaikins Volatility", "high|low", "period", nameof(cvi)) },
            { nameof(decay), new Indicator("Decay", "Linear Decay", "real", "period", nameof(decay)) },
            { nameof(dema), new Indicator("Dema", "Double Exponential Moving Average", "real", "period", nameof(dema)) },
            { nameof(di), new Indicator("Di", "Directional Indicator", "high|low|close", "period", "plus_di|minus_di") },
            { nameof(div), new Indicator("Div", "Vector Division", "real|real", String.Empty, nameof(div)) },
            { nameof(dm), new Indicator("Dm", "Directional Movement", "high|low", "period", "plus_dm|minus_dm") },
            { nameof(dpo), new Indicator("Dpo", "Detrended Price Oscillator", "real", "period", nameof(dpo)) },
            { nameof(dx), new Indicator("Dx", "Directional Movement Index", "high|low|close", "period", nameof(dx)) },
            { nameof(edecay), new Indicator("Edecay", "Exponential Decay", "real", "period", nameof(edecay)) },
            { nameof(ema), new Indicator("Ema", "Exponential Moving Average", "real", "period", nameof(ema)) },
            { nameof(emv), new Indicator("Emv", "Ease of Movement", "high|low|volume", String.Empty, nameof(emv)) },
            { nameof(exp), new Indicator("Exp", "Vector Exponential", "real", String.Empty, nameof(exp)) },
            { nameof(fisher), new Indicator("Fisher", "Fisher Transform", "high|low", "period", "fisher|fisher_signal") },
            { nameof(floor), new Indicator("Floor", "Vector Floor", "real", String.Empty, nameof(floor)) },
            { nameof(fosc), new Indicator("Fosc", "Forecast Oscillator", "real", "period", nameof(fosc)) },
            { nameof(hma), new Indicator("Hma", "Hull Moving Average", "real", "period", nameof(hma)) },
            { nameof(kama), new Indicator("Kama", "Kaufman Adaptive Moving Average", "real", "period", nameof(kama)) },
            { nameof(kvo), new Indicator("Kvo", "Klinger Volume Oscillator", "high|low|close|volume", "short period|long period", nameof(kvo)) },
            { nameof(lag), new Indicator("Lag", "Lag", "real", "period", nameof(lag)) },
            { nameof(linreg), new Indicator("LinReg", "Linear Regression", "real", "period", nameof(linreg)) },
            { nameof(linregintercept), new Indicator("LinRegIntercept", "Linear Regression Intercept", "real", "period", nameof(linregintercept)) },
            { nameof(linregslope), new Indicator("LinRegSlope", "Linear Regression Slope", "real", "period", nameof(linregslope)) },
            { nameof(ln), new Indicator("Ln", "Vector Natural Log", "real", String.Empty, nameof(ln)) },
            { nameof(log10), new Indicator("Log10", "Vector Base-10 Log", "real", String.Empty, nameof(log10)) },
            { nameof(macd), new Indicator("Macd", "Moving Average Convergence/Divergence", "real", "short period|long period|signal period", "macd|macd_signal|macd_histogram") },
            { nameof(marketfi), new Indicator("MarketFi", "Market Facilitation Index", "high|low|volume", String.Empty, nameof(marketfi)) },
            { nameof(mass), new Indicator("Mass", "Mass Index", "high|low", "period", nameof(mass)) },
            { nameof(max), new Indicator("Max", "Maximum In Period", "real", "period", nameof(max)) },
            { nameof(md), new Indicator("Md", "Mean Deviation Over Period", "real", "period", nameof(md)) },
            { nameof(medprice), new Indicator("MedPrice", "Median Price", "high|low", String.Empty, nameof(medprice)) },
            { nameof(mfi), new Indicator("Mfi", "Money Flow Index", "high|low|close|volume", "period", nameof(mfi)) },
            { nameof(min), new Indicator("Min", "Minimum In Period", "real", "period", nameof(min)) },
            { nameof(mom), new Indicator("Mom", "Momentum", "real", "period", nameof(mom)) },
            { nameof(msw), new Indicator("Msw", "Mesa Sine Wave", "real", "period", "msw_sine|msw_lead") },
            { nameof(mul), new Indicator("Mul", "Vector Multiplication", "real|real", String.Empty, nameof(mul)) },
            { nameof(natr), new Indicator("Natr", "Normalized Average True Range", "high|low|close", "period", nameof(natr)) },
            { nameof(nvi), new Indicator("Nvi", "Negative Volume Index", "close|volume", String.Empty, nameof(nvi))},
            { nameof(obv), new Indicator("Obv", "On Balance Volume", "close|volume", String.Empty, nameof(obv)) },
            { nameof(ppo), new Indicator("Ppo", "Percentage Price Oscillator", "real", "short period|long period", nameof(ppo)) },
            { nameof(psar), new Indicator("Psar", "Parabolic SAR", "high|low", "acceleration factor step|acceleration factor maximum", nameof(psar)) },
            { nameof(pvi), new Indicator("Pvi", "Positive Volume Index", "close|volume", String.Empty, nameof(pvi)) },
            { nameof(qstick), new Indicator("Qstick", "Qstick", "open|close", "period", nameof(qstick)) },
            { nameof(roc), new Indicator("Roc", "Rate of Change", "real", "period", nameof(roc)) },
            { nameof(rocr), new Indicator("RocR", "Rate of Change Ratio", "real", "period", nameof(rocr)) },
            { nameof(round), new Indicator("Round", "Vector Round", "real", String.Empty, nameof(round)) },
            { nameof(rsi), new Indicator("Rsi", "Relative Strength Index", "real", "period", nameof(rsi)) },
            { nameof(sin), new Indicator("Sin", "Vector Sine", "real", String.Empty, nameof(sin)) },
            { nameof(sinh), new Indicator("Sinh", "Vector Hyperbolic Sine", "real", String.Empty, nameof(sinh)) },
            { nameof(sma), new Indicator("Sma", "Simple Moving Average", "real", "period", nameof(sma)) },
            { nameof(sqrt), new Indicator("Sqrt", "Vector Square Root", "real", String.Empty, nameof(sqrt)) },
            { nameof(stddev), new Indicator("StdDev", "Standard Deviation Over Period", "real", "period", nameof(stddev)) },
            { nameof(stderr), new Indicator("StdErr", "Standard Error Over Period", "real", "period", nameof(stderr)) },
            { nameof(stoch), new Indicator("Stoch", "Stochastic Oscillator", "high|low|close", "%k period|%k slowing period|%d period", "stoch_k|stoch_d") },
            { nameof(stochrsi), new Indicator("StochRsi", "Stochastic RSI", "real", "period", nameof(stochrsi)) },
            { nameof(sub), new Indicator("Sub", "Vector Subtraction", "real|real", String.Empty, nameof(sub)) },
            { nameof(sum), new Indicator("Sum", "Sum Over Period", "real", "period", nameof(sum)) },
            { nameof(tan), new Indicator("Tan", "Vector Tangent", "real", String.Empty, nameof(tan)) },
            { nameof(tanh), new Indicator("Tanh", "Vector Hyperbolic Tangent", "real", String.Empty, nameof(tanh)) },
            { nameof(tema), new Indicator("Tema", "Triple Exponential Moving Average", "real", "period", nameof(tema)) },
            { nameof(todeg), new Indicator("ToDeg", "Vector Degree Conversion", "real", String.Empty, "degrees") },
            { nameof(torad), new Indicator("ToRad", "Vector Radian Conversion", "real", String.Empty, "radians") },
            { nameof(tr), new Indicator("Tr", "True Range", "high|low|close", String.Empty, nameof(tr)) },
            { nameof(trima), new Indicator("Trima", "Triangular Moving Average", "real", "period", nameof(trima)) },
            { nameof(trix), new Indicator("Trix", "Trix", "real", "period", nameof(trix)) },
            { nameof(trunc), new Indicator("Trunc", "Vector Truncate", "real", String.Empty, nameof(trunc)) },
            { nameof(tsf), new Indicator("Tsf", "Time Series Forecast", "real", "period", nameof(tsf)) },
            { nameof(typprice), new Indicator("TypPrice", "Typical Price", "high|low|close", String.Empty, nameof(typprice)) },
            { nameof(ultosc), new Indicator("UltOsc", "Ultimate Oscillator", "high|low|close", "short period|medium period|long period", nameof(ultosc)) },
            { nameof(var), new Indicator("Var", "Variance Over Period", "real", "period", nameof(var)) },
            { nameof(vhf), new Indicator("Vhf", "Vertical Horizontal Filter", "real", "period", nameof(vhf)) },
            { nameof(vidya), new Indicator("Vidya", "Variable Index Dynamic Average", "real", "short period|long period|alpha", nameof(vidya)) },
            { nameof(volatility), new Indicator("Volatility", "Annualized Historical Volatility", "real", "period", nameof(volatility)) },
            { nameof(vosc), new Indicator("Vosc", "Volume Oscillator", "volume", "short period|long period", nameof(vosc)) },
            { nameof(vwma), new Indicator("Vwma", "Volume Weighted Moving Average", "close|volume", "period", nameof(vwma)) },
            { nameof(wad), new Indicator("Wad", "Williams Accumulation/Distribution", "high|low|close", String.Empty, nameof(wad)) },
            { nameof(wcprice), new Indicator("WcPrice", "Weighted Close Price", "high|low|close", String.Empty, nameof(wcprice)) },
            { nameof(wilders), new Indicator("Wilders", "Wilders Smoothing", "real", "period", nameof(wilders)) },
            { nameof(willr), new Indicator("WillR", "Williams %R", "high|low|close", "period", nameof(willr)) },
            { nameof(wma), new Indicator("Wma", "Weighted Moving Average", "real", "period", nameof(wma)) },
            { nameof(zlema), new Indicator("ZlEma", "Zero-Lag Exponential Moving Average", "real", "period", nameof(zlema)) }
        };

        public static Indicator abs = IndicatorsDefinition[nameof(abs)];

        public static Indicator acos = IndicatorsDefinition[nameof(acos)];

        public static Indicator ad = IndicatorsDefinition[nameof(ad)];

        public static Indicator add = IndicatorsDefinition[nameof(add)];

        public static Indicator adosc = IndicatorsDefinition[nameof(adosc)];

        public static Indicator adx = IndicatorsDefinition[nameof(adx)];

        public static Indicator adxr = IndicatorsDefinition[nameof(adxr)];

        public static Indicator ao = IndicatorsDefinition[nameof(ao)];

        public static Indicator apo = IndicatorsDefinition[nameof(apo)];

        public static Indicator aroon = IndicatorsDefinition[nameof(aroon)];

        public static Indicator aroonosc = IndicatorsDefinition[nameof(aroonosc)];

        public static Indicator asin = IndicatorsDefinition[nameof(asin)];

        public static Indicator atan = IndicatorsDefinition[nameof(atan)];

        public static Indicator atr = IndicatorsDefinition[nameof(atr)];

        public static Indicator avgprice = IndicatorsDefinition[nameof(avgprice)];

        public static Indicator bbands = IndicatorsDefinition[nameof(bbands)];

        public static Indicator bop = IndicatorsDefinition[nameof(bop)];

        public static Indicator cci = IndicatorsDefinition[nameof(cci)];

        public static Indicator ceil = IndicatorsDefinition[nameof(ceil)];

        public static Indicator cmo = IndicatorsDefinition[nameof(cmo)];

        public static Indicator cos = IndicatorsDefinition[nameof(cos)];

        public static Indicator cosh = IndicatorsDefinition[nameof(cosh)];

        public static Indicator crossany = IndicatorsDefinition[nameof(crossany)];

        public static Indicator crossover = IndicatorsDefinition[nameof(crossover)];

        public static Indicator cvi = IndicatorsDefinition[nameof(cvi)];

        public static Indicator decay = IndicatorsDefinition[nameof(decay)];

        public static Indicator dema = IndicatorsDefinition[nameof(dema)];

        public static Indicator di = IndicatorsDefinition[nameof(di)];

        public static Indicator div = IndicatorsDefinition[nameof(div)];

        public static Indicator dm = IndicatorsDefinition[nameof(dm)];

        public static Indicator dpo = IndicatorsDefinition[nameof(dpo)];

        public static Indicator dx = IndicatorsDefinition[nameof(dx)];

        public static Indicator edecay = IndicatorsDefinition[nameof(edecay)];

        public static Indicator ema = IndicatorsDefinition[nameof(ema)];

        public static Indicator emv = IndicatorsDefinition[nameof(emv)];

        public static Indicator exp = IndicatorsDefinition[nameof(exp)];

        public static Indicator fisher = IndicatorsDefinition[nameof(fisher)];

        public static Indicator floor = IndicatorsDefinition[nameof(floor)];

        public static Indicator fosc = IndicatorsDefinition[nameof(fosc)];

        public static Indicator hma = IndicatorsDefinition[nameof(hma)];

        public static Indicator kama = IndicatorsDefinition[nameof(kama)];

        public static Indicator kvo = IndicatorsDefinition[nameof(kvo)];

        public static Indicator lag = IndicatorsDefinition[nameof(lag)];

        public static Indicator linreg = IndicatorsDefinition[nameof(linreg)];

        public static Indicator linregintercept = IndicatorsDefinition[nameof(linregintercept)];

        public static Indicator linregslope = IndicatorsDefinition[nameof(linregslope)];

        public static Indicator ln = IndicatorsDefinition[nameof(ln)];

        public static Indicator log10 = IndicatorsDefinition[nameof(log10)];

        public static Indicator macd = IndicatorsDefinition[nameof(macd)];

        public static Indicator marketfi = IndicatorsDefinition[nameof(marketfi)];

        public static Indicator mass = IndicatorsDefinition[nameof(mass)];

        public static Indicator max = IndicatorsDefinition[nameof(max)];

        public static Indicator md = IndicatorsDefinition[nameof(md)];

        public static Indicator medprice = IndicatorsDefinition[nameof(medprice)];

        public static Indicator mfi = IndicatorsDefinition[nameof(mfi)];

        public static Indicator min = IndicatorsDefinition[nameof(min)];

        public static Indicator mom = IndicatorsDefinition[nameof(mom)];

        public static Indicator msw = IndicatorsDefinition[nameof(msw)];

        public static Indicator mul = IndicatorsDefinition[nameof(mul)];

        public static Indicator natr = IndicatorsDefinition[nameof(natr)];

        public static Indicator nvi = IndicatorsDefinition[nameof(nvi)];

        public static Indicator obv = IndicatorsDefinition[nameof(obv)];

        public static Indicator ppo = IndicatorsDefinition[nameof(ppo)];

        public static Indicator psar = IndicatorsDefinition[nameof(psar)];

        public static Indicator pvi = IndicatorsDefinition[nameof(pvi)];

        public static Indicator qstick = IndicatorsDefinition[nameof(qstick)];

        public static Indicator roc = IndicatorsDefinition[nameof(roc)];

        public static Indicator rocr = IndicatorsDefinition[nameof(rocr)];

        public static Indicator round = IndicatorsDefinition[nameof(round)];

        public static Indicator rsi = IndicatorsDefinition[nameof(rsi)];

        public static Indicator sin = IndicatorsDefinition[nameof(sin)];

        public static Indicator sinh = IndicatorsDefinition[nameof(sinh)];

        public static Indicator sma = IndicatorsDefinition[nameof(sma)];

        public static Indicator sqrt = IndicatorsDefinition[nameof(sqrt)];

        public static Indicator stddev = IndicatorsDefinition[nameof(stddev)];

        public static Indicator stderr = IndicatorsDefinition[nameof(stderr)];

        public static Indicator stoch = IndicatorsDefinition[nameof(stoch)];

        public static Indicator stochrsi = IndicatorsDefinition[nameof(stochrsi)];

        public static Indicator sub = IndicatorsDefinition[nameof(sub)];

        public static Indicator sum = IndicatorsDefinition[nameof(sum)];

        public static Indicator tan = IndicatorsDefinition[nameof(tan)];

        public static Indicator tanh = IndicatorsDefinition[nameof(tanh)];

        public static Indicator tema = IndicatorsDefinition[nameof(tema)];

        public static Indicator todeg = IndicatorsDefinition[nameof(todeg)];

        public static Indicator torad = IndicatorsDefinition[nameof(torad)];

        public static Indicator tr = IndicatorsDefinition[nameof(tr)];

        public static Indicator trima = IndicatorsDefinition[nameof(trima)];

        public static Indicator trix = IndicatorsDefinition[nameof(trix)];

        public static Indicator trunc = IndicatorsDefinition[nameof(trunc)];

        public static Indicator tsf = IndicatorsDefinition[nameof(tsf)];

        public static Indicator typprice = IndicatorsDefinition[nameof(typprice)];

        public static Indicator ultosc = IndicatorsDefinition[nameof(ultosc)];

        public static Indicator var = IndicatorsDefinition[nameof(var)];

        public static Indicator vhf = IndicatorsDefinition[nameof(vhf)];

        public static Indicator vidya = IndicatorsDefinition[nameof(vidya)];

        public static Indicator volatility = IndicatorsDefinition[nameof(volatility)];

        public static Indicator vosc = IndicatorsDefinition[nameof(vosc)];

        public static Indicator vwma = IndicatorsDefinition[nameof(vwma)];

        public static Indicator wad = IndicatorsDefinition[nameof(wad)];

        public static Indicator wcprice = IndicatorsDefinition[nameof(wcprice)];

        public static Indicator wilders = IndicatorsDefinition[nameof(wilders)];

        public static Indicator willr = IndicatorsDefinition[nameof(willr)];

        public static Indicator wma = IndicatorsDefinition[nameof(wma)];

        public static Indicator zlema = IndicatorsDefinition[nameof(zlema)];
    }
}
