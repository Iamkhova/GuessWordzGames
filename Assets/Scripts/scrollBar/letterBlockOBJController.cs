using UnityEngine;
using System.Collections;

public class letterBlockOBJController : MonoBehaviour {
	
	// Set Key values for Letter Block
	public int value;
	public bool blockActive = false;
	public bool onFocus = false;
	public Sprite activeGraphic;
	public float posX;
	public float posY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setValue(int theValue)
	{
		value = theValue;
	}

	public int getValue()
	{
		return value;
	}

	public void setActiveGraphic(Sprite theGraphic)
	{
		activeGraphic = theGraphic;
		//trigger picture update
		gameObject.GetComponent<SpriteRenderer>().sprite = activeGraphic;

		}
}
