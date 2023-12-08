using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework; 

namespace SpaceGame.Menu
{
    public class Message
    {
        private Vector2 _position;
        private string _messageText { get; set; }
        private SpriteFont Font { get; }


        public Message(Vector2 position, string messageText)
        {
            Font = Globals.Content.Load<SpriteFont>("font");

            _position = position;
            _messageText = messageText;
        }

        public void Update(string messageText)
        {
           _messageText = messageText;
        }

       
        public void Draw()
        {
            var x = _position.X - Font.MeasureString(_messageText).X / 2;
            var y = _position.Y - Font.MeasureString(_messageText).Y / 2;

        
            Globals.SpriteBatch.DrawString(Font, _messageText, new Vector2(x, y), Color.White);
        }
    }
}
