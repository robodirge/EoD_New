using System;
using System.IO;
using System.Text.RegularExpressions;
using Gtk;

using NetOffice;
using Word = NetOffice.WordApi;
using NetOffice.WordApi.Enums;
using System.Reflection;

namespace EoD
{
	public partial class Level5Dialog : Gtk.Dialog
	{
		static string sToSpellCheck;

		Gtk.ListStore tsSpellingError;
		Gtk.ListStore tsSpellingCorrection;

		Gtk.TreeViewColumn tvcError;
		Gtk.TreeViewColumn tvcCorrection;
		
		Gtk.CellRendererText crtError;
		Gtk.CellRendererText crtCorrection;

		Word.Application app;
		Word.ProofreadingErrors spellErrorsColl;

		Word._Document doc1;

		public Level5Dialog (ref string sTempText)//sTempText)
		{
			sToSpellCheck = sTempText;

			this.Build();
			textview1.Buffer.Text = sToSpellCheck;

			InitSetUp();
			CheckSpelling();
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a){
			//if (sToSpellCheck != ""){
			//	app.Documents.Close(WdSaveOptions.wdDoNotSaveChanges);
			//	app.Quit();
			//}
		}

		public void AppQuit(){
			if (sToSpellCheck != ""){
				app.Documents.Close(WdSaveOptions.wdDoNotSaveChanges);
				app.Quit();

			}
		}

		public string getText(){
			return textview1.Buffer.Text;
		}

		public void InitSetUp(){
			tvcError = new Gtk.TreeViewColumn();
			tvcError.Title = "Error";

			tvcCorrection = new Gtk.TreeViewColumn();
			tvcCorrection.Title = "Correction";

			treeViewError1.AppendColumn(tvcError);
			treeViewCorrection1.AppendColumn(tvcCorrection);

			crtError = new Gtk.CellRendererText();
			crtCorrection = new Gtk.CellRendererText();

			tvcError.PackStart(crtError, true);
			tvcCorrection.PackStart(crtCorrection, true);

			tvcError.AddAttribute(crtError, "text", 0);
			tvcCorrection.AddAttribute(crtCorrection, "text", 0);

			tsSpellingError = new Gtk.ListStore(typeof (string), typeof (int), typeof (int), typeof (int));
			tsSpellingCorrection = new Gtk.ListStore(typeof (string));

			treeViewError1.Model = tsSpellingError;
			treeViewCorrection1.Model = tsSpellingCorrection;

			app = new Word.Application();
			app.DisplayAlerts = WdAlertLevel.wdAlertsNone;

			object template = Missing.Value;
			object newTemplate = Missing.Value;
			object documentType = Missing.Value;
			object visible = true;
			app.Visible = false;
			doc1 = app.Documents.Add(template, newTemplate, documentType, visible);
		}

		public void CheckSpelling(){
			int errors = 0;
			tsSpellingCorrection.Clear();
			tsSpellingError.Clear();

			if (sToSpellCheck == ""){
				Console.WriteLine("no content");
				button23.Sensitive = false;
			}
			else{

				Word.Range rng;
				object first = 0;
				object last = doc1.Characters.Count - 1;
				rng = doc1.Range(first, last);
				rng.Select();
				rng.Text = "";


				doc1.Words.First.InsertBefore(textview1.Buffer.Text);

				doc1.Content.LanguageID = WdLanguageID.wdEnglishUK;

				spellErrorsColl = doc1.SpellingErrors;
				errors = spellErrorsColl.Count;

				object optional = Missing.Value;

				button23.Sensitive = true;

				Word.SpellingSuggestions correctionSpelling;

				if(errors > 0){
					for(int p = 1; p <= spellErrorsColl.Count; p++){

						correctionSpelling = app.GetSpellingSuggestions(spellErrorsColl[p].Text);
						tsSpellingError.AppendValues(spellErrorsColl[p].Text, p, spellErrorsColl[p].Start, spellErrorsColl[p].End);
					}
				}

				//doc1.CheckSpelling(
				//	optional, optional, optional, optional, optional, optional,
				//	optional, optional, optional, optional, optional, optional);

				label1.Text = errors + " Errors";
				//object first = 0;
				//object last = doc1.Characters.Count - 1;
				//M2MainTextView1.Buffer.Text = doc1.Range(first, last).Text;
				//textBox1.Text = doc1.Range(ref first, ref last).Text;
			}
		}
		
