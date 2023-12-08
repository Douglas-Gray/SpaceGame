using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public static class SoundManager
    {

        private static List <Song>gameSongs = new List<Song>();
        private static List<Song> titleSongs = new List<Song>();

        private static Random _random;

        public static void Init()
        {
            _random = new();

            titleSongs.Add(Globals.Content.Load<Song>("Music/dark-spectrometer"));
            titleSongs.Add(Globals.Content.Load<Song>("Music/caves-of-dawn"));

            gameSongs.Add(Globals.Content.Load<Song>("Music/space-chillout"));
            gameSongs.Add(Globals.Content.Load<Song>("Music/outer-reaches-of-space"));
            gameSongs.Add(Globals.Content.Load<Song>("Music/in-space"));
            gameSongs.Add(Globals.Content.Load<Song>("Music/guitar"));

            MediaPlayer.IsRepeating = true;

        }

        public static void PlayMusic(bool gameStart)
        {
            if (gameStart)
            {
                MediaPlayer.Play(gameSongs[_random.Next(0, gameSongs.Count)]);
            }
            else
            {
                MediaPlayer.Play(titleSongs[_random.Next(0, titleSongs.Count)]);
            }
        }
        public static void Reset()
        {
  
        }
    }
}
