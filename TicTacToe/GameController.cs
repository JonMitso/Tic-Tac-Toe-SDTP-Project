using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameController
	{
		public GameController ()
		{
			
		}

		public void SelectSquareAt(Point2D pt)
		{
			foreach (Shape s in _squares)
			{
				if (s.IsAt (pt))
				{
					s.Selected = true;
				}
			}
		}

		public bool IsAt(Point2D pt)
		{
			return SwinGame.PointInRect (pt, x, y, Width, Height);
		}
	}
}

