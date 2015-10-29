using System;
using SwinGameSDK;
using Color = SwinGameSDK.Color;

namespace MyGame
{
	public class Square
	{
		//constant base values
		private const int HEIGHT = 175;
		private const int WIDTH = 175;
		private const int RADIUS = 86;

		//fields
		private int _width, _height;
		private float _x, _y;
		private Color _color;
		private bool _selected;
		private bool _turn;

		public Square (Color color, int width, int height, float x, float y)
		{
			_color = color;
			_width = width;
			_height = height;
			_x = x;
			_y = y;
		}

		public Square () : this (Color.Black, 25, 25, 25, 25)
		{

		}

		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		public float X
		{
			get
			{
				return _x;
			}
			set
			{
				_x = value;
			}
		}

		public float Y
		{
			get
			{
				return _y;
			}
			set
			{
				_y = value;
			}
		}

		public int Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
			}
		}

		public int Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}
		}

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
			}
		}

		public bool Turn
		{
			get { return _turn; }
			set { _turn = value; }
		}

		public bool IsAt (Point2D pt)
		{
			if (SwinGame.PointInRect (pt, _x, _y, _width, _height))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Draw ( float x, float y, int width, int height)
		{
			_x = x;
			_y = y;
			_width = width;
			_height = height;
			SwinGame.FillRectangle (_color, x, y, width, height);

			if ((Selected == true) && (_turn == true))
			{
				DrawNaught ();
			}

			if ((Selected == true) && (_turn == false))
			{
				DrawCross ();
			}
		}

		public void DrawCross ()
		{
			SwinGame.DrawLine ( Color.White, _x, _y, _x + _width, _y + _height);
			SwinGame.DrawLine ( Color.White, _x, _y + _height, _x + _width, _y);
		}

		public void DrawNaught ()
		{
			SwinGame.DrawCircle ( Color.White, (_x + (_width / 2)), (_y + (_height / 2)), RADIUS );
		}
	}
}