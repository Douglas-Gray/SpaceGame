using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework; 
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpaceGame.Managers
{
    public static class ScoreManager
    {
        
        private static SpriteFont _font;
        private static Vector2 _textPosition;
        private static string _playerScore;
        private static int _score; 
 
        public static void Init()
        {
            _font = Globals.Content.Load<SpriteFont>("font");
        }

        public static void Reset()
        {
           _score = 0;
        }
        public static void Update(List<Alien> aliens)
        {

            foreach (var a in aliens)
            {
                if (a.HP <= 0)
                {
                    _score += 1;
                }    
            }

            _playerScore = _score.ToString(); 
            var x = _font.MeasureString(_score.ToString()).X / 2;
            _textPosition = new(Globals.Bounds.X + x - Globals.Bounds.X / 2, 14);
        }

        public static void Draw()
        {
            Globals.SpriteBatch.DrawString(_font, _playerScore, _textPosition, Color.White);
        }

        public static int ReturnScore()
        {
            return _score; 
        }

    }
}
