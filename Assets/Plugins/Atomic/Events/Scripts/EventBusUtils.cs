using System.Runtime.CompilerServices;
using UnityEngine;

namespace Atomic.Events
{
    public static class EventBusUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NameToId(in string name) => new PropertyName(name).GetHashCode();

        ///For debugging purposes only. Returns the string value representing the string in the Editor.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string IdToName(in int id) => new PropertyName(id).ToString();
    }
}