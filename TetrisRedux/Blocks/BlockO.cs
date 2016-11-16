using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisRedux.Blocks
{
    public class BlockO : Block
    {
        public BlockO(GameWorld world, Vector2 position) : base(world, new Color(0xFF, 0xF3, 0x19, 0xFF))
        {
            this.position = position;
            blockShape = new bool[2, 2];
            blockShape[0, 0] = true;
            blockShape[1, 0] = true;
            blockShape[0, 1] = true;
            blockShape[1, 1] = true;
        }
    }
}
