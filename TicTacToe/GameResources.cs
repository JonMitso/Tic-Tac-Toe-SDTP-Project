using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class GameResources
	{
		public GameResources ()
		{
			
		}

		public static void LoadBundle ()
		{
			SwinGame.LoadResourceBundle ("TicTacToeBundle.txt");
		}

		public static void LoadFonts ()
		{
			SwinGame.LoadFontNamed ( "arial", "arial.ttf", 12 );
		}

		public static void LoadImages ()
		{

		}

		public static void LoadSounds ()
		{

		}

		public static void LoadResources ()
		{
			LoadBundle ();
		}

		private static void FreeFonts ()
		{

		}

		private static void FreeImages ()
		{

		}

		private static void FreeSounds ()
		{

		}

		private static void FreeResources ()
		{

		}
	}
}

