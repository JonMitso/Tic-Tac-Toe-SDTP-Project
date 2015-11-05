using System;
using SwinGameSDK;
using System.Collections.Generic;

/// <summary>
/// Game states.
/// Control the flow of the game.
/// </summary>
namespace MyGame
{
	public enum GameState
	{
		// Player name input state.
		InputState,

		// Game interaction state.
		PlayState,

		//Display winning row
		PostMatchState,

		// End Game state. Continue or Quit.
		EndingState,

		// Closes the game
		Quitting
	}
}