using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlockWars
{
    namespace Blocks
    {
        class Block
        {
            private List<GraphicsHelpers.VertexPositionColorNormal> verticeList;
            private Vector3 position;
            private Color color;

            public Block()
            {
                position = new Vector3(0, 0, 0);
                color = Color.Red;
                updateVerticeList();
            }
            public Block(Vector3 rootPosition)
            {
                position = rootPosition;
                color = Color.Red;
                updateVerticeList();
            }
            public Block(Vector3 rootPosition, Color cubeColor)
            {
                position = rootPosition;
                color = cubeColor;
                updateVerticeList();
            }

            protected void updateVerticeList()
            {
                verticeList = new List<GraphicsHelpers.VertexPositionColorNormal>(updateVerticeList(position, color));
            }
            protected static List<GraphicsHelpers.VertexPositionColorNormal> updateVerticeList(Vector3 rootPosition)
            {
                return new List<GraphicsHelpers.VertexPositionColorNormal>(updateVerticeList(rootPosition, Color.Red));
            }
            protected static GraphicsHelpers.VertexPositionColorNormal[] updateVerticeList(Vector3 rootPosition, Color cubeColor)
            {
                GraphicsHelpers.VertexPositionColorNormal[] vertices = new GraphicsHelpers.VertexPositionColorNormal[36];

                // A
                vertices[0].Position = new Vector3(rootPosition.X, rootPosition.Y + 1, rootPosition.Z); //0,1,0
                vertices[1].Position = new Vector3(rootPosition.X, rootPosition.Y, rootPosition.Z); //0,0,0
                vertices[2].Position = new Vector3(rootPosition.X + 1, rootPosition.Y, rootPosition.Z); //1,0,0
                // B
                vertices[3].Position = new Vector3(rootPosition.X, rootPosition.Y + 1, rootPosition.Z); //0,1,0
                vertices[4].Position = new Vector3(rootPosition.X + 1, rootPosition.Y + 1, rootPosition.Z); //1,1,0
                vertices[5].Position = new Vector3(rootPosition.X + 1, rootPosition.Y, rootPosition.Z); //1,0,0
                // C
                vertices[6].Position = new Vector3(rootPosition.X + 1, rootPosition.Y + 1, rootPosition.Z); //0,0,0
                vertices[7].Position = new Vector3(rootPosition.X + 1, rootPosition.Y, rootPosition.Z); //1,1,0
                vertices[8].Position = new Vector3(rootPosition.X + 1, rootPosition.Y, rootPosition.Z + 1); //1,0,0
                // D
                vertices[9].Position = new Vector3(rootPosition.X + 1, rootPosition.Y + 1, rootPosition.Z); //1,1,0
                vertices[10].Position = new Vector3(rootPosition.X + 1, rootPosition.Y + 1, rootPosition.Z + 1); //1,0,0
                vertices[11].Position = new Vector3(rootPosition.X + 1, rootPosition.Y, rootPosition.Z + 1); //1,0,1
                // E
                vertices[12].Position = new Vector3(rootPosition.X, rootPosition.Y, rootPosition.Z); //0,0,0
                vertices[13].Position = new Vector3(rootPosition.X, rootPosition.Y, rootPosition.Z + 1); //0,0,1
                vertices[14].Position = new Vector3(rootPosition.X + 1, rootPosition.Y, rootPosition.Z + 1); //1,0,1
                // F
                vertices[15].Position = new Vector3(rootPosition.X, rootPosition.Y, rootPosition.Z); //0,0,0
                vertices[16].Position = new Vector3(rootPosition.X + 1, rootPosition.Y, rootPosition.Z); //1,0,0
                vertices[17].Position = new Vector3(rootPosition.X + 1, rootPosition.Y, rootPosition.Z + 1); //1,0,1
                // G
                vertices[18].Position = new Vector3(rootPosition.X, rootPosition.Y + 1, rootPosition.Z + 1); //0,1,1
                vertices[19].Position = new Vector3(rootPosition.X, rootPosition.Y, rootPosition.Z + 1); //0,0,1
                vertices[20].Position = new Vector3(rootPosition.X, rootPosition.Y, rootPosition.Z); //0,0,0
                // H
                vertices[21].Position = new Vector3(rootPosition.X, rootPosition.Y + 1, rootPosition.Z + 1); //0,1,1
                vertices[22].Position = new Vector3(rootPosition.X, rootPosition.Y + 1, rootPosition.Z); //0,1,0
                vertices[23].Position = new Vector3(rootPosition.X, rootPosition.Y, rootPosition.Z); //0,0,0
                // I
                vertices[24].Position = new Vector3(rootPosition.X, rootPosition.Y + 1, rootPosition.Z + 1); //0,1,1
                vertices[25].Position = new Vector3(rootPosition.X, rootPosition.Y + 1, rootPosition.Z); //0,1,0
                vertices[26].Position = new Vector3(rootPosition.X + 1, rootPosition.Y + 1, rootPosition.Z); //1,1,0
                // J
                vertices[27].Position = new Vector3(rootPosition.X, rootPosition.Y + 1, rootPosition.Z + 1); //0,1,1
                vertices[28].Position = new Vector3(rootPosition.X + 1, rootPosition.Y + 1, rootPosition.Z + 1); //1,1,1
                vertices[29].Position = new Vector3(rootPosition.X + 1, rootPosition.Y + 1, rootPosition.Z); //1,1,0
                // K
                vertices[30].Position = new Vector3(rootPosition.X, rootPosition.Y + 1, rootPosition.Z + 1); //0,1,1
                vertices[31].Position = new Vector3(rootPosition.X, rootPosition.Y, rootPosition.Z + 1); //0,0,1
                vertices[32].Position = new Vector3(rootPosition.X + 1, rootPosition.Y, rootPosition.Z + 1); //1,0,1
                // L
                vertices[33].Position = new Vector3(rootPosition.X, rootPosition.Y + 1, rootPosition.Z + 1); //0,1,1
                vertices[34].Position = new Vector3(rootPosition.X + 1, rootPosition.Y + 1, rootPosition.Z + 1); //1,1,1
                vertices[35].Position = new Vector3(rootPosition.X, rootPosition.Y, rootPosition.Z + 1); //1,0,1

                for (int i = 0; i < vertices.Length / 3; i++)
                {
                    int index1 = i * 3;
                    int index2 = i * 3 + 1;
                    int index3 = i * 3 + 2;

                    Vector3 side1 = vertices[index1].Position - vertices[index3].Position;
                    Vector3 side2 = vertices[index1].Position - vertices[index2].Position;
                    Vector3 normal = Vector3.Cross(side1, side2);

                    vertices[index1].Normal += normal;
                    vertices[index2].Normal += normal;
                    vertices[index3].Normal += normal;

                    vertices[index1].Normal.Normalize();
                    vertices[index2].Normal.Normalize();
                    vertices[index3].Normal.Normalize();

                    vertices[index1].Color = cubeColor;
                    vertices[index2].Color = cubeColor;
                    vertices[index3].Color = cubeColor;
                }

                return vertices;
            }

            public List<GraphicsHelpers.VertexPositionColorNormal> getVerticeList()
            {
                return verticeList;
            }

            public void setPosition(Vector3 newPosition)
            {
                position = newPosition;
                updateVerticeList();
            }
            public void setColor(Color newColor)
            {
                color = newColor;
                updateVerticeList();
            }
        }
    }
}
