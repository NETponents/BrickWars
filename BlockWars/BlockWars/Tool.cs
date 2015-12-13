using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockWars
{
    namespace GameObjects
    {
        namespace Tools
        {
            /// <summary>
            /// Base Tool class.
            /// </summary>
            public partial class Tool
            {
                public string name;
                public string hudMajor;
                public string hudMinor;
                public string hudCrossHair;

                /// <summary>
                /// Default constructor for Tool class.
                /// </summary>
                public Tool()
                {

                }
            }
            /// <summary>
            /// Builder tool.
            /// </summary>
            public class Builder : Tool
            {
                /// <summary>
                /// Default constructor for Builder class.
                /// </summary>
                public Builder()
                {

                }
            }
            /// <summary>
            /// Gun tool.
            /// </summary>
            public class Gun : Tool
            {
                /// <summary>
                /// Default constructor for Gun class.
                /// </summary>
                public Gun()
                {

                }
            }
            /// <summary>
            /// Status tool.
            /// </summary>
            public class Status : Tool
            {
                /// <summary>
                /// Default constructor for status tool.
                /// </summary>
                public Status()
                {

                }
            }
        }
    }
}
