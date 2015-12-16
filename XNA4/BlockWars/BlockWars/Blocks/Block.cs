using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlockWars.GraphicsHelpers;

namespace BlockWars
{
    namespace Blocks
    {
        /// <summary>
        /// Main class for in-game block object.
        /// </summary>
        [Serializable]
        public abstract class Block
        {
            private VertexIndexPair drawData;
            protected Vector3 position;
            protected Color color;
            protected float size;
            private float offset
            {
                get
                {
                    return (1.0f - size) / 2.0f;
                }
            }
            public bool userRemovable;
            protected float health;
            protected string name;
            protected string colorName;

            /// <summary>
            /// Constructor for Block class.
            /// </summary>
            public Block()
            {
                position = new Vector3(0, 0, 0);
                color = Color.Red;
                colorName = "Red";
                size = 1.0f;
                userRemovable = true;
                health = 100.0f;
                name = "Basic Block";
                updateVerticeList();
            }
            /// <summary>
            /// Constructor for Block class.
            /// </summary>
            /// <param name="rootPosition">Root location of block.</param>
            public Block(Vector3 rootPosition)
            {
                position = rootPosition;
                color = Color.Red;
                colorName = "Red";
                size = 1.0f;
                userRemovable = true;
                health = 100.0f;
                name = "Basic Block";
                updateVerticeList();
            }
            /// <summary>
            /// Constructor for Block class.
            /// </summary>
            /// <param name="rootPosition">Root location of block.</param>
            /// <param name="cubeColor">Color of cube.</param>
            public Block(Vector3 rootPosition, Color cubeColor, string colName)
            {
                position = rootPosition;
                color = cubeColor;
                colorName = colName;
                size = 1.0f;
                userRemovable = true;
                health = 100.0f;
                name = "Basic Block";
                updateVerticeList();
            }
            /// <summary>
            /// Constructor for Block class.
            /// </summary>
            /// <param name="rootPosition">Root location of block.</param>
            /// <param name="cubeColor">Color of cube.</param>
            /// <param name="lSize">Length of side of cube.</param>
            public Block(Vector3 rootPosition, Color cubeColor, string colName, float lSize)
            {
                position = rootPosition;
                color = cubeColor;
                colorName = colName;
                size = lSize;
                userRemovable = true;
                health = 100.0f;
                name = "Basic Block";
                updateVerticeList();
            }
            /// <summary>
            /// Constructor for Block class.
            /// </summary>
            /// <param name="rootPosition">Root location of block.</param>
            /// <param name="cubeColor">Color of cube.</param>
            /// <param name="lSize">Length of side of cube.</param>
            /// <param name="isUserRemovable">Can be removed by player using selector tool.</param>
            public Block(Vector3 rootPosition, Color cubeColor, string colName, float lSize, bool isUserRemovable)
            {
                position = rootPosition;
                color = cubeColor;
                colorName = colName;
                size = lSize;
                userRemovable = isUserRemovable;
                health = 100.0f;
                name = "Basic Block";
                updateVerticeList();
            }
            /// <summary>
            /// Constructor for Block class.
            /// </summary>
            /// <param name="rootPosition">Root location of block.</param>
            /// <param name="cubeColor">Color of cube.</param>
            /// <param name="lSize">Length of side of cube.</param>
            /// <param name="isUserRemovable">Can be removed by player using selector tool.</param>
            /// <param name="blockHealth">Starting health of block.</param>
            public Block(Vector3 rootPosition, Color cubeColor, string colName, float lSize, bool isUserRemovable, float blockHealth)
            {
                position = rootPosition;
                color = cubeColor;
                colorName = colName;
                size = lSize;
                userRemovable = isUserRemovable;
                health = blockHealth;
                name = "Basic Block";
                updateVerticeList();
            }
            /// <summary>
            /// Constructor for Block class.
            /// </summary>
            /// <param name="rootPosition">Root location of block.</param>
            /// <param name="cubeColor">Color of cube.</param>
            /// <param name="lSize">Length of side of cube.</param>
            /// <param name="isUserRemovable">Can be removed by player using selector tool.</param>
            /// <param name="blockHealth">Starting health of block.</param>
            /// <param name="blockName">Display name of block.</param>
            public Block(Vector3 rootPosition, Color cubeColor, string colName, float lSize, bool isUserRemovable, float blockHealth, string blockName)
            {
                position = rootPosition;
                color = cubeColor;
                size = lSize;
                colorName = colName;
                userRemovable = isUserRemovable;
                health = blockHealth;
                name = blockName;
                updateVerticeList();
            }

