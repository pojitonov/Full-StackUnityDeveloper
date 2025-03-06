using System;

namespace SampleGame
{
    [Serializable]
    public struct Weapon
    {
        public WeaponType Type;
        public float AttackRadius;
        public ProjectilePrototype Projectile;
    }

    public enum WeaponType
    {
        Melee,
        Bow
    }
}