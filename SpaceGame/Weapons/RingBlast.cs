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
            const float angleStep = (float)(Math.PI / 16);

            ProjectileData pd = new()
            {
                Position = player.Position,
                Rotation = player.Rotation - 2 * angleStep,
                Lifespan = 2f,
                Speed = 800
            };

            for (int i = 0; i < 50; i++)
            {
                pd.Rotation += angleStep;
                ProjectileManager.AddProjectile(pd);
            }
        }

    }
}
