using System;
using SwinGameSDK;
using Color = SwinGameSDK.Color;

namespace MyGame
{
	public class Square
	{
		private const int HEIGHT = 50;
		private const int WIDTH = 50;
		private Color COLOR = Color.Black;
		private const int RADIUS = 24;
		private float _x, _y;
		private bool _selected;

		public Square (int x, int y)
		{
			_x = x;
			_y = x;
		}

		public int Height
		{
			get { return HEIGHT; }
		}

		public int Width
		{
			get { return WIDTH; }
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

		public void Draw ()
		{
			SwinGame.FillRectangle (COLOR, _x, _y, WIDTH, HEIGHT);
		}

		public void DrawCross ()
		{
			SwinGame.DrawLine ( Color.White, this.X + 2, this.Y + 2, this.X + 48, this.Y + 48);
			SwinGame.DrawLine ( Color.White, this.X + 2, this.Y + 48, this.X + 48, this.Y + 2);
		}

		public void DrawNaught ()
		{
			SwinGame.DrawCircle ( Color.White, this.X + 2, this.Y + 2, RADIUS );
		}
	}
}

