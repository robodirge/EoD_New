using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	#region Setup

	public void ReportSectionOne(){
		SHLevel1();

		// Supply text for title label 
		MainLabelTitle.Text = "Project Details";
		
		// Client fields
		M1H1MainLabelHeader1.Text = "Client name:";
		M1MainEntryField1.Sensitive = true;
		M1MainEntryField1.Text = "";

		// Project fields
		M2H1MainLabelHeader1.Text = "Project name:";
		M2MainEntryField1.Sensitive = true;
		M2MainEntryField1.Text = "";

		// URL Fields
		M3H1MainLabelHeader1.Text = "Was a URL used for testing?";

		M3MainTextView1.Sensitive = false;
		M3MainTextView1.Buffer.Text = "";
		radiobutton7.Active = true;

		radiobutton6.Label = "Yes";
		radiobutton7.Label = "No";

		M3MainTextView1.HeightRequest = 20;
		GtkScrolledWindow2.SetPolicy(PolicyType.Never,PolicyType.Always);

		// Supply content for version fields
		M4H1MainLabelHeader1.Text = "Is a build / version number avalible?";

		M4MainTextView1.Sensitive = false;
		M4MainTextView1.Buffer.Text = "";
		radiobutton9.Active = true;

		radiobutton8.Label = "Yes";
		radiobutton9.Label = "No";

		M4MainTextView1.HeightRequest = 15;
		GtkScrolledWindow3.SetPolicy(PolicyType.Never,PolicyType.Always);
		
		// Supply content for Client fields
		M5H1MainLabelHeader1.Text = "Was a primary environment used for testing?";	// "Test environment(s)";
		M5H2MainCheck1.Label = "Cross environment checks/smoke tests";
		M5H2MainCheck1.Active = false;
		M5H2MainCheck2.Label = "Issue Verification & Retest";
		M5H2MainCheck2.Active = false;

		radiobutton11.Active = true;
		M5MainEntryField1.Sensitive = false;
		M5MainEntryField1.Text = "";
		label1.Text = "Primary environment 1:";
		button1.Sensitive = false;

		button1.Label = "+";
		radiobutton10.Label = "Yes";
		radiobutton11.Label = "No";

		// Bottom Nav buttons
		MainButtonControls1.Sensitive = false;
		MainButtonControls2.Sensitive = false;
		MainButtonControls3.Sensitive = false;
		MainButtonControls2.Label = "Spell Check";
		MainButtonControls3.Label = "Back";
		
		// Var set up
		addCounter = 2;
		programControl = 1;

		return;
	}

	public void SHLevel1(){
		//---------Section 1  ----------
		MainVboxSubContainerM1.HideAll();
		//-------------------------------
		MainVboxSubContainerM1.Show();
		MainHboxSubContainerM1H1.Show();
		M1H1MainLabelHeader1.Show();
		hbox11.Show();
		M1MainEntryField1.Show();
		//---------Section 2  ----------
		MainVboxSubContainerM2.HideAll();
		//-------------------------------
		MainVboxSubContainerM2.Show();
		MainHboxSubContainerM2H1.Show();
		M2H1MainLabelHeader1.Show();
		M2MainEntryField1.Show();
		//---------Section 3  ----------
		MainVboxSubContainerM3.HideAll();
		//-------------------------------
		MainVboxSubContainerM3.Show();
		MainHboxSubContainerM3H1.Show();
		MainHboxSubContainerM3H1Sub1.Show();
		M3H1MainLabelHeader1.Show();
		radiobutton6.Show();
		radiobutton7.Show();
		GtkScrolledWindow2.Show();
		M3MainTextView1.Show();
		//---------Section 4  ----------
		MainVboxSubContainerM4.HideAll();
		//-------------------------------
		MainVboxSubContainerM4.Show();
		MainHboxSubContainerM4H1.Show();
		MainHboxSubContainerM4H1Sub1.Show();
		M4H1MainLabelHeader1.Show();
		radiobutton8.Show();
		radiobutton9.Show();
		GtkScrolledWindow3.Show();
		M4MainTextView1.Show();
		//---------Section 5  ----------
		MainVboxSubContainerM5.HideAll();
		//-------------------------------
		MainVboxSubContainerM5.Show();
		MainHboxSubContainerM5H1.Show();
		MainHboxSubContainerM5H1Sub1.Show();
		M5H1MainLabelHeader1.Show();
		radiobutton10.Show();
		radiobutton11.Show();
		vbox1.Show();
		hbox1.Show();
		label1.Show();
		M5MainEntryField1.Show();
		button1.Show();
		hseparator11.Show();
		MainHboxSubContainerM5H2.Show();
		M5H2MainCheck1.Show();
		M5H2MainCheck2.Show();
		hseparator7.Show();
	}
	
	#endregion

	#region General Page

	public void Level1Toggled6 (){
		if (radiobutton6.Active)
			M3MainTextView1.Sensitive = true; 
		else{
			M3MainTextView1.Sensitive = false;
		}
		return;
	}

	protected void Level1Toggled8 (){
		//MainWindow myMainClass = new MainWindow();
		if (radiobutton8.Active) {
			M4MainTextView1.Sensitive = true; 
		}
		else{
			M4MainTextView1.Sensitive = false;
		}
		return;
	}

	protected void Level1Toggled10 (){
		//MainWindow myMainClass = new MainWindow();
		if (radiobutton10.Active){
			//M5MainTextView1.Sensitive = true; 
			MainButtonControls1.Sensitive = true;

			M5MainEntryField1.Sensitive = true;
			M5MainEntryField2.Sensitive = true;
			M5MainEntryField3.Sensitive = true;
			M5MainEntryField4.Sensitive = true;
			M5MainEntryField5.Sensitive = true;
			M5MainEntryField6.Sensitive = true;
			M5MainEntryField7.Sensitive = true;
			button1.Sensitive = true;
			button2.Sensitive = true;
			button3.Sensitive = true;
			button4.Sensitive = true;
			button5.Sensitive = true;
			button6.Sensitive = true;
		}
		else{
			//M5MainTextView1.Sensitive = false;

			M5MainEntryField1.Sensitive = false;
			M5MainEntryField2.Sensitive = false;
			M5MainEntryField3.Sensitive = false;
			M5MainEntryField4.Sensitive = false;
			M5MainEntryField5.Sensitive = false;
			M5MainEntryField6.Sensitive = false;
			M5MainEntryField7.Sensitive = false;
			button1.Sensitive = false;
			button2.Sensitive = false;
			button3.Sensitive = false;
			button4.Sensitive = false;
			button5.Sensitive = false;
			button6.Sensitive = false;

			if((M5H2MainCheck1.Active)||(M5H2MainCheck2.Active)){
			}else{
				MainButtonControls1.Sensitive = false;
			}
		}
		return;
	}

	protected void Level1ButtonControls1Clicked (){
		//MainWindow myMainClass = new MainWindow();
		bool clientNameBool = false;
		clientNameString = IsInvalid(M1MainEntryField1.Text, ref clientNameBool, "Client name");
		bool projectNameBool = false;
		projectNameString = IsInvalid(M2MainEntryField1.Text, ref projectNameBool, "Project name");


		if(clientNameBool)
			M1MainEntryField1.Text = clientNameString;
		if(projectNameBool)
			M2MainEntryField1.Text = projectNameString;

		bool primBool = true;

		//Check all 7 primary fields if text not = to ""  // I could link the '+' to the enviro chooser
		if(radiobutton10.Active){
			if(M5MainEntryField1.Text == ""){
				MessageDialog PF = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, ("Primary environment 1: Text is missing. Please supply an environment and click 'Next'."));
				PF.Title= "Missing input";
				ResponseType response = (ResponseType) PF.Run();
				if (response == ResponseType.Ok || response == ResponseType.DeleteEvent){
					primBool = false;
					PF.Destroy();
				}
			}
		}

		if((clientNameBool) && (projectNameBool) && (primBool)){
			SetLevel1Options();
			programControl = 2; 
			ReportSectionTwo();
		}

		return;
	}

	public string IsInvalid(string illegaltemp, ref bool bvalue, string sTitle){
		//MainWindow myMainClass = new MainWindow();
		illegaltemp = illegaltemp.Trim();
		string oldstring = illegaltemp;
		string invalid = new string(System.IO.Path.GetInvalidFileNameChars()) + new string(System.IO.Path.GetInvalidPathChars());
		foreach (char c in invalid){
			illegaltemp = illegaltemp.Replace(c.ToString(), ""); 
		}
		

		if(illegaltemp == ""){

			MessageDialog E1 = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, (sTitle + " field is empty"));
			E1.WidthRequest = 600; 
			E1.Title= sTitle + " field is empty";

			ResponseType response = (ResponseType) E1.Run();
			if (response == ResponseType.Ok || response == ResponseType.DeleteEvent){
				bvalue = false;
				illegaltemp = oldstring;
				E1.Destroy();
			}
		}
		else if(oldstring != illegaltemp){
			string errortemp = (sTitle + " Is incorrect. Are you happy for this name to be used: ") + illegaltemp;

			MessageDialog SN = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.YesNo, errortemp);
			SN.WidthRequest = 600; 
			SN.Title= sTitle + " is invalid";

			ResponseType response = (ResponseType) SN.Run();
			if (response == ResponseType.Yes){
				bvalue = true;
				SN.Destroy();
			}
			else if (response == ResponseType.No|| response == ResponseType.DeleteEvent){
				bvalue = false;
				illegaltemp = oldstring;
				SN.Destroy();
			}
		}
		else
			bvalue = true;

		return illegaltemp;
	}

	protected void Level1Check1Toggled (){
		if(M5H2MainCheck1.Active)
			MainButtonControls1.Sensitive = true;
		else{
			if((radiobutton10.Active)||(M5H2MainCheck2.Active)){
			}
			else{
				MainButtonControls1.Sensitive = false;
			}
		}
	}

	protected void Level1Check2Toggled (){
		if(M5H2MainCheck2.Active)
			MainButtonControls1.Sensitive = true;
		else{
			if((radiobutton10.Active)||(M5H2MainCheck1.Active)){
			}
			else{
				MainButtonControls1.Sensitive = false;
			}
		}
	}

	protected void PrimAdd (){
		//MainWindow myMainClass = new MainWindow();
		switch (addCounter){
		case 2:
			hbox2.ShowAll();
			button1.Hide();
			M5MainEntryField2.Text = "";
			label2.Text = "Primary environment 2:";
			addCounter++;
			break;
		case 3:
			hbox3.ShowAll();
			button2.Hide();
			M5MainEntryField3.Text = "";
			label3.Text = "Primary environment 3:";
			addCounter++;
			break;
		case 4:
			hbox4.ShowAll();
			button3.Hide();
			M5MainEntryField4.Text = "";
			label4.Text = "Primary environment 4:";
			addCounter++;
			break;
		case 5:
			hbox5.ShowAll();
			button4.Hide();
			M5MainEntryField5.Text = "";
			label5.Text = "Primary environment 5:";
			addCounter++;
			break;
		case 6:
			hbox6.ShowAll();
			button5.Hide();
			M5MainEntryField6.Text = "";
			label6.Text = "Primary environment 6:";
			addCounter++;
			break;
		case 7:
			hbox7.ShowAll();
			button6.Hide();
			M5MainEntryField7.Text = "";
			label7.Text = "Primary environment 7:";
			addCounter++;
			break;
		default:

			break;
		}
	}

	protected void SetLevel1Options(){  ///Needs testing!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		int[] tempContainer = new int[7];
		int iCount = 0;

		//Check all 7 primary fields if text not = to ""  // I could link the '+' to the enviro chooser
		if(radiobutton10.Active){
			primEnabled = true;
			int iTempCount = 1; // Has to be 1 as field1 cant be ""
			tempContainer[iCount] = 1; iCount++;
			if((hbox2.Visible) && (M5MainEntryField2.Text != "")){
				iTempCount++;
				tempContainer[iCount] = 2; iCount++;
			}
			if((hbox3.Visible) && (M5MainEntryField3.Text != "")){
				iTempCount++;
				tempContainer[iCount] = 3; iCount++;
			}
			if((hbox4.Visible) && (M5MainEntryField4.Text != "")){
				iTempCount++;
				tempContainer[iCount] = 4; iCount++;
			}
			if((hbox5.Visible) && (M5MainEntryField5.Text != "")){
				iTempCount++;
				tempContainer[iCount] = 5; iCount++;
			}
			if((hbox6.Visible) && (M5MainEntryField6.Text != "")){
				iTempCount++;
				tempContainer[iCount] = 6; iCount++;
			}
			if((hbox7.Visible) && (M5MainEntryField7.Text != "")){
				iTempCount++;
				tempContainer[iCount] = 7; iCount++;
			}

			primListArray = new string[iTempCount];
			//value is - apply to an array which is global!

			for(int x =0; x < primListArray.Length; x++){
				switch(tempContainer[x]){
				case 1:
					primListArray[x] = M5MainEntryField1.Text;
					break;
				case 2:
					primListArray[x] = M5MainEntryField2.Text;
					break;
				case 3:
					primListArray[x] = M5MainEntryField3.Text;
					break;
				case 4:
					primListArray[x] = M5MainEntryField4.Text;
					break;
				case 5:
					primListArray[x] = M5MainEntryField5.Text;
					break;
				case 6:
					primListArray[x] = M5MainEntryField6.Text;
					break;
				case 7: 
					primListArray[x] = M5MainEntryField7.Text;
					break;
				default:
					//Console.Writeline("Null");
					break;
				}
			}
		}else{
			primEnabled = false;
		}

		if(radiobutton6.Active){
			urlUsedString = M3MainTextView1.Buffer.Text;
		}else{
			urlUsedString = @"N/A";
		}

		if(radiobutton8.Active){
			buildVersionString = M4MainTextView1.Buffer.Text;
		}else{
			buildVersionString = "N/A";
		}

		if(M5H2MainCheck1.Active){
			bSmokes = true;
		}else{
			bSmokes = false;
		}

		if(M5H2MainCheck2.Active){
			bIssueVoption = true;
		}else{
			bIssueVoption = false;
		}

		return;
	}

	#endregion
}

