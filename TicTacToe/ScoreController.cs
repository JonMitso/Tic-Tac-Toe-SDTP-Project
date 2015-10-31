using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	static class ScoreController
	{
		private static int _tie;

		private static Player _playerX;

		private static Player _playerO;

		static ScoreController ()
		{
			_playerO = GameController.PlayerO;
			_playerX = GameController.PlayerX;
		}

		public static void IncreasePlayerScore ( Player player )
		{
			player.Score += 1;
		}

		public static void DrawScore ()
		{
			SwinGame.DrawTextOnScreen ( "SCORES:", Color.Black, SwinGame.FontNamed( "arial" ), 570, 35);
			SwinGame.DrawTextOnScreen ( _playerX.Name + ": " + _playerX.Score.ToString (), Color.Black, SwinGame.FontNamed( "arial" ), 570, 60);
			SwinGame.DrawTextOnScreen ( _playerO.Name + ": " + _playerO.Score.ToString (), Color.Black, SwinGame.FontNamed( "arial" ), 570, 85);
			SwinGame.DrawTextOnScreen ( "Ties: " + _tie.ToString (), Color.Black, SwinGame.FontNamed( "arial" ), 570, 110);
		}

		public static int TieValue
		{
			get
			{
				return _tie;
			}
			set
			{
				_tie = value;
			}
		}
	}
}

