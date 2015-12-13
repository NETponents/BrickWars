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
        public enum UIButtonState
        {
            released,
            pressed
        }
        public interface IUIElement
        {
            public void Update();
            public Texture2D Draw();
        }
        public interface IClickable
        {
            public void ProcessMouse(MouseState ms);
        }
        public interface IKeyboardControllable
        {
            public void ProcessKeyboard(KeyboardState ks);
        }
        public interface IActionable
        {
            public string ProcessAction();
        }
        public class Button : IUIElement, IClickable, IActionable
        {
            private UIButtonState isClicked = UIButtonState.released;
            private Vector2 startPos;
            private Vector2 endPos;
            protected string text;

            public Button()
            {

            }

            public void Update()
            {
                throw new NotImplementedException();
            }

            public Texture2D Draw()
            {
                throw new NotImplementedException();
            }

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

            public string ProcessAction()
            {
                throw new NotImplementedException();
            }
        }
        public class Label : IUIElement
        {
            private string text;
            private Vector2 position;

            public Label()
            {
                position = new Vector2(0, 0);
                text = "";
            }
            public Label(Vector2 pos)
            {
                position = pos;
                text = "";
            }
            public Label(Vector2 pos, string txt)
            {
                position = pos;
                text = txt;
            }

            public void Update()
            {
                throw new NotImplementedException();
            }

            public Texture2D Draw()
            {
                throw new NotImplementedException();
            }
        }
    }
}
