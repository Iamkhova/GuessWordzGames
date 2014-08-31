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
	public string centerPhrase(string phraseline)
	{

		int padding;
		string phrase = phraseline;

		padding = (getMaxRowLength() - phrase.Length) / 2;

		System.Text.StringBuilder sb = new System.Text.StringBuilder ();
		sb.Append ("".PadLeft (padding));
		sb.Append (phrase);
		sb.Append ("".PadRight (padding));
		phrase = sb.ToString ();

		Debug.Log ("Padding: " + padding);
		Debug.Log("Center Phrase: *" + phrase + "*");
		Debug.Log("Phrase Length: " + phrase.Length.ToString());

		return phrase;

	}

	/*
      * convertPhrase Handles the converting of phrase into game data. 
      * This takes the string and breaks it into separate rows.  The loop 
      * takes the word and assign it to corresponding row line depending 
      * on the number of free letter spaces available.
      */
	public PhraseData convertPhrase(string phrase, string hint, string title)
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
			for (int cycle = 0; cycle < maxRowLength; cycle++)
			{
				if (linecount == cycle)
				{
					if (line[cycle].Length <= maxRowLength)
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

		Debug.Log("Line1: " + line[0]);
		Debug.Log("Line2: " + line[1]);
		Debug.Log("Line3: " + line[2]);
		Debug.Log("Line4: " + line[3]);

		return tempPhrase;

	}//end function convertPhrase


}