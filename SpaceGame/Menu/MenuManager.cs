using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace SpaceGame.Menu
{
    public class MenuManager
    {
        private Texture2D ButtonTexture { get; }
        private SpriteFont Font { get; }
        private readonly List<Button> _buttons = new();
        public int Counter { get; set; }

        public MenuManager()
        {
            ButtonTexture = Globals.Content.Load<Texture2D>("button");
            Font = Globals.Content.Load<SpriteFont>("font");
        }

        public Button AddButton(Vector2 pos, string buttonText)
        {
            Button b = new(ButtonTexture, pos, buttonText);
            _buttons.Add(b);

            return b;
        }

        public void Update()
        {
            foreach (var item in _buttons)
            {
                item.Update();
            }
        }

        public void Draw()
        {
            foreach (var item in _buttons)
            {
                item.Draw();
            }

            //Globals.SpriteBatch.DrawString(Font, Counter.ToString(), new(10, 10), Color.Black);
        }

    }
}
