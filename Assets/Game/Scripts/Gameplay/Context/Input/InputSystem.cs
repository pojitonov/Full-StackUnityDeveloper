using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;
using UnityEngine;

namespace SampleGame
{
    public sealed class InputSystem : IEcsRunSystem
    {
        private readonly InputMap _inputMap;
        private readonly EcsSharedInject<GameData> _gameData;

        public void Run(IEcsSystems systems)
        {
            ref var inputData = ref _gameData.Value.inputData;
            inputData.moveDirection = float3.zero;

            if (Input.GetKey(_inputMap.forward))
            {
                inputData.moveDirection.z = 1;
            }
            else if (Input.GetKey(_inputMap.backward))
            {
                inputData.moveDirection.z = -1;
            }
            else if (Input.GetKey(_inputMap.left))
            {
                inputData.moveDirection.x = -1;
            }
            else if (Input.GetKey(_inputMap.right))
            {
                inputData.moveDirection.x = 1;
            }
        }

        public InputSystem(InputMap inputMap)
        {
            _inputMap = inputMap;
        }
    }
}