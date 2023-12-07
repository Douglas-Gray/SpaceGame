using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class Alien : Sprite
    {
        public int HP { get; private set; }
        public Alien(Texture2D texture, Vector2 position, int speed) : base(texture, position)
        {
            Speed = speed; 
            HP = 1; 
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
        }
    }
}
