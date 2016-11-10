using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisRedux.Blocks
{
    public abstract class Block
    {
        public bool[,] blockShape;
        public Vector2 position;
        private Color color;
        protected GameWorld world;

        protected Block(GameWorld parent, Color c)
        {
            color = c;
            position = Vector2.Zero;
            world = parent;
        }

        public void Draw(Texture2D blockTex, SpriteBatch sb)
        {
            for (int x = 0; x < Width; ++x)
            {
                for (int y = 0; y < Height; ++y)
                {
                    if (blockShape[x, y])
                        sb.Draw(blockTex, (position + new Vector2(x, y)) * blockTex.Width, color);
                }
            }
        }

        public void Move(Vector2 move)
        {
            if (world.TheGrid.CanPlaceBlockAt(this, position + move))
            {
                position += move;
            }
        }

        public static Block GetNextBlock(GameWorld world)
        {
            List<Block> nextBlock = new List<Block>();
            nextBlock.Add(new BlockI(world, Vector2.Zero));
            nextBlock.Add(new BlockJ(world, Vector2.Zero));
            nextBlock.Add(new BlockL(world, Vector2.Zero));
            nextBlock.Add(new BlockO(world, Vector2.Zero));
            nextBlock.Add(new BlockS(world, Vector2.Zero));
            nextBlock.Add(new BlockT(world, Vector2.Zero));
            nextBlock.Add(new BlockZ(world, Vector2.Zero));
            int r = world.Random.Next(nextBlock.Count);
            return nextBlock[r];
          

        }

        public Color Color => color;

        public abstract int Width
        {
            get;
        }

        public abstract int Height
        {
            get;
        }
    }
}
