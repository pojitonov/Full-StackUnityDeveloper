using System;
using UnityEngine;

namespace Homework
{
    /**
       Конвертер представляет собой преобразователь ресурсов, который берет ресурсы
       из зоны погрузки (справа) и через несколько секунд преобразовывает его в
       ресурсы другого типа (слева).

       Конвертер работает автоматически. Когда заканчивается цикл переработки
       ресурсов, то конвертер берет следующую партию и начинает цикл по новой, пока
       можно брать ресурсы из зоны загрузки или пока есть место для ресурсов выгрузки.

       Также конвертер можно выключать. Если конвертер во время работы был
       выключен, то он возвращает обратно ресурсы в зону загрузки. Если в это время
       были добавлены еще ресурсы, то при переполнении возвращаемые ресурсы
       «сгорают».

       Характеристики конвертера:
       - Зона погрузки: вместимость бревен
       - Зона выгрузки: вместимость досок
       - Кол-во ресурсов, которое берется с зоны погрузки
       - Кол-во ресурсов, которое поставляется в зону выгрузки
       - Время преобразования ресурсов
       - Состояние: вкл/выкл
     */
    public sealed class Converter
    {
        private readonly int _inputCapacity;
        private readonly int _outputCapacity;
        private readonly int _resourcesPerCycle;
        private readonly int _conversionOutput;
        private readonly float _conversionTime;
        private readonly bool _isRunning;
        private float _currentTime;
        public int InputResourcesCount { get; private set; }
        public int OutputResourcesCount { get; private set; }

        public Converter(int inputCapacity, int outputCapacity, int resourcesPerCycle, int conversionOutput, float conversionTime)
        {
            _inputCapacity = inputCapacity;
            _outputCapacity = outputCapacity;
            _resourcesPerCycle = resourcesPerCycle;
            _conversionOutput = conversionOutput;
            _conversionTime = conversionTime;
            _isRunning = true;
        }

        public int LoadInputResources(int count)
        {
            int availableSpace = _inputCapacity - InputResourcesCount;
            int toAdd = Math.Min(availableSpace, count);
            InputResourcesCount += toAdd;
            return count - toAdd;
        }

        public void Update(float time)
        {
            if (!_isRunning)
                return;
            _currentTime += time;
            if (_currentTime >= _conversionTime)
            {
                _currentTime = 0;
                ProcessResources();
            }
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
    }
}