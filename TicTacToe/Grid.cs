using System;
using SwinGameSDK;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

		// The list of squares to be used in the grid
		private List<Square> _squares;

		/// <summary>
		/// Initializes a new grid.
		/// </summary>
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
		public void SelectSquareX (Point2D pt)
		{
			foreach (Square s in _squares)
			{
				//Determines whether the position of the mouse pointer when the user clicks is inside a square, if it is set the _selected field to true
				if (s.IsAt (pt))
				{
					//Only draw if the square is not selected
					if ( s.SelectedO == false && s.SelectedX == false )
					{
						SwinGame.PlaySoundEffect ( SwinGame.SoundEffectNamed ( "X" ) );
						s.SelectedX = true;

						if ( CheckWinState () )
						{
							ScoreController.IncreasePlayerScore ( GameController.ActivePlayer );
							GameController.SwitchState (GameState.PostMatchState);
						}
						else if ( CheckFull () )
						{
							ScoreController.TieValue += 1;
							GameController.SwitchState (GameState.PostMatchState);
						}
						else
						{
							GameController.ActivePlayer = GameController.PlayerO;
						}
					}
				}
			}
		}

		/// <summary>
		/// Sets the boolean value _selected equal to true
		/// </summary>
		/// <param name="pt">Point.</param>
		public void SelectSquareO (Point2D pt)
		{
			foreach (Square s in _squares)
			{
				//Determines whether the position of the mouse pointer when the user clicks is inside a square, if it is set the _selected field to true
				if (s.IsAt (pt))
				{
					//Only draw if the square is not selected
					if ( s.SelectedO == false && s.SelectedX == false )
					{
						s.SelectedO = true;
						SwinGame.PlaySoundEffect ( SwinGame.SoundEffectNamed ("O") );

						if ( CheckWinState () )
						{
							ScoreController.IncreasePlayerScore ( GameController.ActivePlayer );
							GameController.SwitchState (GameState.PostMatchState);
						}
						else if ( CheckFull () )
						{
							ScoreController.TieValue += 1;
							GameController.SwitchState (GameState.PostMatchState);
						}
						else
						{
							GameController.ActivePlayer = GameController.PlayerX;
						}
					}
				}
			}
		}


		/// <summary>
		/// Checks against all possible win conditions for each player and returns true if the game has detected that a player has won
		/// </summary>
		/// <returns><c>true</c>, if window state was checked, <c>false</c> otherwise.</returns>
		public bool CheckWinState () //To win in Tic-Tac-Toe there must be three consecutive naughts or crosses vertically, horizontally or diagonally on the 3x3 grid
		{
			if ( _squares[0].SelectedO && _squares[1].SelectedO && _squares[2].SelectedO )
			{
				return true;
			} 
			else if ( _squares[3].SelectedO && _squares[4].SelectedO && _squares[5].SelectedO )
			{
				return true;
			}
			else if ( _squares[6].SelectedO && _squares[7].SelectedO && _squares[8].SelectedO )
			{
				return true;
			}
			else if ( _squares[0].SelectedO && _squares[3].SelectedO && _squares[6].SelectedO )
			{
				return true;
			}
			else if ( _squares[1].SelectedO && _squares[4].SelectedO && _squares[7].SelectedO )
			{
				return true;
			}
			else if ( _squares[2].SelectedO && _squares[5].SelectedO && _squares[8].SelectedO )
			{
				return true;
			}
			else if ( _squares[0].SelectedO && _squares[4].SelectedO && _squares[8].SelectedO )
			{
				return true;
			}
			else if ( _squares[2].SelectedO && _squares[4].SelectedO && _squares[6].SelectedO )
			{
				return true;
			}
			else if ( _squares[0].SelectedX && _squares[1].SelectedX && _squares[2].SelectedX )
			{
				return true;
			} 
			else if ( _squares[3].SelectedX && _squares[4].SelectedX && _squares[5].SelectedX )
			{
				return true;
			}
			else if ( _squares[6].SelectedX && _squares[7].SelectedX && _squares[8].SelectedX )
			{
				return true;
			}
			else if ( _squares[0].SelectedX && _squares[3].SelectedX && _squares[6].SelectedX )
			{
				return true;
			}
			else if ( _squares[1].SelectedX && _squares[4].SelectedX && _squares[7].SelectedX )
			{
				return true;
			}
			else if ( _squares[2].SelectedX && _squares[5].SelectedX && _squares[8].SelectedX )
			{
				return true;
			}
			else if ( _squares[0].SelectedX && _squares[4].SelectedX && _squares[8].SelectedX )
			{
				return true;
			}
			else if ( _squares[2].SelectedX && _squares[4].SelectedX && _squares[6].SelectedX )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Checks if every square is selected by either Player0 or PlayerX, if so return true indicating a draw.
		/// </summary>
		/// <returns><c>true</c>, if full was checked, <c>false</c> otherwise.</returns>
		public bool CheckFull ()
		{
			if ( ( ( _squares [0].SelectedO ) || ( _squares [0].SelectedX ) ) && ( ( _squares [1].SelectedO ) || ( _squares [1].SelectedX ) ) && ( ( _squares [2].SelectedO ) || ( _squares [2].SelectedX ) ) &&
				 ( ( _squares [3].SelectedO ) || ( _squares [3].SelectedX ) ) && ( ( _squares [4].SelectedO ) || ( _squares [4].SelectedX ) ) && ( ( _squares [5].SelectedO ) || ( _squares [5].SelectedX ) ) &&
				 ( ( _squares [6].SelectedO ) || ( _squares [6].SelectedX ) ) && ( ( _squares [7].SelectedO ) || ( _squares [7].SelectedX ) ) && ( ( _squares [8].SelectedO ) || ( _squares [8].SelectedX ) ) )
			{
				return true;
			}
			else 
			{
				return false;
			}
		}

		public List<Square> Squares
		{
			get
			{
				return _squares;
			}
		}

		/// <summary>
		/// Reset the grid to default state.
		/// </summary>
		public void Reset ()
		{
			foreach (Square s in _squares)
			{
				s.SelectedX = false;
				s.SelectedO = false;
			}
		}
	}
}