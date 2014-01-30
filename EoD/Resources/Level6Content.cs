
using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	public void ReportSectionSix(){

		SHLevel6();

		MainLabelTitle.Text = "Environments";

		
		GtkScrolledWindow.SetPolicy(PolicyType.Never,PolicyType.Never);
		M1H1MainLabelHeader1.Text = "Select your enviroments";
		button8.Label = "Select Environments";
		button8.Sensitive = false;
		button8.WidthRequest = 150;
	}

	public void SHLevel6(){
		MainVboxSubContainerM1.HideAll();
		MainVboxSubContainerM1.Show();
		MainHboxSubContainerM1H1.Show();
		M1H1MainLabelHeader1.Show();
		MainHboxSubContainerM1H2.Show();
		hbox9.Show();
		button8.Show();
		
		MainVboxSubContainerM2.Hide();
		MainVboxSubContainerM3.Hide();
		MainVboxSubContainerM4.Hide();
		MainVboxSubContainerM5.Hide();
	}


	protected void Level6Button (){
		programControl = 7;
		ReportSectionSeven();
	}

}

