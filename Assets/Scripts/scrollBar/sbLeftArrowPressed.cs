using UnityEngine;
using System.Collections;

public class sbLeftArrowPressed : MonoBehaviour {

	private void OnMouseDown()
	{
		GameObject test;
		test = GameObject.Find ("ScrollBlockController");
		test.gameObject.GetComponent<scrollBarController> ().sbScrollLeft ();
		Debug.Log ("Left arrow pressed");
		
	}
}
