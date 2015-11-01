using System;
using SwinGameSDK;
using System.Collections.Generic;

/// <summary>
/// Game controller.
/// Controls every aspect of the game.
/// </summary>
namespace MyGame
{
	public static class GameController
	{
		// Stored player objects
		private static Player _playerX;
		private static Player _playerO;

		// The active player
		private static Player _activePlayer;

		// Stored grid
		// Uses squares
		private static Grid _grid;

		// Gamestate stack
		// Controls flow of game
		// Add to stack through push()
		// Remove from stack through pop()
		private static Stack<GameState> _state = new Stack<GameState>();

		/// <summary>
		/// Initializes the GameController.
		/// </summary>
		static GameController ()
		{
			_state.Push(GameState.Quitting);
			_state.Push(GameState.InputState);
			_grid = new Grid ();
		}

		/// <summary>
		/// Gets the X player.
		/// </summary>
		/// <value>The X player.</value>
		public static Player PlayerX 
		{
			get
			{
				return _playerX;
			}
		}

		/// <summary>
		/// Gets the O player.
		/// </summary>
		/// <value>The O player.</value>
		public static Player PlayerO 
		{
			get
			{
				return _playerO;
			}
		}

		public static Player ActivePlayer
		{
			get
			{
				return _activePlayer;
			}
			set
			{
				_activePlayer = value;
			}
		}

		/// <summary>
		/// Gets the current game state.
		/// </summary>
		/// <value>The game state.</value>
		public static GameState CurrentState 
		{
			get 
			{ 
				return _state.Peek(); 
			}
		}

		/// <summary>
		/// Draws the input state.
		/// </summary>
		public static void DrawInput ()
		{
			SwinGame.ShowPanel ( "PlayerInputPanel" );
			SwinGame.DrawInterface ();
		}

		/// <summary>
		/// Draws the play state.
		/// </summary>
		public static void DrawGame ()
		{
			SwinGame.ShowPanel ( "PlayPanel" );
			SwinGame.DrawInterface ();
			_grid.GridDraw ();

			ScoreController.DrawScore ();

			SwinGame.DrawTextOnScreen ( _activePlayer.Name + "'s Turn!", Color.Black, SwinGame.FontNamed( "arial" ), 570, 160);
		}

		/// <summary>
		/// Draws the end game state.
		/// </summary>
		public static void DrawEndOfGame ()
		{
			SwinGame.ShowPanel ( "GameOverPanel" );
			SwinGame.DrawInterface ();

			if ( _grid.CheckWinState () )
			{
				SwinGame.DrawTextOnScreen ( _activePlayer.Name + " wins!", Color.Black, SwinGame.FontNamed( "arial" ), ( ( SwinGame.ScreenWidth () / 2 ) - ( SwinGame.TextWidth ( SwinGame.FontNamed( "arial" ), _activePlayer.Name + "wins!") / 2)), 270);
			}
			else if (_grid.CheckFull () )
			{
				SwinGame.DrawTextOnScreen ( "It's a tie!", Color.Black, SwinGame.FontNamed( "arial" ), ( ( SwinGame.ScreenWidth () / 2 ) - ( SwinGame.TextWidth ( SwinGame.FontNamed( "arial" ), "It's a tie!") / 2)), 270);
			}
		}

		/// <summary>
		/// Draws the game screen.
		/// Draws depending on game state.
		/// Included in game loop, so think of this as part of the loop.
		/// </summary>
		public static void DrawScreen ()
		{
			SwinGame.ClearScreen ( Color.White );
			SwinGame.GUISetBackgroundColor ( Color.White );
			SwinGame.GUISetForegroundColor ( Color.Black );

			switch (CurrentState) {
			case GameState.InputState:
				DrawInput();
				break;
			case GameState.PlayState:
				DrawGame ();
				break;
			case GameState.EndingState:
				DrawEndOfGame();
				break;
			}

			SwinGame.RefreshScreen (60);
		}
			
		/// <summary>
		/// Handles the input during the input state.
		/// </summary>
		static void HandleInputState ()
		{
			// Sets the X and O player names as per the input.
			// Sets to default 'PlayerX' or 'PlayerO' if no input.
			if ( SwinGame.ButtonClicked ( "InputButton1" ))
			{
				if ( SwinGame.TextBoxText ( "PlayerXTextBox" ).TrimEnd () == "" )
				{
					_playerX = new Player ( "PlayerX" );
				}
				else
				{
					_playerX = new Player ( SwinGame.TextBoxText ( "PlayerXTextBox" ).TrimEnd () );
				}

				if ( SwinGame.TextBoxText ( "PlayerOTextBox" ).TrimEnd () == "" )
				{
					_playerO = new Player ( "PlayerO" );
				}
				else
				{
					_playerO = new Player ( SwinGame.TextBoxText ( "PlayerOTextBox" ).TrimEnd () );
				}

				SwinGame.HidePanel ( "PlayerInputPanel" );

				_activePlayer = PlayerX;

				GameController.SwitchState ( GameState.PlayState );
			}
		}

		/// <summary>
		/// Handles the input during the play state.
		/// </summary>
		static void HandlePlayState ()
		{
			// Selects a square on the grid.
			if ( (SwinGame.MouseClicked ( MouseButton.LeftButton )) && _activePlayer == PlayerX )
			{
				_grid.SelectSquareX ( SwinGame.MousePosition() );
			}
			else if ( (SwinGame.MouseClicked (MouseButton.LeftButton )) && _activePlayer == PlayerO )
			{
				_grid.SelectSquareO ( SwinGame.MousePosition() );
			}
				
			// Ends the game.
			if ( SwinGame.ButtonClicked ( "PlayButton1" ) )
			{
				SwinGame.HidePanel ( "PlayPanel" );
				GameController.SwitchState ( GameState.Quitting );
			}
		}

		/// <summary>
		/// Handles the input during the endgame state.
		/// </summary>
		static void HandleEndingState ()
		{
			// Restarts the game.
			// Retains player info and score.
			// Resets the grid.
			if ( SwinGame.ButtonClicked ( "GameOverButton1" ) )
			{
				SwinGame.HidePanel ( "GameOverPanel" );
				GameController.SwitchState ( GameState.PlayState );
				_grid.Reset ();
			}

			// Ends the game.
			if ( SwinGame.ButtonClicked ( "GameOverButton2" ) )
			{
				SwinGame.HidePanel ( "GameOverPanel" );
				GameController.SwitchState ( GameState.Quitting );
			}
		}

		/// <summary>
		/// Handles the user input.
		/// Input is dependent on game state.
		/// Included in game loop, so think of this as part of the loop.
		/// </summary>
		public static void HandleUserInput ()
		{
			SwinGame.ProcessEvents();
			SwinGame.UpdateInterface ();

			switch (CurrentState) {
			case GameState.InputState:
				HandleInputState ();
				break;
			case GameState.PlayState:
				HandlePlayState ();
				break;
			case GameState.EndingState:
				HandleEndingState ();
				break;
			}
		}

		/// <summary>
		/// Adds a new state to the stack.
		/// </summary>
		/// <param name="state">State.</param>
		public static void AddNewState (GameState state)
		{
			_state.Push(state);
		}

		/// <summary>
		/// Ends the current game state and removes from the stack.
		/// </summary>
		public static void EndCurrentState ()
		{
			_state.Pop();
		}

		/// <summary>
		/// Switches the current game state.
		/// </summary>
		/// <param name="newState">New state.</param>
		public static void SwitchState (GameState newState)
		{
			EndCurrentState();
			AddNewState(newState);
		}
	}
}