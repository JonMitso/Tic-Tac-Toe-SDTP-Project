using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
			GameResources.LoadResources ();
            //Open the game window
            SwinGame.OpenGraphicsWindow("TicTacToe", 800, 600);
            //SwinGame.ShowSwinGameSplashScreen();
			SwinGame.ClearScreen (Color.White);

			SwinGame.ShowPanel ("GameOverPanel");

			SwinGame.GUISetBackgroundColor (Color.White);
			SwinGame.GUISetForegroundColor (Color.Black);


			//GameResources.LoadResources();
			//Grid grid = new Grid ();
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

				SwinGame.DrawInterface ();
				SwinGame.UpdateInterface ();

                //Clear the screen and draw the framerate
				//grid.GridDraw ();

//				if (SwinGame.MouseClicked (MouseButton.LeftButton))
//				{
//					grid.SelectSquareAt (SwinGame.MousePosition ());
//				}
//
//				if (SwinGame.MouseClicked (MouseButton.RightButton))
//				{
//					grid.Reset ();
//				}
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}