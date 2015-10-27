using System;
using SwinGameSDK;
using Color = SwinGameSDK.Color;

namespace MyGame
{
	public class Square
	{
		private const int HEIGHT = 50;
		private const int WIDTH = 50;
		private const Color COLOR = Color.Black;
		private const int RADIUS = 24;
		private float _x, _y;
		private bool _selected;

		public Square ()
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

			}
		}

		public float X
		{
			get
			{
				return _x;
			}
		}

		public float Y
		{
			get
			{
				return _y;
			}
		}

		public float Height
		{
			get
			{
				return _height;
			}
		}

		public float Width
		{
			get
			{
				return _width;
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

		public static void Draw ()
		{
			SwinGame.FillRectangle (COLOR, _x, _y, WIDTH, HEIGHT);
		}

		public static void DrawCross ()
		{
			SwinGame.DrawLine ( Color.White, this.X + 2, this.Y + 2, this.X + 48, this.Y + 48);
			SwinGame.DrawLine ( Color.White, this.X + 2, this.Y + 48, this.X + 48, this.Y + 2);
		}

		public static void DrawNaught ()
		{
			SwinGame.DrawCircle ( Color.White, this.X + 2, this.Y + 2, RADIUS );
		}
	}
}

