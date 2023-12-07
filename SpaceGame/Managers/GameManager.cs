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
            var texture = Globals.Content.Load<Texture2D>("bullet"); 
            ProjectileManager.Init();
            UIManager.Init(texture); 

            _player = new(Globals.Content.Load<Texture2D>("player"), 
                new (Globals.Bounds.X / 2, Globals.Bounds.Y /2));

            AlienManager.Init();
            AlienManager.AddAlienGreen(); 

        }

        public void Restart()
        {
            ProjectileManager.Reset();
            AlienManager.Reset();
            _player.Reset();
        }

        public void Update()
        {
            InputManager.Update(); 
            _player.Update(AlienManager.Aliens);
            AlienManager.Update(_player); 
            ProjectileManager.Update(AlienManager.Aliens);

            if (_player.Dead) Restart();

        }

        public void Draw()
        {
            _player.Draw();
            ProjectileManager.Draw();
            AlienManager.Draw();
            UIManager.Draw(_player); 
        }
 
    }
}
