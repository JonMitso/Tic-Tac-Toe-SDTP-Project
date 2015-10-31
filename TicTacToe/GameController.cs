using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public static class GameController
	{
		private static Player _playerX;
		private static Player _playerO;

		//The winning player
		//Placeholder name of 'Player'
		private static Player _winningPlayer = new Player ( "Player" );

		private static Player _activePlayer = new Player ( "Player" );

		private static Grid _grid;

		private static Stack<GameState> _state = new Stack<GameState>();

		static GameController ()
		{
			_state.Push(GameState.Quitting);
			_state.Push(GameState.InputState);
			_grid = new Grid ();
		}

		public static Player PlayerX 
		{
			get
			{
				return _playerX;
			}
		}

		public static Player PlayerO 
		{
			get
			{
				return _playerO;
			}
		}

		public static GameState CurrentState 
		{
			get 
			{ 
				return _state.Peek(); 
			}
		}

		public static void DrawInput ()
		{
			SwinGame.ShowPanel ( "PlayerInputPanel" );

			SwinGame.UpdateInterface ();
			SwinGame.DrawInterface ();
		}

		public static void DrawGame ()
		{
			SwinGame.ShowPanel ( "PlayPanel" );
			SwinGame.UpdateInterface ();
			SwinGame.DrawInterface ();
			_grid.GridDraw ();

			ScoreController.DrawScore ();
			SwinGame.DrawTextOnScreen ( _activePlayer.Name + "'s Turn!", Color.Black, SwinGame.FontNamed( "arial" ), 570, 160);
		}

		public static void DrawEndOfGame ()
		{
			SwinGame.ShowPanel ( "GameOverPanel" );
			SwinGame.UpdateInterface ();
			SwinGame.DrawInterface ();

			SwinGame.DrawTextOnScreen ( _winningPlayer.Name + " wins!", Color.Black, SwinGame.FontNamed( "arial" ), ( ( SwinGame.ScreenWidth () / 2 ) - ( SwinGame.TextWidth ( SwinGame.FontNamed( "arial" ), _winningPlayer.Name + "wins!") / 2)), 270);
		}

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

		static void HandleInputState ()
		{
			if ( SwinGame.ButtonClicked ( "InputButton1" ) )
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

				GameController.SwitchState ( GameState.PlayState );
			}
		}

		static void HandlePlayState ()
		{
			if ( SwinGame.MouseClicked ( MouseButton.LeftButton ) )
			{
				_grid.SelectSquareAt ( SwinGame.MousePosition() );
			}

			if ( SwinGame.ButtonClicked ( "PlayButton1" ) )
			{
				SwinGame.HidePanel ( "PlayPanel" );

				//EndingState as placeholder, set to Quitting in final product
				GameController.SwitchState ( GameState.EndingState );
			}
		}

		static void HandleEndingState ()
		{
			if ( SwinGame.ButtonClicked ( "GameOverButton1" ) )
			{
				SwinGame.HidePanel ( "GameOverPanel" );
				GameController.SwitchState ( GameState.PlayState );
			}

			if ( SwinGame.ButtonClicked ( "GameOverButton2" ) )
			{
				SwinGame.HidePanel ( "GameOverPanel" );
				GameController.SwitchState ( GameState.Quitting );
			}
		}

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

		public static void AddNewState (GameState state)
		{
			_state.Push(state);
		}

		public static void EndCurrentState ()
		{
			_state.Pop();
		}

		public static void SwitchState (GameState newState)
		{
			EndCurrentState();
			AddNewState(newState);
		}
	}
}

