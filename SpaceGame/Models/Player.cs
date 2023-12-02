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
        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        { }

        private void Fire()
        {
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

            if (InputManager.MouseClicked)
            {
                Fire(); 
            }

        }
    }
}
