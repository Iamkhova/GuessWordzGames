using UnityEngine;
using System.Collections;

public class sbBlockPressed : MonoBehaviour {

	private void OnMouseDown()
	{
		int value;
		GameObject test;

		if (this.gameObject.GetComponent<letterBlockOBJController> ().currentState == letterBlockOBJController.blockState.Active) {
						this.gameObject.GetComponent<letterBlockOBJController> ().toggleState ();
						value = this.gameObject.GetComponent<letterBlockOBJController> ().getValue ();
						test = GameObject.Find ("GameBoardController");
						test.gameObject.GetComponent<GameController> ().processLetterSelected (value);
						Debug.Log ("Keyboard block value:" + value + " pressed.");
				} else {
						Debug.Log ("Keyboard block value ALREADY pressed once.");
				}
	}
}
