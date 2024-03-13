using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GME1011HeroicExperience
{
    internal class Hero
    {
        private int _health;
        private string _name;
        private Texture2D _currentSprite;
        private SpriteFont _heroFont;
        private float _heroX, _heroY;

        public Hero(int health, string name, Texture2D currentSprite, SpriteFont heroFont)
        {
            _health = health;
            _name = name;
            _currentSprite = currentSprite;
            _heroX = 100;
            _heroY = 10;
            _heroFont = heroFont;
         }

        public int GetHealth() {  return _health; }
        public string GetName() { return _name; }   

        public int DealDamage() { Random _rng = new Random(); return _rng.Next(3, 10);  }
        public void TakeDamage(int damage) { _health -= damage; }

        public void Update(GameTime gameTime) 
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                _heroY--;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                _heroY++;

           
        }

        public bool CollidesWithCanonball(Canonball danger)
        {
            if(danger == null) {  return false; }
            Rectangle myBounds = GetBounds();
            Rectangle dangerBounds = danger.GetBounds();
            if (myBounds.Intersects(dangerBounds))
            {
                return true;
            }
            else
                return false;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)_heroX, (int)_heroY, _currentSprite.Width, _currentSprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(_heroFont, _health + "", new Vector2(_currentSprite.Width / 2, _heroY - 60), Color.White);
            spriteBatch.Draw(_currentSprite, new Vector2(_heroX, _heroY), Color.White);
            spriteBatch.End();
        }

        public override string ToString() { return "Hero[" + _name + "," + _health + "]";}

    }
}
