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
        public class TerrainBlock : Block
        {
            public TerrainBlock()
                : base(Vector3.Zero, Color.Green, "Green", 1.0f, false, 1, "Terrain Block")
            {
                
            }
            public TerrainBlock(Vector3 rootPosition)
                : base(rootPosition, Color.Green, "Green", 1.0f, false, 1, "Terrain Block")
            {
                
            }
            public TerrainBlock(Vector3 rootPosition, Color cColor, string colName)
                : base(rootPosition, cColor, colName, 1.0f, false, 1, "Terrain Block")
            {

            }
            public TerrainBlock(Vector3 rootPosition, Color cColor, string colName, float cSize)
                : base(rootPosition, cColor, colName, cSize, false, 1, "Terrain Block")
            {

            }
            public TerrainBlock(Vector3 rootPosition, Color cColor, string colName, float cSize, bool isUserRemovable)
                : base(rootPosition, cColor, colName, cSize, isUserRemovable, 1, "Terrain Block")
            {

            }
            public override string getHealth()
            {
                return "Indestructable";
            }
            public override bool isIdestructable()
            {
                return true;
            }
            public override bool addDamage(float damage)
            {
                return true;
            }
        }
        [Serializable]
        public class WallBlock : Block
        {
            public WallBlock()
                : base(Vector3.Zero, Color.Blue, "Blue", 1.0f, false, 1, "Arena Wall Block")
            {
                
            }
            public WallBlock(Vector3 rootPosition)
                : base(rootPosition, Color.Blue, "Blue", 1.0f, false, 1, "Arena Wall Block")
            {

            }
            public WallBlock(Vector3 rootPosition, Color cColor, string colName)
                : base(rootPosition, cColor, colName, 1.0f, false, 1, "Arena Wall Block")
            {

            }
            public WallBlock(Vector3 rootPosition, Color cColor, string colName, float cSize)
                : base(rootPosition, cColor, colName, cSize, false, 1, "Arena Wall Block")
            {

            }
            public WallBlock(Vector3 rootPosition, Color cColor, string colName, float cSize, bool isUserRemovable)
                : base(rootPosition, cColor, colName, cSize, isUserRemovable, 1, "Arena Wall Block")
            {

            }
            public override string getHealth()
            {
                return "Indestructable";
            }
            public override bool isIdestructable()
            {
                return true;
            }
            public override bool addDamage(float damage)
            {
                return true;
            }
        }
    }
}
