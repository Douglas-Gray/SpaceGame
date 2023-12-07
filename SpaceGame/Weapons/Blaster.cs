using SpaceGame.Managers;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Weapons
{
    public class Blaster : Weapon
    {
        public Blaster()
        {
            cooldown = 0.1f;
            maxAmmo = 60;
            Ammo = maxAmmo;
            reloadTime = 1f; 
        }

        protected override void CreateProjectiles(Player player)
        {
            ProjectileData pd = new()
            {
                Position = player.Position,
                Rotation = player.Rotation,
                Lifespan = 2f,
                Speed = 600
            };

            ProjectileManager.AddProjectileBullet(pd); 
        }

    }
}
