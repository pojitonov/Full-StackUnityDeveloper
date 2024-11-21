using System;
using NUnit.Framework;

namespace Homework
{
    public sealed class ConverterTests
    {
        Converter _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new Converter(
                inputCapacity: 10,
                outputCapacity: 10,
                resourcesPerCycle: 5,
                conversionOutput: 2,
                conversionTime: 5f
            );
            _converter.Start();
        }

        [Test]
        public void WhenShutdown_ThenDoNothing()
        {
            //Arrange:
            _converter.LoadInputResources(10);
            _converter.Update(2f);

            //Act:
            _converter.Shutdown();

            //Assert:
            Assert.IsFalse(_converter.IsRunning);
            Assert.AreEqual(10, _converter.InputResourcesCount);
            Assert.AreEqual(0, _converter.OutputResourcesCount);
        }

        [Test]
        public void WhenLoadResourcesWithExceedCapacity_ThenReturnExceededItems()
        {
            //Arrange:
            var excess = _converter.LoadInputResources(12);

            //Assert:
            Assert.AreEqual(10, _converter.InputResourcesCount);
            Assert.AreEqual(2, excess);
        }

        [Test]
        public void WhenUpdateTimeLessThanConversionTime_ThenDoNotConvert()
        {
            //Arrange:
            _converter.LoadInputResources(10);

            //Act:
            _converter.Update(2f);

            //Assert:
            Assert.AreEqual(10, _converter.InputResourcesCount);
            Assert.AreEqual(0, _converter.OutputResourcesCount);
        }

        [Test]
        public void WhenUpdateTimeIsEqualToConversionTime_ThenCompleteCycle()
        {
            //Arrange:
            _converter.LoadInputResources(10);

            //Act:
            _converter.Update(5f);

            //Assert:
            Assert.AreEqual(5, _converter.InputResourcesCount);
            Assert.AreEqual(2, _converter.OutputResourcesCount);
        }

        [Test]
        public void NegativeUpdateTimeThrowException()
        {
            //Arrange:
            _converter.LoadInputResources(10);

            //Assert:
            Assert.Catch<ArgumentOutOfRangeException>(() => _converter.Update(-2f));

        }

        [TestCase(10, 2f, 10, 0)]
        [TestCase(5, 5f, 0, 2)]
        [TestCase(4, 5f, 4, 0)]
        public void Test_ConversionCycle(int inputResources, float updateTime, int expectedInput, int expectedOutput)
        {
            //Arrange:
            _converter.LoadInputResources(inputResources);

            //Act:
            _converter.Update(updateTime);

            //Assert:
            Assert.AreEqual(expectedInput, _converter.InputResourcesCount);
            Assert.AreEqual(expectedOutput, _converter.OutputResourcesCount);
        }
    }
}