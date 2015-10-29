using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameController
	{
		private static GameState _currentState;

		public GameController ()
		{
			_currentState = GameState.SplashState;
		}

		public static GameState GetState
		{
			get { return _currentState; }
			set { _currentState = value; }
		}

		public static void DrawScreen ()
		{
			
		}
	}
}

