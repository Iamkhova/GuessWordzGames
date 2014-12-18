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

	public enum blockState
	{
		Inactive, Active

	}

	public blockState currentState;
	public blockState newState;

	// Use this for initialization
	void Start () {
		currentState = blockState.Active;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void toggleState()
	{
		// TODO Apply Shaders Code to Tint Texture to Grayscale

		if (currentState == blockState.Active) {
			transform.renderer.material.color = Color.black;
			currentState = blockState.Inactive;
		}
	
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
