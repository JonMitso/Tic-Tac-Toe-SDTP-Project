using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Grid
	{
		//constant base values
		private const int HEIGHT = 175;
		private const int WIDTH = 175;
		private const int RADIUS = 24;

		private List<Square> _squares;

		public Grid ()
		{
			_squares = new List<Square> ();

			for (int i = 0; i < 9; i++)
			{
				_squares.Add ( new Square ());
			}
		}

		public void GridDraw ()
		{
			_squares [0].Draw (25, 25, WIDTH, HEIGHT);
			_squares [1].Draw (202, 25, WIDTH, HEIGHT);
			_squares [2].Draw (379, 25, WIDTH, HEIGHT);
			_squares [3].Draw (25, 202, WIDTH, HEIGHT);
			_squares [4].Draw (202, 202, WIDTH, HEIGHT);
			_squares [5].Draw (379, 202, WIDTH, HEIGHT);
			_squares [6].Draw (25, 379, WIDTH, HEIGHT);
			_squares [7].Draw (202, 379, WIDTH, HEIGHT);
			_squares [8].Draw (379, 379, WIDTH, HEIGHT);
		}

		public void SelectSquareAt (Point2D pt)
		{
			foreach (Square s in _squares)
			{
				if (s.IsAt (pt))
				{
					s.Selected = true;
				}
			}
		}
	}
}

