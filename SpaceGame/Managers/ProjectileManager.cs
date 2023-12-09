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
        private static Texture2D _textureAlienBullet;
        private static Texture2D _textureExplosion;
        public static List<Projectile> Projectiles { get; } = new();
        public static List<Projectile> AlienProjectiles { get; } = new();

        private static Random _random;

        public static void Init()
        {
            _textureBullet = Globals.Content.Load<Texture2D>("bullet");
            _textureAlienBullet = Globals.Content.Load<Texture2D>("alienBullet");
            _textureExplosion = Globals.Content.Load<Texture2D>("explosion4x4");
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
                if (p.texture == _textureExplosion)
                { 
                    if (p.Lifespan <= 0.70) { color = Color.LightYellow; }
                    if (p.Lifespan <= 0.60) { color = Color.Yellow; }
                    if (p.Lifespan < 0.30) { color = Color.Orange; }
                    if (p.Lifespan < 0.20) { color = Color.DarkOrange; }

                    p.Draw(color * (p.Lifespan * 4)); 
                }
                else
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
