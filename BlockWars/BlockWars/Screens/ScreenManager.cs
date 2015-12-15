using System;
using System.Collections.Generic;
using BlockWars.Display.Screens;

namespace BlockWars
{
    namespace Display
    {
        /// <summary>
        /// Manages different screens with UI element collections and stores their states when not in use.
        /// </summary>
        public class ScreenManager
        {
            List<Screen> screenList = new List<Screen>();
            
            /// <summary>
            /// Default constructor for ScreenManager class.
            /// </summary>
            public ScreenManager()
            {

            }

            /// <summary>
            /// Gets screen at given index.
            /// </summary>
            /// <param name="index">Index of screen to find.</param>
            /// <returns>Screen at index.</returns>
            public Screen this[int index]
            {
                get
                {
                    return screenList[index];
                }
            }
            /// <summary>
            /// Gets screen with specified name.
            /// </summary>
            /// <param name="sName">Name of screen to find.</param>
            /// <returns>Screen with specified name.</returns>
            public Screen this[string sName]
            {
                get
                {
                    foreach (Screen i in screenList)
                    {
                        if (i.Name == sName)
                        {
                            return i;
                        }
                    }
                    throw new ScreenNotFoundException();
                }
            }
        }
        /// <summary>
        /// Exception for screen that does not exist with specified search parameters.
        /// </summary>
        [Serializable]
        public class ScreenNotFoundException : Exception
        {
            public ScreenNotFoundException()
            {
            
            }
            public ScreenNotFoundException(string message)
                : base(message)
            {

            }
            public ScreenNotFoundException(string message, Exception inner)
                : base(message, inner)
            {

            }
            protected ScreenNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
                : base(info, context)
            {

            }
        }
    }
}
