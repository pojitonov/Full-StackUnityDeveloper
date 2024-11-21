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
        private float _currentTime;
        public int InputResourcesCount { get; private set; }
        public int OutputResourcesCount { get; private set; }
        public bool IsRunning { get; private set; }

        public Converter(int inputCapacity, int outputCapacity, int resourcesPerCycle, int conversionOutput,
            float conversionTime)
        {
            _inputCapacity = inputCapacity;
            _outputCapacity = outputCapacity;
            _resourcesPerCycle = resourcesPerCycle;
            _conversionOutput = conversionOutput;
            _conversionTime = conversionTime;
            Start();
        }

        public int LoadInputResources(int count)
        {
            if(count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than 0.");
                
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
                throw new ArgumentOutOfRangeException(nameof(time), "Time must be greater than 0.");
            if (!IsRunning)
                return;
            _currentTime += time;
            int cycles = (int)(_currentTime / _conversionTime);
            for (int i = 0; i < cycles; i++)
            {
                ProcessResources();
            }
        }

        public void Shutdown()
        {
            IsRunning = false;

            InputResourcesCount += OutputResourcesCount;
            OutputResourcesCount = 0;
            BurnExcessInputResources();
        }

        private void Start()
        {
            _currentTime = 0;
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