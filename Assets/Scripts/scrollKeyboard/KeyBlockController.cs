using UnityEngine;
using System.Collections;

public class KeyBlockController : MonoBehaviour {

	// Set Key values for Letter Block
	public bool isActive = false;
	public bool isSelectable = false;
	public int value;
	public int oldValue;
	public Sprite[] scrollLetterSprite = new Sprite[26];
	public Sprite activeGraphic; 

	const int VALUE_A = 0; const int VALUE_B = 1; const int VALUE_C = 2; const int VALUE_D = 3; const int VALUE_E = 4; const int VALUE_F = 5; const int VALUE_G = 6; 
	const int VALUE_H = 7; const int VALUE_I = 8; const int VALUE_J = 9; const int VALUE_K = 10; const int VALUE_L = 11; const int VALUE_M = 12; const int VALUE_N = 13; 
	const int VALUE_O = 14; const int VALUE_P = 15; const int VALUE_Q = 16; const int VALUE_R = 17; const int VALUE_S = 18; const int VALUE_T = 19; const int VALUE_U = 20; 
	const int VALUE_V = 21; const int VALUE_W = 22; const int VALUE_X = 23; const int VALUE_Y = 24; const int VALUE_Z = 25; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getValue()
	{
		return value;
	}

	public void setValue(int theValue)
	{
		int tempValue = theValue;

		// Check if over
		if (tempValue > VALUE_Z) 
		{
			tempValue = VALUE_A;

				}

		//Check if Under
		if (tempValue < VALUE_A) 
		{
			tempValue = VALUE_Z;
				}

		oldValue = value;
		value = tempValue;
		activeGraphic = getBlockSprite (value);

		//trigger picture update
		gameObject.GetComponent<SpriteRenderer>().sprite = activeGraphic;
	}

	public void swipeRight()
	{
		int tempValue;
		tempValue = value + 1;
		setValue (tempValue);

	}

	public void swipeLeft()
	{
		int tempValue;
		tempValue = value - 1;
		setValue (tempValue);
		
	}


	// Find Sprite that matches block
	private Sprite getBlockSprite (int letter)
	{
		Sprite value;
		switch (letter) 
		{
		case VALUE_A :
			value = scrollLetterSprite[0];
			break;
		case VALUE_B :
			value = scrollLetterSprite[1];
			break;
		case VALUE_C :
			value = scrollLetterSprite[2];
			break;
		case VALUE_D :
			value = scrollLetterSprite[3];
			break;
		case VALUE_E :
			value = scrollLetterSprite[4];
			break;
		case VALUE_F :
			value = scrollLetterSprite[5];
			break;
		case VALUE_G :
			value = scrollLetterSprite[6];
			break;
		case VALUE_H :
			value = scrollLetterSprite[7];
			break;
		case VALUE_I :
			value = scrollLetterSprite[8];
			break;
		case VALUE_J :
			value = scrollLetterSprite[9];
			break;
		case VALUE_K :
			value = scrollLetterSprite[10];
			break;
		case VALUE_L :
			value = scrollLetterSprite[11];
			break;
		case VALUE_M :
			value = scrollLetterSprite[12];
			break;
		case VALUE_N :
			value = scrollLetterSprite[13];
			break;
		case VALUE_O :
			value = scrollLetterSprite[14];
			break;
		case VALUE_P :
			value = scrollLetterSprite[15];
			break;
		case VALUE_Q :
			value = scrollLetterSprite[16];
			break;
		case VALUE_R :
			value = scrollLetterSprite[17];
			break;
		case VALUE_S :
			value = scrollLetterSprite[18];
			break;
		case VALUE_T :
			value = scrollLetterSprite[19];
			break;
		case VALUE_U :
			value = scrollLetterSprite[20];
			break;
		case VALUE_V :
			value = scrollLetterSprite[21];
			break;
		case VALUE_W :
			value = scrollLetterSprite[22];
			break;
		case VALUE_X :
			value = scrollLetterSprite[23];
			break;
		case VALUE_Y :
			value = scrollLetterSprite[24];
			break;
		case VALUE_Z :
			value = scrollLetterSprite[25];
			break;
		default:
			value = scrollLetterSprite[0];
			break;
			
		}
		
		return value;
	}


}
