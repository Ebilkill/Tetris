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
        public BlockT(GameWorld world, Vector2 pos) : base(world, new Color(0x94, 0x0B, 0xA0, 0xFF))
        {
            this.position = pos;
            this.blockShape = new bool[3, 2];
            this.blockShape[0, 0] = true;
            this.blockShape[1, 0] = true;
            this.blockShape[2, 0] = true;
            this.blockShape[1, 1] = true;
        }
    }
}
