using Microsoft.Xna.Framework;
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

        private readonly BGManager _bgm = new(); 

        private bool gameStart = false;
        private int score;

        public GameManager()
        {

            var ButtonTexture = Globals.Content.Load<Texture2D>("button");

            menuManager.AddButton(new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2), "Start").OnClick += Action;
            menuManager.AddMessage(new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2 - 100), $"S P A C E  G A M E");

            _player = new(Globals.Content.Load<Texture2D>("player"), 
                new (Globals.Bounds.X / 2, Globals.Bounds.Y /2));

            _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("background"), 0.5f, 0.5f));
            _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("planets"), 0.3f, 0.3f));


            SoundManager.Init(); 
            ScoreManager.Init();
            ProjectileManager.Init();
            UIManager.Init();
            AlienManager.Init();
            AlienManager.AddAlienGreen();

            SoundManager.PlayMusic(gameStart);
        }

        public void Action(object sender, EventArgs e)
        {
            gameStart = true;
            SoundManager.PlayMusic(gameStart);
        }

        public void Restart()
        {
            menuManager.Reset();
            menuManager.AddMessage(new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2 - 200), $"S P A C E  G A M E");
            menuManager.AddMessage(new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2 - 100), $"Lights Out... Score: {score}");

            gameStart = false;

            SoundManager.PlayMusic(gameStart);

            ScoreManager.Reset(); 
            ProjectileManager.Reset();
            AlienManager.Reset();
            _player.Reset();
        }

        public void Update()
        {

            InputManager.Update();
            menuManager.Update();

            _bgm.Update(100.0f);

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

            Globals.SpriteBatch.Begin();
            _bgm.Draw();

            if (!gameStart) 
            {
                menuManager.Draw(); 
            }
            else
            {
                ProjectileManager.Draw();
                _player.Draw(Color.White);
                UIManager.Draw(_player);

                AlienManager.Draw();
                ScoreManager.Draw();
            }

            Globals.SpriteBatch.End(); 
        }
 
    }
}
