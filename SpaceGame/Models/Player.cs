﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class Player : Sprite
    {
        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        { }

        public void Update()
        {
            if (InputManager.Direction != Vector2.Zero)
            {
                var direction = Vector2.Normalize(InputManager.Direction);
                Position += direction * Speed * Globals.TotalSeconds; 

            }

            var toMousePointer = InputManager.MousePosition - Position;
            Rotation = (float)Math.Atan2(toMousePointer.Y, toMousePointer.X); 

        }
    }
}