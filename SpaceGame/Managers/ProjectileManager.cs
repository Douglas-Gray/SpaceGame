using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public static class ProjectileManager
    {
        private static Texture2D _texture;
        public static List<Projectile> Projectiles { get; } = new(); 

        public static void Init()
        {
            _texture = Globals.Content.Load<Texture2D>("bullet"); 
        }

        public static void AddProjectile(ProjectileData projectileData)
        {
            Projectiles.Add(new(_texture, projectileData)); 
        }

        public static void Update(List<Alien> aliens)
        {
            foreach (var p in Projectiles)
            {
                p.Update(); 

                foreach (var a in aliens)
                {
                    if (a.HP <= 0) continue; 
                    if((p.Position - a.Position).Length() < 16)
                    {
                        a.TakeDamage(1);
                        p.Destroy();
                        break; 
                    }
                }

            }
            Projectiles.RemoveAll((p) => p.Lifespan <= 0); 
        }

        public static void Draw()
        {
            foreach (var p in Projectiles)
            {
                p.Draw(); 
            }
        }

    }
}
