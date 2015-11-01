using System;
using SwinGameSDK;
using System.Collections.Generic;
using Color = SwinGameSDK.Color;

/// <summary>
/// A Square.
/// Squares are required in the grid.
/// </summary>
namespace MyGame
{
	public class Square
	{
		// Constant base values
		private const int HEIGHT = 175;
		private const int WIDTH = 175;
		private const int RADIUS = 86;

		// Square fields
		private int _width, _height;
		private float _x, _y;
		private Color _color;
		private bool _selected;
		private bool _turn;


		/// <summary>
		/// Initializes a new Square.
		/// </summary>
		/// <param name="color">Color.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public Square (Color color, int width, int height, float x, float y)
		{
			_color = color;
			_width = width;
			_height = height;
			_x = x;
			_y = y;
			_selected = false;
		}

		/// <summary>
		/// Base Square constructor.
		/// </summary>
		public Square () : this (Color.Black, 25, 25, 25, 25)
		{
			
		}

		/// <summary>
		/// Gets or sets the color.
		/// </summary>
		/// <value>The color.</value>
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

		/// <summary>
		/// Gets or sets the x value.
		/// </summary>
		/// <value>The x value.</value>
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

		/// <summary>
		/// Gets or sets the y value.
		/// </summary>
		/// <value>The y value.</value>
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

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>The height.</value>
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

		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		/// <value>The width.</value>
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

		/// <summary>
		/// Gets or sets a value indicating whether this Square is selected.
		/// </summary>
		/// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
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
			get
			{
				return _turn;
			}
			set
			{
				_turn = value;
			}
		}
		/// <summary>
		/// Determines whether this instance is at the specified point.
		/// </summary>
		/// <returns><c>true</c> if this instance is at the specified pt; otherwise, <c>false</c>.</returns>
		/// <param name="pt">Point.</param>
		public bool IsAt (Point2D pt)
		{
			if (SwinGame.PointInRect (pt, X, Y, Width, Height))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Draw the Square.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		public void Draw ( float x, float y, int width, int height)
		{
			_x = x;
			_y = y;
			_width = width;
			_height = height;
			SwinGame.FillRectangle (Color, x, y, width, height);

			if ((Selected) && (_turn == true))
			{
				DrawCross ();
			}

			else if ((Selected) && (_turn == false))
			{
				DrawNaught ();
			}
		}

		/// <summary>
		/// Draws the cross.
		/// </summary>
		public void DrawCross ()
		{
			SwinGame.DrawLine ( Color.White, _x, _y, _x + _width, _y + _height);
			SwinGame.DrawLine ( Color.White, _x, _y + _height, _x + _width, _y);
		}

		/// <summary>
		/// Draws the naught.
		/// </summary>
		public void DrawNaught ()
		{
			SwinGame.DrawCircle ( Color.White, (_x + (_width / 2)), (_y + (_height / 2)), RADIUS );
		}
	}
}