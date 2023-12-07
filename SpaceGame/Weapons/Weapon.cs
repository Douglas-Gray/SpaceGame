using SpaceGame.Managers;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Weapons
{
    public abstract class Weapon
    {
        protected float cooldown;
        protected float cooldownleft;
        protected int maxAmmo;
        public int Ammo { get; protected set; }
        protected float reloadTime;
        public bool Reloading { get; private set; }




        protected Weapon()
        {
            cooldownleft = 0f;
            Reloading = false;
        }

        public virtual void Reload()
        {

            if (Reloading || (Ammo == maxAmmo)) return;
            cooldownleft = reloadTime;
            Reloading = true;
            Ammo = maxAmmo;

        }

        protected abstract void CreateProjectiles(Player player); 

        public virtual void Fire(Player player)
        {
            if (cooldownleft > 0 || Reloading) return;
            Ammo--;
            if (Ammo > 0)
            {
                cooldownleft = cooldown;
            }
            else
            {
                Reload();
            }

            CreateProjectiles(player); 
        }

        public virtual void Update()
        {
            if (cooldownleft > 0)
            {
                cooldownleft -= Globals.TotalSeconds;
            }
            else if (Reloading)
            {
                Reloading = false; 
            }
        }
    }
}
