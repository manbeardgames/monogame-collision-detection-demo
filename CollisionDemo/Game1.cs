/* ----------------------------------------------------------------------------
    This is free and unencumbered software released into the public domain.

    Anyone is free to copy, modify, publish, use, compile, sell, or
    distribute this software, either in source code form or as a compiled
    binary, for any purpose, commercial or non-commercial, and by any
    means.

    In jurisdictions that recognize copyright laws, the author or authors
    of this software dedicate any and all copyright interest in the
    software to the public domain. We make this dedication for the benefit
    of the public at large and to the detriment of our heirs and
    successors. We intend this dedication to be an overt act of
    relinquishment in perpetuity of all present and future rights to this
    software under copyright law.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
    IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
    OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
    OTHER DEALINGS IN THE SOFTWARE.

    For more information, please refer to <http://unlicense.org/>
---------------------------------------------------------------------------- */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CollisionDemo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //  Represents the first circle (A).
        private Circle _circleA;

        //  Represents the second circe (B).
        private Circle _circleB;

        //  The texture used to draw the circles.
        private Texture2D _circleTexture;

        //  A value that indicates if the two bounding boxes are colliding.
        private bool _areColliding;

        //  A 1x1 white pixel texture we can use to render primitives.
        private Texture2D _pixel;

        //  The previous frame keyboard state.
        private KeyboardState _prevKeyboardState;

        //  The current frame keyboard state.
        private KeyboardState _curKeyboardState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            //  Define the x and y center, and the radius of each circle.
            //  The circle image is 64px x 64px so the radius is 32px.
            _circleA = new Circle(100, 100, 32);
            _circleB = new Circle(200, 200, 32);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //  Create the 1x1 pixel texture
            _pixel = new Texture2D(GraphicsDevice, 1, 1);
            _pixel.SetData<Color>(new Color[] { Color.White });

            //  Load the circle texture
            _circleTexture = Content.Load<Texture2D>("white-circle");

        }

        protected override void Update(GameTime gameTime)
        {
            //  Update the input states.
            _prevKeyboardState = _curKeyboardState;
            _curKeyboardState = Keyboard.GetState();

            MoveCircleA();
            MoveCircleB();

            //  Check if _boxA and _boxB are colliding.
            _areColliding = CollisionChecks.Circle(_circleA, _circleB);

            base.Update(gameTime);
        }

        /// <summary>
        ///     Moves circle (A) based on keyboard input.
        /// </summary>
        private void MoveCircleA()
        {
            if(_curKeyboardState.IsKeyDown(Keys.W))
            {
                _circleA.Center.Y--;
            }
            else if(_curKeyboardState.IsKeyDown(Keys.S))
            {
                _circleA.Center.Y++;
            }
            
            if (_curKeyboardState.IsKeyDown(Keys.A))
            {
                _circleA.Center.X--;
            }
            else if (_curKeyboardState.IsKeyDown(Keys.D))
            {
                _circleA.Center.X++;
            }
        }

        /// <summary>
        ///     Moves circle (B) based on keyboard input.
        /// </summary>
        private void MoveCircleB()
        {
            if (_curKeyboardState.IsKeyDown(Keys.Up))
            {
                _circleB.Center.Y--;
            }
            else if (_curKeyboardState.IsKeyDown(Keys.Down))
            {
                _circleB.Center.Y++;
            }

            if (_curKeyboardState.IsKeyDown(Keys.Left))
            {
                _circleB.Center.X--;
            }
            else if (_curKeyboardState.IsKeyDown(Keys.Right))
            {
                _circleB.Center.X++;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //  Draw the bounding boxes as white rectangles.
            Color color = Color.White;

            //  If the bounding boxes are colliding, make them red instead.
            if(_areColliding)
            {
                color = Color.Red;
            }

            _spriteBatch.Begin();
            _spriteBatch.Draw(texture: _circleTexture,
                              position: _circleA.Center.ToVector2(),
                              sourceRectangle: null,
                              color: color,
                              rotation: 0.0f,
                              origin: new Vector2(_circleTexture.Width, _circleTexture.Height) * 0.5f,
                              scale: 1.0f,
                              effects: SpriteEffects.None,
                              layerDepth: 0.0f);

            _spriteBatch.Draw(texture: _circleTexture,
                              position: _circleB.Center.ToVector2(),
                              sourceRectangle: null,
                              color: color,
                              rotation: 0.0f,
                              origin: new Vector2(_circleTexture.Width, _circleTexture.Height) * 0.5f,
                              scale: 1.0f,
                              effects: SpriteEffects.None,
                              layerDepth: 0.0f);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
