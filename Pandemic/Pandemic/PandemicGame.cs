using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pandemic
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PandemicGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite sprite = new Sprite();
        ContentManager content;
        MouseState mouse;
        Texture2D background;
        MouseState prevMouseState;
        KeyboardState keyboardState;
        List<string> X = new List<string>();
        List<string> Y = new List<string>();
        List<City> city= new List<City>();
        CityList citylist= new CityList();
         
        bool kay = false;
        public PandemicGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 720;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            city = citylist.Create();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("Textures\\background");
            
            





            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"X.txt"))
                {
                    for (int i = 0; i < X.Count; i++)
                    {
                        // If the line doesn't contain the word 'Second', write the line to the file.
                            file.WriteLine(X[i]);
                    }
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Y.txt"))
                {
                    for (int i = 0; i<Y.Count; i++)
                    {
                        // If the line doesn't contain the word 'Second', write the line to the file.
                        file.WriteLine(Y[i]);
                    }
                }
            }

            // TODO: Add your update logic here
             mouse = Mouse.GetState();
            //if (mouseState.X != prevMouseState.X ||
            //    mouseState.Y != prevMouseState.Y)
            //  //  ringsPosition = new Vector2(mouseState.X, mouseState.Y);
            //prevMouseState = mouseState;
             if (mouse.RightButton == ButtonState.Pressed && kay == false)
             {
                 X.Add(Convert.ToString(mouse.X));
                 Y.Add(Convert.ToString(mouse.Y));
                 kay = true;
             }
             if (mouse.RightButton == ButtonState.Released) kay = false;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 1200, 720), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
