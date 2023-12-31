﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public static class AlienManager
    {
        public static List<Alien> Aliens { get; } = new();
        private static Texture2D _textureAlienSeeker;
        private static Texture2D _textureAlienTurret;
        private static float _spawnCooldown;
        private static float _spawnTimeSeeker;
        private static float _spawnTimeTurret;
        private static Random _random;
        private static int _padding;

        public static void Init()
        {
            _textureAlienSeeker = Globals.Content.Load<Texture2D>("alienShipRed");
            _textureAlienTurret = Globals.Content.Load<Texture2D>("alienTurret");
            _spawnCooldown = 0.33f;
            _spawnTimeSeeker = _spawnCooldown;
            _spawnTimeTurret = _spawnCooldown; 
            _random = new();
            _padding = _textureAlienSeeker.Width / 2;
        }

        public static void Reset()
        {
            Aliens.Clear();
            _spawnTimeTurret = _spawnCooldown;
            _spawnTimeSeeker = _spawnCooldown; 
        }


        private static Vector2 RandomPositionEdge()
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

        private static Vector2 RandomPositionInside(Player player)
        {
            Vector2 position = new();

            position.X = (int)_random.NextInt64(0, Globals.Bounds.X);
            position.Y = (int)_random.NextInt64(0, Globals.Bounds.Y);

            while ( (position.X < player.Position.X + 150 && position.X > player.Position.X - 150) && (position.Y < player.Position.Y + 150 && position.Y > player.Position.Y - 150) )
            { 
                position.X = (int)_random.NextInt64(0, Globals.Bounds.X);
                position.Y = (int)_random.NextInt64(0, Globals.Bounds.Y);
            }
          
            return position;
        }

        public static void AddAlienGreen()
        {
            Aliens.Add(new(_textureAlienSeeker, RandomPositionEdge(), 100, "seeker")); 
        }

        public static void AddAlienTurret(Player player)
        {
            Aliens.Add(new(_textureAlienTurret, RandomPositionInside(player), 0, "turret"));
        }

        public static void Update(Player player)
        {
            _spawnTimeSeeker -= Globals.TotalSeconds;
            _spawnTimeTurret -= Globals.TotalSeconds;

            if ( _spawnTimeSeeker < 0 )
            {
                _spawnTimeSeeker += _spawnCooldown;
                AddAlienGreen();
            }

            if(_spawnTimeTurret < 0)
            {
                _spawnTimeTurret += _spawnCooldown * 12;
                AddAlienTurret(player);
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
                a.Draw(Color.White);
            }
        }
    }
}
