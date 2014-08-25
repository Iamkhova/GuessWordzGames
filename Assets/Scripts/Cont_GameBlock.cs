using UnityEngine;
using System.Collections;

public class Cont_GameBlock : MonoBehaviour 
{
	// Exposed Variables
	public Sprite defaultGraphic;
	public Sprite activeGraphic;
	public string blockStringValue;

	public enum GameBlockState
	{
		Inactive,
		ActiveHidden,
		ActiveExposed
	}

	public GameBlockState currentState;
	public GameBlockState newState;

	// Use this for initialization
	void Start () {
	
		currentState = GameBlockState.Inactive;
	}
	
	// Update is called once per frame
	void Update () {

		if (currentState != GameBlockState.ActiveHidden && newState == GameBlockState.ActiveHidden) 
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = activeGraphic;
			currentState = newState;

		}

		if (currentState != GameBlockState.Inactive && newState == GameBlockState.Inactive) 
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = defaultGraphic;
			currentState = newState;
				
		}
	
	}


}
