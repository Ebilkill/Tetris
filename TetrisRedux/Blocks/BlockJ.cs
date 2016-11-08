using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TetrisRedux.Blocks
{
    class BlockJ : Block
    {
        public BlockJ(GameWorld world, Vector2 position) : base(world, new Color(0xDF, 0x81, 0xE8, 0xFF))
        {
            this.position = position;
            blockShape = new bool[Width, Height];
            blockShape[0, 2] = true;
            blockShape[1, 0] = true;
            blockShape[1, 1] = true;
            blockShape[1, 2] = true;
            
        }

        public override int Height => 3;
        public override int Width => 2;
    }
}
