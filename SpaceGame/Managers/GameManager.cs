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
            ProjectileManager.Init();

            _player = new(Globals.Content.Load<Texture2D>("player"), 
                new (Globals.Bounds.X / 2, Globals.Bounds.Y /2));

            AlienManager.Init();
            AlienManager.AddAlien(); 

        }

        public void Update()
        {
            InputManager.Update(); 
            _player.Update();
            AlienManager.Update(_player); 
            ProjectileManager.Update(AlienManager.Aliens); 
        }

        public void Draw()
        {
            _player.Draw();
            ProjectileManager.Draw();
            AlienManager.Draw(); 
        }
 
    }
}
