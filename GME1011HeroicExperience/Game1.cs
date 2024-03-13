using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GME1011HeroicExperience
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Our attributes
        private SpriteFont _gamefont;
        private Hero _myHero;
        private Canonball _canonball;
        private Texture2D _heroSprite;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gamefont = Content.Load<SpriteFont>("GameFont");

            _heroSprite = Content.Load<Texture2D>("hero-small");
            _myHero = new Hero(5, "Aaron", _heroSprite, _gamefont);

            _canonball = new Canonball(Content.Load<Texture2D>("Canonball_Sprite"));

            // TODO: use this.Content to load your game content here
        }



        protected override void Update(GameTime gameTime)
        {
            
            _myHero.Update(gameTime);
            if (_myHero.CollidesWithCanonball(_canonball))
            {
                _myHero.TakeDamage(1);
                _canonball = null;
            }



            if(_canonball != null)
                _canonball.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _myHero.Draw(_spriteBatch);

            if (_canonball != null)
                _canonball.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
