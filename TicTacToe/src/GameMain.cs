using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("TicTacToe", 800, 600);
            //SwinGame.ShowSwinGameSplashScreen();

			//GameResources.LoadResources();
			Grid grid = new Grid ();
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);

				grid.GridDraw ();

				if (SwinGame.MouseClicked (MouseButton.LeftButton))
				{
					grid.SelectSquareAtL (SwinGame.MousePosition ());
				}

				if (SwinGame.MouseClicked (MouseButton.RightButton))
				{
					grid.SelectSquareAtR (SwinGame.MousePosition ());
				}

				SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}