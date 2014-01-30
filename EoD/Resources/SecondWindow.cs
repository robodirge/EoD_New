using System;

namespace EoD
{
	public partial class SecondWindow : Gtk.Window
	{
		public SecondWindow () : 
			base (Gtk.WindowType.Toplevel)
		{
			//secondcontent();

			//secondcontent test2 = new secondcontent();
			//test2.testfunc();

			this.Build ();
		}



		public void testfunc2(int a, int b, int c){
			Console.WriteLine(a + " " + b + " " + c);
		}

		public class secondcontent{
			public void testfunc(){
				Console.WriteLine("ncfadloanolc");

				//SecondWindow mySecondclass = new SecondWindow();
				//mySecondclass.testfunc2(); 

			}

		}
	}
}

