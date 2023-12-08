using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Menu;
using SpaceGame.Models;
using System;

namespace SpaceGame.Managers
{
    public class GameManager
    {

        private readonly Player _player;
        private readonly MenuManager menuManager = new();
        private bool gameStart = false; 

        public GameManager()
        {
            var ButtonTexture = Globals.Content.Load<Texture2D>("button"); 

            menuManager.AddButton(new(Globals.Bounds.X / 2 - ButtonTexture.Width / 2, Globals.Bounds.Y / 2)).OnClick += Action;

            var texture = Globals.Content.Load<Texture2D>("bullet");

            _player = new(Globals.Content.Load<Texture2D>("player"), 
                new (Globals.Bounds.X / 2, Globals.Bounds.Y /2));

            ScoreManager.Init();
            ProjectileManager.Init();
            UIManager.Init(texture);

            AlienManager.Init();
            AlienManager.AddAlienGreen(); 

        }

        public void Action(object sender, EventArgs e)
        {
            gameStart = true; 
        }

        public void Restart()
        {
            gameStart = false; 

            ScoreManager.Reset(); 
            ProjectileManager.Reset();
            AlienManager.Reset();
            _player.Reset();
        }

        public void Update()
        {
            InputManager.Update();
            menuManager.Update();

            if (!gameStart)
            {
                menuManager.Update(); 
            }
            else
            {
                _player.Update(AlienManager.Aliens);
                ScoreManager.Update(AlienManager.Aliens);
                AlienManager.Update(_player);
                ProjectileManager.Update(AlienManager.Aliens);

                if (_player.Dead) Restart();
            }    
        }

        public void Draw()
        {
            if (!gameStart) 
            {
                menuManager.Draw(); 
            }
            else
            {
                _player.Draw();
                ProjectileManager.Draw();
                AlienManager.Draw();
                ScoreManager.Draw();
                UIManager.Draw(_player);
            }          
        }
 
    }
}
