using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public static class UIManager
    {
        private static Texture2D _bulletTexture;
        private static Texture2D _ringBlastIconTexture;

        public static void Init()
        {
          _bulletTexture = Globals.Content.Load<Texture2D>("bullet");
          _ringBlastIconTexture = Globals.Content.Load<Texture2D>("Icons/RingBlastIcon");
        }

        public static void Draw(Player player)
        {
            Color weaponColour = player.Weapon.Reloading ? Color.Red : Color.White; 

            for (int i = 0; i < player.Weapon.Ammo; i++)
            {
                Vector2 position = new(i * _bulletTexture.Height * 2, Globals.Bounds.Y - _bulletTexture.Height * 2);
                Globals.SpriteBatch.Draw(_bulletTexture, position, null, weaponColour * 0.75f, 0, Vector2.Zero, 2, SpriteEffects.None, 1); 
            }

            Color abilityColour = player.Ability.Reloading ? Color.LightSkyBlue * 0.25f : Color.LightSkyBlue;

            for (int i = 0; i < player.Ability.Ammo; i++)
            {
                Vector2 position = new(Globals.Bounds.X - _ringBlastIconTexture.Width * 3, i * _ringBlastIconTexture.Height + _ringBlastIconTexture.Height / 2) ;
                Globals.SpriteBatch.Draw(_ringBlastIconTexture, position, null, abilityColour, 0, Vector2.Zero, 2, SpriteEffects.None, 1);
            }
        }

    }
}
