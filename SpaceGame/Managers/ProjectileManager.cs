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
        private static Texture2D _textureBullet;
        private static Texture2D _textureAlienBullet;
        private static Texture2D _textureExplosion;
        public static List<Projectile> Projectiles { get; } = new();
        public static List<Projectile> AlienProjectiles { get; } = new();

        public static void Init()
        {
            _textureBullet = Globals.Content.Load<Texture2D>("bullet");
            _textureAlienBullet = Globals.Content.Load<Texture2D>("alienBullet");
            _textureExplosion = Globals.Content.Load<Texture2D>("explosion");
        }

        public static void Reset()
        {
            Projectiles.Clear();
            AlienProjectiles.Clear(); 
        }

        public static void AddProjectileBullet(ProjectileData projectileData)
        {
            Projectiles.Add(new(_textureBullet, projectileData));
        }

        public static void AddAlienProjectileBullet(ProjectileData projectileData)
        {
            AlienProjectiles.Add(new(_textureAlienBullet, projectileData));
        }

        public static void AddProjectileExplosion(ProjectileData projectileData)
        {
            Projectiles.Add(new(_textureExplosion, projectileData));
        }

        public static void Update(List<Alien> aliens)
        {
            foreach (var p in Projectiles)
            {
                p.Update(); 

                foreach (var a in aliens)
                {
                    if (a.HP <= 0) continue; 
                    if((p.Position - a.Position).Length() < 8)
                    {
                        a.TakeDamage(1);
                        p.Destroy();
                        break; 
                    }
                }

            }
            Projectiles.RemoveAll((p) => p.Lifespan <= 0);

            foreach (var ap in AlienProjectiles)
            {
                ap.Update();

            }
            Projectiles.RemoveAll((ap) => ap.Lifespan <= 0);
        }

        public static void Draw()
        {
            foreach (var p in Projectiles)
            {
                p.Draw(); 
            }

            foreach (var ap in AlienProjectiles)
            {
                ap.Draw();
            }
        }

    }
}
