using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using BlockWars.Blocks;

namespace BlockWars
{
    namespace GameObjects
    {
        /// <summary>
        /// Object to hold data about the game world.
        /// </summary>
        public class World
        {
            #region Variables
            // Private
            private List<Block> _blockList;
            private Cursor _cursor;
            #endregion

            #region Initializers
            /// <summary>
            /// Default constructor for a blank playing world.
            /// </summary>
            public World()
            {
                _blockList = new List<Block>();
            }
            #endregion
        }
    }
}
