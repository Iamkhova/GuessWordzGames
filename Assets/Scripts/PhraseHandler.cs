using UnityEngine;
using System.Collections;

public class PhraseHandler : MonoBehaviour {

	public class PhraseData
	{
		public string title;
		public string line1;
		public string line2;
		public string line3;
		public string line4;
		public string hint;

	}//end PhraseData Class

	//Get Max Length of Scoreboard Row
	private int getMaxRowLength()
	{
		// Pull data from attached componets
		GameObject gameBoardController = GameObject.Find("GameBoardController");
		GameController gameController = gameBoardController.GetComponent<GameController>();

		int max;
		// Pull data from attached componets

		max = gameController.maxNumRows;

		return max;

	}

	//Get Max Column Length of Scoreboard
	private int getMaxColLength()
	{
		// Pull data from attached componets
		GameObject gameBoardController = GameObject.Find("GameBoardController");
		GameController gameController = gameBoardController.GetComponent<GameController>();

		int max;
		// Pull data from attached componets
		
		max = gameController.maxNumColumns;
		
		return max;
		
	}

	//Center the Phrase for the board
	string centerPhrase(string phraseline)
	{

		int padding;
		string phrase = phraseline;

		padding = (getMaxRowLength () - phrase.Length) / 2;

		System.Text.StringBuilder sb = new System.Text.StringBuilder ();
		sb.Append (" ".PadLeft (padding));
		sb.Append (phrase);
		sb.Append (" ".PadRight (padding));
		phrase = sb.ToString ();

		Debug.Log ("Padding: " + padding);
		Debug.Log ("Center Phrase: *" + phrase + "*");
		Debug.Log ("Phrase Length: " + phrase.Length.ToString ());

		return phrase;


	}

	public PhraseData getNewPhrase()
	{
		//TODO Ideally this will load from XML file or from WEB API
		PhraseData newPhrase = new PhraseData ();

		string title = " Andriod App Developer";
		string phrase = "Kareem Jamaal Glover like candy apples";
		string hint ="Married to Carmen Neal";

		// Convert phrase into game format
		newPhrase = convertPhrase (phrase, hint, title);

		//Center phrase line
		//TODO This needs to be changed into a array of line
		newPhrase.line1 = centerPhrase (newPhrase.line1);
		newPhrase.line2 = centerPhrase (newPhrase.line2);
		newPhrase.line3 = centerPhrase (newPhrase.line3);
		newPhrase.line4 = centerPhrase (newPhrase.line4);


		Debug.Log ("Center Phrase Line 1:" + newPhrase.line1);
		Debug.Log ("Center Phrase Line 2:" + newPhrase.line2);
		Debug.Log ("Center Phrase Line 3:" + newPhrase.line3);
		Debug.Log ("Center Phrase Line 4:" + newPhrase.line4);


		return newPhrase;
	}

	/*
      * convertPhrase Handles the converting of phrase into game data. 
      * This takes the string and breaks it into separate rows.  The loop 
      * takes the word and assign it to corresponding row line depending 
      * on the number of free letter spaces available.
      */
	PhraseData convertPhrase(string phrase, string hint, string title)
	{
		//Variables
		int maxRowLength = getMaxRowLength();
		int maxColLength = getMaxColLength();

		PhraseData tempPhrase = new PhraseData ();
		string space, tempword;
		string[] line = new string[maxRowLength];

		Debug.Log("received Phrase: " + phrase);
		Debug.Log("Phrase Length: " + phrase.Length.ToString());

		//Initalize Variables
		int wordcount = 0;
		int linecount = 0;
		string[] words = phrase.Split(' '); // split string into word array
		for (int i = 0; i < maxColLength; i++) 
		{
			line[i] = "";
		}
		space = "";
		tempword = "";

		// Start Phrase Splitting Loop

		foreach (string word in words) 
		{
			for (int cycle = 0; cycle < maxColLength; cycle++)
			{
				if (linecount == cycle)
				{
					if (line[cycle].Length < maxRowLength)
					{
						if (line[cycle].Length > 0){space = " ";}
						tempword = line[cycle];
						tempword += space + "" + word;

						if (tempword.Length < maxRowLength)
						{
							line[cycle] += space + "" + word;
						}else{
							linecount = cycle + 1;
							space = "";
						}
					}
				}

			}// end for loop

			wordcount += 1;
		}// end foreach

		tempPhrase.hint = hint;
		tempPhrase.title = title;
		tempPhrase.line1 = line[0];
		tempPhrase.line2 = line[1];
		tempPhrase.line3 = line[2];
		tempPhrase.line4 = line[3];

		Debug.Log("Line1: " + line[0] + line[0].Length.ToString());
		Debug.Log("Line2: " + line[1] + line[1].Length.ToString());
		Debug.Log("Line3: " + line[2] + line[2].Length.ToString());
		Debug.Log("Line4: " + line[3] + line[3].Length.ToString());

		return tempPhrase;

	}//end function convertPhrase


}