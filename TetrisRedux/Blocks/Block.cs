﻿using Microsoft.Xna.Framework;
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
        static List<Block> nextBlock = new List<Block>();

        public static void makeList(GameWorld world)
        {
            nextBlock.Add(new BlockI(world, Vector2.Zero));
            nextBlock.Add(new BlockJ(world, Vector2.Zero));
            nextBlock.Add(new BlockL(world, Vector2.Zero));
            nextBlock.Add(new BlockO(world, Vector2.Zero));
            nextBlock.Add(new BlockS(world, Vector2.Zero));
            nextBlock.Add(new BlockT(world, Vector2.Zero));
            nextBlock.Add(new BlockZ(world, Vector2.Zero));
        }
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
            else
            {
                if (move.Y > 0)
                {
                    world.TheGrid.setBlockPosition(this);
                }
            }
        }

        public void Turn()
        {
            int newWidth = this.Height;
            int newHeight = this.Width;
            bool[,] turnedBlock = new bool[newWidth, newHeight];
            for(int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++) 
                {
                    turnedBlock[Height - 1 - y, x] = blockShape[x, y];
                }
            }
            blockShape = turnedBlock;
        }
             

        public static Block GetNextBlock(GameWorld world)
        {
            int r = world.Random.Next(nextBlock.Count);
            return nextBlock[r];
        }

        public Color Color => color;

        public int Width => blockShape.GetLength(0);
        public int Height => blockShape.GetLength(1);
    }
}
