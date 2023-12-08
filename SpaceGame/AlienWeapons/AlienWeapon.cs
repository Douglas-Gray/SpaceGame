using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.AlienWeapons
{
    public abstract class AlienWeapon
    {
        protected float cooldown;
        protected float cooldownleft;
        protected int maxAmmo;
        protected float reloadTime;

        protected AlienWeapon()
        {
            cooldownleft = 0f;
        }

        protected abstract void CreateProjectiles(Alien alien);

        public virtual void Fire(Alien alien)
        {
            if (cooldownleft > 0) return;
            cooldownleft = cooldown;
            
            CreateProjectiles(alien);
        }

        public virtual void Update()
        {
            if (cooldownleft > 0)
            {
                cooldownleft -= Globals.TotalSeconds;
            }
        }
    }
}
