using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using TetrisRedux.Blocks;

/*
 * A class for representing the game world.
 */
public class GameWorld
{
    /*
     * enum for different game states (playing or game over)
     */
    enum GameState
    {
        Playing, GameOver
    }

    /*
     * screen width and height
     */
    int screenWidth, screenHeight;

    /*
     * random number generator
     */
    Random random;

    /*
     * main game font
     */
    SpriteFont font;

    /*
     * sprite for representing a single tetris block element
     */
    Texture2D block;

    /*
     * the current game state
     */
    GameState gameState;

    /*
     * the main playing grid
     */
    TetrisGrid grid;
    private int time = 0;
    int fallingspeed = 500;

    public GameWorld(int width, int height, ContentManager Content)
    {
        // Initialize the screen size.
        screenWidth = width;
        screenHeight = height;

        // Initialize the random number generator for the game.
        random = new Random();

        // Set the active game state to playing by default.
        gameState = GameState.Playing;

        // Initialize the list of all blocks.
        Block.makeList(this);

        // Load textures.
        block = Content.Load<Texture2D>("block");
        font = Content.Load<SpriteFont>("SpelFont");

        // Load the tetris grid.
        grid = new TetrisGrid(this, block);
    }

    public void Reset()
    {
        grid.Clear();
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Left))
        {
            grid.CurrentBlock.Move(new Vector2(-1, 0));
        }
        if (inputHelper.KeyPressed(Keys.Right))
        {
            grid.CurrentBlock.Move(new Vector2(1, 0));
        }
        if (inputHelper.KeyPressed(Keys.Down))
        {
            grid.CurrentBlock.Move(new Vector2(0, 1));
        }
        if (inputHelper.KeyPressed(Keys.Space, false))
        {
            grid.CurrentBlock.Turn();
        }
    }



    public void Update(GameTime gameTime)
    {
        time += gameTime.ElapsedGameTime.Milliseconds;
        if (time > fallingspeed)
        {
            grid.CurrentBlock.Move(new Vector2(0, 1));
            time -= fallingspeed;
        }
          
    }

    /// <summary>
    /// Draws the game world.
    /// </summary>
    /// <param name="gameTime">The GameTime object passed to every update method (from MonoGame.Game).</param>
    /// <param name="spriteBatch">The spritebatch to draw everything with.</param>
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        spriteBatch.End(); 
    }

    /*
     * utility method for drawing text on the screen
     */
    public void DrawText(string text, Vector2 positie, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, text, positie, Color.Blue);
    }

    /// <summary>
    /// Sets the <code>GameState</code> to game over.
    /// </summary>
    public void KillPlayer()
    {
        gameState = GameState.GameOver;
    }

    /// <summary>
    /// The random number generator that this gameworld uses.
    /// </summary>
    public Random Random => random;

    /// <summary>
    /// The grid that Tetris is played in.
    /// </summary>
    public TetrisGrid TheGrid => grid;
}
