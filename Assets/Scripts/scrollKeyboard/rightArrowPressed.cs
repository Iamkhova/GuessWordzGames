using UnityEngine;
using System.Collections;

public class rightArrowPressed : MonoBehaviour {


	private void OnMouseDown()
	{
		 GameObject test;
		test = GameObject.Find ("ScrollBlockController");
		test.gameObject.GetComponent<ScrollBlockController> ().scrollRight ();
		Debug.Log ("Right arrow pressed");

	}
}
