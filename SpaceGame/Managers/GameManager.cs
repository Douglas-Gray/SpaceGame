using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SpaceGame.Menu;
using SpaceGame.Models;
using System;
using System.Xml.Schema;

namespace SpaceGame.Managers
{
    public class GameManager
    {

        private readonly Player _player;
        private readonly MenuManager menuManager = new();
        private bool gameStart = false;
        private int score;
        private Song titleTheme = Globals.Content.Load<Song>("SFX/dark-spectrometer");
        private Song gameTheme = Globals.Content.Load<Song>("SFX/space-chillout");

        public GameManager()
        {

            var ButtonTexture = Globals.Content.Load<Texture2D>("button");

            menuManager.AddButton(new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2), "Start").OnClick += Action;
            menuManager.AddMessage(new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2 - 100), $"S P A C E  G A M E");

            MediaPlayer.Play(titleTheme);

            _player = new(Globals.Content.Load<Texture2D>("player"), 
                new (Globals.Bounds.X / 2, Globals.Bounds.Y /2));

            ScoreManager.Init();
            ProjectileManager.Init();
            UIManager.Init();
            AlienManager.Init();
            AlienManager.AddAlienGreen();
        }

        public void Action(object sender, EventArgs e)
        {
            gameStart = true;

            MediaPlayer.Play(gameTheme);
        }

        public void Restart()
        {
            menuManager.Reset();
            menuManager.AddMessage(new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2 - 200), $"S P A C E  G A M E");
            menuManager.AddMessage(new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2 - 100), $"Lights Out... Score: {score}");

            MediaPlayer.Play(titleTheme);

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
                _player.Update(AlienManager.Aliens, ProjectileManager.AlienProjectiles);
                ScoreManager.Update(AlienManager.Aliens);
                AlienManager.Update(_player);
                ProjectileManager.Update(AlienManager.Aliens);

                if (_player.Dead) { score = ScoreManager.ReturnScore();  Restart(); }
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
