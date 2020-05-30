using System.Diagnostics.CodeAnalysis;
using Shouldly;
using Tulip.NETCore.Tests.Models;
using Xunit;

namespace Tulip.NETCore.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Indicator_Tests : IClassFixture<IndicatorsMapFixture>
    {
        private readonly IndicatorsMapFixture _fixture;

        public Indicator_Tests(IndicatorsMapFixture fixture)
        {
            _fixture = fixture;
        }

        [SkippableTheory]
        [JsonFileData("DataSets/untest.json", typeof(double), "_")]
        [JsonFileData("DataSets/atoz.json", typeof(double), "_")]
        [JsonFileData("DataSets/extra.json", typeof(double), "_")]
        public void Should_Return_CorrectOutput_With_OKStatus_For_DoubleInput(TestDataModel<double> model, string fileName)
        {
            Skip.If(model.Skip, "Test has been skipped in configuration");

            const double equalityTolerance = 0.001d;

            _fixture.IndicatorsMap.ShouldContainKey(model.Name, $"Cannot find definition for '{model.Name}");
            var indicator = _fixture.IndicatorsMap[model.Name];

            model.Options.Length.ShouldBe(indicator.Options.Length, "Number of options must match the definition");
            var inputOffset = indicator.Start(model.Options);
            model.Inputs.Length.ShouldBe(indicator.Inputs.Length, "Number of inputs must match the definition");
            var outputLength = model.Inputs[0].Length - inputOffset;
            outputLength.ShouldBePositive("Output array should have the correct length");

            var resultOutput = new double[model.Outputs.Length][];
            resultOutput.Length.ShouldBe(indicator.Outputs.Length, "Number of outputs must match the definition");
            for (var i = 0; i < resultOutput.Length; i++)
            {
                resultOutput[i] = new double[outputLength];
            }

            var returnCode = indicator.Run(model.Inputs, model.Options, resultOutput);
            returnCode.ShouldBe(0, "Function should complete with success status code TI_OK(0)");

            for (var i = 0; i < resultOutput.Length; i++)
            {
                resultOutput[i].Length.ShouldBe(model.Outputs[i].Length, "Expected and calculated length of the output arrays should be equal");
                resultOutput[i].ShouldBe(model.Outputs[i], equalityTolerance);
            }
        }

        [SkippableTheory]
        [JsonFileData("DataSets/untest.json", typeof(decimal), "_")]
        [JsonFileData("DataSets/atoz.json", typeof(decimal), "_")]
        [JsonFileData("DataSets/extra.json", typeof(decimal), "_")]
        public void Should_Return_CorrectOutput_With_OKStatus_For_DecimalInput(TestDataModel<decimal> model, string fileName)
        {
            Skip.If(model.Skip, "Test has been skipped in configuration");

            const decimal equalityTolerance = 0.001m;

            _fixture.IndicatorsMap.ShouldContainKey(model.Name, $"Cannot find definition for '{model.Name}");
            var indicator = _fixture.IndicatorsMap[model.Name];

            model.Options.Length.ShouldBe(indicator.Options.Length, "Number of options must match the definition");
            var inputOffset = indicator.Start(model.Options);
            model.Inputs.Length.ShouldBe(indicator.Inputs.Length, "Number of inputs must match the definition");
            var outputLength = model.Inputs[0].Length - inputOffset;
            outputLength.ShouldBePositive("Output array should have the correct length");

            var resultOutput = new decimal[model.Outputs.Length][];
            resultOutput.Length.ShouldBe(indicator.Outputs.Length, "Number of outputs must match the definition");
            for (var i = 0; i < resultOutput.Length; i++)
            {
                resultOutput[i] = new decimal[outputLength];
            }

            var returnCode = indicator.Run(model.Inputs, model.Options, resultOutput);
            returnCode.ShouldBe(0, "Function should complete with success status code TI_OK(0)");

            for (var i = 0; i < resultOutput.Length; i++)
            {
                resultOutput[i].Length.ShouldBe(model.Outputs[i].Length, "Expected and calculated length of the output arrays should be equal");
                resultOutput[i].ShouldBe(model.Outputs[i], equalityTolerance);
            }
        }
    }
}