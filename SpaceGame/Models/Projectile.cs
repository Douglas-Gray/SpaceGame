using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class Projectile : Sprite
    {
        public Vector2 Direction { get; set; }
        public float Lifespan { get; private set; }


        public Projectile(Texture2D texture, ProjectileData projectileData) : base(texture, projectileData.Position)
        {
            Speed = projectileData.Speed;
            Rotation = projectileData.Rotation;
            Direction = new((float)Math.Cos(Rotation), (float)Math.Sin(Rotation)); 
            Lifespan = projectileData.Lifespan;
        }

        public void Update()
        {
            Position += Direction * Speed * Globals.TotalSeconds;
            Lifespan -= Globals.TotalSeconds; 
        }

    }
}
