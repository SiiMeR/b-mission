using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController
{
	private int currentScore = 0;
	
	public int CurrentScore
	{
		get { return currentScore; }
		set { currentScore = value; }
	}


	public void addScore(int score)
	{
		CurrentScore += score;
	}
}
