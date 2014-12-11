using UnityEngine;
using System.Collections;

public class sbRightArrowPressed : MonoBehaviour {

	private void OnMouseDown()
	{
		GameObject test;
		test = GameObject.Find ("ScrollBlockController");
		test.gameObject.GetComponent<scrollBarController> ().sbScrollRight ();
		Debug.Log ("Right arrow pressed");
		
	}
}
