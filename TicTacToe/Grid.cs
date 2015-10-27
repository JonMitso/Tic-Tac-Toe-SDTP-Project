using System;
using System.Collections.Generic;

namespace MyGame
{
	public class Grid
	{
		private List<Square> _squares;

		public Grid ()
		{
			_squares = new List<Square> ();

			for (int i = 0; i < 9; i++)
			{
				_squares.Add ( new Square ());
			}
		}
	}
}

