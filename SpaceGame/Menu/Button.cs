using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceGame.Managers;
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;

namespace SpaceGame.Menu
{
    public class Button
    {
        private readonly Texture2D _texture;
        private Vector2 _position;
        private readonly Rectangle _rect;
        private Color _shade = Color.White;
        private string _buttonText { get; }
       private SpriteFont Font { get; }


        public Button(Texture2D texture, Vector2 position, string buttonText)
        {
            Font = Globals.Content.Load<SpriteFont>("font");

            _texture = texture;
            _position = position;
            _buttonText = buttonText; 
            _rect = new((int)position.X, (int)position.Y, texture.Width, texture.Height);
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
            var x = _position.X + (Rectangle.Width - Font.MeasureString(_buttonText).X) / 2;
            var y = _position.Y + (Rectangle.Height - Font.MeasureString(_buttonText).Y) / 2;

            Globals.SpriteBatch.Draw(_texture, Rectangle, _shade);
            Globals.SpriteBatch.DrawString(Font, _buttonText, new Vector2(x, y), Color.Black);
        }
    }
}
