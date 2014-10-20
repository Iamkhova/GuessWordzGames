using UnityEngine;
using System.Collections;

public class GameBlockController : MonoBehaviour {
	// Exposed Variables
	public Sprite defaultGraphic;
	public Sprite activeGraphic; 
	public Sprite exposedGraphic;
	public Sprite[] letterSprite = new Sprite[26];
	public Sprite commaSprite, dashSprite, slashSprite, aposSprite;
	public string blockValue;
	public char blockStringValue;
	public int blockID;

	const char LETTER_A = 'A'; const char LETTER_B = 'B'; const char LETTER_C = 'C'; const char LETTER_D = 'D';
	const char LETTER_E = 'E'; const char LETTER_F = 'F'; const char LETTER_G = 'G'; const char LETTER_H = 'H';
	const char LETTER_I = 'I'; const char LETTER_J = 'J'; const char LETTER_K = 'K'; const char LETTER_L = 'L';
	const char LETTER_M = 'M'; const char LETTER_N = 'N'; const char LETTER_O = 'O'; const char LETTER_P = 'P';
	const char LETTER_Q = 'Q'; const char LETTER_R = 'R'; const char LETTER_S = 'S'; const char LETTER_T = 'T';
	const char LETTER_U = 'U'; const char LETTER_V = 'V'; const char LETTER_W = 'W'; const char LETTER_X = 'X';
	const char LETTER_Y = 'Y'; const char LETTER_Z = 'Z';
	const char LETTER_COMMA = ','; 
	const char LETTER_DASH = '-';
	const char LETTER_SLASH = '/';
	const char LETTER_APOS = '\'';



	public enum GameBlockState
	{
		Inactive,
		ActiveHidden,
		ActiveExposed
	}
	
	public GameBlockState currentState;
	public GameBlockState newState;

	//Init Game Sprite on awake
	void Awake () {

		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();

		if (spriteRenderer != null)
						spriteRenderer.sprite = defaultGraphic;

		}
	
	// Use this for initialization
	void Start () {
		
		currentState = GameBlockState.Inactive;
		//TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false);
	}
	
	// Update is called once per frame
	void Update () {


		GameObject test;
		string temp;
		int value;

		checkStateChange ();
		if (!string.IsNullOrEmpty (Input.inputString)) 
		{
			Debug.Log ("Key Hit: " + Input.inputString);

			temp = Input.inputString;
			temp = temp.ToUpper();
			char[] array = temp.ToCharArray();
			value = convertLetter(array[0]);
			test = GameObject.Find ("GameBoardController");
			test.gameObject.GetComponent<GameController> ().processLetterSelected (value);
			Debug.Log("Char Hit: " + array[0]);


				}
	
	}


	// Handle game state changes
	void checkStateChange()
	{
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
		
		if (currentState != GameBlockState.ActiveExposed && newState == GameBlockState.ActiveExposed) 
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = exposedGraphic;
			currentState = newState;
			
		}


	}

	// Find Sprite that matches block
	private Sprite getBlockSprite (char letter)
	{
		Sprite value;
		switch (letter) 
		{
		case LETTER_A :
			value = letterSprite[0];
		break;
		case LETTER_B :
			value = letterSprite[1];
			break;
		case LETTER_C :
			value = letterSprite[2];
			break;
		case LETTER_D :
			value = letterSprite[3];
			break;
		case LETTER_E :
			value = letterSprite[4];
			break;
		case LETTER_F :
			value = letterSprite[5];
			break;
		case LETTER_G :
			value = letterSprite[6];
			break;
		case LETTER_H :
			value = letterSprite[7];
			break;
		case LETTER_I :
			value = letterSprite[8];
			break;
		case LETTER_J :
			value = letterSprite[9];
			break;
		case LETTER_K :
			value = letterSprite[10];
			break;
		case LETTER_L :
			value = letterSprite[11];
			break;
		case LETTER_M :
			value = letterSprite[12];
			break;
		case LETTER_N :
			value = letterSprite[13];
			break;
		case LETTER_O :
			value = letterSprite[14];
			break;
		case LETTER_P :
			value = letterSprite[15];
			break;
		case LETTER_Q :
			value = letterSprite[16];
			break;
		case LETTER_R :
			value = letterSprite[17];
			break;
		case LETTER_S :
			value = letterSprite[18];
			break;
		case LETTER_T :
			value = letterSprite[19];
			break;
		case LETTER_U :
			value = letterSprite[20];
			break;
		case LETTER_V :
			value = letterSprite[21];
			break;
		case LETTER_W :
			value = letterSprite[22];
			break;
		case LETTER_X :
			value = letterSprite[23];
			break;
		case LETTER_Y :
			value = letterSprite[24];
			break;
		case LETTER_Z :
			value = letterSprite[25];
			break;
		case LETTER_DASH :
			value = dashSprite;
			break;
		case LETTER_APOS :
			value = aposSprite;
			break;
		case LETTER_COMMA :
			value = commaSprite;
			break;
		case LETTER_SLASH :
			value = slashSprite;
			break;
		default:
			value = dashSprite;
			break;
				
		}

		return value;
	}

	// Find Sprite that matches block
	private int convertLetter (char letterValue)
	{
		int value;
		switch (letterValue) 
		{
		case LETTER_A :
			value = 0;
			break;
		case LETTER_B :
			value = 1;
			break;
		case LETTER_C :
			value = 2;
			break;
		case LETTER_D :
			value = 3;
			break;
		case LETTER_E :
			value = 4;
			break;
		case LETTER_F :
			value = 5;
			break;
		case LETTER_G :
			value = 6;
			break;
		case LETTER_H :
			value = 7;
			break;
		case LETTER_I :
			value = 8;
			break;
		case LETTER_J :
			value = 9;
			break;
		case LETTER_K :
			value = 10;
			break;
		case LETTER_L :
			value = 11;
			break;
		case LETTER_M :
			value = 12;
			break;
		case LETTER_N :
			value = 13;
			break;
		case LETTER_O :
			value = 14;
			break;
		case LETTER_P :
			value = 15;
			break;
		case LETTER_Q :
			value = 16;
			break;
		case LETTER_R :
			value = 17;
			break;
		case LETTER_S :
			value = 18;
			break;
		case LETTER_T :
			value = 19;
			break;
		case LETTER_U :
			value = 20;
			break;
		case LETTER_V :
			value = 21;
			break;
		case LETTER_W :
			value = 22;
			break;
		case LETTER_X :
			value = 23;
			break;
		case LETTER_Y :
			value = 24;
			break;
		case LETTER_Z :
			value = 25;
			break;
		default:
			value = 999;
			break;
			
		}
		
		return value;
	}

	public void setValue (char letter)
	{

		blockStringValue = letter;
		blockValue = blockStringValue.ToString();
		exposedGraphic = getBlockSprite (letter);
		Debug.Log ("Set Value Called");
	}

	public void setID (int id)
	{
		blockID = id;

		}

	public int getValue()
	{
		int value;
		value = convertLetter (blockStringValue);
		return value;

	}


	public void stateActiveHidden()
	{
		newState = GameBlockState.ActiveHidden;
		}

	public void stateActiveExposed()
	{
		newState = GameBlockState.ActiveExposed;
		}
	

}
