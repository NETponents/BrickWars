using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BlockWars
{
    namespace Blocks
    {
        //[Serializable]
        public class Cursor : Block
        {
            public Cursor()
                : base(Vector3.Zero, Color.White, "White", 1.05f, false, 1, "Cursor")
            {

            }
            public Cursor(Vector3 position)
                : base(position, Color.White, "White", 1.05f, false, 1, "Cursor")
            {

            }
            public Cursor(Vector3 position, Color cColor)
                : base(position, cColor, "White", 1.05f, false, 1, "Cursor")
            {
                
            }
            public Cursor(Vector3 position, Color cColor, float cSize)
                : base(position, cColor, "White", cSize, false, 1, "Cursor")
            {
                
            }
            public static Color invertColor(Color sColor)
            {
                Vector3 newCol = Vector3.Zero;
                Vector3 oldCol = sColor.ToVector3() * new Vector3(255, 255, 255);
                newCol.X = (float)255 - oldCol.X;
                newCol.Y = (float)255 - oldCol.Y;
                newCol.Z = (float)255 - oldCol.Z;
                sColor = new Color(newCol);
                return sColor;
            }
        }
        [Serializable]
        public class Dummy : Block
        {
            public Dummy()
                : base(Vector3.Zero, Color.Transparent, "Transparent", 1.0f, false, 1, "Dummy Block")
            {

            }
            public Dummy(Vector3 position)
                : base(position, Color.Transparent, "Transparent", 1.0f, false, 1, "Dummy Block")
            {

            }
            public Dummy(Vector3 position, float cSize)
                : base(position, Color.Transparent, "Transparent", cSize, false, 1, "Dummy Block")
            {

            }
        }
        [Serializable]
        public class Empty : Block
        {
            public Empty()
                : base()
            {

            }
        }
    }
}
