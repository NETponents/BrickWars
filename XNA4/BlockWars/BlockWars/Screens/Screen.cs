using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BlockWars
{
    namespace Display
    {
        namespace Screens
        {
            public class Screen
            {
                public string Name
                {
                    get;
                    protected set;
                }
                
                /// <summary>
                /// Default initializer for a blank screen.
                /// </summary>
                public Screen()
                {
                    Name = "Default";
                }

                public virtual void Leave()
                {

                }
                public virtual void Enter()
                {

                }
            }
        }
    }
}
