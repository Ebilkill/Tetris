using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisRedux.Blocks
{
    public class BlockT : Block
    {
        public BlockT(GameWorld world, Vector2 pos) : base(world, new Color(0xFF, 0x00, 0xFF, 0xFF))
        {
            this.position = pos;
            this.blockShape = new bool[Width, Height];
            this.blockShape[0, 0] = true;
            this.blockShape[1, 0] = true;
            this.blockShape[2, 0] = true;
            this.blockShape[1, 1] = true;
        }

        public override int Height => 2;

        public override int Width => 3;
    }
}
