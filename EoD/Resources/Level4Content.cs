
using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	public void ReportSectionFour(){

		SHLevel4();
		// Supply text for title label 
		MainLabelTitle.Text = "Metrics";

		M5H1MainLabelHeader1.Text = "Stats:";
		label1.Text = "New issues raised today:";
		label2.Text = "Issues re-opened today:";
		label3.Text = "Issues closed today:";
		label4.Text = "Total number of issues open against this project:";

		label1.WidthRequest = 300;
		label2.WidthRequest = 300;
		label3.WidthRequest = 300;
		label4.WidthRequest = 300;

		label1.Xalign = 0.0f;
		label2.Xalign = 0.0f;
		label3.Xalign = 0.0f;
		label4.Xalign = 0.0f;

		label1.Justify = Justification.Left;
		label2.Justify = Justification.Left;
		label3.Justify = Justification.Left;
		label4.Justify = Justification.Left;

		M5MainEntryField1.Text = sMetric1;
		M5MainEntryField2.Text = sMetric2;
		M5MainEntryField3.Text = sMetric3;
		M5MainEntryField4.Text = sMetric4;

		M1H1MainLabelHeader1.WidthRequest = 300;
	}

	public void SHLevel4(){
		//---------Section 1  ----------
		MainVboxSubContainerM1.Hide();
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
	}

	public void backlevel4(){
		M5MainEntryField1.Text = sMetric1;
		M5MainEntryField2.Text = sMetric2;
		M5MainEntryField3.Text = sMetric3;
		M5MainEntryField4.Text = sMetric4;
		return;
	}

	protected void level4Button (){
		if(M5MainEntryField1.Text == ""){
			sMetric1 = "0";
		}else{
			sMetric1 = M5MainEntryField1.Text;
		}

		if(M5MainEntryField2.Text == ""){
			sMetric2 = "0";
		}else{
			sMetric2 = M5MainEntryField2.Text;
		}

		if(M5MainEntryField3.Text == ""){
			sMetric3 = "0";
		}else{
			sMetric3 = M5MainEntryField3.Text;
		}

		if(M5MainEntryField4.Text == ""){
			sMetric4 = "0";
		}else{
			sMetric4 = M5MainEntryField4.Text;
		}

		programControl = 5;
		ReportSectionFive();
	}
		
}

