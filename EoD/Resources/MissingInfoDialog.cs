using System;

namespace EoD
{
	public partial class MissingInfoDialog : Gtk.Dialog
	{
		public MissingInfoDialog ()
		{
			this.Build ();
		}

		public void SetLabelText(string myText){
			MILabel1.Text = myText;
			return;
		}

		protected void OnButton19Clicked (object sender, EventArgs e)
		{
			this.Destroy();
		}
	}
}

