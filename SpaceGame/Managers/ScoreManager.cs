using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework; 
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public static class ScoreManager
    {
        public static int Score { get; set; }
        private static SpriteFont _font;
        private static Vector2 _textPosition;
        private static string _playerScore;

        public static void Init()
        {
            _font = Globals.Content.Load<SpriteFont>("font");
        }

        public static void Reset()
        {
            Score = 0; 
        }
        public static void Update(List<Alien> aliens)
        {

            foreach (var a in aliens)
            {
                if (a.HP <= 0)
                {
                    Score += 1;
                }    
            }

            _playerScore = Score.ToString(); 
            var x = _font.MeasureString(Score.ToString()).X / 2;
            _textPosition = new(Globals.Bounds.X + x - Globals.Bounds.X / 2, 14);
        }

        public static void Draw()
        {
            Globals.SpriteBatch.DrawString(_font, _playerScore, _textPosition, Color.White);
        }
    }
}
