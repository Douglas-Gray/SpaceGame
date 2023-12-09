using SpaceGame.Managers;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Weapons
{
    public class RingBlast : Weapon
    {
        public RingBlast()
        {
            cooldown = 0.75f;
            maxAmmo = 1;
            Ammo = maxAmmo;
            reloadTime = 3f;
        }

        protected override void CreateProjectiles(Player player)
        {
            const float angleStep = (float)(Math.PI / 32);

            ProjectileData pd = new()
            {
                Position = player.Position,
                Rotation = player.Rotation - 2 * angleStep,
                Lifespan = 2f,
                Speed = 800,
                ProjectileType = "ringblast"
            };

            for (int i = 0; i < 80; i++)
            {
                pd.Rotation += angleStep;
                ProjectileManager.AddProjectileBullet(pd);
            }
        }

    }
}
