using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public Transform prefab;
	public float gameboard_x = -7.0f;
	public float gameboard_y = 2.0f;
	public int maxNumRows = 14;
	public int maxNumColumns = 4;

	public GameObject[] gameBlockArray;

	//Do upon Init
	void Awake()
	{

	}

	// Use this for initialization
	void Start () {
		buildGameBoard();  
		gameBlockArray = GameObject.FindGameObjectsWithTag ("game_block");
	
	}// end of void START
	
	// Update is called once per frame
	void Update () {
	
	}

	// This Dynamically Builds the GameBoard
	void buildGameBoard()
	{
		int row = 0;
		int col = 0;	

		float xstart = gameboard_x;
		float ystart = gameboard_y;

		while (col < maxNumColumns) {

			while (row < maxNumRows) {
						Instantiate (prefab, new Vector3 (xstart + row, ystart - col, 0), Quaternion.identity);
						row++;
				}

			row = 0;
			col++;

			Debug.Log("Col=" + col);
		}
	}// end of buildGameBoard
}
