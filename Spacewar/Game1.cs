using System;
using System.Collections.Generic;
using System.Drawing.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.XAudio2;
using Spacewar.Classes;

namespace Spacewar
{

   
    public class Game1 : Game
    {
        //  инструменты 
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //поля 
      //  private Asteroid _asteroid;
        private Player _player;
        private Space _space;
        
        private List<Asteroid> _asteroids;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
           // _asteroid = new Asteroid();
            _asteroids = new List<Asteroid>();
            _player = new Player();
            _space = new Space();


            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //_asteroids.LoadContent(Content);
            _player.LoadContent(Content);
            _space.LoadContent(Content);


            for (int i = 0; i < 10; i++)
            {
                LoadAsteroid();


            }
          




            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _player.Update(_graphics.PreferredBackBufferWidth,
                _graphics.PreferredBackBufferHeight);
            _space.Update();
            UpdateAsteroid();
            //_asteroids.Update();
          
            

            base.Update(gameTime);
        }
       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            {
                _space.Draw(_spriteBatch);
                _player.Draw(_spriteBatch);
               // _asteroids.Draw(_spriteBatch);

                foreach(Asteroid asteroid in _asteroids)
                {
                    asteroid.Draw(_spriteBatch);
                }


            }


            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void UpdateAsteroid()
        {
            for (int i = 0; i < _asteroids.Count; i++)
            {
                Asteroid asteroid = _asteroids[i];

                asteroid.Update();
                //teleport
                if (asteroid.Position.Y > _graphics.PreferredBackBufferHeight)
                {

                    Random random = new Random();
                    int x = random.Next(0, _graphics.PreferredBackBufferWidth - asteroid.Width);
                    int y = random.Next(0, _graphics.PreferredBackBufferHeight);
                    asteroid.Position = new Vector2(x, -y);
                }
                //check coolisiton
                if (asteroid.Coolistion.Intersects(_player.Coolision))
                {
                    _asteroids.Remove(asteroid);
                    i--;
                }
               
                
                

                
            }


            if (_asteroids.Count < 10)
            {
                LoadAsteroid();
            }

        }
        private void LoadAsteroid()
        {
            Asteroid asteroid = new Asteroid();
            asteroid.LoadContent(Content);

            Random random = new Random();
            int x = random.Next(0, _graphics.PreferredBackBufferWidth - asteroid.Width);
            int y = random.Next(0, _graphics.PreferredBackBufferHeight);
            asteroid.Position = new Vector2(x, -y);

            _asteroids.Add(asteroid);
        }

    }
}
