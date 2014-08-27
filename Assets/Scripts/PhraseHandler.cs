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

	/*
      * convertPhrase Handles the converting of phrase into game data. 
      * This takes the string and breaks it into separate rows.  The loop 
      * takes the word and assign it to corresponding row line depending 
      * on the number of free letter spaces available.
      */
	public PhraseData convertPhrase(string phrase, string hint, string title)
	{
		// Pull data from attached componets
		GameObject gameBoardController = GameObject.Find("GameBoardController");
		GameController gameController = gameBoardController.GetComponent<GameController>();

		//Variables
		PhraseData tempPhrase = new PhraseData ();
		string space, tempword;
		string[] line = new string[gameController.maxNumColumns];

		Debug.Log("received Phrase: " + phrase);
		Debug.Log("Phrase Length: " + phrase.Length.ToString());

		//Initalize Variables
		int wordcount = 0;
		int linecount = 0;
		string[] words = phrase.Split(' '); // split string into word array
		for (int i = 0; i < gameController.maxNumColumns; i++) 
		{
			line[i] = "";
		}
		space = "";
		tempword = "";

		// Start Phrase Splitting Loop

		foreach (string word in words) 
		{
			for (int cycle = 0; cycle < gameController.maxNumColumns; cycle++)
			{
				if (linecount == cycle)
				{
					if (line[cycle].Length <= gameController.maxNumRows)
					{
						if (line[cycle].Length > 0){space = " ";}
						tempword = line[cycle];
						tempword += space + "" + word;

						if (tempword.Length < gameController.maxNumRows)
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