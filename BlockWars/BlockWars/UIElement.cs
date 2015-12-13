using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace BlockWars
{
    namespace GUI
    {
        /// <summary>
        /// Toggle states of clickable UI elements.
        /// </summary>
        public enum UIButtonState
        {
            released,
            pressed
        }
        /// <summary>
        /// Base definition for UI elements.
        /// </summary>
        public interface IUIElement
        {
            public void Update();
            public Texture2D Draw();
        }
        /// <summary>
        /// Interface for clickable UI elements.
        /// </summary>
        public interface IClickable
        {
            public void ProcessMouse(MouseState ms);
        }
        /// <summary>
        /// Interface for UI elements that can take keyboard input.
        /// </summary>
        public interface IKeyboardControllable
        {
            public void ProcessKeyboard(KeyboardState ks);
        }
        /// <summary>
        /// Interface for UI elements that can launch an action when fired.
        /// </summary>
        public interface IActionable
        {
            public string ProcessAction();
        }
        /// <summary>
        /// Clickable button UI element.
        /// </summary>
        public class Button : IUIElement, IClickable, IActionable
        {
            private UIButtonState isClicked = UIButtonState.released;
            private Vector2 startPos;
            private Vector2 endPos;
            protected string text;

            /// <summary>
            /// Default contstructor for Button class.
            /// </summary>
            public Button()
            {

            }
            /// <summary>
            /// Updates the UI element.
            /// </summary>
            public void Update()
            {
                throw new NotImplementedException();
            }
            /// <summary>
            /// Provides a 2D texture of a graphical representation of button instance.
            /// </summary>
            /// <returns>2D texture of button.</returns>
            public Texture2D Draw()
            {
                throw new NotImplementedException();
            }
            /// <summary>
            /// Updates UI element relative to recent mouse events.
            /// </summary>
            /// <param name="ms">Current state of mouse.</param>
            public void ProcessMouse(MouseState ms)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    if (ms.X >= startPos.X && ms.X <= endPos.Y && ms.Y >= startPos.Y && ms.Y <= endPos.Y)
                    {
                        isClicked = UIButtonState.pressed;
                    }
                }
            }
            /// <summary>
            /// Checks to see if the button has been activated.
            /// </summary>
            /// <returns>State of UI element.</returns>
            public string ProcessAction()
            {
                // TODO: Replace with delegate for event firing.
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// Actionless label UI element.
        /// </summary>
        public class Label : IUIElement
        {
            private string text;
            private Vector2 position;

            /// <summary>
            /// Default constructor for Label UI element.
            /// </summary>
            public Label()
            {
                position = new Vector2(0, 0);
                text = "";
            }
            /// <summary>
            /// Constructor for label UI element.
            /// </summary>
            /// <param name="pos">Position of element.</param>
            public Label(Vector2 pos)
            {
                position = pos;
                text = "";
            }
            /// <summary>
            /// Constructor of label UI element.
            /// </summary>
            /// <param name="pos">Position of element.</param>
            /// <param name="txt">Text to display.</param>
            public Label(Vector2 pos, string txt)
            {
                position = pos;
                text = txt;
            }
            /// <summary>
            /// Updates label UI element.
            /// </summary>
            public void Update()
            {
                throw new NotImplementedException();
            }
            /// <summary>
            /// Provides a 2D texture graphical representation of label UI element.
            /// </summary>
            /// <returns>2D texture of label.</returns>
            public Texture2D Draw()
            {
                throw new NotImplementedException();
            }
        }
    }
}
