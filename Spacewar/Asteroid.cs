using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Spacewar
{
     public  class Asteroid
    {
        private Vector2 _position;
        private Texture2D _texture;
        private Rectangle _coolisiton;



         public int Width
        {
            get { return _texture.Width; }
        }
        public Vector2 Position
        {
            set { _position = value; }
           get { return _position; }
        }
        public Rectangle Coolistion
        {
            get { return _coolisiton; }
        }
         public Asteroid() : this(Vector2.Zero)
        {
            


        }

        public Asteroid(Vector2 position)
        {
            _texture = null;
            _position = position;
            _coolisiton = new Rectangle((int)_position.X, (int)_position.Y, 0 , 0);
        }
        
            

        public void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("asteroid");
        }
        public void Update()
        {
            _position.Y += 10;
            _coolisiton = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
