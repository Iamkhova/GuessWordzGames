using UnityEngine;
using System.Collections;

public class leftArrowPressed : MonoBehaviour {

	private void OnMouseDown()
	{
		GameObject test;
		test = GameObject.Find ("ScrollBlockController");
		test.gameObject.GetComponent<ScrollBlockController> ().scrollLeft ();
		Debug.Log ("Left arrow pressed");
		
	}

}
