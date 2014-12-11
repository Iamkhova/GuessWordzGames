using UnityEngine;
using System.Collections;

public class scrollBarObjController : MonoBehaviour {

	public int[] blockSlot = new int[10];
	public GameObject arrowLeft;
	public GameObject arrowRight;
	public int maxKeyBlocks = 9;
	public float posX;
	public float posY;
	public int blockWidth;

	// Use this for initialization
	void Start () {
	
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setPosition (float _posX, float _posY,int _blockWidth, int _startValue)
	{
		GameObject theBlock;
		float convertWidth;
		posX = _posX;
		posY = _posY;
		blockWidth = _blockWidth;

		arrangeScrollBar (_startValue);

		// Add arrows
		arrowRight = GameObject.Find ("prefab_arrow_right");
		arrowLeft = GameObject.Find ("prefab_arrow_left");
		arrowLeft.transform.rotation = Quaternion.Euler(0,180,0);

		arrowLeft.transform.position = new Vector3 (_posX, _posY, 0);
		convertWidth = (1 * (float)maxKeyBlocks + 1)  +  ((_blockWidth * maxKeyBlocks) / (float)100) + (float)1.50; 
		arrowRight.transform.position = new Vector3 (_posX + convertWidth, _posY, 0);

		for (int i = 0; i <= maxKeyBlocks; i++) {
				theBlock = GameObject.Find ("LetterBlock" + blockSlot[i] + "");


				// Convert width from pixels to Unity Screen Units <<-- need to understand this better
				convertWidth = (1 * (float)i) + ((_blockWidth * i) / (float)100) + (float)1.25; 
				theBlock.transform.position = new Vector3 (_posX + convertWidth, _posY, 0);

		}

	}

	public void updatePosition (int _startValue)
	{
		GameObject theBlock;
		float convertWidth;

		hideLetterBlocks ();
		arrangeScrollBar (_startValue);

		for (int i = 0; i <= maxKeyBlocks; i++) 
		{
			theBlock = GameObject.Find ("LetterBlock" + blockSlot [i] + "");

			// Convert width from pixels to Unity Screen Units <<-- need to understand this better
			convertWidth = (1 * (float)i) + ((blockWidth * i) / (float)100) + (float)1.25; 
			theBlock.transform.position = new Vector3 (posX + convertWidth, posY, 0);
		}

		
	}

	private void hideLetterBlocks ()
	{
		GameObject theBlock;
		for (int i = 0; i <= maxKeyBlocks; i++) {
			theBlock = GameObject.Find ("LetterBlock" + blockSlot[i] + "");
			theBlock.transform.position = new Vector3 (-12, 5, 0);

		}

	}
	private void arrangeScrollBar (int _startValue)
	{
		int tempValue;

		tempValue = _startValue;

		for (int i = 0; i <= 9; i++) 
		{
		
			// Check if over
			if (tempValue > 25) 
			{
				tempValue = 0;
				
			}
			
			//Check if Under
			if (tempValue < 0) 
			{
				tempValue = 25;
			}

			blockSlot[i] = tempValue;
			tempValue ++;


		}

	}
}
