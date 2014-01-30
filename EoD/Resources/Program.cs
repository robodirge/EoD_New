using System;
using Gtk;

namespace EoD
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.main();
			//win.Show ();
			Application.Run ();
		}
	}
}
