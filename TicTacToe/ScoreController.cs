using System;
using SwinGameSDK;

namespace MyGame
{
	public class ScoreController
	{
		private int _tie;

		public ScoreController ()
		{
			
		}

		public void IncreasePlayerScore ( Player player )
		{
			player.Score += 1;
		}

		public int TieValue
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

