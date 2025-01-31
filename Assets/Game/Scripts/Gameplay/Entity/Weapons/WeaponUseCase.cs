using Atomic.Entities;

namespace Game.Gameplay
{
    public static class WeaponUseCase
    {
        public static bool AddCLips(in IEntity character, in int amount)
        {
            var weapon = character.GetWeapon();
            if (weapon == null) 
                return true;
            
            if (!weapon.TryGetAmmo(out var ammo)) 
                return false;
            
            return ammo.Add(amount);
        }
    }
}