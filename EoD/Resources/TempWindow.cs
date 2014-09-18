using System;
using Gtk;

namespace EoD
{
	public partial class TempWindow : Gtk.Window
	{
		public TempWindow () :
			base (Gtk.WindowType.Toplevel)
		{

			Build();
		}
	}
}

