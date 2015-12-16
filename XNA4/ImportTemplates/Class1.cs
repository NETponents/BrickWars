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

namespace ImportTemplates
{
    public struct BlockTemplate
    {
        public string Position;
        public string Color;
    }
    public struct BlockRangeTemplate
    {
        public string startPosition;
        public string endPosition;
        public string Color;
        public string Name;
        public float Health;
    }
}
