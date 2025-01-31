using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.XAudio2;

namespace Spacewar.Classes
{
    public class Space
    {
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _position2;
        private float _speed;

       public  Space()
        {
            _texture = null;
          //  _position = new Vector2(0, _texture.Height);
            _position2 =  Vector2.Zero;
            _speed = 1;

             
        }
        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("space");
            _position = new Vector2(0, -_texture.Height);

        }
        public void Update()
        {
            _position.Y += _speed;
            _position2.Y += _speed;


             if ( _position.Y >= 0)
            {
                _position.Y = _texture.Height;
                _position2.Y = 0;


            }
             
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,_position, Color.White);
            spriteBatch.Draw(_texture, _position2, Color.White);

        }

    }
}
