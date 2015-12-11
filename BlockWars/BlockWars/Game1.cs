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

        private SpriteFont _sf_menuitem;
        private SpriteFont _sf_debug;

        private BasicEffect basicEffect;
        //private Effect coreEffects;

        private CameraController cameraController = new CameraController(new Vector3(0, 0, 3));

        private GraphicsHelpers.VertexPositionColorNormal[] vertices;

        VertexBuffer vertexBuffer;

        Matrix world = Matrix.CreateTranslation(0, 0, 0);
        Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, 100f);

        MouseState originalMouseState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.IsFullScreen = true;
            //graphics.PreferredBackBufferWidth = 1680;  // set this value to the desired width of your window
            //graphics.PreferredBackBufferHeight = 1050;   // set this value to the desired height of your window
            //graphics.ApplyChanges();
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

            _sf_menuitem = Content.Load<SpriteFont>("MenuItem");
            _sf_debug = Content.Load<SpriteFont>("Debug");

            //coreEffects = Content.Load<Effect>("coreEffects");
            basicEffect = new BasicEffect(GraphicsDevice);

            //basicEffect = new BasicEffect(GraphicsDevice);

            List<GraphicsHelpers.VertexPositionColorNormal> verticesList = new List<GraphicsHelpers.VertexPositionColorNormal>();
            List<Blocks.Block> blockList = new List<Blocks.Block>();
            blockList.Add(new Blocks.Block(new Vector3(0, 0, 0)));

            foreach (Blocks.Block i in blockList)
            {
                verticesList.AddRange(i.getVerticeList());
            }

            vertices = verticesList.ToArray();

            //vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), blockList.Count * 36, BufferUsage.WriteOnly);
            //vertexBuffer.SetData<GraphicsHelpers.VertexPositionColorNormal>(vertices);

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
                _showDebug = true;
                if (_showDebug)
                {
                    _showDebug = false;
                }
                else
                {
                    _showDebug = true;
                }
            }
            float timeDifference = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
            ProcessInput(timeDifference);
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
            //coreEffects.Parameters["ViewVector"].SetValue(cameraController.camera.getViewVector());
            //coreEffects.CurrentTechnique = coreEffects.Techniques["Ambient"];

            //basicEffect.World = world;
            //basicEffect.View = view;
            //basicEffect.Projection = projection;
            //basicEffect.VertexColorEnabled = true;

            //GraphicsDevice.SetVertexBuffer(vertexBuffer);

            basicEffect.World = world;
            basicEffect.View = view;
            basicEffect.Projection = projection;
            basicEffect.VertexColorEnabled = true;

            basicEffect.EnableDefaultLighting();

            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rs;

            GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                //GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 36);
                //GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, 36, indices.ToArray<int>(), 0, 12, GraphicsHelpers.VertexPositionColorNormal.VertexDeclaration);
                this.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 12, GraphicsHelpers.VertexPositionColorNormal.VertexDeclaration);
            }
            
            spriteBatch.Begin();
            spriteBatch.DrawString(_sf_debug, cameraController.camera.ToString(), new Vector2(5, 5), Color.Yellow);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void ProcessInput(float amount)
        {
            MouseState currentMouseState = Mouse.GetState();
            KeyboardState keyState = Keyboard.GetState();

            cameraController.updateCamera(ref currentMouseState, ref keyState, amount);
        }
    }
}
