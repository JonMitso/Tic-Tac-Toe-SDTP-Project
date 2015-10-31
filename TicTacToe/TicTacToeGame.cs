using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class TicTacToeGame
	{
		private List<Player> _players = new List<Player> ();

		private int _playerIndex = 0;

		public Player Player {
			get { return _players[_playerIndex]; }
		}

		private Grid _grid;

		public TicTacToeGame ()
		{
			
		}
	}
}

