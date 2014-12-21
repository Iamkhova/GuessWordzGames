using UnityEngine;
using System.Collections;


// Logically this should be GameBoard Controller
// TODO Fix this someday as it still bothers me
public class GameController : MonoBehaviour 
{
	public Transform prefab;
	public float gameboard_x = -7.0f;
	public float gameboard_y = 2.0f;
	public int maxNumRows = 14;
	public int maxNumColumns = 4;
	public string title = "";
	public string phrase = "Kareem Jamaal Glover";
	public string hint ="";

	public GameObject[] gameBlockArray;
	public PhraseHandler.PhraseData thePhrase = new PhraseHandler.PhraseData();
	public PhraseHandler phraseHandler;


	//Do upon Init
	void Awake()
	{
	
	}

	// Use this for initialization
	void Start () {
		loadGamePieces ();
		buildGameBoard();
		loadPhrasesIntoBoard ();

	
	}// end of void START
	
	// Update is called once per frame
	void Update () {
	
	}

	// Load Graphics into Scene
	void loadGamePieces()
	{
		for (int i = 0; i <= (maxNumRows * maxNumColumns); i++) 
		{
			Instantiate (prefab, new Vector3 (0, 0, 0), Quaternion.identity);
		}

		//load gameblocks into array
		gameBlockArray = GameObject.FindGameObjectsWithTag ("game_block");
	
	}


	// This Dynamically Builds the GameBoard
	void buildGameBoard()
	{
		int row = 0;
		int col = 0;
		int count = 1;

		float xstart = gameboard_x;
		float ystart = gameboard_y;

		while (col < maxNumColumns) {
			//while we are here lets set the block ID
			while (row < maxNumRows) {
				gameBlockArray[count].transform.position = new Vector3(xstart + row, ystart - col, 0);
				gameBlockArray[count].gameObject.GetComponent<GameBlockController>().setID(count);

				row++;
				count++;
			}
			row = 0;
			col++;

			Debug.Log("Col=" + col);
		}
	}// end of buildGameBoard

	// Load Phrases into Gameboard
	void loadPhrasesIntoBoard()
	{

		char[] letterArray;
		string gamePhrase;

		//load gameblocks into array
		phraseHandler = GetComponent<PhraseHandler>();
		thePhrase = phraseHandler.getNewPhrase();

		//compile phrase into one variable
		gamePhrase = thePhrase.line1 + thePhrase.line2 + thePhrase.line3 + thePhrase.line4;
		phrase = gamePhrase;

		//load string into charcater array
		letterArray = gamePhrase.ToCharArray();

		for (int i = 1; i <= gamePhrase.Length; i++) 
		{

			gameBlockArray[i].gameObject.GetComponent<GameBlockController>().setID(i);
			gameBlockArray[i].gameObject.GetComponent<GameBlockController>().setValue(letterArray[i-1]);

			//TODO Assign sprite graphic to array

			if (letterArray[i-1] != ' ') {
				gameBlockArray[i].gameObject.GetComponent<GameBlockController>().newState = GameBlockController.GameBlockState.ActiveHidden;
			}


			// TODO Light up Board on Freebies

			char blockValue = gameBlockArray[i].gameObject.GetComponent<GameBlockController>().blockStringValue;

			if (blockValue == '\'') { gameBlockArray[i].gameObject.GetComponent<GameBlockController>().stateActiveExposed();}
			if (blockValue == '/') { gameBlockArray[i].gameObject.GetComponent<GameBlockController>().stateActiveExposed();}
			if (blockValue == '-') { gameBlockArray[i].gameObject.GetComponent<GameBlockController>().stateActiveExposed();}
			if (blockValue == ',') { gameBlockArray[i].gameObject.GetComponent<GameBlockController>().stateActiveExposed();}
			
		}

	}

	public void processLetterSelected (int letterValue)
	{
		bool _guessRight = false;

				for (int i = 1; i <= 56; i++) {
						if (gameBlockArray [i - 1].gameObject.GetComponent<GameBlockController> ().getValue () == letterValue) 
						{
							Debug.Log ("Letter Match Found.. proceed.");
							gameBlockArray [i - 1].gameObject.GetComponent<GameBlockController> ().stateActiveExposed();
							this.GetComponent<ScoringHandler>().addPoints(); // Add points to score
							_guessRight = true;
						}

				}

			if (_guessRight) {
						this.GetComponent<ScoringHandler> ().guessRight ();
				} else {
						this.GetComponent<ScoringHandler> ().guessWrong ();
				}

		//Check for Gameover
		if (isGameOver()) {

			Debug.Log ("Run Game Over Code");


				}
		}

	private bool isGameOver()
	{
		bool _gameOver = true;

	
		for (int i = 1; i <= 56; i++) 
		{ 
			if (gameBlockArray [i - 1].gameObject.GetComponent<GameBlockController>().currentState == GameBlockController.GameBlockState.ActiveHidden)
			{
				_gameOver = false;

			}

					
		}

		if (this.GetComponent<ScoringHandler> ().getGuessLeft() <= 0) {
			_gameOver = true;
		}

		if (_gameOver == true) {Debug.Log("All inactive blocks found or chances used up.");} else {Debug.Log ("Inactive letters still exist.");}

		return _gameOver;


	}
}
