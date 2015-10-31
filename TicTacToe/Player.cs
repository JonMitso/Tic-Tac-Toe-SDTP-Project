using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Player
	{
		private string _name;
		private int _score;

		public Player ( string name )
		{
			_name = name;
			_score = 0;
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public int Score
		{
			get
			{
				return _score;
			}
			set
			{
				_score = value;
			}
		}
	}
}

