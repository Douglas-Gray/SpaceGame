using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework; 
using System;
using SpaceGame.Managers;
using SpaceGame.AlienWeapons;
using SpaceGame.Weapons;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace SpaceGame.Models
{
    public class Alien : Sprite
    {
        public int HP { get; private set; }
        public string Type { get; private set; }
        public AlienWeapon AlienWeapon { get; set; } = new AlienBlaster();

        public static Random random;

        public Alien(Texture2D texture, Vector2 position, int speed, string type) : base(texture, position)
        {
            Speed = speed; 
            HP = 1; 
            Type = type;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage; 
        }

        public void Update(Player player)
        {
            var toPlayer = player.Position - Position;
            Rotation = (float)Math.Atan2(toPlayer.Y, toPlayer.X); 

            if (toPlayer.Length() > 4)
            {
                var dir = Vector2.Normalize(toPlayer);
                Position += dir * Speed * Globals.TotalSeconds;

            }

            if (HP <= 0) { Explode();}

            if (Type.Equals("turret"))
            {
                AlienWeapon.Fire(this);
                AlienWeapon.Update();
            }

        }

        public void Explode()
        {
            random = new();

            const float angleStep = (float)(Math.PI / 32);

            SoundEffect soundEffect = Globals.Content.Load<SoundEffect>("SFX/explosionSfx");

            soundEffect.Play();

            ProjectileData pd = new()
            {
                Position = Position,
                Rotation = Rotation - 2 * angleStep,
                Lifespan = 0.70f,
                Speed = 400,
                ProjectileType = "explosion"
            };
            for (int i = 0; i < 80; i++)
            {
                pd.Speed = random.Next(20, 100);
                pd.Rotation += angleStep;
                ProjectileManager.AddProjectileExplosion(pd);
            }
        }
    }
}
