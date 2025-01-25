using System;
using UnityEngine;

namespace Game.Scripts.Interfaces
{
    public interface IEventListener
    {
        event Action<GameObject> OnEventTriggered;
    }

}