using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
			// Load game resources
			GameResources.LoadResources ();

            // Open the game window
            SwinGame.OpenGraphicsWindow("TicTacToe", 800, 600);
            //SwinGame.ShowSwinGameSplashScreen();
			// Commented out splash screen for testing purposes

            // Run the game loop until window is closed or the game state switches to quitting
			do
            {
				GameController.DrawScreen ();
				GameController.HandleUserInput ();
				SwinGame.RefreshScreen (60);
			} while( ! ( SwinGame.WindowCloseRequested() == true || GameController.CurrentState == GameState.Quitting || SwinGame.KeyTyped (KeyCode.vk_ESCAPE) || SwinGame.KeyTyped (KeyCode.vk_q) ));
        }
    }
}