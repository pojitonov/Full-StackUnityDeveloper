using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(fileName = "InputMap", menuName = "SampleGame/Common/New InputMap")]
    public sealed class InputMap : ScriptableObject
    {
        public KeyCode forward = KeyCode.W;
        public KeyCode backward = KeyCode.S;
        public KeyCode left = KeyCode.A;
        public KeyCode right = KeyCode.D;
    }
}