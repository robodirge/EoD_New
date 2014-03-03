
using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

using NetOffice;
using Word = NetOffice.WordApi;
using NetOffice.WordApi.Enums;
using System.Reflection;

public partial class MainWindow: Gtk.Window{

	public void ReportSectionThree(){

		SHLevel3();
		// Supply text for title label 
		MainLabelTitle.Text = "Issue Summary";
		
		M1MainTextView1.HeightRequest = 40;
		M1MainTextView1.Buffer.Text = sBlockingNumbers;
		GtkScrolledWindow.SetPolicy(PolicyType.Never,PolicyType.Always);
		
		M1H1MainLabelHeader1.Text = "Issues that have blocked testing?";
		radiobutton3.Active = true;
		radiobutton2.Label = "Yes";
		radiobutton3.Label = "No";
		
		M1MainTextView1.Sensitive = false;

		label8.Text = "Issues blocking testing:";
		
		M5H1MainLabelHeader1.Text = "Top 5 issues of concern:";
			
		label1.Text = "1:";
		label2.Text = "2:";
		label3.Text = "3:";
		label4.Text = "4:";
		label5.Text = "5:";

		label1.Justify = Justification.Right;
		label2.Justify = Justification.Right;
		label3.Justify = Justification.Right;
		label4.Justify = Justification.Right;

		label1.WidthRequest = 0;
		label2.WidthRequest = 0;
		label3.WidthRequest = 0;
		label4.WidthRequest = 0;

		M5MainEntryField1.Sensitive = true;
		M5MainEntryField2.Sensitive = true;
		M5MainEntryField3.Sensitive = true;
		M5MainEntryField4.Sensitive = true;
		M5MainEntryField5.Sensitive = true;

		M5MainEntryField1.Text = top5ListArray[0];
		M5MainEntryField2.Text = top5ListArray[1];
		M5MainEntryField3.Text = top5ListArray[2];
		M5MainEntryField4.Text = top5ListArray[3];
		M5MainEntryField5.Text = top5ListArray[4];


		if(sBlockingyN == "Yes"){
			M1MainTextView1.Buffer.Text = sBlockingNumbers;
			radiobutton2.Active = true;
			Level3Check2Toggled();
		}else{
			M1MainTextView1.Buffer.Text = "";
			radiobutton2.Active = false;
			Level3Check2Toggled();
		}
	
	}

	public void SHLevel3(){
		//---------Section 1  ----------
		MainVboxSubContainerM1.HideAll();
		//-------------------------------
		MainVboxSubContainerM1.Show();
		MainHboxSubContainerM1H1.ShowAll();
		hbox8.ShowAll();
		MainHboxSubContainerM1H2.HideAll();
		//---------other  -----------
		MainVboxSubContainerM2.Hide();
		MainVboxSubContainerM3.Hide();
		MainVboxSubContainerM4.Hide();

		//---------Section 5 -----------
		MainVboxSubContainerM5.HideAll();
		//-------------------------------
		MainVboxSubContainerM5.Show();
		MainHboxSubContainerM5H1.Show();
		M5H1MainLabelHeader1.Show();
		vbox1.Show();
		hbox1.ShowAll();
		button1.Hide();
		hbox2.ShowAll();
		button2.Hide();
		hbox3.ShowAll();
		button3.Hide();
		hbox4.ShowAll();
		button4.Hide();
		hbox5.ShowAll();
		button5.Hide();
	}

	public void backlevel3(){


		M5MainEntryField1.Text = top5ListArray[0];
		M5MainEntryField2.Text = top5ListArray[1];
		M5MainEntryField3.Text = top5ListArray[2];
		M5MainEntryField4.Text = top5ListArray[3];
		M5MainEntryField5.Text = top5ListArray[4];

	}

	protected void Level3Button (){
		bool bNextSection1 = true;

		if(radiobutton2.Active){
			if(M1MainTextView1.Buffer.Text == ""){
				MessageDialog PF = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, ("Missing issue numbers!"));
				PF.Title= "Please provide issue numbers.";
				ResponseType response = (ResponseType) PF.Run();
				if (response == ResponseType.Ok || response == ResponseType.DeleteEvent){
					PF.Destroy();
					bNextSection1 = false;
				}
			}
		}



		bool bAllBlank = true;

		for(int x = 1; x < 6; x++){
			switch(x){
			case 1:
				if((M5MainEntryField1.Text == "") || (M5MainEntryField1.Text == "N/A")){
					top5ListArray[0] = "N/A"; 
					bAllBlank = false;
				}
				else{
					top5ListArray[0] = M5MainEntryField1.Text;
				}
				break;
			case 2:
				if((M5MainEntryField2.Text == "") || (M5MainEntryField2.Text == "N/A")){
					top5ListArray[1] = "N/A"; 
					bAllBlank = false;
				}
				else{
					top5ListArray[1] = M5MainEntryField2.Text;
				}
				break;
			case 3:
				if((M5MainEntryField3.Text == "") || (M5MainEntryField3.Text == "N/A")){
					top5ListArray[2] = "N/A";
					bAllBlank = false;
				} 
				else{
					top5ListArray[2] = M5MainEntryField3.Text;
				}
				break;
			case 4:
				if((M5MainEntryField4.Text == "") || (M5MainEntryField4.Text == "N/A")){
					top5ListArray[3] = "N/A"; 
					bAllBlank = false;
				}
				else{
					top5ListArray[3] = M5MainEntryField4.Text;
				}
				break;
			case 5:
				if((M5MainEntryField5.Text == "") || (M5MainEntryField5.Text == "N/A")){
					top5ListArray[4] = "N/A"; 
					bAllBlank = false;
				}
				else{
					top5ListArray[4] = M5MainEntryField5.Text;
				}
				break;
			default:
				break;
			}

		}

		//rearrange
		int p;
		if(!bAllBlank){
			for(int x = 0; x < 5; x++){
				if(top5ListArray[x] == "N/A"){
					p = x + 1;
					for(; p < 5; p++){

						if(top5ListArray[p] != "N/A"){
							top5ListArray[x] = top5ListArray[p];
							top5ListArray[p] = "N/A";
							break;
						}
					}
				}
			}

			M5MainEntryField1.Text = top5ListArray[0];
			M5MainEntryField2.Text = top5ListArray[1];
			M5MainEntryField3.Text = top5ListArray[2];
			M5MainEntryField4.Text = top5ListArray[3];
			M5MainEntryField5.Text = top5ListArray[4];

		}
		else{
			//Don't include section in report
			//Console.Writeline("All empty");
		}

		if(bNextSection1){
			if((M1MainTextView1.Buffer.Text != "")&&(radiobutton2.Active)){
				sBlockingyN = "Yes";
				sBlockingNumbers = M1MainTextView1.Buffer.Text;
			}else{
				sBlockingyN = "No";
				sBlockingNumbers = "N/A";
			}


			programControl = 4;
			ReportSectionFour();
		}
	}

	protected void Level3Check2Toggled (){
		if (radiobutton2.Active) {
			M1MainTextView1.Sensitive = true; 
		}
		else{
			M1MainTextView1.Sensitive = false;
		}
		return;
	}

}

