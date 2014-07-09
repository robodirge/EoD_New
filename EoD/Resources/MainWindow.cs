using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

	#region Globals

	public string clientNameString;
	public string projectNameString;
	public string urlUsedString;
	public string buildVersionString;
	public string[] primListArray;
	public static bool primEnabled;
	public string[] top5ListArray;
	public static string sBlockingNumbers;
	public static string sBlockingyN;
	public static bool bSmokes;
	public static bool bRetests;
	public static bool bInitEnabled;
	public string[] initArray = new string[15];
	public bool[] initEnabledArray = new bool[15];
	public static string sAllinitials;
	public static string sDateTested;
	public static string Otherinitials;
	public static bool pageControl;

	public bool bIssueVoption;
	public bool bTestExe;
	public bool bScripting;

	public bool tempbb;// = false;

	public bool bisEnabled;
	public bool bOthercon;

	public bool bTestExe1;
	public bool bScripting1;

	public bool bDocRan;

	public static string sTTC;
	public static string sBOOT;
	public static string mytempfilename;
	public static string sMetric1;
	public static string sMetric2;
	public static string sMetric3;
	public static string sMetric4;

	public static string sPrim1;
	public static string sPrim2;
	public static string sPrim3;
	public static string sPrim4;
	public static string sPrim5;
	public static string sPrim6;
	public static string sPrim7;

	public static int primNOCounter;
	public int addCounter;
	public int programControl;
	#endregion

	public MainWindow () : base (Gtk.WindowType.Toplevel){}

	public void main(){
		this.Build();
		onSetUpVar();
		checkWord();


		ReportSectionOne();

	}
		
	public void onSetUpVar(){
		sTTC = "";
		sBOOT = "";

		sMetric1 = "";
		sMetric2 = "";
		sMetric3 = "";
		sMetric4 = "";

		top5ListArray = new string[5];
		top5ListArray[0] = "";
		top5ListArray[1] = "";
		top5ListArray[2] = "";
		top5ListArray[3] = "";
		top5ListArray[4] = "";

		mytempfilename = "";
		sBlockingNumbers = "";
		sBlockingyN = "No";

		Otherinitials = "";
		bisEnabled = false;
		sDateTested = DateTime.Now.ToString("dd/MM/yyyy");

		bTestExe1 = false;
		bTestExe = false;
		bScripting1 = false;
		bScripting = false;

		tempbb = false;

		bDocRan = false;

		for(int x = 0; x < initArray.Length; x++){
			switch(x){
			case 0:
				initArray[x] = "AF";
				InCheck1.Label = initArray[x];
				InCheck1.Active = false;
				break;
			case 1:
				initArray[x] = "BV";
				InCheck2.Label = initArray[x];
				InCheck2.Active = false;
				break;
			case 2:
				initArray[x] = "ELR";
				InCheck3.Label = initArray[x];
				InCheck3.Active = false;
				break;
			case 3:
				initArray[x] = "GH";
				InCheck4.Label = initArray[x];
				InCheck4.Active = false;
				break;
			case 4:
				initArray[x] = "JG";
				InCheck5.Label = initArray[x];
				InCheck5.Active = false;
				break;
			case 5:
				initArray[x] = "KH";
				InCheck6.Label = initArray[x];
				InCheck6.Active = false;
				break;
			case 6:
				initArray[x] = "LHW";
				InCheck7.Label = initArray[x];
				InCheck7.Active = false;
				break;
			case 7:
				initArray[x] = "LW";
				InCheck8.Label = initArray[x];
				InCheck8.Active = false;
				break;
			case 8: 
				initArray[x] = "MG";
				InCheck9.Label = initArray[x];
				InCheck9.Active = false;
				break;
			case 9: 
				initArray[x] = "SA";
				InCheck10.Label = initArray[x];
				InCheck10.Active = false;
				break;
			case 10: 
				initArray[x] = "SS";
				InCheck11.Label = initArray[x];
				InCheck11.Active = false;
				break;
			case 11: 
				initArray[x] = "TG";
				InCheck12.Label = initArray[x];
				InCheck12.Active = false;
				break;
			case 12: 
				initArray[x] = "TY";
				InCheck13.Label = initArray[x];
				InCheck13.Active = false;
				break;
			case 13: 
				initArray[x] = "WT";
				InCheck14.Label = initArray[x];
				InCheck14.Active = false;
				break;
			case 14: 
				initArray[x] = "ZHC";
				InCheck15.Label = initArray[x];
				InCheck15.Active = false;
				break;
			default:
				break;
			}
		}
	}

	//<param> Application closes </param>
	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Application.Quit ();
		a.RetVal = true;
	}

	#region MainEvents

	protected void OnM5H2MainCheck2Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1Check2Toggled();
			break;
		case 2:
			break;
		default:
			break;
		}
	}

	protected void OnM5H2MainCheck1Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1Check1Toggled();
			break;
		case 2:
			break;
		default:
			break;
		}
	}

	protected void OnMainButtonControls1Clicked (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1ButtonControls1Clicked();
			break;
		case 2:
			Level2Button();
			break;
		case 3:
			Level3Button();
			break;
		case 4:
			level4Button();
			break;
		case 5:
			level5Button();
			break;
		case 6:
			Level6Button();
			break;
		case 7:
			if(!bDocRan)
				CreateDoc ();
			else
				restartDoc();
			break;
		default:
			break;
		}
	}

	protected void OnButton1Clicked (object sender, EventArgs e){
		switch (programControl){
		case 1:
			PrimAdd();
			break;
		case 2:
			break;
		default:
			break;
		}
	}

	protected void OnRadiobutton10Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1Toggled10();
			break;
		case 2:
			break;
		case 3:
			break;
		default:
			break;
		}
	}

	protected void OnRadiobutton8Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1Toggled8();
			break;
		case 2:
			break;
		default:
			break;
		}
	}

	protected void OnRadiobutton6Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1Toggled6();
			break;
		case 2:

			break;
		default:
			break;
		}
	}

	protected void OnRadiobutton2Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			break;
		case 3:
			Level3Check2Toggled();
			break;
		default:
			break;
		}
	}

	//ATM Blank
	protected void OnMainButtonControls2Clicked(object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			//level5ButtonControls2Clicked();
			break;
		default:
			break;
		}
	}

	protected void OnM3H2MainCheck1Toggled(object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			Level2Check1Toggled();
			break;
		case 3:
			break;
		default:
			break;
		}
	}

	protected void OnM3H2MainCheck2Toggled(object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			Level2Check2Toggled();
			break;
		case 3:
			break;
		default:
			break;
		}
	}

	protected void OnM3H2MainCheck3Toggled(object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			Level2Check3Toggled();
			break;
		case 3:
			break;
		default:
			break;
		}
	}

	protected void OnMainButtonControls3Clicked (object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			bTestExe1 = bTestExe;
			bScripting1 = bScripting;

			if(Initradiobutton1.Active == false){
				Otherinitials = "";
				bisEnabled = false;
			}else{
				Otherinitials = M1MainEntryField1.Text;
				bisEnabled = true;
			}

			sDateTested = M2MainEntryField1.Text;

			programControl = 1;
			ReportSectionOne();
			backlevel1();
			break;
		case 3:
			if((M1MainTextView1.Buffer.Text != "")&&(radiobutton2.Active)){
				sBlockingyN = "Yes";
				sBlockingNumbers = M1MainTextView1.Buffer.Text;
			}else{
				sBlockingyN = "No";
				sBlockingNumbers = "N/A";
			}

			top5ListArray[0] = M5MainEntryField1.Text;
			top5ListArray[1] = M5MainEntryField2.Text;
			top5ListArray[2] = M5MainEntryField3.Text;
			top5ListArray[3] = M5MainEntryField4.Text;
			top5ListArray[4] = M5MainEntryField5.Text;

			programControl = 2;
			ReportSectionTwo();
			backlevel2();
			break;
		case 4:
			sMetric1 = M5MainEntryField1.Text;
			sMetric2 = M5MainEntryField2.Text;
			sMetric3 = M5MainEntryField3.Text;
			sMetric4 = M5MainEntryField4.Text;


			programControl = 3;
			ReportSectionThree();
			backlevel3();
			break;
		case 5:
			sTTC = M1MainTextView1.Buffer.Text;
			sBOOT =  M2MainTextView1.Buffer.Text;
			programControl = 4;
			ReportSectionFour();
			backlevel4();
			break;
		case 6:
			programControl = 5;
			ReportSectionFive();
			backlevel5();
			break;
		case 7:
			programControl = 5;
			ReportSectionFive();
			backlevel5();
			break;
		default:
			break;
		}
	}

	#region Initials

	protected void OnInCheck1Toggled (object sender, EventArgs e){
		if(InCheck1.Active){
			initEnabledArray[0] = true;
		}
		else{
			initEnabledArray[0] = false;
		}
	}

	protected void OnInCheck2Toggled (object sender, EventArgs e){
		if(InCheck2.Active){
			initEnabledArray[1] = true;
		}
		else{
			initEnabledArray[1] = false;
		}
	}

	protected void OnInCheck3Toggled (object sender, EventArgs e){
		if(InCheck3.Active){
			initEnabledArray[2] = true;
		}
		else{
			initEnabledArray[2] = false;
		}
	}

	protected void OnInCheck4Toggled (object sender, EventArgs e){
		if(InCheck4.Active){
			initEnabledArray[3] = true;
		}
		else{
			initEnabledArray[3] = false;
		}
	}

	protected void OnInCheck5Toggled (object sender, EventArgs e){
		if(InCheck5.Active){
			initEnabledArray[4] = true;
		}
		else{
			initEnabledArray[4] = false;
		}
	}

	protected void OnInCheck6Toggled (object sender, EventArgs e){
		if(InCheck6.Active){
			initEnabledArray[5] = true;
		}
		else{
			initEnabledArray[5] = false;
		}
	}

	protected void OnInCheck7Toggled (object sender, EventArgs e){
		if(InCheck7.Active){
			initEnabledArray[6] = true;
		}
		else{
			initEnabledArray[6] = false;
		}
	}

	protected void OnInCheck8Toggled (object sender, EventArgs e){
		if(InCheck8.Active){
			initEnabledArray[7] = true;
		}
		else{
			initEnabledArray[7] = false;
		}
	}

	protected void OnInCheck9Toggled (object sender, EventArgs e){
		if(InCheck9.Active){
			initEnabledArray[8] = true;
		}
		else{
			initEnabledArray[8] = false;
		}
	}

	protected void OnInCheck10Toggled (object sender, EventArgs e){
		if(InCheck10.Active){
			initEnabledArray[9] = true;
		}
		else{
			initEnabledArray[9] = false;
		}
	}

	protected void OnInCheck11Toggled (object sender, EventArgs e){
		if(InCheck11.Active){
			initEnabledArray[10] = true;
		}
		else{
			initEnabledArray[10] = false;
		}
	}

	protected void OnInCheck12Toggled (object sender, EventArgs e){
		if(InCheck12.Active){
			initEnabledArray[11] = true;
		}
		else{
			initEnabledArray[11] = false;
		}
	}

	protected void OnInCheck13Toggled (object sender, EventArgs e){
		if(InCheck13.Active){
			initEnabledArray[12] = true;
		}
		else{
			initEnabledArray[12] = false;
		}
	} 

	protected void OnInCheck14Toggled (object sender, EventArgs e){
		if(InCheck14.Active){
			initEnabledArray[13] = true;
		}
		else{
			initEnabledArray[13] = false;
		}
	}

	protected void OnInCheck15Toggled (object sender, EventArgs e){
		if(InCheck15.Active){
			initEnabledArray[14] = true;
		}
		else{
			initEnabledArray[14] = false;
		}
	} 

	#endregion 

	#region ensection

	protected void OnInitradiobutton1Toggled (object sender, EventArgs e){
			switch (programControl){
			case 1:
				break;
			case 2:
				InCheck15Toggled();
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			default:
				break;
			}
	}

	protected void OnButton8Clicked (object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			level5Toggled8();
			break;
		case 6:
			break;
		case 7:
			FilePickerClicked();
			break;
		default:
			break;
		}
	}

	protected void OnButton10Clicked (object sender, EventArgs e){
		switch (programControl){
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			level5Toggled10();
			break;
		case 6:
			break;

		default:
			break;
		}
	}

	#endregion

	#endregion
}



