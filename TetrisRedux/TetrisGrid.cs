using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TetrisRedux.Blocks;

/*
 * a class for representing the Tetris playing grid
 */
public class TetrisGrid
{
    /*
     * sprite for representing a single grid block
     */
    private Texture2D gridblock;

    /*
     * the position of the tetris grid
     */
    private Vector2 position;

    /// <summary>
    /// The positions in the grid to draw. A position is considered not occupied when the position is equal to EmptyColor.
    /// </summary>
    private Color[,] occupiedPositions;

    /// <summary>
    /// The block that the player can move around. 
    /// </summary>
    private Block currentBlock;

    private GameWorld world;

    public TetrisGrid(GameWorld parent, Texture2D b)
    {
        gridblock = b;
        position = Vector2.Zero;
        occupiedPositions = new Color[Width, Height];
        world = parent;
    }

    /*
     * clears the grid
     */
    public void Clear()
    {
        for (int x = 0; x < Width; ++x)
        {
            for (int y = 0; y < Height; ++y)
            {
                occupiedPositions[x, y] = EmptyColor;
            }
        }

        currentBlock = Block.GetNextBlock(world);
    }

    /// <summary>
    /// Checks whether a block can be placed at the specified position.
    /// </summary>
    /// <param name="block">The block to check availability for.</param>
    /// <param name="pos">The position where the block wants to be.</param>
    /// <returns>True if the block can be placed in the specified position, false otherwise.</returns>
    public bool CanPlaceBlockAt(Block block, Vector2 pos)
    {
        if (pos.X < 0 || pos.Y < 0)
        {
            return false;
        }

        if (pos.X + block.Width > Width || pos.Y + block.Height > Height)
        {
            return false;
        }

        for (int x = 0; x < block.Width; x++)
        {
            for(int y = 0; y < block.Height; y++)
            {
                if (occupiedPositions[(int)pos.X + x, (int)pos.Y + y] != EmptyColor && block.blockShape[x, y])
                {
                    return false;
                }
            }
        }
        

        return true;
    }

    /*
     * draws the grid on the screen
     */
    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        for (int x = 0; x < Width; ++x)
        {
            for (int y = 0; y < Height; ++y)
            {
                Vector2 drawPos = new Vector2(x * gridblock.Width, y * gridblock.Height);
                s.Draw(gridblock, drawPos, BackgroundColor);
                s.Draw(gridblock, drawPos, occupiedPositions[x, y]);
            }
        }

       currentBlock.Draw(gridblock, s);
    }

    /// <summary>
    /// Sets a block into the grid. Also gets a new block. Can also cause the player to be game over.
    /// </summary>
    /// <param name="blockToSet">The block to set into the grid.</param>
    public void setBlockPosition(Block blockToSet)
    {
        for(int x = 0; x < blockToSet.Width; x++)
        {
            for(int y = 0; y < blockToSet.Height; y++)
            {
                if (blockToSet.blockShape[x, y])
                {
                     occupiedPositions[x + (int)blockToSet.position.X , y +(int)blockToSet.position.Y] = blockToSet.Color;
                }
            }
        }

        blockToSet.position = Vector2.Zero;
        currentBlock = Block.GetNextBlock(world);
        if (!this.CanPlaceBlockAt(CurrentBlock, currentBlock.position))
        {
            world.KillPlayer();
        }
    }

    /*
     * width in terms of grid elements
     */
    public int Width => 12;

    /*
     * height in terms of grid elements
     */
    public int Height => 20;

    /// <summary>
    /// The block that the player can move.
    /// </summary>
    public Block CurrentBlock => currentBlock;

    /// <summary>
    /// The color of the background of the grid.
    /// </summary>
    public Color BackgroundColor => new Color(0x55, 0x55, 0x55, 0xFF);

    /// <summary>
    /// The color that specifies a position in the grid that is empty.
    /// </summary>
    public Color EmptyColor => new Color(0, 0, 0, 0);
}