            /// <summary>
            /// Recalculate vertice positions after property update.
            /// </summary>
            protected void updateVerticeList()
            {
                drawData = updateVerticeList(position, size, color);
            }
            /// <summary>
            /// Recalculate vertice positions after property update.
            /// </summary>
            /// <param name="rootPosition">Root position of cube.</param>
            /// <returns>Vertex/Index list pair of cube vertices.</returns>
            protected static VertexIndexPair updateVerticeList(Vector3 rootPosition)
            {
                return updateVerticeList(rootPosition, 1.0f, Color.Red);
            }
            /// <summary>
            /// Recalculate vertice positions after property update.
            /// </summary>
            /// <param name="rootPosition">Root position of cube.</param>
            /// <param name="wSize">Length of side of cube.</param>
            /// <param name="cubeColor">Vertex color of cube.</param>
            /// <returns>Vertex/Index list pair of cube vertices.</returns>
            protected static VertexIndexPair updateVerticeList(Vector3 rootPosition, float wSize, Color cubeColor)
            {
                float wOffset = (float)((1.0f - wSize) / 2);
                wSize = wSize + wOffset;
                // Vertex array
                VertexPositionColorNormal[] aVertex = new VertexPositionColorNormal[8];
                aVertex[0].Position = rootPosition + new Vector3(wOffset, wOffset, wOffset);
                aVertex[1].Position = rootPosition + new Vector3(wOffset, wOffset, wSize);
                aVertex[2].Position = rootPosition + new Vector3(wOffset, wSize, wOffset);
                aVertex[3].Position = rootPosition + new Vector3(wOffset, wSize, wSize);
                aVertex[4].Position = rootPosition + new Vector3(wSize, wOffset, wOffset);
                aVertex[5].Position = rootPosition + new Vector3(wSize, wOffset, wSize);
                aVertex[6].Position = rootPosition + new Vector3(wSize, wSize, wOffset);
                aVertex[7].Position = rootPosition + new Vector3(wSize, wSize, wSize);

                // Coloring
                for (int i = 0; i < aVertex.Length; i++)
                {
                    aVertex[i].Color = cubeColor;
                }
                ///////////////////////////////
                //           DEBUG           //
                aVertex[0].Color = Color.White;
                aVertex[1].Color = Color.White;
                aVertex[2].Color = Color.White;
                ///////////////////////////////

                //Index array
                int[] aIndex = new int[36];
                // A
                aIndex[0] = 4;
                aIndex[1] = 0;
                aIndex[2] = 2;
                // B
                aIndex[3] = 2;
                aIndex[4] = 6;
                aIndex[5] = 4;
                // C
                aIndex[6] = 5;
                aIndex[7] = 4;
                aIndex[8] = 6;
                // D
                aIndex[9] = 6;
                aIndex[10] = 7;
                aIndex[11] = 5;
                // E
                aIndex[12] = 5;
                aIndex[13] = 1;
                aIndex[14] = 0;
                // F
                aIndex[15] = 0;
                aIndex[16] = 4;
                aIndex[17] = 5;
                // G
                aIndex[18] = 0;
                aIndex[19] = 1;
                aIndex[20] = 3;
                // H
                aIndex[21] = 3;
                aIndex[22] = 2;
                aIndex[23] = 0;
                // I
                aIndex[24] = 6;
                aIndex[25] = 2;
                aIndex[26] = 3;
                // J
                aIndex[27] = 3;
                aIndex[28] = 7;
                aIndex[29] = 6;
                // K
                aIndex[30] = 3;
                aIndex[31] = 1;
                aIndex[32] = 5;
                // L
                aIndex[33] = 5;
                aIndex[34] = 7;
                aIndex[35] = 3;

                VertexIndexPair result = new VertexIndexPair();
                result.vertices = aVertex;
                result.index = aIndex;

                for (int i = 0; i < aIndex.Length / 3; i++)
                {
                    int index1 = aIndex[i * 3];
                    int index2 = aIndex[i * 3 + 1];
                    int index3 = aIndex[i * 3 + 2];

                    Vector3 side1 = aVertex[index1].Position - aVertex[index3].Position;
                    Vector3 side2 = aVertex[index1].Position - aVertex[index2].Position;
                    Vector3 normal = Vector3.Cross(side1, side2);

                    aVertex[index1].Normal += normal;
                    aVertex[index2].Normal += normal;
                    aVertex[index3].Normal += normal;

                    aVertex[index1].Normal.Normalize();
                    aVertex[index2].Normal.Normalize();
                    aVertex[index3].Normal.Normalize();
                }

                return result;
            }

            /// <summary>
            /// Gets vertice list of cube.
            /// </summary>
            /// <returns>Vertex/Position/Color/Normal collection of cube vertices.</returns>
            public VertexPositionColorNormal[] getVerticeList()
            {
                return drawData.vertices;
            }

