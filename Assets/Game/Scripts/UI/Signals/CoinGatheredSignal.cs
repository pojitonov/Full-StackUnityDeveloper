using UnityEngine;

namespace Game.UI.Signals
{
    public class CoinGatheredSignal
    {
        public int Money { get; }
        public Vector3 StartPosition { get; }

        public CoinGatheredSignal(int money, Vector3 startPosition)
        {
            StartPosition = startPosition;
            Money = money;
        }
    }
}
