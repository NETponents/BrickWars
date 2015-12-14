using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BlockWars
{
    /*
    namespace Display
    {
        namespace Screens
        {
            /// <summary>
            /// Definition for Screen class instance that contains 3D content.
            /// </summary>
            public interface IContent3D
            {
                void Draw3DContent();
            }
            /// <summary>
            /// Definition for Screen class instance that contains 2D content.
            /// </summary>
            public interface IContent2D
            {
                void Draw2DContent();
            }
            /// <summary>
            /// Interface of interactive Screen class instance that accepts controller input.
            /// </summary>
            public interface IInput
            {
                void Update(ref Game1 gameObject, MouseState ms, KeyboardState ks);
            }
            /// <summary>
            /// Base class for Screen objects.
            /// </summary>
            public abstract class Screen
            {
                private string name;
                
                /// <summary>
                /// Default constructor for Screen class.
                /// </summary>
                public Screen()
                {

                }
                /// <summary>
                /// Updates screen and any included content.
                /// </summary>
                /// <param name="gameObject">Reference to current game instance.</param>
                public abstract void Update(ref Game1 gameObject)
                {

                }
                /// <summary>
                /// Draws the screen and any included content.
                /// </summary>
                public abstract void Draw()
                {
                    this.Draw3DContent();
                    this.Draw2DContent();
                }
                /// <summary>
                /// Gets name of screen.
                /// </summary>
                /// <returns>Name of screen.</returns>
                public string getName()
                {
                    return name;
                }
                /// <summary>
                /// Draws 3D content in screen instance.
                /// </summary>
                protected virtual void Draw3DContent()
                {
                    // Do nothing, item has no 3D content.
                }
                /// <summary>
                /// Draws 2D content in current screen instance.
                /// </summary>
                protected virtual void Draw2DContent()
                {
                    // Do nothing, item has no 2D content.
                }
                /// <summary>
                /// Resets the screen to its original state.
                /// </summary>
                public abstract void Reset()
                {

                }
            }
        }
    }*/
}
