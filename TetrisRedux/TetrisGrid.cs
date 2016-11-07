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
    /// 
    /// </summary>
    private Color[,] occupiedPositions;

    /// <summary>
    /// 
    /// </summary>
    private Block currentBlock;

    private GameWorld world;

    public TetrisGrid(GameWorld parent, Texture2D b)
    {
        gridblock = b;
        position = Vector2.Zero;
        occupiedPositions = new Color[Width, Height];
        world = parent;
        this.Clear();
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

    /*
     * width in terms of grid elements
     */
    public int Width => 12;

    /*
     * height in terms of grid elements
     */
    public int Height => 20;

    public Block CurrentBlock => currentBlock;
    public Color BackgroundColor => new Color(0x55, 0x55, 0x55, 0xFF);
    public Color EmptyColor => new Color(0, 0, 0, 0);
}

