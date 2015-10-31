using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	/// <summary>
	/// Creates a Swingame drawing of the 3x3 grid layout
	/// </summary>
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

			//creates nine new square objects and adds them to the field _squares
			for (int i = 0; i < 9; i++)	
			{
				_squares.Add ( new Square ());
			}
		}

		/// <summary>
		/// Accesses the individual objects and positions each square accordingly to create a grid structure
		/// </summary>
		public void GridDraw ()
		{
			_squares [0].Draw (25, 35, WIDTH, HEIGHT);
			_squares [1].Draw (202, 35, WIDTH, HEIGHT);
			_squares [2].Draw (379, 35, WIDTH, HEIGHT);
			_squares [3].Draw (25, 212, WIDTH, HEIGHT);
			_squares [4].Draw (202, 212, WIDTH, HEIGHT);
			_squares [5].Draw (379, 212, WIDTH, HEIGHT);
			_squares [6].Draw (25, 389, WIDTH, HEIGHT);
			_squares [7].Draw (202, 389, WIDTH, HEIGHT);
			_squares [8].Draw (379, 389, WIDTH, HEIGHT);
		}

		/// <summary>
		/// Sets the boolean value _selected equal to true
		/// </summary>
		/// <param name="pt">Point2D</param>
		public void SelectSquareAt (Point2D pt)
		{
			foreach (Square s in _squares)
			{
				//Determines whether the position of the mouse pointer when the user clicks is inside a square, if it is set the _selected field to true
				if (s.IsAt (pt))
				{
					s.Selected = true;
				}
			}
		}

		public void Reset ()
		{
			foreach (Square s in _squares)
			{
				s.Selected = false;
			}
		}
	}
}
