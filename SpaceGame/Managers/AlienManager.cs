using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public static class AlienManager
    {
        public static List<Alien> Aliens { get; } = new();
        private static Texture2D _texture;
        private static float _spawnCooldown;
        private static float _spawnTime;
        private static Random _random;
        private static int _padding;

        public static void Init()
        {
            _texture = Globals.Content.Load<Texture2D>("AlienGreen");
            _spawnCooldown = 0.33f;
            _spawnTime = _spawnCooldown;
            _random = new();
            _padding = _texture.Width / 2;
        }

        private static Vector2 RandomPosition()
        {
            float width = Globals.Bounds.X;
            float height = Globals.Bounds.Y;
            Vector2 position = new(); 

            if (_random.NextDouble() < width / (width + height))
            {
                position.X = (int)(_random.NextDouble() * width);
                position.Y = (int)(_random.NextDouble() < 0.5 ? - _padding : height + _padding);

            }
            else
            {
                position.Y = (int)(_random.NextDouble() * height);
                position.X = (int)(_random.NextDouble() < 0.5 ? - _padding : width + _padding);
            }

            return position; 
        }

        public static void AddAlien()
        {
            Aliens.Add(new(_texture, RandomPosition()) ); 
        }

        public static void Update(Player player)
        {
            _spawnTime -= Globals.TotalSeconds; 

            if ( _spawnTime < 0 )
            {
                _spawnTime += _spawnCooldown;
                AddAlien(); 
            }

            foreach (var a in Aliens)
            {
                a.Update(player); 
            }
            Aliens.RemoveAll((a) => a.HP <= 0); 
        }

        public static void Draw()
        {
            foreach (var a in Aliens)
            {
                a.Draw(); 
            }
        }
    }
}
