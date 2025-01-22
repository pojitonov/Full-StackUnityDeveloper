using System.Runtime.CompilerServices;
using UnityEngine;

namespace Atomic.Entities
{
    public static class EntityUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NameToId(string name)
        {
            return new PropertyName(name).GetHashCode();
        }
        
        ///For debugging purposes only. Returns the string value representing the string in the Editor.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string IdToName(int id)
        {
            return new PropertyName(id).ToString();
        }
    }
}