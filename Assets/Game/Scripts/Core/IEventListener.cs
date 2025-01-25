using System;
using UnityEngine;

namespace Game.Scripts.Core
{
    public interface IEventListener
    {
        event Action<GameObject> OnEventTriggered;
    }

}