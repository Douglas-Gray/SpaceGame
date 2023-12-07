using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Abilities;
using SpaceGame.Managers;
using SpaceGame.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class Player : Sprite
    {

        public Weapon Weapon { get; set; } = new Blaster();
        public Ability Ability { get; set; } = new RingBlast();

        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
     
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

            Weapon.Update();
            Ability.Update();

            if (InputManager.MouseLeftDown)
            {
                Weapon.Fire(this); 
            }

            if (InputManager.SpacePressed) {
                Ability.Fire(this); 
            }

            if (InputManager.MouseRightClicked)
            {
                Weapon.Reload(); 
            }

        }
    }
}
