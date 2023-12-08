using SpaceGame.Managers;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.AlienWeapons
{
    public class AlienBlaster : AlienWeapon
    {
        public AlienBlaster()
        {
            cooldown = 1.5f;
        }

        protected override void CreateProjectiles(Alien alien)
        {
            ProjectileData pd = new()
            {
                Position = alien.Position,
                Rotation = alien.Rotation,
                Lifespan = 2f,
                Speed = 200
            };

            ProjectileManager.AddAlienProjectileBullet(pd);
        }

    }
}
