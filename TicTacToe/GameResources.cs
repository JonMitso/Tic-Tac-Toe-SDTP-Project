using System;
using SwinGameSDK;
using System.Collections.Generic;

/// <summary>
/// Game resources.
/// </summary>
namespace MyGame
{
	public class GameResources
	{
		public GameResources ()
		{
			
		}

		/// <summary>
		/// Loads the resource bundle.
		/// The bundle includes the panel data.
		/// </summary>
		public static void LoadBundle ()
		{
			SwinGame.LoadResourceBundle ("TicTacToeBundle.txt");
		}

		/// <summary>
		/// Loads the fonts.
		/// </summary>
		public static void LoadFonts ()
		{
			SwinGame.LoadFontNamed ( "arial", "arial.ttf", 12 );
		}

		/// <summary>
		/// Loads the images.
		/// </summary>
		public static void LoadImages ()
		{

		}

		/// <summary>
		/// Loads the sounds.
		/// </summary>
		public static void LoadSounds ()
		{

		}

		/// <summary>
		/// Loads all required resources.
		/// </summary>
		public static void LoadResources ()
		{
			LoadBundle ();
		}

		/// <summary>
		/// Frees the fonts.
		/// </summary>
		private static void FreeFonts ()
		{

		}

		/// <summary>
		/// Frees the images.
		/// </summary>
		private static void FreeImages ()
		{

		}

		/// <summary>
		/// Frees the sounds.
		/// </summary>
		private static void FreeSounds ()
		{

		}

		/// <summary>
		/// Frees all resources.
		/// </summary>
		private static void FreeResources ()
		{

		}
	}
}

