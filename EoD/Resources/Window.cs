using System;


namespace EoD
{
	public partial class Window : Gtk.Window
	{
		public Window () : 
			base (Gtk.WindowType.Toplevel)
		{
			//this.Build ();
			windownew();
		}

		public void windownew(){

			this.Build();
			label2.Text = (@"Creating the daily report now.
This application will close once completed"); 

			this.ShowAll();

			System.Threading.Thread.Sleep(30);
		}
	}
}

