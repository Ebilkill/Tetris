using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TetrisGame : Game
{
    SpriteBatch spriteBatch;
    InputHelper inputHelper;
    GameWorld gameWorld;

    public TetrisGame()
    {        
        // initialize the graphics device
        GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);
        
        // set the directory where game assets are located
        this.Content.RootDirectory = "Content";
        
        // set the desired window size
        graphics.PreferredBackBufferWidth = 800;
        graphics.PreferredBackBufferHeight = 600;

        // create the input helper object
        inputHelper = new InputHelper();

        IsMouseVisible = true;
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // create and reset the game world
        gameWorld = new GameWorld(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Content);
        gameWorld.Reset();
    }

    protected override void Update(GameTime gameTime)
    {
        inputHelper.Update(gameTime);
        if (inputHelper.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape)) Exit();
        gameWorld.HandleInput(gameTime, inputHelper);
        gameWorld.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        gameWorld.Draw(gameTime, spriteBatch);
    }
}

