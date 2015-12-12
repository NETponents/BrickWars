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
        class Block
        {
            private VertexIndexPair drawData;
            private Vector3 position;
            private Color color;
            private float size;
            private float offset
            {
                get
                {
                    return (1.0f - size) / 2.0f;
                }
            }
            public bool userRemovable;
            public float health;
            public string name;

            public Block()
            {
                position = new Vector3(0, 0, 0);
                color = Color.Red;
                size = 1.0f;
                userRemovable = true;
                health = 100.0f;
                name = "Basic Block";
                updateVerticeList();
            }
            public Block(Vector3 rootPosition)
            {
                position = rootPosition;
                color = Color.Red;
                size = 1.0f;
                userRemovable = true;
                health = 100.0f;
                name = "Basic Block";
                updateVerticeList();
            }
            public Block(Vector3 rootPosition, Color cubeColor)
            {
                position = rootPosition;
                color = cubeColor;
                size = 1.0f;
                userRemovable = true;
                health = 100.0f;
                name = "Basic Block";
                updateVerticeList();
            }
            public Block(Vector3 rootPosition, Color cubeColor, float lSize)
            {
                position = rootPosition;
                color = cubeColor;
                size = lSize;
                userRemovable = true;
                health = 100.0f;
                name = "Basic Block";
                updateVerticeList();
            }
            public Block(Vector3 rootPosition, Color cubeColor, float lSize, bool isUserRemovable)
            {
                position = rootPosition;
                color = cubeColor;
                size = lSize;
                userRemovable = isUserRemovable;
                health = 100.0f;
                name = "Basic Block";
                updateVerticeList();
            }
            public Block(Vector3 rootPosition, Color cubeColor, float lSize, bool isUserRemovable, float blockHealth)
            {
                position = rootPosition;
                color = cubeColor;
                size = lSize;
                userRemovable = isUserRemovable;
                health = blockHealth;
                name = "Basic Block";
                updateVerticeList();
            }
            public Block(Vector3 rootPosition, Color cubeColor, float lSize, bool isUserRemovable, float blockHealth, string blockName)
            {
                position = rootPosition;
                color = cubeColor;
                size = lSize;
                userRemovable = isUserRemovable;
                health = blockHealth;
                name = blockName;
                updateVerticeList();
            }

            protected void updateVerticeList()
            {
                drawData = updateVerticeList(position, size, color);
            }
            protected static VertexIndexPair updateVerticeList(Vector3 rootPosition)
            {
                return updateVerticeList(rootPosition, 1.0f, Color.Red);
            }
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

            public VertexPositionColorNormal[] getVerticeList()
            {
                return drawData.vertices;
            }

            public int[] getIndices()
            {
                return drawData.index;
            }

            public void setPosition(Vector3 newPosition)
            {
                position = newPosition;
                updateVerticeList();
            }
            public Vector3 getPosition()
            {
                return position;
            }
            public void setColor(Color newColor)
            {
                color = newColor;
                updateVerticeList();
            }

            public BoundingBox getCollisionBox()
            {
                Vector3 startPos = position + new Vector3(offset, offset, offset);
                Vector3 endPos = startPos + new Vector3(offset + size, offset + size, offset + size);
                return new BoundingBox(startPos, endPos);
            }
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
                    return null;
                }
            }

            public bool addDamage(float damage)
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
    }
}
