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
        public void WhenConverterCreated_ThenItNotStartedAutomatically()
        {
            //Arrange:
            _converter = new Converter(
                inputCapacity: 10,
                outputCapacity: 10,
                resourcesPerCycle: 5,
                conversionOutput: 2,
                conversionTime: 5f
            );

            //Assert:
            Assert.AreEqual(_converter.IsRunning, false);
        }

        [Test]
        public void WhenConverterShutdown_ThenConverterNotRunning()
        {
            //Arrange:
            _converter.LoadInputResources(10);
            _converter.Update(5f);

            //Act:
            _converter.Shutdown();

            //Assert:
            Assert.IsFalse(_converter.IsRunning);
        }

        [Test]
        public void WhenCycleStarted_ThenInputCountReduced()
        {
            //Arrange:
            _converter.LoadInputResources(10);

            //Act:
            _converter.Update(2f);

            //Assert:
            Assert.AreEqual(10, _converter.InputResourcesCount);
        }

        [Test]
        public void WhenOverflowInLoadingZone_ExcessResourcesAreBurned()
        {
            // Arrange:
            _converter.LoadInputResources(10);

            // Act:
            _converter.Update(5f);
            int excess = _converter.LoadInputResources(12);

            // Assert:
            Assert.AreEqual(10, _converter.InputResourcesCount);
            Assert.AreEqual(2, _converter.OutputResourcesCount);
            Assert.AreEqual(7, excess);
        }

        [Test]
        public void WhenShutdownAfterFullCycle_ThenResourcesShouldNotReturnToLoadingZone()
        {
            //Arrange:
            _converter.LoadInputResources(10);
            _converter.Update(5f);

            //Act:
            _converter.Shutdown();
            int excess = _converter.LoadInputResources(5);

            //Assert:
            Assert.AreEqual(10, _converter.InputResourcesCount);
            Assert.AreEqual(2, _converter.OutputResourcesCount);
            Assert.AreEqual(0, excess);
        }

        [Test]
        public void WhenShutdownDuringProcessingAfterOneCycle_ThenPartiallyProcessedResourcesReturnToInput()
        {
            //Arrange:
            _converter.LoadInputResources(10);

            //Act:
            _converter.Update(5.5f);
            _converter.Shutdown();

            //Assert:
            Assert.AreEqual(5, _converter.InputResourcesCount);
            Assert.AreEqual(2, _converter.OutputResourcesCount);
        }

        [Test]
        public void WhenUpdateInvokedInASequence_ThenDeltaTimeAccumulates()
        {
            //Arrange:
            _converter.LoadInputResources(10);

            //Act:
            _converter.Update(2f);
            _converter.Update(2f);
            _converter.Update(2f);

            //Assert:
            Assert.AreEqual(5, _converter.InputResourcesCount);
        }
        
        [Test]
        public void WhenShutdownDuringProcessing_ThenResourcesReturnBackAndHandleOverflow()
        {
            // Arrange:
            _converter.LoadInputResources(10);
            _converter.Update(2.5f);


            // Act:
            _converter.Shutdown();
            int excess = _converter.LoadInputResources(10);

            // Assert:
            Assert.AreEqual(10, _converter.InputResourcesCount);
            Assert.AreEqual(0, _converter.OutputResourcesCount);
            Assert.AreEqual(10, excess);
        }

        [Test]
        public void WhenShutdownDuringPartialProcessing_ThenPartiallyProcessedResourcesReturnToInput()
        {
            //Arrange:
            _converter.LoadInputResources(10);

            //Act:
            _converter.Update(2.5f);
            _converter.Shutdown();

            //Assert:
            Assert.AreEqual(10, _converter.InputResourcesCount);
            Assert.AreEqual(0, _converter.OutputResourcesCount);
        }

        [Test]
        public void WhenShutdownDuringProcessingAndOverflowOccurs_ThenExcessInputIsBurned()
        {
            //Arrange:
            _converter.LoadInputResources(10);

            //Act:
            _converter.Update(2.5f);
            _converter.Shutdown();
            int excess = _converter.LoadInputResources(5);

            //Assert:
            Assert.AreEqual(10, _converter.InputResourcesCount);
            Assert.AreEqual(0, _converter.OutputResourcesCount);
            Assert.AreEqual(5, excess);
        }

        [TestCase(10, 1.0f, 10)]
        [TestCase(10, 2.5f, 10)]
        [TestCase(10, 5.0f, 5)]
        [TestCase(10, 6.0f, 5)]
        public void WhenShutdown_ThenReturnsCorrectPartialResourcesToInput(int initialInput, float updateTime,
            int expectedInput)
        {
            // Arrange:
            _converter.LoadInputResources(initialInput);

            // Act:
            _converter.Update(updateTime);
            _converter.Shutdown();

            // Assert:
            Assert.AreEqual(expectedInput, _converter.InputResourcesCount);
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
        public void WhenConverterIsOff_ThenCanLoadResources()
        {
            // Arrange:
            _converter.Shutdown();

            // Act:
            int excess = _converter.LoadInputResources(12);

            // Assert:
            Assert.AreEqual(10, _converter.InputResourcesCount);
            Assert.AreEqual(2, excess);
            Assert.IsFalse(_converter.IsRunning);
        }

        [TestCase(0f)]
        [TestCase(-1f)]
        public void NegativeUpdateTimeThrowException(float time)
        {
            //Arrange:
            _converter.LoadInputResources(10);

            //Assert:
            Assert.Catch<ArgumentOutOfRangeException>(() => _converter.Update(time));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void NegativeResourcesAmountThrowException(int count)
        {
            //Assert:
            Assert.Catch<ArgumentOutOfRangeException>(() => _converter.LoadInputResources(count));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void NegativeInputOnCreationThrowException(int inputValue)
        {
            //Assert:
            Assert.Catch<ArgumentOutOfRangeException>(() => _converter = new Converter(inputValue, 1, 1, 1, 1));
            Assert.Catch<ArgumentOutOfRangeException>(() => _converter = new Converter(1, inputValue, 1, 1, 1));
            Assert.Catch<ArgumentOutOfRangeException>(() => _converter = new Converter(1, 1, inputValue, 1, 1));
            Assert.Catch<ArgumentOutOfRangeException>(() => _converter = new Converter(1, 1, 1, inputValue, 1));
            Assert.Catch<ArgumentOutOfRangeException>(() => _converter = new Converter(1, 1, 1, 1, inputValue));
        }
    
        [Test]
        public void WhenConverterIsOff_ThenUpdateDoesNothing()
        {
            // Arrange:
            _converter.LoadInputResources(10);

            // Act:
            _converter.Shutdown();
            _converter.Update(10f);

            // Assert:
            Assert.AreEqual(10, _converter.InputResourcesCount);
            Assert.AreEqual(0, _converter.OutputResourcesCount);
            Assert.IsFalse(_converter.IsRunning);
        }

        [Test]
        public void WhenNotEnoughResourcesForCycle_ThenDoNotProcess()
        {
            // Arrange:
            _converter.LoadInputResources(3);

            // Act:
            _converter.Update(10f);

            // Assert:
            Assert.AreEqual(3, _converter.InputResourcesCount);
            Assert.AreEqual(0, _converter.OutputResourcesCount);
        }

        [Test]
        public void WhenOutputZoneFull_ThenStopProcessing()
        {
            // Arrange:
            _converter = new Converter(
                inputCapacity: 10,
                outputCapacity: 3,
                resourcesPerCycle: 5,
                conversionOutput: 2,
                conversionTime: 5f
            );
            _converter.Start();
            _converter.LoadInputResources(10);
        
            // Act:
            _converter.Update(10f);

            // Assert:
            Assert.AreEqual(5, _converter.InputResourcesCount);
            Assert.AreEqual(2, _converter.OutputResourcesCount);
        }
        
        [TestCase(20, 2f, 10, 0)]
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
        
        [TestCase(10, 5, 5, 1, 5f, 5, 1)]
        [TestCase(5, 10, 5, 1, 5f, 0, 1)]
        [TestCase(10, 1, 5, 2, 5f, 10, 0)]
        public void Test_ConverterWithDifferentSettings(
            int inputCapacity, int outputCapacity, int resourcesPerCycle, int conversionOutput, float conversionTime,
            int expectedInput, int expectedOutput)
        {
            // Arrange:
            _converter = new Converter(inputCapacity, outputCapacity, resourcesPerCycle, conversionOutput,
                conversionTime);
            _converter.LoadInputResources(inputCapacity);
            _converter.Start();
        
            // Act:
            _converter.Update(conversionTime);
        
            // Assert:
            Assert.AreEqual(expectedInput, _converter.InputResourcesCount);
            Assert.AreEqual(expectedOutput, _converter.OutputResourcesCount);
        }
    }
}