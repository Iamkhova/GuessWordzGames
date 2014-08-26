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

	public PhraseData convertPhrase(string phrase, string hint, string title)
	{
		PhraseData tempPhrase = new PhraseData ();
		string line1, line2, line3, line4, space, tempword;

		Debug.Log("received Phrase: " + phrase);

		int wordcount = 0;
		string[] words = phrase.Split(' '); // split string into word array

		GameObject gameBoardController = GameObject.Find("GameBoardController");
		GameController gameController = gameBoardController.GetComponent<GameController>();


		//Initalize Variables
		line1 = "";
		line2 = "";
		line3 = "";
		line4 = "";
		space = "";
		tempword = "";

		//Start Word Splitting Loop
		int linecount = 1;

		//foreach (string s in arr)
		foreach (string word in words) 
		{
			if (linecount == 1)
			{
				if (line1.Length <= gameController.maxNumRows)
				{
					if (line1.Length > 0) { space = " "; }
					tempword = line1;
					tempword += space + "" + word;

					if (tempword.Length < gameController.maxNumRows)
					{
						line1 += space + "" + word;
					}
					else{
						linecount = 2;
						space = "";
					}//end if/else
				}// end if
			}// end if

			Debug.Log("word cycle 1" + word);

			if (linecount == 2)
			{
				if (line1.Length <= gameController.maxNumRows)
				{
					if (line2.Length > 0) { space = " ";}
					tempword = line2;
					tempword += space + "" + word;

					if (tempword.Length < gameController.maxNumRows)
					{
						line2 += space + "" + word;
					}// endif
					else
					{
						linecount = 3;
						space = "";
					}// endif/else
				}// end if	
			}// end if

			if (linecount == 3)
			{
				if (line3.Length <= gameController.maxNumRows)
				{
					if (line1.Length > 0) {space = " "; }
					tempword = line3;
					tempword += space + " " + word;

					if (tempword.Length < gameController.maxNumRows)
					{
						line3 += space + " " + word;
					}
					else{
						linecount = 4;
						space = "";
					}//endifelse
				}//endif
			}// endif

			if (linecount == 4)
			{
				if (line1.Length <= gameController.maxNumRows)
				{
					if (line4.Length > 0) { space = " "; }
					tempword = line4;
					tempword += space + " " + word;

					if (tempword.Length < gameController.maxNumRows)
					{
						line4 += space + " " + word;
					}else{
						linecount = 5;
					}
				}
			}

			wordcount += 1;
		}// end foreach

		tempPhrase.hint = hint;
		tempPhrase.title = title;
		tempPhrase.line1 = line1;
		tempPhrase.line2 = line2;
		tempPhrase.line3 = line3;
		tempPhrase.line4 = line4;

		Debug.Log("Line1: " + line1);
		Debug.Log("Line2" + line2);
		Debug.Log("Line3" + line3);
		Debug.Log("Line4" + line4);

		return tempPhrase;

	}//end function convertPhrase


}