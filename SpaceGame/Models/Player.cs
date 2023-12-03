using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class Player : Sprite
    {

        private readonly float _cooldown;
        private float _cooldownleft;
        private readonly int _maxAmmo; 
        public int Ammo { get; private set; }
        private readonly float _reloadTime;
        public bool Reloading { get; private set; }
        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
            _cooldown = 0.25f;
            _cooldownleft = 0f;
            _maxAmmo = 30;
            Ammo = _maxAmmo;
            _reloadTime = 2f;
            Reloading = false; 
        }

        private void Reload()
        {
            if (Reloading) return;
            _cooldownleft = _reloadTime;
            Reloading = true;
            Ammo = _maxAmmo; 
        }

        private void Fire()
        {
            if (_cooldownleft > 0 || Reloading) return;
            Ammo--; 
            if (Ammo > 0)
            {
                _cooldownleft = _cooldown; 
            }
            else
            {
                Reload(); 
            }


            ProjectileData projectileData = new()
            {
                Position = Position,
                Rotation = Rotation,
                Lifespan = 2,
                Speed = 600
            };

            ProjectileManager.AddProjectile(projectileData); 
        }

        public void Update()
        {
            if (_cooldownleft > 0)
            {
                _cooldownleft -= Globals.TotalSeconds; 
            }
            else if (Reloading)
            {
                Reloading = false; 
            }

            if (InputManager.Direction != Vector2.Zero)
            {
                var direction = Vector2.Normalize(InputManager.Direction);
                Position = new(
                        MathHelper.Clamp(Position.X + (direction.X * Speed * Globals.TotalSeconds), 0, Globals.Bounds.X),
                        MathHelper.Clamp(Position.Y + (direction.Y * Speed * Globals.TotalSeconds), 0, Globals.Bounds.Y)
                ); 
            }

            var toMousePointer = InputManager.MousePosition - Position;
            Rotation = (float)Math.Atan2(toMousePointer.Y, toMousePointer.X); 

            if (InputManager.MouseLeftDown)
            {
                Fire(); 
            }

            if (InputManager.MouseRightClicked)
            {
                Reload(); 
            }

        }
    }
}