		protected void OnTreeViewError1CursorChanged (object sender, EventArgs e){
			tsSpellingCorrection.Clear();

			TreeSelection selection = (sender as TreeView).Selection;
			TreeModel model;
			TreeIter iter;
			int ibob = 0;
			Word.SpellingSuggestions correctionSpelling;

			if(selection.GetSelected(out model, out iter)){
				//Console.WriteLine("Selected item: " + model.GetValue(iter, 0).ToString() + " - " + model.GetValue(iter, 1).ToString());

				ibob = Convert.ToInt32(model.GetValue(iter, 1).ToString());

				correctionSpelling = app.GetSpellingSuggestions(spellErrorsColl[ibob].Text);
				//Console.WriteLine(spellErrorsColl[0].Text + " 0");
				if(correctionSpelling.Count > 1){
					for(int x = 1; x <= correctionSpelling.Count; x++){
						tsSpellingCorrection.AppendValues(correctionSpelling[x].Name);
					} 
				}else{
					tsSpellingCorrection.AppendValues("No correction");
				}
			}	                       
		}


		protected void OnTreeViewCorrection1CursorChanged (object sender, EventArgs e){
			TreeSelection selection = treeViewCorrection1.Selection;
			TreeModel model;
			TreeIter iter;

			if(selection.GetSelected(out model, out iter)){
				string sGetText = model.GetValue(iter, 0).ToString();
				if(sGetText == "No correction"){
					button8.Sensitive = false;
				}else{
					button8.Sensitive = true;
				}

			}
		}

		protected void OnButton8Clicked (object sender, EventArgs e){
			TreeSelection selection2 = treeViewCorrection1.Selection;//(sender as TreeView).Selection;
			TreeModel model2;
			TreeIter iter2;

			TreeSelection selection1 = treeViewError1.Selection;//(sender as TreeView).Selection;
			TreeModel model1;
			TreeIter iter1;

			int ibob;
			object first = 0;
			object last = 0;
			if(selection1.GetSelected(out model1, out iter1)){
				ibob = Convert.ToInt32(model1.GetValue(iter1, 1).ToString());
				Console.WriteLine("Tree one : " + ibob);
				first = Convert.ToInt32(model1.GetValue(iter1, 2).ToString());
				last = Convert.ToInt32(model1.GetValue(iter1, 3).ToString());
			}

			if(selection2.GetSelected(out model2, out iter2)){
				//Console.WriteLine("Selected item: " + model.GetValue(iter, 0).ToString());
				//spellErrorsColl[ibob].Text = model2.GetValue(iter2, 0).ToString();

				//object first = 0;
				//object last = doc1.Characters.Count - 1;
				Word.Range rng;
				rng = doc1.Range(first, last);
				rng.Select();
				rng.Text = model2.GetValue(iter2, 0).ToString();

				first = 0;
				last = doc1.Characters.Count - 1;
				textview1.Buffer.Text = doc1.Range(first, last).Text;

				tsSpellingError.Remove(ref iter1);
				tsSpellingError.Clear();
				tsSpellingCorrection.Clear();
				button8.Sensitive = false;

				sToSpellCheck = textview1.Buffer.Text;
				CheckSpelling();
								/*
				doc1.Range(first, last).Text = "";  ///errrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrorrrrrrrrrrrrrrrrr
				int ilength = model2.GetValue(iter2, 0).ToString().Length;

				last = ilength;
				doc1.Range(first, last).Text = model2.GetValue(iter2, 0).ToString();
				//doc1.Range(first, first).Text = model2.GetValue(iter2, 0).ToString();

				first = 0;
				last = doc1.Characters.Count - 1;
				textview1.Buffer.Text = "";
				textview1.Buffer.Text = doc1.Range(first, last).Text;
				*/
			}

		}

		protected void OnButton23Clicked (object sender, EventArgs e){
			/*
			if (sToSpellCheck != ""){
				app.Documents.Close(WdSaveOptions.wdDoNotSaveChanges);
				app.Quit();
			}
			//DeleteEventArgs a = e;
			OnDeleteEvent(sender, null);
			*/
		}

		protected void CheckSpelling (object sender, EventArgs e)
		{
			CheckSpelling();

		}
	}
}

