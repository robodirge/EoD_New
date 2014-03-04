
using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	public void ReportSectionFive(){

		SHLevel5();

		MainLabelTitle.Text = "Report Detail";
		MainVboxSubContainerM1.Show();
		MainVboxSubContainerM2.Show();
		MainVboxSubContainerM3.Hide();
		MainVboxSubContainerM4.Hide();
		MainVboxSubContainerM5.Hide();

		M1H1MainLabelHeader1.Text = "Test tasks completed:";
		M1MainTextView1.Sensitive = true;
		M1MainTextView1.WrapMode = WrapMode.Word;
		M1MainTextView1.Buffer.Text = "";
		M1MainTextView1.HeightRequest = 100;
		GtkScrolledWindow.SetPolicy(PolicyType.Never,PolicyType.Always);
		
		M2H1MainLabelHeader1.Text = "Brief overview of testing:";
		M2MainTextView1.Sensitive = true;
		M2MainTextView1.Buffer.Text = "";
		M2MainTextView1.WrapMode = WrapMode.Word;
		M2MainTextView1.HeightRequest = 300;

		GtkScrolledWindow1.SetPolicy(PolicyType.Never,PolicyType.Always);

		button8.WidthRequest = 100;
		button8.Sensitive = true;
		button9.WidthRequest = 100;
		button8.Label = "Info";
		button9.Label = "Spell Check";

		button10.WidthRequest = 100;
		button10.Sensitive = true;
		button11.WidthRequest = 100;
		button10.Label = "Info";
		button11.Label = "Spell Check";
		MainButtonControls1.Sensitive = true;

		MainButtonControls1.Label = "Next";
		M1MainTextView1.Buffer.Text = sTTC;
		M2MainTextView1.Buffer.Text = sBOOT;
	}

	public void SHLevel5(){
		MainVboxSubContainerM3.Hide();
		MainVboxSubContainerM4.Hide();
		MainVboxSubContainerM5.Hide();

		// Section 1:
		MainVboxSubContainerM1.HideAll();
		MainVboxSubContainerM1.Show();
		MainHboxSubContainerM1H1.Show();
		M1H1MainLabelHeader1.Show();
		hbox8.ShowAll();
		label8.Hide();
		hseparator6.Show();
		MainHboxSubContainerM1H2.Show();
		hbox9.ShowAll();
		hseparator2.Show();
		// Section 2:
		MainVboxSubContainerM2.HideAll();
		MainVboxSubContainerM2.Show();
		MainHboxSubContainerM2H1.Show();
		M2H1MainLabelHeader1.Show();
		GtkScrolledWindow1.ShowAll();
		hseparator8.Show();
		hseparator3.Show();
		MainHboxSubContainerM2H2.Show();
		hbox10.ShowAll();
	}

	public void backlevel5(){
		M1MainTextView1.Buffer.Text = sTTC;
		M2MainTextView1.Buffer.Text = sBOOT;
		return;
	}

	#region Content

	public void level5Toggled8 (){
		string sTemp = (@"Brief explanation of the work you have undertaken. Be specific here as to what you have done. Relate it back to the tasks that were required of you in the brief. 
E.g. Copy/link and rendering checks of 18 IKEA Kitchen emails across all specified environments.
E.g. Retests including verification of all issues marked as resolved in the tracker.
E.g. Commenced test execution against the fully scripted test plan on ...environments.
E.g. Conducted tests of all the changes detailed in the 'xyz.doc' document provided by the client.

If a scenario arises where you're not in work the following day - make sure this section makes it very clear to another tester what you have done.

");

		MessageDialog PF = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Close, sTemp);
		PF.WidthRequest = 450; 
		PF.Title= "Info";
		ResponseType response = (ResponseType) PF.Run();
		if (response == ResponseType.Close || response == ResponseType.DeleteEvent){
			PF.Destroy();
		}
	}

	public void level5Toggled10 (){
		string sTemp = (@"Remember this is for the client - to give them an overview of what we have done, the results we have found and our general feedback on the application. Be factual - avoid subjective statements or opinions.  Use 'We' rather than 'I'. 

Things to include might be:

-	A summary of how the site/app is behaving compared to expected behaviour. 
-	How is the testing progressing against the time scheduled? Were we able to get done today what we had planned? If not, why?
-	A brief rundown of the major problems you're seeing
-	If our testing budget is used up - could more testing be required?
-	Ensure all information is measureable.
-	User experience feedback that may be valuable to the client, that is supported by factual evidence with issues in the tracker.

DO NOT:
-	Do not offer an opinion as to whether the app is ready for release.
-	Do not provide subjective feelings (e.g. We felt that the website performed well).
-	Do not suggest that we are ahead of schedule.

");

		MessageDialog PF = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Close, sTemp);
		PF.WidthRequest = 450; 
		PF.Title= "Info";
		ResponseType response = (ResponseType) PF.Run();
		if (response == ResponseType.Close || response == ResponseType.DeleteEvent){
			PF.Destroy();
		}
	}

	#endregion

	protected void level5ButtonControls2Clicked (int iRef){
		string sRef;
		EoD.Level5Dialog Nw = null;
		if(iRef == 1){
			sRef = M1MainTextView1.Buffer.Text;
			Nw = new EoD.Level5Dialog(ref sRef);
		}
		else if(iRef == 2){
			sRef = M2MainTextView1.Buffer.Text;
			Nw = new EoD.Level5Dialog(ref sRef);
		}
		else{
			//Console.Writeline("Error missing content -- level5ButtonControls2Clicked");
		}

		//EoD.Level5Dialog Nw = new EoD.Level5Dialog(M2MainTextView1.Buffer.Text);
		ResponseType response = (ResponseType) Nw.Run();
		if (response == ResponseType.DeleteEvent){
			Nw.AppQuit();
			if(iRef == 1){
				M1MainTextView1.Buffer.Text = Nw.getText();
			}
			else if(iRef == 2){
				M2MainTextView1.Buffer.Text = Nw.getText();
			}
			Nw.Destroy();
		}
	}

	protected void level5Button (){
		sTTC = M1MainTextView1.Buffer.Text;
		sBOOT = M2MainTextView1.Buffer.Text;


		if(bSmokes){
			programControl = 7;
			ReportSectionSeven();
		}
		else{
			programControl = 7;
			ReportSectionSeven();
			//Create Document
		}
	}

	protected void OnButton11Clicked (object sender, EventArgs e){
		level5ButtonControls2Clicked (2);
	}

	protected void OnButton9Clicked (object sender, EventArgs e){
		level5ButtonControls2Clicked (1);
	}
}

