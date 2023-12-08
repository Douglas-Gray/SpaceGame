using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public Weapon Ability { get; set; } = new RingBlast();

        public bool Dead { get; private set; }

        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
     
        }

        public Player(Texture2D tex) : base(tex, GetStartPosition())
        {
            Reset();
        }
        private static Vector2 GetStartPosition()
        {
            return new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2);
        }
        public void Reset()
        {
            Weapon = new Blaster();
            Ability = new RingBlast();
            Dead = false;
            Position = GetStartPosition();
        }

        private void CheckDeath(List<Alien> aliens, List<Projectile> projectiles)
        {
            foreach (var a in aliens)
            {
                if (a.HP <= 0) continue;
                if ((Position - a.Position).Length() < texture.Width - a.texture.Width)
                {
                    Dead = true;
                    break;
                }
            }

            foreach (var p in projectiles)
            {
                if ((Position - p.Position).Length() < texture.Width - p.texture.Width)
                {
                    Dead = true;
                    break;
                }
            }
        }
        public void Update(List<Alien> aliens, List<Projectile> projectiles)
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

            CheckDeath(aliens, projectiles);

        }
    }
}
