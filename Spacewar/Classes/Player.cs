using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.XAudio2;

namespace Spacewar.Classes
{
   public  class Player
    {
        private Vector2 _position;
        private Texture2D _texture;
         public Player()
        {
            _position = new Vector2(30,30);
            _texture = null;

        }
        public void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("player");

        }
        public  void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _position.Y += 5;
            }
        }
        public void Draw(SpriteBatch  spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
