using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Game.App
{
    public interface IRepository
    {
        UniTask<bool> SetState(Dictionary<string, object> gameState);
        UniTask<(bool, Dictionary<string, object>)> GetState();
    }
} 