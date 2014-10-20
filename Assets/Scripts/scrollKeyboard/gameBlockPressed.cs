using UnityEngine;
using System.Collections;

public class gameBlockPressed : MonoBehaviour {

	private void OnMouseDown()
	{
		int value;
		GameObject test;

		value = this.gameObject.GetComponent<KeyBlockController> ().getValue ();
		test = GameObject.Find ("GameBoardController");
		test.gameObject.GetComponent<GameController> ().processLetterSelected (value);


		Debug.Log ("Keyboard block value:" + value + " pressed.");
		
	}
}
