using System;
using SwinGameSDK;
using System.Collections.Generic;

/// <summary>
/// Player.
/// </summary>
namespace MyGame
{
	public class Player
	{
		// Player fields
		private string _name;
		private int _score;

		/// <summary>
		/// Initializes a new Player.
		/// </summary>
		/// <param name="name">Name.</param>
		public Player ( string name )
		{
			_name = name;
			_score = 0;
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
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

		/// <summary>
		/// Gets or sets the score.
		/// </summary>
		/// <value>The score.</value>
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

