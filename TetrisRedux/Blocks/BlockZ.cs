using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TetrisRedux.Blocks
{
    class BlockZ : Block
    {
        public BlockZ(GameWorld world, Vector2 pos) : base(world, new Color(0x2F, 0xE8, 0x17, 0xFF))
        {
            this.position = pos;
            blockShape = new bool[Width, Height];
            blockShape[0, 0] = true;
            blockShape[1, 0] = true;
            blockShape[1, 1] = true;
            blockShape[2, 1] = true;
        }

        public override int Height => 2;

        public override int Width => 3;
    }
}

