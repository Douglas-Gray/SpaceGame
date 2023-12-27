using Microsoft.Xna.Framework;
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
        private static Texture2D _textureLaser;
        private static Texture2D _textureAlienBullet;
        private static Texture2D _textureExplosion;
        public static List<Projectile> Projectiles { get; } = new();
        public static List<Projectile> AlienProjectiles { get; } = new();

        private static Random _random;

        public static void Init()
        {
            _textureBullet = Globals.Content.Load<Texture2D>("bullet");
            _textureAlienBullet = Globals.Content.Load<Texture2D>("alienLaser");
            _textureExplosion = Globals.Content.Load<Texture2D>("explosion4x4");
            _textureLaser = Globals.Content.Load<Texture2D>("laser");
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

        public static void AddProjectileLaser(ProjectileData projectileData)
        {
            Projectiles.Add(new(_textureLaser, projectileData));
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
                    if((p.Position - a.Position).Length() < a.texture.Width)
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
            Color color = Color.White;
            foreach (var p in Projectiles)
            {
                if (p.ProjectileType.Equals("explosion"))
                {
                    if (p.Lifespan <= p.OriginalLifespan) { color = Color.LightYellow; }
                    if (p.Lifespan <= p.OriginalLifespan / 1.2) { color = Color.Yellow; }
                    if (p.Lifespan <= p.OriginalLifespan / 3) { color = Color.Orange; }
                    if (p.Lifespan <= p.OriginalLifespan / 6) { color = Color.DarkOrange; }

                    p.Draw(color * (p.Lifespan * 4));
                }
                if (p.ProjectileType.Equals("ringblast"))
                {
                    p.Draw(Color.DarkBlue);
                }
                if(p.ProjectileType.Equals("blaster"))
                {

                    p.Draw(Color.White);
                }
            }

            foreach (var ap in AlienProjectiles)
            {
                ap.Draw(Color.White);
            }
        }

    }
}
