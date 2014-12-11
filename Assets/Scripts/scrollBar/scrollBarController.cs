using UnityEngine;
using System.Collections;

public class scrollBarController : MonoBehaviour {

	GameObject[] letterBlock = new GameObject[26];
	GameObject scrollBlock;


	public Sprite[] scrollLetterSprite = new Sprite[26];
	public float scrollBlockPosX = 0;
	public float scrollBlockPosY = 0;
	public int keyBlockHeight = 25;
	public int keyBlockWidth = 25;
	public int sbStartValue = 0;


	const int LEFTARROW = 0;
	const int RIGHTARROW = 1;
	
	const int VALUE_A = 0; const int VALUE_B = 1; const int VALUE_C = 2; const int VALUE_D = 3; const int VALUE_E = 4; const int VALUE_F = 5; const int VALUE_G = 6; 
	const int VALUE_H = 7; const int VALUE_I = 8; const int VALUE_J = 9; const int VALUE_K = 10; const int VALUE_L = 11; const int VALUE_M = 12; const int VALUE_N = 13; 
	const int VALUE_O = 14; const int VALUE_P = 15; const int VALUE_Q = 16; const int VALUE_R = 17; const int VALUE_S = 18; const int VALUE_T = 19; const int VALUE_U = 20; 
	const int VALUE_V = 21; const int VALUE_W = 22; const int VALUE_X = 23; const int VALUE_Y = 24; const int VALUE_Z = 25; 

	// Use this for initialization
	void Start () {
	
		initLetterBlocks ();
		initScrollBlock ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void initLetterBlocks()
	{

		for (int i = 0; i <= 25; i++) 
		{
			//spawn Object
			letterBlock[i] = new GameObject ("LetterBlock" + i + "");
			//Add Components
			letterBlock[i].AddComponent<letterBlockOBJController> ();
			letterBlock[i].AddComponent<SpriteRenderer> ();
			letterBlock[i].AddComponent<BoxCollider2D> ();
			letterBlock[i].AddComponent<sbBlockPressed> ();
			//Set up Defaults
			letterBlock[i].transform.position = new Vector3(-12,5,0); // set up off camera
			letterBlock[i].transform.localScale = new Vector3(5,5,1);
			letterBlock[i].GetComponent<letterBlockOBJController>().setValue(i);
			letterBlock[i].GetComponent<letterBlockOBJController>().setActiveGraphic(getBlockSprite (i));
			letterBlock[i].GetComponent<BoxCollider2D>().size = new Vector3(0.25f,0.25f,0);

		}//end for loop

	}// end initLetterBlocks

	public void initScrollBlock()
	{
		scrollBlock = new GameObject ("ScrollBlock");
		scrollBlock.AddComponent<scrollBarObjController> ();
		scrollBlock.GetComponent<scrollBarObjController> ().setPosition (scrollBlockPosX, scrollBlockPosY, keyBlockWidth, sbStartValue);

	}

	public void sbScrollLeft()
	{
		int tempValue = sbStartValue;
		tempValue++;
		sbStartValue = letterRangeCheck (tempValue);
		updateScrollBlockPosition (sbStartValue);

	}

	public void sbScrollRight()
	{
		int tempValue = sbStartValue;
		tempValue--;
		sbStartValue = letterRangeCheck (tempValue);
		updateScrollBlockPosition (sbStartValue);
		
	}
	

	private void updateScrollBlockPosition (int _startValue)
	{
		GameObject sbObj;

		sbObj = GameObject.Find ("ScrollBlock");
		sbObj.gameObject.GetComponent<scrollBarObjController> ().updatePosition (_startValue);

	}

	private int letterRangeCheck(int _value)
	{
		int theValue = _value;

		// Check if over
		if (theValue > 25) 
		{
			theValue = 0;
			
		}
		
		//Check if Under
		if (theValue < 0) 
		{
			theValue = 25;
		}

		
		
		return theValue;


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
