using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TetrisRedux.Blocks
{
    class BlockL : Block
    {
        public BlockL(GameWorld world, Vector2 position) : base(world, new Color(0xFF, 0xAE, 0x19, 0xFF))
        {
            this.position = position;
            blockShape = new bool[2, 3];
            blockShape[0, 0] = true;
            blockShape[0, 1] = true;
            blockShape[0, 2] = true;
            blockShape[1, 2] = true;
            
        }
    }
}
