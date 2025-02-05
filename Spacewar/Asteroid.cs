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
         public Asteroid() : this(Vector2.Zero)
        {
            


        }

        public Asteroid(Vector2 position)
        {
            _texture = null;
            _position = position;
        }
        
            

        public void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("asteroid");
        }
        public void Update()
        {
            _position.Y += 10;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
