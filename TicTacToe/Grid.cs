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

			foreach (Square s in _squares)
			{
				_squares.Add (s);
				_squares.Draw (s);
			}

		}

		public void SetupGrid()
		{
			Shape s1 = new Shape ();
			Shape s2 = new Shape ();
			Shape s3 = new Shape ();
			Shape s4 = new Shape ();
			Shape s5 = new Shape ();
			Shape s6 = new Shape ();
			Shape s7 = new Shape ();
			Shape s8 = new Shape ();
			Shape s9 = new Shape ();

			for (int i = 0; i <= 9; i++)
			{
				_squares.Add (s1);
				_squares.Add (s2);
				_squares.Add (s3);
				_squares.Add (s4);
				_squares.Add (s5);
				_squares.Add (s6);
				_squares.Add (s7);
				_squares.Add (s8);
				_squares.Add (s9);
			}

			foreach (Sqaure s in _squares)
			{
				s.Draw ();
			}
		}
	}
}

