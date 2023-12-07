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

        public static void Init(Texture2D texture)
        {
            _bulletTexture = texture; 
        }

        public static void Draw(Player player)
        {
            Color weaponColour = player.Weapon.Reloading ? Color.Red : Color.White; 

            for (int i = 0; i < player.Weapon.Ammo; i++)
            {
                Vector2 position = new(10, i * _bulletTexture.Height * 3);
                Globals.SpriteBatch.Draw(_bulletTexture, position, null, weaponColour * 0.75f, 0, Vector2.Zero, 2, SpriteEffects.None, 1); 
            }

            Color abilityColour = player.Ability.Reloading ? Color.Red : Color.White;

            for (int i = 0; i < player.Ability.Ammo; i++)
            {
                Vector2 position = new(Globals.Bounds.X - _bulletTexture.Width * 3, i * _bulletTexture.Height * 3) ;
                Globals.SpriteBatch.Draw(_bulletTexture, position, null, abilityColour * 0.75f, 0, Vector2.Zero, 2, SpriteEffects.None, 1);
            }
        }

    }
}
