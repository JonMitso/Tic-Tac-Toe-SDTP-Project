using NUnit.Framework;
using System;
using System.Collections.Generic;
using MyGame;
using SwinGameSDK;

namespace TicTacToe.Tests
{
	[TestFixture ()]
	public class Test
	{
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
	}
}

