using SpaceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class BGManager
    {
        private readonly List<Layer> _layers;

        public BGManager()
        {
            _layers = new();
        }

        public void AddLayer(Layer layer)
        {
            _layers.Add(layer);
        }

        public void Update(float movement)
        {
            foreach (var layer in _layers)
            {
                layer.Update(movement);
            }
        }

        public void Draw()
        {
            foreach (var layer in _layers)
            {
                layer.Draw();
            }
        }
    }

}
