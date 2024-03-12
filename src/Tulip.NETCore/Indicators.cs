using System.Collections;
using System.Collections.Generic;

namespace Tulip;

public class Indicators : IEnumerable<Indicator>
{
    private const string HighInput = "high";
    private const string LowInput = "low";
    private const string CloseInput = "close";
    private const string OpenInput = "open";
    private const string VolumeInput = "volume";
    private const string RealInput = "real";

    private const string PeriodOption = "period";

    internal static readonly Dictionary<string, Indicator> IndicatorsDefinition = new(StringComparer.OrdinalIgnoreCase)
    {
        { nameof(abs), new Indicator("Abs", "Vector Absolute Value", $"{RealInput}", String.Empty, nameof(abs)) },
        { nameof(acos), new Indicator("Acos", "Vector Arccosine", $"{RealInput}", String.Empty, nameof(acos)) },
        { nameof(ad), new Indicator("Ad", "Accumulation/Distribution Line", $"{HighInput}|{LowInput}|{CloseInput}|{VolumeInput}", String.Empty, nameof(ad)) },
        { nameof(add), new Indicator("Add", "Vector Addition", $"{RealInput}|{RealInput}", String.Empty, nameof(add)) },
        { nameof(adosc), new Indicator("AdOsc", "Accumulation/Distribution Oscillator", $"{HighInput}|{LowInput}|{CloseInput}|{VolumeInput}", $"short {PeriodOption}|long {PeriodOption}", nameof(adosc)) },
        { nameof(adx), new Indicator("Adx", "Average Directional Movement Index", $"{HighInput}|{LowInput}|{CloseInput}", $"{PeriodOption}", nameof(dx)) },
        { nameof(adxr), new Indicator("Adxr", "Average Directional Movement Rating", $"{HighInput}|{LowInput}|{CloseInput}", $"{PeriodOption}", nameof(dx)) },
        { nameof(ao), new Indicator("Ao", "Awesome Oscillator", $"{HighInput}|{LowInput}", String.Empty, nameof(ao)) },
        { nameof(apo), new Indicator("Apo", "Absolute Price Oscillator", $"{RealInput}", $"short {PeriodOption}|long {PeriodOption}", nameof(apo)) },
        { nameof(aroon), new Indicator("Aroon", "Aroon", $"{HighInput}|{LowInput}", $"{PeriodOption}", "aroon_down|aroon_up") },
        { nameof(aroonosc), new Indicator("AroonOsc", "Aroon Oscillator", $"{HighInput}|{LowInput}", $"{PeriodOption}", nameof(aroonosc)) },
        { nameof(asin), new Indicator("Asin", "Vector Arcsine", $"{RealInput}", String.Empty, nameof(asin)) },
        { nameof(atan), new Indicator("Atan", "Vector Arctangent", $"{RealInput}", String.Empty, nameof(atan)) },
        { nameof(atr), new Indicator("Atr", "Average True Range", $"{HighInput}|{LowInput}|{CloseInput}", $"{PeriodOption}", nameof(atr)) },
        { nameof(avgprice), new Indicator("AvgPrice", "Average Price", $"{OpenInput}|{HighInput}|{LowInput}|{CloseInput}", String.Empty, nameof(avgprice)) },
        { nameof(bbands), new Indicator("Bbands", "Bollinger Bands", $"{RealInput}", $"{PeriodOption}|stddev", "bbands_lower|bbands_middle|bbands_upper") },
        { nameof(bop), new Indicator("Bop", "Balance of Power", $"{OpenInput}|{HighInput}|{LowInput}|{CloseInput}", String.Empty, nameof(bop)) },
        { nameof(cci), new Indicator("Cci", "Commodity Channel Index", $"{HighInput}|{LowInput}|{CloseInput}", $"{PeriodOption}", nameof(cci)) },
        { nameof(ceil), new Indicator("Ceil", "Vector Ceiling", $"{RealInput}", String.Empty, nameof(ceil)) },
        { nameof(cmo), new Indicator("Cmo", "Chande Momentum Oscillator", $"{RealInput}", $"{PeriodOption}", nameof(cmo)) },
        { nameof(cos), new Indicator("Cos", "Vector Cosine", $"{RealInput}", String.Empty, nameof(cos)) },
        { nameof(cosh), new Indicator("Cosh", "Vector Hyperbolic Cosine", $"{RealInput}", String.Empty, nameof(cosh)) },
        { nameof(crossany), new Indicator("Crossany", "Crossany", $"{RealInput}|{RealInput}", String.Empty, nameof(crossany)) },
        { nameof(crossover), new Indicator("Crossover", "Crossover", $"{RealInput}|{RealInput}", String.Empty, nameof(crossover)) },
        { nameof(cvi), new Indicator("Cvi", "Chaikins Volatility", $"{HighInput}|{LowInput}", $"{PeriodOption}", nameof(cvi)) },
        { nameof(decay), new Indicator("Decay", "Linear Decay", $"{RealInput}", $"{PeriodOption}", nameof(decay)) },
        { nameof(dema), new Indicator("Dema", "Double Exponential Moving Average", $"{RealInput}", $"{PeriodOption}", nameof(dema)) },
        { nameof(di), new Indicator("Di", "Directional Indicator", $"{HighInput}|{LowInput}|{CloseInput}", $"{PeriodOption}", "plus_di|minus_di") },
        { nameof(div), new Indicator("Div", "Vector Division", $"{RealInput}|{RealInput}", String.Empty, nameof(div)) },
        { nameof(dm), new Indicator("Dm", "Directional Movement", $"{HighInput}|{LowInput}", $"{PeriodOption}", "plus_dm|minus_dm") },
        { nameof(dpo), new Indicator("Dpo", "Detrended Price Oscillator", $"{RealInput}", $"{PeriodOption}", nameof(dpo)) },
        { nameof(dx), new Indicator("Dx", "Directional Movement Index", $"{HighInput}|{LowInput}|{CloseInput}", $"{PeriodOption}", nameof(dx)) },
        { nameof(edecay), new Indicator("Edecay", "Exponential Decay", $"{RealInput}", $"{PeriodOption}", nameof(edecay)) },
        { nameof(ema), new Indicator("Ema", "Exponential Moving Average", $"{RealInput}", $"{PeriodOption}", nameof(ema)) },
        { nameof(emv), new Indicator("Emv", "Ease of Movement", $"{HighInput}|{LowInput}|{VolumeInput}", String.Empty, nameof(emv)) },
        { nameof(exp), new Indicator("Exp", "Vector Exponential", $"{RealInput}", String.Empty, nameof(exp)) },
        { nameof(fisher), new Indicator("Fisher", "Fisher Transform", $"{HighInput}|{LowInput}", $"{PeriodOption}", "fisher|fisher_signal") },
        { nameof(floor), new Indicator("Floor", "Vector Floor", $"{RealInput}", String.Empty, nameof(floor)) },
        { nameof(fosc), new Indicator("Fosc", "Forecast Oscillator", $"{RealInput}", $"{PeriodOption}", nameof(fosc)) },
        { nameof(hma), new Indicator("Hma", "Hull Moving Average", $"{RealInput}", $"{PeriodOption}", nameof(hma)) },
        { nameof(kama), new Indicator("Kama", "Kaufman Adaptive Moving Average", $"{RealInput}", $"{PeriodOption}", nameof(kama)) },
        { nameof(kvo), new Indicator("Kvo", "Klinger Volume Oscillator", $"{HighInput}|{LowInput}|{CloseInput}|{VolumeInput}", $"short {PeriodOption}|long {PeriodOption}", nameof(kvo)) },
        { nameof(lag), new Indicator("Lag", "Lag", $"{RealInput}", $"{PeriodOption}", nameof(lag)) },
        { nameof(linreg), new Indicator("LinReg", "Linear Regression", $"{RealInput}", $"{PeriodOption}", nameof(linreg)) },
        { nameof(linregintercept), new Indicator("LinRegIntercept", "Linear Regression Intercept", $"{RealInput}", $"{PeriodOption}", nameof(linregintercept)) },
        { nameof(linregslope), new Indicator("LinRegSlope", "Linear Regression Slope", $"{RealInput}", $"{PeriodOption}", nameof(linregslope)) },
        { nameof(ln), new Indicator("Ln", "Vector Natural Log", $"{RealInput}", String.Empty, nameof(ln)) },
        { nameof(log10), new Indicator("Log10", "Vector Base-10 Log", $"{RealInput}", String.Empty, nameof(log10)) },
        { nameof(macd), new Indicator("Macd", "Moving Average Convergence/Divergence", $"{RealInput}", $"short {PeriodOption}|long {PeriodOption}|signal {PeriodOption}", "macd|macd_signal|macd_histogram") },
        { nameof(marketfi), new Indicator("MarketFi", "Market Facilitation Index", $"{HighInput}|{LowInput}|{VolumeInput}", String.Empty, nameof(marketfi)) },
        { nameof(mass), new Indicator("Mass", "Mass Index", $"{HighInput}|{LowInput}", $"{PeriodOption}", nameof(mass)) },
        { nameof(max), new Indicator("Max", "Maximum In Period", $"{RealInput}", $"{PeriodOption}", nameof(max)) },
        { nameof(md), new Indicator("Md", "Mean Deviation Over Period", $"{RealInput}", $"{PeriodOption}", nameof(md)) },
        { nameof(medprice), new Indicator("MedPrice", "Median Price", $"{HighInput}|{LowInput}", String.Empty, nameof(medprice)) },
        { nameof(mfi), new Indicator("Mfi", "Money Flow Index", $"{HighInput}|{LowInput}|{CloseInput}|{VolumeInput}", $"{PeriodOption}", nameof(mfi)) },
        { nameof(min), new Indicator("Min", "Minimum In Period", $"{RealInput}", $"{PeriodOption}", nameof(min)) },
        { nameof(mom), new Indicator("Mom", "Momentum", $"{RealInput}", $"{PeriodOption}", nameof(mom)) },
        { nameof(msw), new Indicator("Msw", "Mesa Sine Wave", $"{RealInput}", $"{PeriodOption}", "msw_sine|msw_lead") },
        { nameof(mul), new Indicator("Mul", "Vector Multiplication", $"{RealInput}|{RealInput}", String.Empty, nameof(mul)) },
        { nameof(natr), new Indicator("Natr", "Normalized Average True Range", $"{HighInput}|{LowInput}|{CloseInput}", $"{PeriodOption}", nameof(natr)) },
        { nameof(nvi), new Indicator("Nvi", "Negative Volume Index", $"{CloseInput}|{VolumeInput}", String.Empty, nameof(nvi))},
        { nameof(obv), new Indicator("Obv", "On Balance Volume", $"{CloseInput}|{VolumeInput}", String.Empty, nameof(obv)) },
        { nameof(ppo), new Indicator("Ppo", "Percentage Price Oscillator", $"{RealInput}", $"short {PeriodOption}|long {PeriodOption}", nameof(ppo)) },
        { nameof(psar), new Indicator("Psar", "Parabolic SAR", $"{HighInput}|{LowInput}", "acceleration factor step|acceleration factor maximum", nameof(psar)) },
        { nameof(pvi), new Indicator("Pvi", "Positive Volume Index", $"{CloseInput}|{VolumeInput}", String.Empty, nameof(pvi)) },
        { nameof(qstick), new Indicator("Qstick", "Qstick", $"{OpenInput}|{CloseInput}", $"{PeriodOption}", nameof(qstick)) },
        { nameof(roc), new Indicator("Roc", "Rate of Change", $"{RealInput}", $"{PeriodOption}", nameof(roc)) },
        { nameof(rocr), new Indicator("RocR", "Rate of Change Ratio", $"{RealInput}", $"{PeriodOption}", nameof(rocr)) },
        { nameof(round), new Indicator("Round", "Vector Round", $"{RealInput}", String.Empty, nameof(round)) },
        { nameof(rsi), new Indicator("Rsi", "Relative Strength Index", $"{RealInput}", $"{PeriodOption}", nameof(rsi)) },
        { nameof(sin), new Indicator("Sin", "Vector Sine", $"{RealInput}", String.Empty, nameof(sin)) },
        { nameof(sinh), new Indicator("Sinh", "Vector Hyperbolic Sine", $"{RealInput}", String.Empty, nameof(sinh)) },
        { nameof(sma), new Indicator("Sma", "Simple Moving Average", $"{RealInput}", $"{PeriodOption}", nameof(sma)) },
        { nameof(sqrt), new Indicator("Sqrt", "Vector Square Root", $"{RealInput}", String.Empty, nameof(sqrt)) },
        { nameof(stddev), new Indicator("StdDev", "Standard Deviation Over Period", $"{RealInput}", $"{PeriodOption}", nameof(stddev)) },
        { nameof(stderr), new Indicator("StdErr", "Standard Error Over Period", $"{RealInput}", $"{PeriodOption}", nameof(stderr)) },
        { nameof(stoch), new Indicator("Stoch", "Stochastic Oscillator", $"{HighInput}|{LowInput}|{CloseInput}", $"%k {PeriodOption}|%k slowing {PeriodOption}|%d {PeriodOption}", "stoch_k|stoch_d") },
        { nameof(stochrsi), new Indicator("StochRsi", "Stochastic RSI", $"{RealInput}", $"{PeriodOption}", nameof(stochrsi)) },
        { nameof(sub), new Indicator("Sub", "Vector Subtraction", $"{RealInput}|{RealInput}", String.Empty, nameof(sub)) },
        { nameof(sum), new Indicator("Sum", "Sum Over Period", $"{RealInput}", $"{PeriodOption}", nameof(sum)) },
        { nameof(tan), new Indicator("Tan", "Vector Tangent", $"{RealInput}", String.Empty, nameof(tan)) },
        { nameof(tanh), new Indicator("Tanh", "Vector Hyperbolic Tangent", $"{RealInput}", String.Empty, nameof(tanh)) },
        { nameof(tema), new Indicator("Tema", "Triple Exponential Moving Average", $"{RealInput}", $"{PeriodOption}", nameof(tema)) },
        { nameof(todeg), new Indicator("ToDeg", "Vector Degree Conversion", $"{RealInput}", String.Empty, "degrees") },
        { nameof(torad), new Indicator("ToRad", "Vector Radian Conversion", $"{RealInput}", String.Empty, "radians") },
        { nameof(tr), new Indicator("Tr", "True Range", $"{HighInput}|{LowInput}|{CloseInput}", String.Empty, nameof(tr)) },
        { nameof(trima), new Indicator("Trima", "Triangular Moving Average", $"{RealInput}", $"{PeriodOption}", nameof(trima)) },
        { nameof(trix), new Indicator("Trix", "Trix", $"{RealInput}", $"{PeriodOption}", nameof(trix)) },
        { nameof(trunc), new Indicator("Trunc", "Vector Truncate", $"{RealInput}", String.Empty, nameof(trunc)) },
        { nameof(tsf), new Indicator("Tsf", "Time Series Forecast", $"{RealInput}", $"{PeriodOption}", nameof(tsf)) },
        { nameof(typprice), new Indicator("TypPrice", "Typical Price", $"{HighInput}|{LowInput}|{CloseInput}", String.Empty, nameof(typprice)) },
        { nameof(ultosc), new Indicator("UltOsc", "Ultimate Oscillator", $"{HighInput}|{LowInput}|{CloseInput}", $"short {PeriodOption}|medium {PeriodOption}|long {PeriodOption}", nameof(ultosc)) },
        { nameof(var), new Indicator("Var", "Variance Over Period", $"{RealInput}", $"{PeriodOption}", nameof(var)) },
        { nameof(vhf), new Indicator("Vhf", "Vertical Horizontal Filter", $"{RealInput}", $"{PeriodOption}", nameof(vhf)) },
        { nameof(vidya), new Indicator("Vidya", "Variable Index Dynamic Average", $"{RealInput}", $"short {PeriodOption}|long {PeriodOption}|alpha", nameof(vidya)) },
        { nameof(volatility), new Indicator("Volatility", "Annualized Historical Volatility", $"{RealInput}", $"{PeriodOption}", nameof(volatility)) },
        { nameof(vosc), new Indicator("Vosc", "Volume Oscillator", $"{VolumeInput}", $"short {PeriodOption}|long {PeriodOption}", nameof(vosc)) },
        { nameof(vwma), new Indicator("Vwma", "Volume Weighted Moving Average", $"{CloseInput}|{VolumeInput}", $"{PeriodOption}", nameof(vwma)) },
        { nameof(wad), new Indicator("Wad", "Williams Accumulation/Distribution", $"{HighInput}|{LowInput}|{CloseInput}", String.Empty, nameof(wad)) },
        { nameof(wcprice), new Indicator("WcPrice", "Weighted Close Price", $"{HighInput}|{LowInput}|{CloseInput}", String.Empty, nameof(wcprice)) },
        { nameof(wilders), new Indicator("Wilders", "Wilders Smoothing", $"{RealInput}", $"{PeriodOption}", nameof(wilders)) },
        { nameof(willr), new Indicator("WillR", "Williams %R", $"{HighInput}|{LowInput}|{CloseInput}", $"{PeriodOption}", nameof(willr)) },
        { nameof(wma), new Indicator("Wma", "Weighted Moving Average", $"{RealInput}", $"{PeriodOption}", nameof(wma)) },
        { nameof(zlema), new Indicator("ZlEma", "Zero-Lag Exponential Moving Average", $"{RealInput}", $"{PeriodOption}", nameof(zlema)) }
    };

    private static readonly Lazy<Indicators> Instance = new(() => []);

    private Indicators()
    {
    }

    public static Indicators All => Instance.Value;

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

    public static Indicator Find(string name) =>
        IndicatorsDefinition.TryGetValue(name, out var function)
            ? function
            : throw new ArgumentException("Indicator not found in the library", name);

    public IEnumerator<Indicator> GetEnumerator() => IndicatorsDefinition.Values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
