using System;
using Microsoft.Xna.Framework;

namespace BlockWars
{
    class Camera
    {
        #region instance variables
        private Vector3 _position;
        private float _yaw; //X (up/down)
        private float _pitch; //Y (left/right)
        #endregion

        #region constructors
        public Camera()
        {
            _position = new Vector3(0, 0, 0);
            _yaw = 0.0f;
            _pitch = 0.0f;
        }
        public Camera(Vector3 startPosition)
        {
            _position = startPosition;
            _yaw = 0.0f;
            _pitch = 0.0f;
        }
        public Camera(Vector3 startPosition, float yaw, float pitch)
        {
            _position = new Vector3(0, 0, 0);
            _yaw = 0.0f;
            _pitch = 0.0f;
        }
        #endregion

        #region postion
        public void setPosition(Vector3 cameraPosition)
        {
            _position = cameraPosition;
        }
        public void addPosition(Vector3 addVector)
        {
            Matrix cameraRotation = Matrix.CreateRotationX(_pitch) * Matrix.CreateRotationY(_yaw);
            Vector3 rotatedVector = Vector3.Transform(addVector, cameraRotation);
            _position += rotatedVector;
        }
        public void addPosition(Vector3 addVector, float moveSpeed)
        {
            Matrix cameraRotation = Matrix.CreateRotationX(_yaw) * Matrix.CreateRotationY(_pitch);
            Vector3 rotatedVector = Vector3.Transform(addVector, cameraRotation);
            _position += moveSpeed * rotatedVector;
        }
        public Vector3 getCameraPosition()
        {
            return _position;
        }
        #endregion

        #region yaw
        public void setYaw(float yaw)
        {
            _yaw = yaw;
        }
        public float getYaw()
        {
            return _yaw;
        }
        public void yawUp()
        {
            yawUp(1.0f);
        }
        public void yawUp(float amount)
        {
            _yaw += amount;
        }
        public void yawDown()
        {
            yawDown(1.0f);
        }
        public void yawDown(float amount)
        {
            _yaw -= amount;
        }
        #endregion

        #region pitch
        public void setPitch(float pitch)
        {
            _pitch = pitch;
        }
        public float getPitch()
        {
            return _pitch;
        }
        public void pitchLeft()
        {
            pitchLeft(1.0f);
        }
        public void pitchLeft(float amount)
        {
            _pitch += amount;
        }
        public void pitchRight()
        {
            pitchRight(1.0f);
        }
        public void pitchRight(float amount)
        {
            _pitch -= amount;
        }
        #endregion

        #region view vector
        public Vector3 getViewVector()
        {
            Matrix cameraRotation = Matrix.CreateRotationX(_pitch) * Matrix.CreateRotationY(_yaw);

            Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
            Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            Vector3 cameraFinalTarget = _position + cameraRotatedTarget;

            return cameraFinalTarget;
        }
        #endregion

        #region view
        public Matrix getView()
        {
            Matrix cameraRotation = Matrix.CreateRotationX(_pitch) * Matrix.CreateRotationY(_yaw);

            Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
            Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            Vector3 cameraFinalTarget = _position + cameraRotatedTarget;

            Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);
            Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);

            return Matrix.CreateLookAt(_position, cameraFinalTarget, cameraRotatedUpVector);
        }
        public static Matrix getView(Vector3 cameraPosition, float yaw, float pitch)
        {
            Matrix cameraRotation = Matrix.CreateRotationX(pitch) * Matrix.CreateRotationY(yaw);

            Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
            Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            Vector3 cameraFinalTarget = cameraPosition + cameraRotatedTarget;

            Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);
            Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);

            return Matrix.CreateLookAt(cameraPosition, cameraFinalTarget, cameraRotatedUpVector);
        }
        #endregion

        #region util
        public string ToString()
        {
            return String.Format("POS({0}:{1}:{2}) YAW({3}) PITCH({4})", _position.X, _position.Y, _position.Z, _yaw, _pitch);
        }
        #endregion
    }
}
