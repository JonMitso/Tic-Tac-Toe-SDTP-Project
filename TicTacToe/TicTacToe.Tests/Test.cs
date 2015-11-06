using NUnit.Framework;
using System;
using SwinGameSDK;
using System.Collections.Generic;
using MyGame;

namespace TicTacToe.Tests
{
	[TestFixture ()]
	public class Test
	{
		//Player Tests
		[Test ()]
		public void TestPlayerConstructor ()
		{
			Player _player = new Player ("Jarrod");

			Assert.IsTrue( _player.Name == "Jarrod" );
			Assert.IsTrue( _player.Score == 0 );
		}

		//Square Tests
		[Test ()]
		public void TestSquareConstructor ()
		{
			Square _square = new Square ();

			Assert.IsTrue ( _square.Color == Color.Black );
			Assert.IsTrue ( _square.X == 25 );
			Assert.IsTrue ( _square.Y == 25 );
			Assert.IsTrue ( _square.Width == 25 );
			Assert.IsTrue ( _square.Height == 25 );
		}

		[Test ()]
		public void TestSquareIsAt ()
		{
			Square _square = new Square ();
			//Defaulted to base constructor x, y, width, height = 25

			Assert.IsTrue ( _square.IsAt (SwinGame.PointAt (25, 25) ));
			Assert.IsTrue ( _square.IsAt (SwinGame.PointAt (44, 44) ));

			Assert.IsFalse ( _square.IsAt (SwinGame.PointAt (90, 44) ));
			Assert.IsFalse ( _square.IsAt (SwinGame.PointAt (10, 30) ));
		}

		[Test ()]
		public void TestSquareSelectedO ()
		{
			Square _square = new Square ();

			_square.SelectedO = true;

			Assert.IsTrue (_square.SelectedO == true);

			_square.SelectedO = false;

			Assert.IsFalse (_square.SelectedO == true);
		}

		[Test ()]
		public void TestSquareSelectedX ()
		{
			Square _square = new Square ();

			_square.SelectedX = true;

			Assert.IsTrue (_square.SelectedX == true);

			_square.SelectedX = false;

			Assert.IsFalse (_square.SelectedX == true);
		}

		//Grid Tests
		[Test ()]
		public void TestPopulateGrid ()
		{
			Grid _grid = new Grid ();
			_grid.GridDraw ();

			Assert.IsTrue ( _grid.Squares[4].IsAt ( SwinGame.PointAt ( 230, 230 )) );
			Assert.IsFalse ( _grid.Squares[4].IsAt ( SwinGame.PointAt ( 200, 100 )) );

			Assert.IsTrue ( _grid.Squares[4].SelectedO == false );
			Assert.IsTrue ( _grid.Squares[4].SelectedX == false );
		}

		[Test ()]
		public void TestGridSelectO ()
		{
			Grid _grid = new Grid ();
			_grid.GridDraw ();

			Assert.IsFalse ( _grid.Squares[4].SelectedO == true );

			_grid.SelectSquareO ( SwinGame.PointAt ( 230, 230 ));

			Assert.IsTrue ( _grid.Squares[4].SelectedO == true );
		}

		[Test ()]
		public void TestGridSelectX ()
		{
			Grid _grid = new Grid ();
			_grid.GridDraw ();

			Assert.IsFalse ( _grid.Squares[4].SelectedX == true );

			_grid.SelectSquareX ( SwinGame.PointAt ( 230, 230 ));

			Assert.IsTrue ( _grid.Squares[4].SelectedX == true );
		}

		[Test ()]
		public void TestWinGrid ()
		{
			Grid _grid = new Grid ();
			_grid.GridDraw ();

			Assert.IsFalse ( _grid.CheckWinState () );

			_grid.SelectSquareO ( SwinGame.PointAt ( 230, 230 ));
			Assert.IsTrue ( _grid.Squares[4].SelectedO == true );

			_grid.Squares[1].SelectedO = true;
			_grid.Squares[7].SelectedO = true;

			Assert.IsTrue ( _grid.CheckWinState () );
		}

		[Test ()]
		public void TestFullGrid ()
		{
			Grid _grid = new Grid ();
			_grid.GridDraw ();

			Assert.IsFalse ( _grid.CheckFull () );

			_grid.Squares[0].SelectedX = true;
			_grid.Squares[1].SelectedX = true;
			_grid.Squares[2].SelectedO = true;
			_grid.Squares[3].SelectedO = true;
			_grid.Squares[4].SelectedX = true;
			_grid.Squares[5].SelectedX = true;
			_grid.Squares[6].SelectedX = true;
			_grid.Squares[7].SelectedO = true;
			_grid.Squares[8].SelectedO = true;

			Assert.IsTrue ( _grid.CheckFull () );
		}

		[Test ()]
		public void TestGridReset()
		{
			Grid _grid = new Grid ();
			_grid.GridDraw ();

			_grid.Squares[0].SelectedX = true;
			_grid.Squares[1].SelectedX = true;
			_grid.Squares[2].SelectedO = true;
			_grid.Squares[3].SelectedO = true;
			_grid.Squares[4].SelectedX = true;
			_grid.Squares[5].SelectedX = true;
			_grid.Squares[6].SelectedX = true;
			_grid.Squares[7].SelectedO = true;
			_grid.Squares[8].SelectedO = true;

			Assert.IsTrue ( _grid.Squares[0].SelectedX == true );
			Assert.IsTrue ( _grid.Squares[1].SelectedX == true );
			Assert.IsTrue ( _grid.Squares[2].SelectedO == true );
			Assert.IsTrue ( _grid.Squares[3].SelectedO == true );
			Assert.IsTrue ( _grid.Squares[4].SelectedX == true );
			Assert.IsTrue ( _grid.Squares[5].SelectedX == true );
			Assert.IsTrue ( _grid.Squares[6].SelectedX == true );
			Assert.IsTrue ( _grid.Squares[7].SelectedO == true );
			Assert.IsTrue ( _grid.Squares[8].SelectedO == true );

			_grid.Reset ();

			Assert.IsTrue ( _grid.Squares[0].SelectedX == false );
			Assert.IsTrue ( _grid.Squares[1].SelectedX == false );
			Assert.IsTrue ( _grid.Squares[2].SelectedO == false );
			Assert.IsTrue ( _grid.Squares[3].SelectedO == false );
			Assert.IsTrue ( _grid.Squares[4].SelectedX == false );
			Assert.IsTrue ( _grid.Squares[5].SelectedX == false );
			Assert.IsTrue ( _grid.Squares[6].SelectedX == false );
			Assert.IsTrue ( _grid.Squares[7].SelectedO == false );
			Assert.IsTrue ( _grid.Squares[8].SelectedO == false );
		}
	}
}
