using System;
using System.Collections.Generic;
using System.Linq;
#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion
using System.Text;

namespace Pandemic
{
    class Sprite
    {
        public Texture2D spriteTexture;
        public Vector2 spritePosition;
        public Vector2 speedSprite = new Vector2(0, 5);

        private int frameCount;
        private double timeFrame;
        private int frame;
        private double totalElapsed;

        public Sprite()
        {
        }

        // Конструктор для анимации
        public Sprite(int frameCount, int framesPerSec)
        {
            this.frameCount = frameCount;
            timeFrame = (float)1 / framesPerSec;
            frame = 0;
            totalElapsed = 0;
        }

        // Загрузка спрайта в игру
        public void Load(ContentManager content, String stringTexture)
        {
            spriteTexture = content.Load<Texture2D>(stringTexture);
        }


        // Рисовка  спрайта
        public void DrawSprite(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteTexture, spritePosition, Color.White);
          //  spriteBatch.Draw(spriteTexture, spritePosition, rec, Color.White);
        }

        public void DrawSprite(SpriteBatch spriteBatch, int k, int j)
        {
            spritePosition.X = 300 * k;
            spritePosition.Y = 55 * j;
            spriteBatch.Draw(spriteTexture, spritePosition, Color.White);
            //  spriteBatch.Draw(spriteTexture, spritePosition, rec, Color.White);
        }
        public void DrawSprite(SpriteBatch spriteBatch, Vector2 spritePosition)
        {
            spriteBatch.Draw(spriteTexture, spritePosition, Color.White);
        }
        public void DrawSprite(SpriteBatch spriteBatch, Vector2 pos, float rotation)
        {
            spritePosition = pos;
            spriteBatch.Draw(spriteTexture, spritePosition, new Rectangle(0, 0, spriteTexture.Width, spriteTexture.Height), Color.White, rotation,
               new Vector2(spriteTexture.Width, spriteTexture.Height), 1f, SpriteEffects.None, 1f);
           //   spriteBatch.Draw(spriteTexture, spritePosition, Color.White);
        }
        // Цикличный переход по фреймам - анимация
        public void UpdateFrame(double elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed > timeFrame)
            {
                frame++;
                frame = frame % (frameCount - 1);
                totalElapsed -= timeFrame;
            }
        }

        // Прорисовка анимированого спрайта
        public void DrawAnimationSprite(SpriteBatch spriteBatch)
        {
            int frameWidth = spriteTexture.Width / frameCount-3;
            Rectangle rectangle = new Rectangle(frameWidth * frame, 0, frameWidth, spriteTexture.Height);
            spriteBatch.Draw(spriteTexture, spritePosition, rectangle, Color.White);
        }
    }
}
