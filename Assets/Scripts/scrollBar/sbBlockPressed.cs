using UnityEngine;
using System.Collections;

public class sbBlockPressed : MonoBehaviour {

	private void OnMouseDown()
	{
		int value;
		GameObject test;

		this.gameObject.GetComponent<letterBlockOBJController> ().toggleState ();
		value = this.gameObject.GetComponent<letterBlockOBJController> ().getValue ();
		test = GameObject.Find ("GameBoardController");
		test.gameObject.GetComponent<GameController> ().processLetterSelected (value);
		
		
		Debug.Log ("Keyboard block value:" + value + " pressed.");
		
	}
}
