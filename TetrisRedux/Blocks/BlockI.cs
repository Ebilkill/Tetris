using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TetrisRedux.Blocks
{
    class BlockI : Block
    {
        public BlockI(GameWorld world, Vector2 position) : base(world, new Color(0x47, 0xE6, 0xFF, 0xFF))
        {
            this.position = position;
            blockShape = new bool[Width, Height];
            blockShape[0, 0] = true;
            blockShape[0, 1] = true;
            blockShape[0, 2] = true;
            blockShape[0, 3] = true;
        }

        public override int Height => 4;
        public override int Width => 1;
    }
}
