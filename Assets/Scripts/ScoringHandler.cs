using UnityEngine;
using System.Collections;

public class ScoringHandler : MonoBehaviour {

	public int guess_wrong = 0;
	public int guess_right = 0;
	public int current_points = 0;
	public int guesses_left = 3;

	// Use this for initialization
	void Start () {
		//TODO load scores from last level
	}
	
	// Update is called once per frame
	void Update () {
	
		//TODO Check for EndGame States

	}

	public void guessWrong()
	{
		guess_wrong += 1;
		guesses_left -= 1;
	}

	public void guessRight()
	{

		guess_right += 1;
	}


	public void addPoints()
	{

		current_points += 100;
	}

	public int getGuessLeft()
	{
		return guesses_left;
	}
}
