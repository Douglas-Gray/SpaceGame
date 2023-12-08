using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using SpaceGame.Managers;

namespace SpaceGame.Menu
{
    public class Button
    {
        private readonly Texture2D _texture;
        private Vector2 _position;
        private readonly Rectangle _rect;
        private Color _shade = Color.White;
        private string _buttonText { get; }
        private SpriteFont _font { get; }


        public Button(Texture2D texture, Vector2 position, string buttonText)
        {
            _font = Globals.Content.Load<SpriteFont>("font");

            _texture = texture;
            _position = position;
            _position.X = position.X - _texture.Width / 2; 
            _buttonText = buttonText; 
            _rect = new((int)_position.X, (int)_position.Y, texture.Width, texture.Height);
        }

        public void Update()
        {
            if (InputManager.MouseCursor.Intersects(_rect))
            {
                _shade = Color.DarkGray;
                if (InputManager.MouseClicked)
                {
                    Click();
                }
            }
            else
            {
                _shade = Color.White;
            }
        }

        public event EventHandler OnClick;

        private void Click()
        {
            OnClick?.Invoke(this, EventArgs.Empty);
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }

        public void Draw()
        {
            var x = _position.X + (Rectangle.Width - _font.MeasureString(_buttonText).X) / 2; 
            var y = _position.Y + (Rectangle.Height - _font.MeasureString(_buttonText).Y) / 2;

            Globals.SpriteBatch.Draw(_texture, Rectangle, _shade);
            Globals.SpriteBatch.DrawString(_font, _buttonText, new Vector2(x, y), Color.Black);
        }
    }
}
