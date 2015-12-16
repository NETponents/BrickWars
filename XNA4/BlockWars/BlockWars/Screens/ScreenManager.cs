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

            int currentIndex = 0;
            
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
                    try
                    {
                        return screenList[index];
                    }
                    catch(Exception e)
                    {
                        throw new ScreenNotFoundException("Screen index not found.", e);
                    }
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
                    throw new ScreenNotFoundException("Screen not found with specified search parameters.");
                }
            }

            /// <summary>
            /// Adds an instance of a screen to the screen collection.
            /// </summary>
            /// <param name="newScreen">Screen to add.</param>
            /// <returns>Index of new screen.</returns>
            public int addScreen(Screen newScreen)
            {
                screenList.Add(newScreen);
                return screenList.Count;
            }

            /// <summary>
            /// Sets a block to the specified screen index.
            /// </summary>
            /// <param name="index">Index of screen.</param>
            public void setScreen(int index)
            {
                if (index < 0 || index >= screenList.Count)
                {
                    throw new ScreenNotFoundException("Screen index not found.");
                }
                else
                {
                    currentIndex = index;
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
