using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

public partial class MainWindow: Gtk.Window{

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
	public string[] initArray = new string[14];
	public bool[] initEnabledArray = new bool[14];
	public static string sAllinitials;
	public static string sDateTested;
	public bool bIssueVoption;
	public bool bTestExe;
	public bool bScripting;
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

	//<param> Application start </param>
	public MainWindow () : base (Gtk.WindowType.Toplevel){}

	public void main(){
		this.Build();
		ReportSectionOne();
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
			//Console.Writeline("asd");
			break;
		default:
			break;
		}
	}//

	protected void OnM5H2MainCheck1Toggled (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1Check1Toggled();
			break;
		case 2:
			//Console.Writeline("asd");
			break;
		default:
			break;
		}
	}//

	protected void OnMainButtonControls1Clicked (object sender, EventArgs e){
		switch (programControl){
		case 1:
			Level1ButtonControls1Clicked();
			break;
		case 2:
			Level2Button();
			////Console.Writeline("asd");
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
			CreateDoc ();
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
			//Console.Writeline("asd");
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
			//Console.Writeline("asd");
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

	//ATM Blank   
	protected void OnRadiobutton4Toggled (object sender, EventArgs e){
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
			programControl = 1;
			ReportSectionOne();
			backlevel1();
			break;
		case 3:
			programControl = 2;
			ReportSectionTwo();
			break;
		case 4:
			programControl = 3;
			ReportSectionThree();
			break;
		case 5:
			programControl = 4;
			ReportSectionFour();
			break;
		case 6:
			programControl = 5;
			ReportSectionFive();
			break;
		case 7:
			//programControl = 6;
			//ReportSectionSix();
			programControl = 5;
			ReportSectionFive();
			break;
		default:
			break;
		}
	}


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
}



