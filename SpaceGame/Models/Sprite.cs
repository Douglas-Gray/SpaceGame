﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework; 


namespace SpaceGame.Models
{
    public class Sprite
    {
        
        protected readonly Vector2 origin;
        public Texture2D texture { get; set; }
        public Vector2 Position { get; set; }
        public int Speed { get; set; }
        public float Rotation { get; set; }

        public Sprite (Texture2D spriteTexture, Vector2 spritePosition)
        {
            texture = spriteTexture;
            Position = spritePosition;
            Speed = 300;
            origin = new(spriteTexture.Width / 2, spriteTexture.Height / 2);

        }

        public virtual void Draw(Color color)
        {
            Globals.SpriteBatch.Draw(texture, Position, null, color, Rotation, origin, 1, SpriteEffects.None, 1); 
        }

    }
}
