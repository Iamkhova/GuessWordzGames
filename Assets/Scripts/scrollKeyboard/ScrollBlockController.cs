using UnityEngine;
using System.Collections;

public class ScrollBlockController : MonoBehaviour {

	public GameObject[] keyBoardBlockArray;
	//public GameObject[] arrowArray;
	public GameObject arrowLeft;
	public GameObject arrowRight;
	public Transform blockPrefab;
	public Transform arrowPrefab;
	public int keyBlockHeight;
	public int keyBlockWidth;
	public float keyBlockSpacing;
	public float scrollBoard_x;
	public float scrollBoard_y;
	public int maxKeyBlocks;

	const int LEFTARROW = 0;
	const int RIGHTARROW = 1;

	// Use this for initialization
	void Start () {

		loadGamePieces ();
		initScrollBoard ();
		buildScrollBoard ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("up")) 
		{ scrollRight (); }
		if (Input.GetKeyDown ("down")) 
		{ scrollLeft (); }

	
	
	}

	public void scrollRight()
	{
		for (int i = 0; i <= maxKeyBlocks; i++) 
		{
			keyBoardBlockArray[i].gameObject.GetComponent<KeyBlockController>().swipeRight();
		}

	}

	public void scrollLeft()
	{
		for (int i = 0; i <= maxKeyBlocks; i++) 
		{
			keyBoardBlockArray[i].gameObject.GetComponent<KeyBlockController>().swipeLeft();
		}
		
	}


	// Load Graphics into Scene
	void loadGamePieces()
	{
		// Create Blocks
		for (int i = 0; i <= maxKeyBlocks; i++) 
		{
			Instantiate (blockPrefab, new Vector3 (-12, 5, 0), Quaternion.identity);
		}

		
		//load gameblocks into array
		keyBoardBlockArray = GameObject.FindGameObjectsWithTag ("scrollkb_block");
		arrowRight = GameObject.Find ("prefab_arrow_right");
		arrowLeft = GameObject.Find ("prefab_arrow_left");
		//arrowArray = GameObject.FindGameObjectsWithTag ("arrow_block");

		arrowLeft.transform.rotation = Quaternion.Euler(0,180,0);
	}

	// Build the ScrollBox onto the Screen
	void buildScrollBoard()
	{
		float convertWidth;

		// Add arrows
		arrowLeft.transform.position = new Vector3 (scrollBoard_x, scrollBoard_y, 0);
		convertWidth = (1 * (float)maxKeyBlocks + 1)  +  ((keyBlockWidth * maxKeyBlocks) / (float)100) + (float)1.50; 
		arrowRight.transform.position = new Vector3 (scrollBoard_x + convertWidth, scrollBoard_y, 0);


		for (int i = 0; i <= maxKeyBlocks; i++) 
		{
			// Convert width from pixels to Unity Screen Units <<-- need to understand this better
			convertWidth = (1 * (float)i)  +  ((keyBlockWidth * i) / (float)100) + (float)1.25; 
			keyBoardBlockArray[i].transform.position = new Vector3(scrollBoard_x + convertWidth , scrollBoard_y, 0);

		
		}

	}

	void initScrollBoard()
	{

		for (int i = 0; i <= maxKeyBlocks; i++) 
		{
			keyBoardBlockArray[i].gameObject.GetComponent<KeyBlockController>().setValue(13 + i);
		}

	}

}
