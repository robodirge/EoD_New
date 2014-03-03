using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	public void ReportSectionTwo(){
		SHLevel2();
		// Supply text for title label 
		MainLabelTitle.Text = "Report Details";
		// Supply content for Client fields
		M1H1MainLabelHeader1.Text = "Testers initials:";
		label10.Text = "Other initials - add / between sets"; 
		M1MainEntryField1.Text = "";
		M1MainEntryField1.Sensitive = false;
		Initradiobutton1.Active = false;

		// Supply content for Project fields
		M2H1MainLabelHeader1.Text = "Date tested:";

		M2MainEntryField1.Text = DateTime.Now.ToString("dd/MM/yyyy"); /// Could make a calender
		
		M3H1MainLabelHeader1.Text = "Test activities:";

		M3H2MainCheck1.Label = "Scripting & Planning";
		M3H2MainCheck2.Label = "Test Execution";
		M3H2MainCheck3.Label = "Issue Verification & Retest";

		M3H2MainCheck1.Active = false;
		M3H2MainCheck2.Active = false;
		M3H2MainCheck3.Active = false;

		if(bIssueVoption)
			MainButtonControls1.Sensitive = true;
		else
			MainButtonControls1.Sensitive = false;

		if(!pageControl)
			InitialsSetup();

		MainButtonControls3.Sensitive = true;
	}

	public void SHLevel2(){
		//---------Section 1  ----------
		MainVboxSubContainerM1.HideAll();
		//-------------------------------
		MainVboxSubContainerM1.Show();
		MainHboxSubContainerM1H1.Show();
		M1H1MainLabelHeader1.Show();
		hbox11.Show();
		label10.Show();
		M1MainEntryField1.Show();
		vbox2.ShowAll();
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
		M3H1MainLabelHeader1.Show();
		MainHboxSubContainerM3H2.ShowAll();
		M3H2MainCheck3.Hide();

		MainVboxSubContainerM4.HideAll();
		MainVboxSubContainerM5.HideAll();

		// Other
		hseparator6.Show();
		hseparator2.Show();
		hseparator8.Show();
		hseparator3.Show();
		hseparator4.Show();
		hseparator9.Show();
		hseparator7.Show();
	}

	public void backlevel2(){
		M3H2MainCheck1.Active = false;
		M3H2MainCheck2.Active = false;
		M3H2MainCheck3.Active = false;

		if(Otherinitials != ""){
			Initradiobutton1.Active = true;
			InCheck15Toggled();
			M1MainEntryField1.Text = Otherinitials;
		}

		M2MainEntryField1.Text = sDateTested;

		for(int x = 0; x < initEnabledArray.Length; x++){
			if(initEnabledArray[x] == true){
				switch(x){
				case 0:
					initArray[x] = "BV";
					InCheck1.Label = initArray[x];
					InCheck1.Active = true;
					break;
				case 1:
					initArray[x] = "ELR";
					InCheck2.Label = initArray[x];
					InCheck2.Active = true;
					break;
				case 2:
					initArray[x] = "SA";
					InCheck3.Label = initArray[x];
					InCheck3.Active = true;
					break;
				case 3:
					initArray[x] = "AF";
					InCheck4.Label = initArray[x];
					InCheck4.Active = true;
					break;
				case 4:
					initArray[x] = "TY";
					InCheck5.Label = initArray[x];
					InCheck5.Active = true;
					break;
				case 5:
					initArray[x] = "TG";
					InCheck6.Label = initArray[x];
					InCheck6.Active = true;
					break;
				case 6:
					initArray[x] = "GH";
					InCheck7.Label = initArray[x];
					InCheck7.Active = true;
					break;
				case 7:
					initArray[x] = "LW";
					InCheck8.Label = initArray[x];
					InCheck8.Active = true;
					break;
				case 8: 
					initArray[x] = "JG";
					InCheck9.Label = initArray[x];
					InCheck9.Active = true;
					break;
				case 9: 
					initArray[x] = "KH";
					InCheck10.Label = initArray[x];
					InCheck10.Active = true;
					break;
				case 10: 
					initArray[x] = "MG";
					InCheck11.Label = initArray[x];
					InCheck11.Active = true;
					break;
				case 11: 
					initArray[x] = "SS";
					InCheck12.Label = initArray[x];
					InCheck12.Active = true;
					break;
				case 12: 
					initArray[x] = "LHW";
					InCheck13.Label = initArray[x];
					InCheck13.Active = true;
					break;
				case 13: 
					initArray[x] = "WT";
					InCheck14.Label = initArray[x];
					InCheck14.Active = true;
					break;
				default:
					break;
				}
			}
		}


		if(bScripting1){
			bScripting = true;
			M3H2MainCheck1.Active = true;
		}
		else{
			M3H2MainCheck1.Active = false;
		}
			
		if(bTestExe1){
			bTestExe = true;
			M3H2MainCheck2.Active = true;
		}
		else{
			M3H2MainCheck2.Active = false;
		}

		if(bIssueVoption || bTestExe || bScripting){
			MainButtonControls1.Sensitive = true;
		}else{
			MainButtonControls1.Sensitive = false;
		}
			
		return;
	}

	public void InitialsSetup(){
		vbox2.Visible = true;
		Initradiobutton2.Active = true;
		//initArray = new string[12];

		for(int x = 0; x < initArray.Length; x++){
			switch(x){
			case 0:
				initArray[x] = "BV";
				InCheck1.Label = initArray[x];
				InCheck1.Active = false;
				break;
			case 1:
				initArray[x] = "ELR";
				InCheck2.Label = initArray[x];
				InCheck2.Active = false;
				break;
			case 2:
				initArray[x] = "SA";
				InCheck3.Label = initArray[x];
				InCheck3.Active = false;
				break;
			case 3:
				initArray[x] = "AF";
				InCheck4.Label = initArray[x];
				InCheck4.Active = false;
				break;
			case 4:
				initArray[x] = "TY";
				InCheck5.Label = initArray[x];
				InCheck5.Active = false;
				break;
			case 5:
				initArray[x] = "TG";
				InCheck6.Label = initArray[x];
				InCheck6.Active = false;
				break;
			case 6:
				initArray[x] = "GH";
				InCheck7.Label = initArray[x];
				InCheck7.Active = false;
				break;
			case 7:
				initArray[x] = "LW";
				InCheck8.Label = initArray[x];
				InCheck8.Active = false;
				break;
			case 8: 
				initArray[x] = "JG";
				InCheck9.Label = initArray[x];
				InCheck9.Active = false;
				break;
			case 9: 
				initArray[x] = "KH";
				InCheck10.Label = initArray[x];
				InCheck10.Active = false;
				break;
			case 10: 
				initArray[x] = "MG";
				InCheck11.Label = initArray[x];
				InCheck11.Active = false;
				break;
			case 11: 
				initArray[x] = "SS";
				InCheck12.Label = initArray[x];
				InCheck12.Active = false;
				break;
			case 12: 
				initArray[x] = "LHW";
				InCheck13.Label = initArray[x];
				InCheck13.Active = false;
				break;
			case 13: 
				initArray[x] = "WT";
				InCheck14.Label = initArray[x];
				InCheck14.Active = false;
				break;
			default:
				break;
			}
		}

		InCheck15.Sensitive = false;
	}

	protected void Level2Button (){
		bool hasEnabled = false;
		sAllinitials = "";
		for(int p = 0; p < initEnabledArray.Length; p++){
			if(initEnabledArray[p]){
				hasEnabled = true;
				sAllinitials += (initArray[p] + "/");
			}
		}


		if((M1MainEntryField1.Text == "")&&(Initradiobutton1.Active == true)){
			MessageDialog PF = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, ("Please provide 'Other' initials."));
			PF.WidthRequest = 600; 
			PF.Title= "Missing initials!Please provide 'Other' initials.";
			ResponseType response = (ResponseType) PF.Run();
			if (response == ResponseType.Ok || response == ResponseType.DeleteEvent){
				PF.Destroy();
			}
		}else if(!hasEnabled){
			MessageDialog PF = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, ("Please check initials boxes or use 'Other' text field."));
			PF.WidthRequest = 600; 
			PF.Title= "Missing initials!";
			ResponseType response = (ResponseType) PF.Run();
			if (response == ResponseType.Ok || response == ResponseType.DeleteEvent){
				PF.Destroy();
			}
		}
		else{
			programControl = 3;
			vbox2.Visible = false;
			label10.Visible = false;
			sDateTested = M2MainEntryField1.Text;


			//sAllinitials
			if((Initradiobutton1.Active) &&(M1MainEntryField1.Text != "")){
				sAllinitials += M1MainEntryField1.Text;
				Otherinitials = M1MainEntryField1.Text;
				sAllinitials = sAllinitials.TrimEnd('/');
			}else{
				Otherinitials = "";
				sAllinitials = sAllinitials.TrimEnd('/');
			}

			pageControl = true;
			bTestExe1 = bTestExe;
			bScripting1 = bScripting;
			M3H2MainCheck1.Active = false;
			M3H2MainCheck2.Active = false;

			ReportSectionThree();
		}
	}

	protected void Level2Check1Toggled (){
		if(M3H2MainCheck1.Active){
			bScripting = true;
			MainButtonControls1.Sensitive = true;
		}
		else{
			bScripting = false;
			if((M3H2MainCheck2.Active)||(bIssueVoption == true)){
			}
			else{
				MainButtonControls1.Sensitive = false;
			}
		}
	}

	protected void Level2Check2Toggled (){
		if(M3H2MainCheck2.Active){
			MainButtonControls1.Sensitive = true;
			bTestExe = true;
		}
		else{
			bTestExe = false;
			if((M3H2MainCheck1.Active)||(bIssueVoption == true)){
			}
			else{
				MainButtonControls1.Sensitive = false;
			}
		}
	}

	protected void Level2Check3Toggled (){
		if(M3H2MainCheck3.Active){
			MainButtonControls1.Sensitive = true;
			bIssueVoption = true;
		}
		else{
			bIssueVoption = false;
			if((M3H2MainCheck1.Active)||(M3H2MainCheck2.Active)){
			}
			else{
				MainButtonControls1.Sensitive = false;
			}
		}
	}

	public void InCheck15Toggled(){
		if (Initradiobutton1.Active)
			M1MainEntryField1.Sensitive = true; 
		else{
			M1MainEntryField1.Sensitive = false;
		}
		return;
	}
}

