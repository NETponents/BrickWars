using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockWars
{
    namespace Display
    {
        namespace Screens
        {
            public class GameScreen : Screen, IContent2D, IContent3D, IInput
            {
                private GameObjects.World gameWorld;

                /// <summary>
                /// Default constructor for GameScreen object.
                /// </summary>
                public GameScreen()
                {

                }
                /// <summary>
                /// Draws current GameScreen object to the screen.
                /// </summary>
                public override void Draw()
                {
                    throw new NotImplementedException();
                }
                /// <summary>
                /// Resets the GameScreen object to its intial state.
                /// </summary>
                public override void Reset()
                {
                    throw new NotImplementedException();
                }

                public override void Draw2DContent()
                {
                    throw new NotImplementedException();
                }

                public override void Draw3DContent()
                {
                    throw new NotImplementedException();
                }
                /// <summary>
                /// Updates the current instance of GameScreen object.
                /// </summary>
                /// <param name="gameObject"></param>
                /// <param name="ms"></param>
                /// <param name="ks"></param>
                public override void Update(ref Game1 gameObject, Microsoft.Xna.Framework.Input.MouseState ms, Microsoft.Xna.Framework.Input.KeyboardState ks)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
