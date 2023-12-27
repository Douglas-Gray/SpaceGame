using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class Layer
    {
        private readonly Texture2D _texture;
        private Vector2 _position;
        private Vector2 _position2;
        private readonly float _depth;
        private readonly float _moveScale;
        private readonly float _defaultSpeed;

        public Layer(Texture2D texture, float depth, float moveScale, float defaultSpeed = 0.0f)
        {
            _texture = texture;
            _depth = depth;
            _moveScale = moveScale;
            _defaultSpeed = defaultSpeed;
            _position = Vector2.Zero;
            _position2 = Vector2.Zero;
        }

        public void Update(float movement)
        {
            _position.Y += ((movement * _moveScale) + _defaultSpeed) * Globals.TotalSeconds;
      
            _position.Y %= _texture.Height;

            if (_position.Y >= 0)
            {
                _position2.Y = _position.Y - _texture.Height;
            }
            else
            {
                _position2.Y = _position.Y + _texture.Height;
            }
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(_texture, _position, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, _depth);
            Globals.SpriteBatch.Draw(_texture, _position2, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, _depth);
        }
    }
}
