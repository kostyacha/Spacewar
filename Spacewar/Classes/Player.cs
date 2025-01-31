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
        private float _speed;
        private float _2speed;
         public Player()
        {
            _position = new Vector2(30,30);
            _texture = null;
            _speed = 7;
            _2speed = 20;
        }
        public void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("player");

        }
        public  void Update( int widthScreen , int heightScreen)
        {
            #region movment
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.S))
            {
                _position.Y += _speed;

            }
            if (keyboard.IsKeyDown(Keys.W))
            {
                _position.Y -= _speed;

            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                _position.X += _speed;

            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                _position.X -= _speed;
                    
            }
            if(keyboard.IsKeyDown(Keys.Space))
            {
                _position.X += _2speed;
            }
            #endregion

            #region Bounds
            if(_position.X < 0)
            {
                _position.X = 0;
            }
            if (_position.X > widthScreen -  _texture.Width)
            {
                _position.X = widthScreen - _texture.Width;
            }
            if (_position.Y < 0)
            {
                _position.Y  = 0;
            }
            if (_position.Y > heightScreen - _texture.Height)
            {
                _position.Y= heightScreen - _texture.Height;
            }
            #endregion
        }

        public void Draw(SpriteBatch  spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
