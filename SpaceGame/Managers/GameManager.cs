using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class GameManager
    {

        private readonly Player _player; 
        public GameManager()
        {

            _player = new(Globals.Content.Load<Texture2D>("player"), new(50, 50)); 

        }

        public void Update()
        {
            InputManager.Update(); 
            _player.Update();
        }

        public void Draw()
        {
            _player.Draw(); 
        }
 
    }
}
