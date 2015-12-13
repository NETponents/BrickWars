using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ImportTemplates;

namespace BlockWars
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private bool _showDebug = false;
        private bool _isFullScreen = false;

        private SpriteFont _sf_menuitem;
        private SpriteFont _sf_debug;
        private SpriteFont _sf_crosshair;

        private PlayerAttrib.ToolState cTool = PlayerAttrib.ToolState.selector;

        private BasicEffect basicEffect;
        //private Effect coreEffects;

        private CameraController cameraController = new CameraController(new Vector3(0, 3, 3));

        private List<Blocks.Block> blockList;
        private Blocks.Block cursor;

        string statusItem = "Nothing";
        float statusHealth = 100.0f;

        string currentBuilder = "Basic Block";
        int currentBuilderHP = 100;

        int lastScrollValue = 0;
        int currentBuild = 0;
        List<Blocks.Block> toolSelector = new List<Blocks.Block>();

        VertexBuffer vertexBuffer;
        
        Matrix world = Matrix.CreateTranslation(0, 0, 0);
        Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, 100f);

        MouseState originalMouseState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsFixedTimeStep = false;

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1680;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 1050;   // set this value to the desired height of your window
            _isFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _sf_menuitem = Content.Load<SpriteFont>("Fonts/MenuItem");
            _sf_debug = Content.Load<SpriteFont>("Fonts/Debug");
            _sf_crosshair = Content.Load<SpriteFont>("Fonts/CrossHair");

            //coreEffects = Content.Load<Effect>("coreEffects");
            basicEffect = new BasicEffect(GraphicsDevice);

            // Load in map
            /// Special blocks
            blockList = new List<Blocks.Block>();
            List<BlockTemplate> blockLoadList = Content.Load<List<BlockTemplate>>("Maps/Map1.special");
            foreach (BlockTemplate i in blockLoadList)
            {
                string[] bPosVals = i.Position.Split(',');
                Vector3 bPos = new Vector3(Convert.ToInt32(bPosVals[0]), Convert.ToInt32(bPosVals[1]), Convert.ToInt32(bPosVals[2]));
                string[] bColVals = i.Color.Split(',');
                Color bCol = new Color((float)Convert.ToDouble(bColVals[0]), (float)Convert.ToDouble(bColVals[1]), (float)Convert.ToDouble(bColVals[2]), (float)Convert.ToDouble(bColVals[3]));
                blockList.Add(new Blocks.Block(bPos, bCol, 0.999f, true, 100.0f, "Pre-built Structure"));
            }
            /// Terrain blocks
            List<BlockRangeTemplate> blockTLoadList = Content.Load<List<BlockRangeTemplate>>("Maps/Map1.terrain");
            foreach (BlockRangeTemplate i in blockTLoadList)
            {
                string[] tStartPos = i.startPosition.Split(',');
                Vector3 tStartPosVec = new Vector3((float)Convert.ToDouble(tStartPos[0]), (float)Convert.ToDouble(tStartPos[1]), (float)Convert.ToDouble(tStartPos[2]));
                string[] tEndPos = i.endPosition.Split(',');
                Vector3 tEndPosVec = new Vector3((float)Convert.ToDouble(tEndPos[0]), (float)Convert.ToDouble(tEndPos[1]), (float)Convert.ToDouble(tEndPos[2]));
                string[] tColVals = i.Color.Split(',');
                Color tCol = new Color((float)Convert.ToDouble(tColVals[0]), (float)Convert.ToDouble(tColVals[1]), (float)Convert.ToDouble(tColVals[2]), (float)Convert.ToDouble(tColVals[3]));
                
                for (int z = (int)tStartPosVec.Z; z <= (int)tEndPosVec.Z; z++)
                {
                    for (int y = (int)tStartPosVec.Y; y <= (int)tEndPosVec.Y; y++)
                    {
                        for (int x = (int)tStartPosVec.X; x <= (int)tEndPosVec.X; x++)
                        {
                            blockList.Add(new Blocks.Block(new Vector3(x, y, z), tCol, 1.0f, false, i.Health, i.Name));
                        }
                    }
                }
            }


            //vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), blockList.Count * 36, BufferUsage.WriteOnly);
            //vertexBuffer.SetData<GraphicsHelpers.VertexPositionColorNormal>(vertices);

            toolSelector.Add(new Blocks.Block(new Vector3(0, 0, 0), Color.Black, 0.999f, true, 100, "Basic Block (Black)"));
            toolSelector.Add(new Blocks.Block(new Vector3(0, 0, 0), Color.White, 0.999f, true, 1000, "Superblock (White)"));
            toolSelector.Add(new Blocks.Block(new Vector3(0, 0, 0), Color.Brown, 0.999f, true, 20, "Garbage"));

            Mouse.SetPosition(5, 5);
            originalMouseState = Mouse.GetState();

            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            // Check for debug enable
            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                if (_showDebug)
                {
                    _showDebug = false;
                }
                else
                {
                    _showDebug = true;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F2))
            {
                if (!_isFullScreen)
                {
                    graphics.IsFullScreen = true;
                    graphics.PreferredBackBufferWidth = 1680;  // set this value to the desired width of your window
                    graphics.PreferredBackBufferHeight = 1050;   // set this value to the desired height of your window
                    _isFullScreen = true;
                }
                else
                {
                    graphics.IsFullScreen = false;
                    graphics.PreferredBackBufferWidth = 640;  // set this value to the desired width of your window
                    graphics.PreferredBackBufferHeight = 480;   // set this value to the desired height of your window
                    _isFullScreen = false;
                }
                graphics.ApplyChanges();
            }
            if(Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                cTool = PlayerAttrib.ToolState.selector;
                draw3DCursor();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                cTool = PlayerAttrib.ToolState.gun;
                cursor = null;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D3))
            {
                cTool = PlayerAttrib.ToolState.status;
                cursor = null;
            }
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (cTool == PlayerAttrib.ToolState.selector)
                {
                    Ray templateCast = GraphicsHelpers.DimensionBlending.CalculateRay(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), view, projection, GraphicsDevice.Viewport);
                    float? lowestHitDistance = null;
                    Vector3 lowestBuildDirection = new Vector3(-2, -2, -2);
                    Vector3[] directions = { Vector3.Up, Vector3.Down, Vector3.Left, Vector3.Right, Vector3.Forward, Vector3.Backward };
                    for (int i = 0; i < directions.Length; i++)
                    {
                        BoundingBox? j = cursor.getSideCollisionBox(directions[i]);
                        if (j == null)
                        {
                            continue;
                        }
                        float? distance = templateCast.Intersects(j.Value);
                        if (distance.HasValue)
                        {
                            if (!lowestHitDistance.HasValue)
                            {
                                lowestHitDistance = distance;
                                lowestBuildDirection = directions[i];
                            }
                            if (distance < lowestHitDistance)
                            {
                                distance = lowestHitDistance;
                                lowestBuildDirection = directions[i];
                            }
                        }
                    }
                    if (!lowestBuildDirection.Equals(new Vector3(-2, -2, -2)))
                    {
                        //if (lowestBuildDirection.X == 1)
                        //{
                        //    lowestBuildDirection.X = 1.001f;
                        //}
                        //if (lowestBuildDirection.Y == 1)
                        //{
                        //    lowestBuildDirection.Y = 1.001f;
                        //}
                        //if (lowestBuildDirection.Z == 1)
                        //{
                        //    lowestBuildDirection.Z = 1.001f;
                        //}

                        Blocks.Block newBlock = new Blocks.Block(cursor.getPosition() + lowestBuildDirection, Color.Black, 0.8f);
                        BoundingBox newSlot = newBlock.getCollisionBox();
                        bool collides = false;
                        foreach (Blocks.Block i in blockList)
                        {
                            if (newSlot.Intersects(i.getCollisionBox()))
                            {
                                collides = true;
                            }
                        }
                        if (!collides)
                        {
                            Blocks.Block temp = new Blocks.Block(newBlock.getPosition(), toolSelector[currentBuild].getColor(), toolSelector[currentBuild].getSize(), toolSelector[currentBuild].userRemovable, toolSelector[currentBuild].health, toolSelector[currentBuild].name);
                            temp.setPosition(newBlock.getPosition());
                            blockList.Add(temp);
                        }
                    }
                }
                else if (cTool == PlayerAttrib.ToolState.gun)
                {
                    cursor = null;
                    Ray targetBox = GraphicsHelpers.DimensionBlending.CalculateRay(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), view, projection, GraphicsDevice.Viewport);
                    Blocks.Block blockTemplate = new Blocks.Block();
                    float? lowestHitDistance = null;
                    List<Blocks.Block> removeQueue = new List<Blocks.Block>();
                    foreach (Blocks.Block i in blockList)
                    {
                        float? dist = targetBox.Intersects(i.getCollisionBox());
                        if (dist.HasValue && dist.Value <= 10.0f)
                        {
                            i.health -= 1.5f;
                            if(i.health <= 0)
                            {
                                removeQueue.Add(i);
                            }
                        }
                    }
                    foreach (Blocks.Block i in removeQueue)
                    {
                        blockList.Remove(i);
                    }
                    if (!lowestHitDistance.HasValue)
                    {
                        // No intersections were found
                    }
                    else
                    {
                        // No need to do anything
                    }
                }
                else
                {
                    cursor = null;
                }
            }
            else if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                if (cTool == PlayerAttrib.ToolState.selector)
                {
                    Blocks.Block delCollider = new Blocks.Block(cursor.getPosition(), Color.Red, 0.8f);
                    BoundingBox delSlot = delCollider.getCollisionBox();
                    List<Blocks.Block> removeQueue = new List<Blocks.Block>();
                    foreach (Blocks.Block i in blockList)
                    {
                        if (delSlot.Intersects(i.getCollisionBox()))
                        {
                            removeQueue.Add(i);
                        }
                    }
                    foreach (Blocks.Block i in removeQueue)
                    {
                        if (i.userRemovable)
                        {
                            blockList.Remove(i);
                        }
                    }
                }
            }
            else if (Mouse.GetState().ScrollWheelValue != lastScrollValue)
            {
                if (cTool == PlayerAttrib.ToolState.selector)
                {
                    if (Mouse.GetState().ScrollWheelValue > lastScrollValue)
                    {
                        currentBuild++;
                        if (currentBuild >= toolSelector.Count)
                        {
                            currentBuild = 0;
                        }
                    }
                    else
                    {
                        currentBuild--;
                        if (currentBuild < 0)
                        {
                            currentBuild = toolSelector.Count - 1;
                        }
                    }
                    currentBuilder = toolSelector[currentBuild].name;
                    currentBuilderHP = (int)toolSelector[currentBuild].health;
                }
                lastScrollValue = Mouse.GetState().ScrollWheelValue;
                
            }
            else
            {
                if (cTool == PlayerAttrib.ToolState.selector)
                {
                    draw3DCursor();
                }
            }

            if (cTool == PlayerAttrib.ToolState.status)
            {
                Ray targetBox = GraphicsHelpers.DimensionBlending.CalculateRay(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), view, projection, GraphicsDevice.Viewport);
                Blocks.Block blockTemplate = new Blocks.Block();
                float? lowestHitDistance = null;
                foreach (Blocks.Block i in blockList)
                {
                    float? dist = targetBox.Intersects(i.getCollisionBox());
                    if (dist.HasValue)
                    {
                        if (!lowestHitDistance.HasValue)
                        {
                            lowestHitDistance = dist;
                            blockTemplate = i;
                        }
                        else
                        {
                            if (dist < lowestHitDistance)
                            {
                                lowestHitDistance = dist;
                                blockTemplate = i;
                            }
                        }
                    }
                }
                if (!lowestHitDistance.HasValue)
                {
                    statusItem = "";
                    statusHealth = 0.0f;
                }
                else
                {
                    statusItem = blockTemplate.name;
                    statusHealth = blockTemplate.health;
                }
            }

            float timeDifference = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
            float speed = 2.0f;
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                speed *= 4;
            }
            ProcessInput(timeDifference, speed);
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            view = cameraController.getView();
            GraphicsDevice.Clear(Color.Black);

            //coreEffects.Parameters["World"].SetValue(world);
            //coreEffects.Parameters["View"].SetValue(view);
            //coreEffects.Parameters["Projection"].SetValue(projection);
            ////coreEffects.Parameters["ViewVector"].SetValue(cameraController.camera.getViewVector());
            //coreEffects.CurrentTechnique = coreEffects.Techniques["Ambient"];

            basicEffect.World = world;
            basicEffect.View = view;
            basicEffect.Projection = projection;
            basicEffect.VertexColorEnabled = true;

            //basicEffect.FogEnabled = true;
            //basicEffect.FogColor = Color.Black.ToVector3(); // For best results, ake this color whatever your background is.
            //basicEffect.FogStart = 15.0f;
            //basicEffect.FogEnd = 20.0f;



            //GraphicsDevice.SetVertexBuffer(vertexBuffer);

            basicEffect.EnableDefaultLighting();
            //basicEffect.DirectionalLight0.Enabled = true;
            //basicEffect.DirectionalLight0.Direction = new Vector3(0, -1, 0);
            //basicEffect.DirectionalLight0.DiffuseColor = new Vector3(0.5f, 0, 0);
            //basicEffect.DirectionalLight0.SpecularColor = new Vector3(0, 1, 0);

            //basicEffect.AmbientLightColor = new Vector3(0.0f, 0.0f, 0.0f);
            //basicEffect.SpecularPower = 0.000001f;

            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.CullClockwiseFace;
            //rs.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rs;

            GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                foreach (Blocks.Block i in blockList)
                {
                    GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, i.getVerticeList(), 0, i.getVerticeList().Length, i.getIndices(), 0, i.getIndices().Length / 3, GraphicsHelpers.VertexPositionColorNormal.VertexDeclaration);
                }
                if (cursor != null)
                {
                    GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, cursor.getVerticeList(), 0, cursor.getVerticeList().Length, cursor.getIndices(), 0, cursor.getIndices().Length / 3, GraphicsHelpers.VertexPositionColorNormal.VertexDeclaration);
                }
            }

            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            spriteBatch.Begin();
            if (_showDebug)
            {
                spriteBatch.DrawString(_sf_debug, cameraController.camera.ToString(), new Vector2(5, 5), Color.Yellow);
                spriteBatch.DrawString(_sf_debug, frameRate.ToString(), new Vector2(5, 21), Color.Yellow);
                if (cursor != null)
                {
                    spriteBatch.DrawString(_sf_debug, cursor.ToString(), new Vector2(5, 64), Color.Yellow);
                }
            }
            spriteBatch.DrawString(_sf_crosshair, "+", new Vector2((GraphicsDevice.Viewport.Width / 2) - 20, (GraphicsDevice.Viewport.Height / 2) - 20), Color.Black);
            if (cTool == PlayerAttrib.ToolState.status)
            {
                spriteBatch.DrawString(_sf_crosshair, statusItem, new Vector2((GraphicsDevice.Viewport.Width / 2) - 50, (GraphicsDevice.Viewport.Height / 2) + 10), Color.Yellow);
                spriteBatch.DrawString(_sf_crosshair, ((int)statusHealth).ToString() + "%", new Vector2((GraphicsDevice.Viewport.Width / 2) - 50, (GraphicsDevice.Viewport.Height / 2) + 60), Color.Yellow);
            }
            if (cTool == PlayerAttrib.ToolState.selector)
            {
                spriteBatch.DrawString(_sf_crosshair, currentBuilder + " - " + currentBuilderHP + " HP", new Vector2(5, GraphicsDevice.Viewport.Height - 70), Color.Yellow);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void ProcessInput(float timeDifference, float moveSpeed)
        {
            MouseState currentMouseState = Mouse.GetState();
            KeyboardState keyState = Keyboard.GetState();

            cameraController.updateCamera(ref currentMouseState, ref keyState, timeDifference, moveSpeed);
        }
        private void draw3DCursor()
        {
            Ray targetBox = GraphicsHelpers.DimensionBlending.CalculateRay(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), view, projection, GraphicsDevice.Viewport);
            Blocks.Block blockTemplate = new Blocks.Block();
            float? lowestHitDistance = null;
            foreach (Blocks.Block i in blockList)
            {
                float? dist = targetBox.Intersects(i.getCollisionBox());
                if (dist.HasValue)
                {
                    if (!lowestHitDistance.HasValue)
                    {
                        lowestHitDistance = dist;
                        blockTemplate = i;
                    }
                    else
                    {
                        if (dist < lowestHitDistance)
                        {
                            lowestHitDistance = dist;
                            blockTemplate = i;
                        }
                    }
                }
            }
            if (!lowestHitDistance.HasValue)
            {
                // No intersections were found
            }
            else
            {
                cursor = new Blocks.Block(blockTemplate.getPosition(), new Color(255, 255, 255, 255), 1.1f);
            }
        }
    }
}
