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
        private bool _isCycleStarted;

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

        public void Start()
        {
            if (IsRunning) return;
            _currentTime = 0;
            _processingProgress = 0;
            IsRunning = true;
        }

        public void Update(float deltaTime)
        {
            if (deltaTime <= 0)
                ValidatePositive(deltaTime, nameof(deltaTime));
            if (!IsRunning) return;
            _processingProgress += deltaTime;
            if (!_isCycleStarted && _processingProgress >= _conversionTime)
                StartCycle();
            if (_isCycleStarted)
                ProcessResources(deltaTime);
        }

        private void StartCycle()
        {
            if (!_isCycleStarted && InputResourcesCount >= _resourcesPerCycle)
            {
                InputResourcesCount -= _resourcesPerCycle;
                _isCycleStarted = true;
            }
        }

        private void ProcessResources(float deltaTime)
        {
            _currentTime += deltaTime;
            if (_currentTime >= _conversionTime)
            {
                CompleteCycle();
                _currentTime -= _conversionTime;
            }
        }

        private void CompleteCycle()
        {
            int availableSpace = _outputCapacity - OutputResourcesCount;
            if (availableSpace >= _conversionOutput)
            {
                OutputResourcesCount += _conversionOutput;
            }
            else
            {
                InputResourcesCount += _resourcesPerCycle;
            }

            _isCycleStarted = false;
        }

        public void Shutdown()
        {
            if (!IsRunning) return;

            IsRunning = false;

            if (_isCycleStarted)
            {
                int partialResourcesToReturn = (int)(_resourcesPerCycle * _processingProgress);
                int availableSpace = _inputCapacity - InputResourcesCount;

                if (partialResourcesToReturn > 0)
                {
                    InputResourcesCount += Math.Min(partialResourcesToReturn, availableSpace);
                    if (partialResourcesToReturn > availableSpace)
                        BurnExcessInputResources();
                }
            }

            _isCycleStarted = false;
            _processingProgress = 0;
            _currentTime = 0;
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