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
        private static Texture2D _texture; 

        public static void Init()
        {
            _texture = Globals.Content.Load<Texture2D>("AlienGreen"); 
        }

        public static void AddAlien()
        {
            Aliens.Add(new(_texture, new(100, 100)) ); 
        }

        public static void Update(Player player)
        { 
            foreach (var a in Aliens)
            {
                a.Update(player); 
            }
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
