using System;
using SwinGameSDK;
using System.Collections.Generic;

/// <summary>
/// Score controller.
/// Obvious.
/// </summary>
namespace MyGame
{
	static class ScoreController
	{
		/// <summary>
		/// The tie value.
		/// </summary>
		private static int _tie;

		// The X player.
		private static Player _playerX;

		// The O player.
		private static Player _playerO;

		/// <summary>
		/// Initializes the ScoreController.
		/// </summary>
		static ScoreController ()
		{
			_playerO = GameController.PlayerO;
			_playerX = GameController.PlayerX;
		}

		/// <summary>
		/// Increases the player score.
		/// </summary>
		/// <param name="player">Player.</param>
		public static void IncreasePlayerScore ( Player player )
		{
			player.Score += 1;
		}

		/// <summary>
		/// Draws the score values including names.
		/// </summary>
		public static void DrawScore ()
		{
			SwinGame.DrawTextOnScreen ( "SCORES:", Color.Black, SwinGame.FontNamed( "arial" ), 570, 35);
			SwinGame.DrawTextOnScreen ( _playerX.Name + ": " + _playerX.Score.ToString (), Color.Black, SwinGame.FontNamed( "arial" ), 570, 60);
			SwinGame.DrawTextOnScreen ( _playerO.Name + ": " + _playerO.Score.ToString (), Color.Black, SwinGame.FontNamed( "arial" ), 570, 85);
			SwinGame.DrawTextOnScreen ( "Ties: " + _tie.ToString (), Color.Black, SwinGame.FontNamed( "arial" ), 570, 110);
		}

		/// <summary>
		/// Gets or sets the tie value.
		/// </summary>
		/// <value>The tie value.</value>
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

