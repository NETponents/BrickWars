using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BlockWars
{
    namespace Blocks
    {
        [Serializable]
        public class Basic : Block
        {
            public Basic()
                : base()
            {
                name = "Basic Block";
            }
            public Basic(Vector3 rootPosition)
                : base(rootPosition)
            {
                name = "Basic Block";
            }
            public Basic(Vector3 rootPosition, Color cColor, string colName)
                : base(rootPosition, cColor, colName)
            {
                name = "Basic Block";
            }
            public Basic(Vector3 rootPosition, Color cColor, string colName, float cSize)
                : base(rootPosition, cColor, colName, cSize)
            {
                name = "Basic Block";
            }
            public Basic(Vector3 rootPosition, Color cColor, string colName, float cSize, bool isUserRemovable)
                : base(rootPosition, cColor, colName, cSize, isUserRemovable)
            {
                name = "Basic Block";
            }
            public Basic(Vector3 rootPosition, Color cColor, string colName, float cSize, bool isUserRemovable, float cHealth)
                : base(rootPosition, cColor, colName, cSize, isUserRemovable, cHealth)
            {
                name = "Basic Block";
            }
        }
        [Serializable]
        public class Super : Block
        {
            public Super()
                : base(Vector3.Zero, Color.White, "White", 1.0f, true, 1000.0f, "Super Block")
            {
                
            }
            public Super(Vector3 rootPosition)
                : base(rootPosition, Color.White, "White", 1.0f, true, 1000.0f, "Super Block")
            {

            }
            public Super(Vector3 rootPosition, float cSize)
                : base(rootPosition, Color.White, "White", cSize, true, 1000.0f, "Super Block")
            {

            }
        }
        [Serializable]
        public class Garbage : Block
        {
            public Garbage()
                : base(Vector3.Zero, Color.Brown, "Brown", 0.80f, true, 50.0f, "Garbage")
            {

            }
            public Garbage(Vector3 rootPosition)
                : base(rootPosition, Color.Brown, "Brown", 0.80f, true, 50.0f, "Garbage")
            {

            }
        }
        [Serializable]
        public class Window : Block
        {
            public Window()
                : base(Vector3.Zero, new Color(0, 0, 255, 30), "Blue", 0.99f, true, 10.0f, "Window")
            {

            }
            public Window(Vector3 rootPosition)
                : base(rootPosition, new Color(0, 0, 255, 30), "Blue", 0.999f, true, 10.0f, "Window")
            {

            }
        }
        [Serializable]
        public class ForceField : Block
        {
            public ForceField()
                : base(Vector3.Zero, new Color(0, 255, 0, 30), "Green", 0.85f, true, 150.0f, "Force Field")
            {

            }
            public ForceField(Vector3 rootPosition)
                : base(rootPosition, new Color(0, 255, 0, 30), "Green", 0.85f, true, 150.0f, "Force Field")
            {

            }
        }
    }
}
