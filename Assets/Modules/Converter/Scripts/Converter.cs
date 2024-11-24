using System;

namespace Homework
{
    public sealed class Converter
    {
        private readonly int _inputCapacity;
        private readonly int _outputCapacity;
        private readonly int _resourcesPerCycle;
        private readonly int _conversionOutput;
        private readonly float _conversionTime;
        private float _processingProgress;
        private float _currentTime;
        public int InputResourcesCount { get; private set; }
        public int OutputResourcesCount { get; private set; }
        public bool IsRunning { get; private set; }

        public Converter(int inputCapacity, int outputCapacity, int resourcesPerCycle, int conversionOutput,
            float conversionTime)
        {
            ValidateInputs(inputCapacity, outputCapacity, resourcesPerCycle, conversionOutput, conversionTime);
            _inputCapacity = inputCapacity;
            _outputCapacity = outputCapacity;
            _resourcesPerCycle = resourcesPerCycle;
            _conversionOutput = conversionOutput;
            _conversionTime = conversionTime;
        }

        private static void ValidateInputs(int inputCapacity, int outputCapacity, int resourcesPerCycle,
            int conversionOutput,
            float conversionTime)
        {
            ValidatePositive(inputCapacity, nameof(inputCapacity));
            ValidatePositive(outputCapacity, nameof(outputCapacity));
            ValidatePositive(resourcesPerCycle, nameof(resourcesPerCycle));
            ValidatePositive(conversionOutput, nameof(conversionOutput));
            ValidatePositive(conversionTime, nameof(conversionTime));
        }

        private static void ValidatePositive<T>(T value, string paramName) where T : IComparable<T>
        {
            if (value.CompareTo(default) <= 0)
                throw new ArgumentOutOfRangeException(paramName, "Value must be greater than 0.");
        }

        public int LoadInputResources(int count)
        {
            if (count <= 0)
                ValidatePositive(count, nameof(count));

            int availableSpace = _inputCapacity - InputResourcesCount;
            if (availableSpace <= 0)
            {
                BurnExcessInputResources();
                return count;
            }

            int toAdd = Math.Min(availableSpace, count);
            InputResourcesCount += toAdd;

            return count - toAdd;
        }

        public void Update(float time)
        {
            if (time <= 0)
                ValidatePositive(time, nameof(time));
            if (!IsRunning)
                return;
            _currentTime += time;
            int cycles = (int)(_currentTime / _conversionTime);
            _currentTime %= _conversionTime;

            for (int i = 0; i < cycles; i++)
            {
                ProcessResources();
            }

            _processingProgress = _currentTime / _conversionTime;
        }

        public void Shutdown()
        {
            IsRunning = false;

            int resourcesUsed = (int)(_resourcesPerCycle * _processingProgress);

            if (resourcesUsed >= _resourcesPerCycle)
                InputResourcesCount += resourcesUsed;
            else
                BurnExcessInputResources();

            _processingProgress = 0;
        }


        public void Start()
        {
            _currentTime = 0;
            _processingProgress = 0;
            IsRunning = true;
        }

        private void ProcessResources()
        {
            if (InputResourcesCount < _resourcesPerCycle)
                return;
            int spaceLeft = _outputCapacity - OutputResourcesCount;
            if (spaceLeft < _conversionOutput)
                return;

            InputResourcesCount -= _resourcesPerCycle;
            OutputResourcesCount += _conversionOutput;
        }

        private void BurnExcessInputResources()
        {
            if (InputResourcesCount > _inputCapacity)
            {
                InputResourcesCount = _inputCapacity;
            }
        }
    }
}