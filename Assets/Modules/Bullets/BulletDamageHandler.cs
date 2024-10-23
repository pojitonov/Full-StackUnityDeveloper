using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletDamageHandler : IBulletDamageHandler
    {
        public void HandleCollision(Bullet bullet, Collision2D collision)
        {
            int damage = bullet.damage;
            GameObject other = collision.gameObject;
            
            if (damage <= 0)
                return;

            if (other.TryGetComponent(out Player player))
            {
                if (bullet.isPlayer != player.isPlayer)
                {
                    if (player.health <= 0)
                        return;

                    player.health = Mathf.Max(0, player.health - damage);
                    player.OnHealthChanged?.Invoke(player, player.health);

                    if (player.health <= 0)
                        player.OnHealthEmpty?.Invoke(player);
                }
            }
            else if (other.TryGetComponent(out Enemy enemy))
            {
                if (bullet.isPlayer != enemy.isPlayer)
                {
                    if (enemy.health > 0)
                    {
                        enemy.health = Mathf.Max(0, enemy.health - damage);
                    }
                }
            }
        }
    }
}