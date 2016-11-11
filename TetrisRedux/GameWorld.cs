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
        screenWidth = width;
        screenHeight = height;
        random = new Random();
        gameState = GameState.Playing;

        block = Content.Load<Texture2D>("block");
        font = Content.Load<SpriteFont>("SpelFont");
        Block.makeList(this);
        grid = new TetrisGrid(this, block);
    }

    public void Reset()
    {
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
        if (inputHelper.KeyPressed(Keys.Up))
        {
            grid.CurrentBlock.Move(new Vector2(0, -1));
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

    public void KillPlayer()
    {
        gameState = GameState.GameOver;
    }

    public Random Random => random;
    public TetrisGrid TheGrid => grid;
}
