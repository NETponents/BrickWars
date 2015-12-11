using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace BlockWars
{
    class CameraController
    {
        public Camera camera;
        private bool controlLock;
        private MouseState previousMouseState;

        public CameraController()
        {
            camera = new Camera();
            controlLock = false;
        }
        public CameraController(Vector3 startPosition)
        {
            camera = new Camera(startPosition);
            controlLock = false;
        }
        public CameraController(Vector3 startPosition, float yaw, float pitch)
        {
            camera = new Camera(startPosition, yaw, pitch);
            controlLock = false;
        }

        public void lockControls()
        {
            controlLock = true;
        }
        public void unlockControls()
        {
            controlLock = false;
        }
        public void toggleControls()
        {
            if (controlLock)
            {
                unlockControls();
            }
            else
            {
                lockControls();
            }
        }

        public void updateCamera(ref MouseState ms, ref KeyboardState keyState, float timeDifference, float moveSpeed)
        {
            if (ms != previousMouseState)
            {
                float xDifference = ms.X - previousMouseState.X;
                float yDifference = ms.Y - previousMouseState.Y;
                camera.setYaw(camera.getYaw() - xDifference * timeDifference);
                camera.setPitch(camera.getPitch() - yDifference * timeDifference);
                Mouse.SetPosition(5, 5);
                previousMouseState = Mouse.GetState();
            }
            Mouse.SetPosition(5, 5);

            Vector3 moveVector = new Vector3(0, 0, 0);
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                moveVector += new Vector3(0, 0, -1);
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                moveVector += new Vector3(0, 0, 1);
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
                moveVector += new Vector3(1, 0, 0);
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
                moveVector += new Vector3(-1, 0, 0);
            if (keyState.IsKeyDown(Keys.Q))
                moveVector += new Vector3(0, 1, 0);
            if (keyState.IsKeyDown(Keys.Z))
                moveVector += new Vector3(0, -1, 0);
            camera.addPosition(moveVector * timeDifference * moveSpeed);
        }
        public void updateCamera(ref MouseState ms, ref KeyboardState keyState, float timeDifference, float moveSpeed, float rotationSpeed)
        {
            if (ms != previousMouseState)
            {
                float xDifference = ms.X - previousMouseState.X;
                float yDifference = ms.Y - previousMouseState.Y;
                camera.setYaw(camera.getYaw() - rotationSpeed * xDifference * timeDifference);
                camera.setPitch(camera.getPitch() - rotationSpeed * yDifference * timeDifference);
                Mouse.SetPosition(5, 5);
                previousMouseState = Mouse.GetState();
            }
            Mouse.SetPosition(5, 5);

            Vector3 moveVector = new Vector3(0, 0, 0);
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                moveVector += new Vector3(0, 0, -1);
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                moveVector += new Vector3(0, 0, 1);
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
                moveVector += new Vector3(1, 0, 0);
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
                moveVector += new Vector3(-1, 0, 0);
            if (keyState.IsKeyDown(Keys.Q))
                moveVector += new Vector3(0, 1, 0);
            if (keyState.IsKeyDown(Keys.Z))
                moveVector += new Vector3(0, -1, 0);
            camera.addPosition(moveVector);
        }

        public Matrix getView()
        {
            return camera.getView();
        }
    }
}
