﻿/*
    PlayGameScreen.cs
    Copyright © Markku Rahikainen 2011.
	www.Stickmansoft.com
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XnaGame
{
    public sealed class PlayGameScreen : MainGameScreen, IPlayGameScreen
    {
        // Font
        SpriteFont screenFont;
        // Menu map
        Texture2D map;

        public PlayGameScreen(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IPlayGameScreen), this);
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            screenFont = Content.Load<SpriteFont>("Fonts\\MenuFont");
            map = Content.Load<Texture2D>("Graphics\\PlayGameScreen");

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        internal protected override void ScreenChanged(object sender, EventArgs e)
        {
            base.ScreenChanged(sender, e);

            if (ScreenManager.TopScreen != this.Screen)
            {
                Visible = true;
            }
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSkyBlue);

            Int32 clientBoundsWidth = GraphicsDevice.Viewport.Width;
            Int32 clientBoundsHeight = GraphicsDevice.Viewport.Height;
            Vector2 textSize = screenFont.MeasureString("Play Game Screen");
            Vector2 position = new Vector2(clientBoundsWidth / 2 - textSize.X / 2,
                                           clientBoundsHeight / 2 - textSize.Y / 2);

            Int32 mapHeight = XGame.Window.ClientBounds.Width - 20;
            Int32 mapWidth = (map.Width / map.Height) * mapHeight;
            Int32 xPos = (XGame.Window.ClientBounds.Height / 2) - mapWidth / 2 + 40;
            Int32 yPos = 10;
            XGame.SpriteBatch.Draw(map, new Rectangle(xPos, yPos, mapWidth, mapHeight), Color.White);

            /*
            XGame.SpriteBatch.DrawString(screenFont, "Play Game Screen", position, Color.Black);
            XGame.SpriteBatch.DrawString(screenFont, "Play Game Screen",
                                         new Vector2(position.X - 3, position.Y - 3), Color.White);*/

            base.Draw(gameTime);
        }
    }
}