using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Game.App
{
    public interface IRepository
    {
        public int Version { get; }
        UniTask<bool> SetState(Dictionary<string, string> gameState);
        UniTask<(bool, Dictionary<string, string>)> GetState(int version);
    }
} 