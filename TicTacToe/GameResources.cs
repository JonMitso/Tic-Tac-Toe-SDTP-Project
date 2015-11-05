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
			SwinGame.LoadSoundEffectNamed ("X", "Blop-Mark_DiAngelo-79054334.wav");
			SwinGame.LoadSoundEffectNamed ("O", "Tick-DeepFrozenApps-397275646.wav");
		}

		/// <summary>
		/// Loads all required resources.
		/// </summary>
		public static void LoadResources ()
		{
			LoadSounds ();
			LoadImages ();
			LoadFonts ();
			LoadBundle ();
		}

		/// <summary>
		/// Frees the fonts.
		/// </summary>
		private static void FreeFonts ()
		{
			SwinGame.FreeFont ( SwinGame.FontNamed ( "arial" ) );
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
			SwinGame.FreeSoundEffect ( SwinGame.SoundEffectNamed ( "X" ) );
			SwinGame.FreeSoundEffect ( SwinGame.SoundEffectNamed ( "O" ) );
		}

		/// <summary>
		/// Frees all resources.
		/// </summary>
		public static void FreeResources ()
		{
			FreeSounds ();
			FreeImages ();
			FreeFonts ();
		}
	}
}