            /// <summary>
            /// Gets list of indices relative to current vertex list.
            /// </summary>
            /// <returns>Index list of cube.</returns>
            public int[] getIndices()
            {
                return drawData.index;
            }

            /// <summary>
            /// Sets position of cube object.
            /// </summary>
            /// <param name="newPosition">Position to move to.</param>
            public void setPosition(Vector3 newPosition)
            {
                position = newPosition;
                updateVerticeList();
            }
            /// <summary>
            /// Gets root position of cube.
            /// </summary>
            /// <returns>Root position of cube.</returns>
            public Vector3 getPosition()
            {
                return position;
            }
            /// <summary>
            /// Sets color of cube.
            /// </summary>
            /// <param name="newColor">New color of cube.</param>
            public void setColor(Color newColor)
            {
                color = newColor;
                updateVerticeList();
            }
            /// <summary>
            /// Gets color of cube.
            /// </summary>
            /// <returns>Current color of cube.</returns>
            public Color getColor()
            {
                return color;
            }
            /// <summary>
            /// Gets length of side of cube.
            /// </summary>
            /// <returns>Length of side.</returns>
            public float getSize()
            {
                return size;
            }

            /// <summary>
            /// Generates pixel-perfect collision box based on absoute dimension of cube.
            /// </summary>
            /// <returns>Collision box of cube.</returns>
            public BoundingBox getCollisionBox()
            {
                Vector3 startPos = position + new Vector3(offset, offset, offset);
                Vector3 endPos = startPos + new Vector3(offset + size, offset + size, offset + size);
                return new BoundingBox(startPos, endPos);
            }
            /// <summary>
            /// Gets pixel-perfect collision box of normalized side of box.
            /// </summary>
            /// <param name="normalizedDirection">Normalized side of box.</param>
            /// <returns>Bounding box of specified side of cube.</returns>
            public BoundingBox? getSideCollisionBox(Vector3 normalizedDirection)
            {
                if (normalizedDirection == Vector3.Up)
                {
                    return new BoundingBox(position + new Vector3(offset, 1 - offset, offset), position + new Vector3(1 - offset, 1 - offset, 1 - offset));
                }
                else if (normalizedDirection == Vector3.Down)
                {
                    return new BoundingBox(position + new Vector3(offset, offset, offset), position + new Vector3(1 - offset, offset, 1 - offset));
                }
                else if (normalizedDirection == Vector3.Left)
                {
                    return new BoundingBox(position + new Vector3(offset, offset, offset), position + new Vector3(offset, 1 - offset, 1 - offset));
                }
                else if (normalizedDirection == Vector3.Right)
                {
                    return new BoundingBox(position + new Vector3(1 - offset, offset, offset), position + new Vector3(1 - offset, 1 - offset, 1 - offset));
                }
                else if (normalizedDirection == Vector3.Forward)
                {
                    return new BoundingBox(position + new Vector3(offset, offset, offset), position + new Vector3(1 - offset, 1 - offset, offset));
                }
                else if (normalizedDirection == Vector3.Backward)
                {
                    return new BoundingBox(position + new Vector3(offset, offset, 1 - offset), position + new Vector3(1 - offset, 1 - offset, 1 - offset));
                }
                else
                {
                    return new BoundingBox(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                }
            }

            /// <summary>
            /// Deals damage to the cube.
            /// </summary>
            /// <param name="damage">Amount of damage to deal to cube.</param>
            /// <returns>If cube still has health after damage.</returns>
            public virtual bool addDamage(float damage)
            {
                health -= damage;
                if (health <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            /// <summary>
            /// Gets the HP count of block.
            /// </summary>
            /// <returns>HP of block.</returns>
            public virtual string getHealth()
            {
                return ((int)health).ToString();
            }
            /// <summary>
            /// Returns if the block cannot be destroyed by anything except the builder tool.
            /// </summary>
            /// <returns>Indestructable property.</returns>
            public virtual bool isIdestructable()
            {
                return false;
            }
            /// <summary>
            /// Gets name of block instance.
            /// </summary>
            /// <returns>Name of block.</returns>
            public virtual string getName()
            {
                return name + " (" + colorName + ")";
            }

            /// <summary>
            /// String summation of cube for HUD or saving.
            /// </summary>
            /// <returns>String summation of cube.</returns>
            public override string ToString()
            {
                return String.Format("[({0}:{1}:{2}),({3},{4},{5},{6}),({7})]",
                    position.X,
                    position.Y,
                    position.Z,
                    color.R,
                    color.G,
                    color.B,
                    color.A,
                    size);
            }
        }

        /// <summary>
        /// Interface for dynamic blocks that need updating every game cycle.
        /// </summary>
        interface IUpdateable
        {
            void Update();
        }
    }
}
