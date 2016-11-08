using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TetrisRedux.Blocks
{
    class BlockS : Block
    {
        public BlockS(GameWorld world, Vector2 position) : base(world, new Color(0xFF, 0x28, 0x19, 0xFF))
        {
            this.position = position;
            blockShape = new bool[Width, Height];
            blockShape[0, 1] = true;
            blockShape[1, 0] = true;
            blockShape[1, 1] = true;
            blockShape[2, 0] = true;
        }

        public override int Height => 2;
        public override int Width => 3;
    }
}
